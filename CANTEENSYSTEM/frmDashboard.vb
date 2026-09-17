Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class frmDashboard

    ' Flicker-free child painting (view switching + custom card borders).
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private userRole As String

    ' PHASE 5 salary controls — buttons now Designer-visible
    ' (btnMarkDeducted/btnCancelDeduction/btnRefreshSalary in designer);
    ' only the deduction filter ComboBox remains runtime.
    Private WithEvents cmbDeductionFilter As ComboBox
    Private salaryControlsBuilt As Boolean = False
    Private salaryColumnsEnsured As Boolean = False
    Private suppressDeductionReload As Boolean = False
    Private suppressDeductionEvent As Boolean = False

    Public Sub New(role As String)
        InitializeComponent()
        Me.userRole = role
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True ' flicker insurance for custom card-border painting
        Try
            ' 1. Force main view visibility
            pnlDashboardView.Visible = True
            pnlDashboardView.BringToFront()

            ' 2. Add emojis to sidebar button text
            AddEmojisToSidebar()

            ' 3. Dynamically attach gold borders to summary cards
            For Each ctrl As Control In pnlDashboardView.Controls
                If TypeOf ctrl Is Panel Then
                    AddHandler ctrl.Paint, AddressOf DrawCardGoldBorders
                End If
            Next

            ' 4. Apply modern chart styling
            StyleNativeDashboardChart()
            RefreshDashboardStats()

            ' 5. Load saved employees from database
            SalesTracker.LoadEmployeesFromDatabase()

            ' 6. PHASE 5: salary controls + grid (DB aggregates, no limit)
            BuildSalaryControls()
            LoadEmployees()

            ' 7. PHASE 1: Load categories + products into inventory view
            LoadCategoriesIntoFilter()
            LoadProducts()

            ' 8. PHASE 7: report types + settings controls
            ExpandReportsArea()
            AddDashboardRefresh()
            InitReportControls()
            BuildSettingsControls()

            ' 9. Set default active view
            SwitchView(pnlDashboardView, btnDashboard)

        Catch ex As Exception
            MessageBox.Show("Dashboard Load Error: " & ex.Message, "Design Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' PHASE 5: salary grid reads employees + salary_deductions aggregates.
    ' Kept under the old name because frmPOS sync paths call it.
    Public Sub LoadEmployees()
        LoadSalaryGrid()
    End Sub

    Public Sub LoadSalaryGrid()
        If dgvTextBoxColumn Is Nothing Then Exit Sub
        Try
            ' Keep the in-memory mirror fresh for POS (new/edited/deleted staff).
            SalesTracker.LoadEmployeesFromDatabase()
            EnsureSalaryColumns()
            dgvTextBoxColumn.Rows.Clear()
            Dim summaries As List(Of SalaryService.EmployeeDeductionSummary) = SalaryService.GetSummaries()
            For Each s In summaries
                Dim savedDeductionStatus As String = If(String.IsNullOrWhiteSpace(s.DeductionStatus), "PENDING", s.DeductionStatus.Trim().ToUpper())
                If savedDeductionStatus <> "PENDING" AndAlso savedDeductionStatus <> "COMPLETE" Then
                    savedDeductionStatus = "PENDING"
                End If
                Dim idx As Integer
                idx = dgvTextBoxColumn.Rows.Add(s.EmpNo, s.FullName, s.Position, savedDeductionStatus, s.PeriodStart, s.PeriodEnd)
                Dim row As DataGridViewRow = dgvTextBoxColumn.Rows(idx)
                row.Cells("colPendingAmt").Value = "₱" & s.PendingTotal.ToString("N2")
                row.Cells("colDeductedAmt").Value = "₱" & s.DeductedTotal.ToString("N2")
                row.Cells("colEmpStatus").Value = If(String.IsNullOrWhiteSpace(s.Status), "Active", s.Status)
                row.Tag = s
            Next
            UpdateSalaryKpis(summaries)
            ApplySalaryFilter()
        Catch ex As Exception
            MessageBox.Show("Failed to load salary deductions: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Runtime grid columns (no Designer edit): per-employee peso totals.
    Private Sub EnsureSalaryColumns()
        If salaryColumnsEnsured Then Exit Sub
        If dgvTextBoxColumn Is Nothing Then Exit Sub
        If Not dgvTextBoxColumn.Columns.Contains("colPendingAmt") Then
            Dim c As New DataGridViewTextBoxColumn()
            c.Name = "colPendingAmt"
            c.HeaderText = "Pending ₱"
            c.ReadOnly = True
            dgvTextBoxColumn.Columns.Add(c)
        End If
        If Not dgvTextBoxColumn.Columns.Contains("colDeductedAmt") Then
            Dim c2 As New DataGridViewTextBoxColumn()
            c2.Name = "colDeductedAmt"
            c2.HeaderText = "Deducted ₱"
            c2.ReadOnly = True
            dgvTextBoxColumn.Columns.Add(c2)
        End If
        If Not dgvTextBoxColumn.Columns.Contains("colEmpStatus") Then
            Dim c3 As New DataGridViewTextBoxColumn()
            c3.Name = "colEmpStatus"
            c3.HeaderText = "Status"
            c3.ReadOnly = True
            dgvTextBoxColumn.Columns.Add(c3)
        End If
        salaryColumnsEnsured = True
    End Sub

    Private Sub UpdateSalaryKpis(summaries As List(Of SalaryService.EmployeeDeductionSummary))
        Try
            Dim pendingTotal As Decimal = 0
            Dim deductedTotal As Decimal = 0
            For Each s In summaries
                pendingTotal += s.PendingTotal
                ' Lifetime collected: open Deducted rows plus Settled history.
                ' Closed periods stay on the card forever; the grid columns
                ' still reset because they sum open rows only.
                deductedTotal += s.DeductedTotal + s.SettledTotal
            Next
            If lblTotalEmployeesCount IsNot Nothing Then lblTotalEmployeesCount.Text = summaries.Count.ToString()
            If lblPendingCount IsNot Nothing Then lblPendingCount.Text = "₱" & pendingTotal.ToString("N2")
            If lblCompletedDeduction IsNot Nothing Then lblCompletedDeduction.Text = "₱" & deductedTotal.ToString("N2")
        Catch ex As Exception
            Debug.WriteLine("UpdateSalaryKpis failed: " & ex.Message)
        End Try
    End Sub

    ' Deduction filter (ComboBox remains runtime; action buttons are Designer-visible).
    Private Sub BuildSalaryControls()
        If salaryControlsBuilt Then Exit Sub
        Try
            If flowLayoutPanelActions IsNot Nothing Then
                ' Designer-visible: btnMarkDeducted/btnCancelDeduction/btnRefreshSalary
                ' already in flowLayoutPanelActions. Just grow the panel.
                FitSalaryActionsPanel()
            End If
            If cmbRoleFilter IsNot Nothing Then
                cmbRoleFilter.ForeColor = Color.Black
                If cmbRoleFilter.BackColor <> Color.White Then cmbRoleFilter.BackColor = Color.White
                suppressDeductionReload = True
                cmbDeductionFilter = New ComboBox()
                cmbDeductionFilter.Name = "cmbDeductionFilter"
                cmbDeductionFilter.DropDownStyle = ComboBoxStyle.DropDownList
                cmbDeductionFilter.Items.AddRange(New Object() {"All Deductions", "With Pending", "Fully Settled"})
                cmbDeductionFilter.SelectedIndex = 0
                cmbDeductionFilter.Size = cmbRoleFilter.Size
                cmbDeductionFilter.Location = New Point(cmbRoleFilter.Left, cmbRoleFilter.Bottom + 6)
                cmbDeductionFilter.Anchor = cmbRoleFilter.Anchor
                cmbDeductionFilter.ForeColor = Color.Black
                cmbDeductionFilter.BackColor = Color.White
                AddHandler cmbDeductionFilter.SelectedIndexChanged, AddressOf cmbDeductionFilter_SelectedIndexChanged
                If pnlSalaryDeductionView IsNot Nothing Then pnlSalaryDeductionView.Controls.Add(cmbDeductionFilter)
                suppressDeductionReload = False
            End If
            salaryControlsBuilt = True
        Catch ex As Exception
            Debug.WriteLine("BuildSalaryControls failed: " & ex.Message)
        End Try
    End Sub

    Private Sub cmbDeductionFilter_SelectedIndexChanged(sender As Object, e As EventArgs)
        If suppressDeductionReload Then Exit Sub
        ApplySalaryFilter()
    End Sub

    ' Size the flow panel from its lowest button so wrapped rows (MARK /
    ' CANCEL / REFRESH, or any future buttons) can never hide below it.
    Private Sub FitSalaryActionsPanel()
        Try
            If flowLayoutPanelActions Is Nothing Then Exit Sub
            Dim need As Integer = flowLayoutPanelActions.Padding.Vertical + 6
            For Each c As Control In flowLayoutPanelActions.Controls
                need = Math.Max(need, c.Bottom + 3)
            Next
            Dim delta As Integer = need - flowLayoutPanelActions.Height
            If delta > 0 Then
                flowLayoutPanelActions.Height += delta
                If dgvTextBoxColumn IsNot Nothing Then
                    dgvTextBoxColumn.Top += delta
                    dgvTextBoxColumn.Height = Math.Max(80, dgvTextBoxColumn.Height - delta)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("FitSalaryActionsPanel failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshSalary_Click(sender As Object, e As EventArgs) Handles btnRefreshSalary.Click
        LoadSalaryGrid()
    End Sub

    Private Function SelectedSalaryEmpNo() As String
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then Return ""
        If row.Cells("colEmpNo").Value Is Nothing Then Return ""
        Return row.Cells("colEmpNo").Value.ToString()
    End Function

    Private Sub btnMarkDeducted_Click(sender As Object, e As EventArgs) Handles btnMarkDeducted.Click
        If Not SalaryHasDataRows() Then
            MessageBox.Show("There are no employees to mark as deducted.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim empNo As String = SelectedSalaryEmpNo()
        If String.IsNullOrEmpty(empNo) Then
            MessageBox.Show("Please select an employee first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        Dim pendTxt As String = If(row.Cells("colPendingAmt").Value IsNot Nothing, row.Cells("colPendingAmt").Value.ToString(), "₱0.00")
        If MessageBox.Show($"Mark all pending deductions for {empNo} as DEDUCTED ({pendTxt})?" & vbCrLf & "This confirms payroll collected the amount.", "Confirm Deduction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub
        Dim n As Integer = SalaryService.MarkDeducted(empNo)
        If n <= 0 Then
            MessageBox.Show("No pending deductions for this employee.", "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"{n} deduction(s) marked as Deducted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LoadSalaryGrid()
    End Sub

    Private Sub btnCancelDeduction_Click(sender As Object, e As EventArgs) Handles btnCancelDeduction.Click
        If Not SalaryHasDataRows() Then
            MessageBox.Show("There are no deductions to cancel.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim empNo As String = SelectedSalaryEmpNo()
        If String.IsNullOrEmpty(empNo) Then
            MessageBox.Show("Please select an employee first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show($"Cancel all PENDING deductions for {empNo}? They will be voided.", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Exit Sub
        Dim n As Integer = SalaryService.CancelPending(empNo)
        If n <= 0 Then
            MessageBox.Show("No pending deductions for this employee.", "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"{n} deduction(s) cancelled.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LoadSalaryGrid()
    End Sub

    Private Sub frmDashboard_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshDashboardStats()
    End Sub

    ' PHASE 6: every dashboard number comes from the database (survives restart).
    Private Sub RefreshDashboardStats()
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COALESCE(SUM(total_amount), 0) AS sales, COUNT(*) AS txns FROM transactions WHERE DATE(transaction_date) = CURDATE() AND status = 'Completed'", conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        If rdr.Read() Then
                            If lblTodaySalesVal IsNot Nothing Then lblTodaySalesVal.Text = "₱" & Convert.ToDecimal(rdr("sales")).ToString("N2")
                            If lblTransactionsVal IsNot Nothing Then lblTransactionsVal.Text = Convert.ToInt32(rdr("txns")).ToString()
                        End If
                    End Using
                End Using
                Using cmd As New MySqlCommand("SELECT COALESCE(SUM(td.quantity), 0) AS items FROM transaction_details td JOIN transactions t ON t.transaction_id = td.transaction_id WHERE DATE(t.transaction_date) = CURDATE() AND t.status = 'Completed'", conn)
                    Dim obj As Object = cmd.ExecuteScalar()
                    If lblItemsSoldVal IsNot Nothing Then lblItemsSoldVal.Text = Convert.ToInt32(If(obj Is DBNull.Value, 0, obj)).ToString()
                End Using
                Using cmd As New MySqlCommand("SELECT COALESCE(SUM(total_amount), 0) AS sd FROM transactions WHERE DATE(transaction_date) = CURDATE() AND status = 'Completed' AND (payment_method LIKE '%salary%' OR payment_method LIKE '%deduction%')", conn)
                    Dim obj2 As Object = cmd.ExecuteScalar()
                    If lblSalaryDeductionVal IsNot Nothing Then lblSalaryDeductionVal.Text = "₱" & Convert.ToDecimal(If(obj2 Is DBNull.Value, 0D, obj2)).ToString("N2")
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("RefreshDashboardStats KPIs failed: " & ex.Message)
        End Try
        LoadRecentTransactions()
        LoadInventoryAlerts()
        UpdateDashboardChart()
    End Sub

    ' Latest 10 completed sales for the Recent Transactions grid.
    Private Sub LoadRecentTransactions()
        If dgvRecentTransactions Is Nothing Then Exit Sub
        Try
            dgvRecentTransactions.Rows.Clear()
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COALESCE(transaction_number, CONCAT('#', transaction_id)) AS tno, transaction_date, payment_method, total_amount, status FROM transactions ORDER BY transaction_date DESC, transaction_id DESC LIMIT 10", conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            dgvRecentTransactions.Rows.Add(
                                rdr("tno").ToString(),
                                Convert.ToDateTime(rdr("transaction_date")).ToString("yyyy-MM-dd HH:mm"),
                                rdr("payment_method").ToString(),
                                "₱" & Convert.ToDecimal(rdr("total_amount")).ToString("N2"),
                                rdr("status").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("LoadRecentTransactions failed: " & ex.Message)
        End Try
    End Sub

    ' Shelf counts for the Inventory Alerts panel.
    Private Sub LoadInventoryAlerts()
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT SUM(stock_quantity = 0) AS oos, SUM(stock_quantity > 0 AND stock_quantity <= reorder_level) AS low, SUM(stock_quantity > reorder_level) AS ok FROM products", conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim oos As Integer = If(rdr("oos") Is DBNull.Value, 0, Convert.ToInt32(rdr("oos")))
                            Dim low As Integer = If(rdr("low") Is DBNull.Value, 0, Convert.ToInt32(rdr("low")))
                            Dim ok As Integer = If(rdr("ok") Is DBNull.Value, 0, Convert.ToInt32(rdr("ok")))
                            ' NOTE: designer names are swapped vs. screen rows —
                            ' lblLowSValue sits on the IN STOCK row (y~44),
                            ' lblInStockValue sits on the LOW STOCK row (y~87).
                            ' Assigned by POSITION so the screen reads correctly.
                            If lblOutStockVal IsNot Nothing Then lblOutStockVal.Text = oos.ToString()
                            If lblLowSValue IsNot Nothing Then lblLowSValue.Text = ok.ToString()
                            If lblInStockValue IsNot Nothing Then lblInStockValue.Text = low.ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("LoadInventoryAlerts failed: " & ex.Message)
        End Try
    End Sub

    ' --- SIDEBAR EMOJI TEXT ASSIGNMENT ---
    Private Sub AddEmojisToSidebar()
        If btnDashboard IsNot Nothing Then btnDashboard.Text = "📊  Dashboard"



        If btnInventory IsNot Nothing Then btnInventory.Text = "📋  Inventory"
        If btnSalaryDeduction IsNot Nothing Then btnSalaryDeduction.Text = "💳 Employee Salary Deduction"
        If btnReports IsNot Nothing Then btnReports.Text = "📈  Reports"
        If btnSettings IsNot Nothing Then btnSettings.Text = "⚙️  Settings"
        If btnLogout IsNot Nothing Then btnLogout.Text = "🚪  Logout"
    End Sub

    ' --- SIDEBAR BUTTON CLICK HANDLERS ---
    Private Sub NavigationButtons_Click(sender As Object, e As EventArgs) Handles _
        btnDashboard.Click,
        btnInventory.Click,
        btnSalaryDeduction.Click,
        btnReports.Click,
        btnSettings.Click,
        btnLogout.Click

        Dim btn As Button = TryCast(sender, Button)
        If btn Is Nothing Then Exit Sub

        ' Logout action
        If btn Is btnLogout Then
            Dim confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                Try
                    AuditLog.Log(Session.CurrentUserId, "Logout", $"{Session.CurrentUsername} logged out (Dashboard)")
                Catch
                End Try
                Session.Clear()
                Navigator.ReturnToSystemSelect(Me)
            End If
            Exit Sub
        End If

        ' View switching
        Select Case btn.Name
            Case "btnDashboard"
                SwitchView(pnlDashboardView, btn)
                RefreshDashboardStats()



            Case "btnInventory"
                If pnlInventoryView IsNot Nothing Then SwitchView(pnlInventoryView, btn)
                LoadProducts()
            Case "btnSalaryDeduction"
                If pnlSalaryDeductionView IsNot Nothing Then SwitchView(pnlSalaryDeductionView, btn)
                LoadSalaryGrid()
            Case "btnReports"
                If Me.pnlReportsView IsNot Nothing Then SwitchView(Me.pnlReportsView, btn)
            Case "btnSettings"
                If pnlSettingsView IsNot Nothing Then SwitchView(pnlSettingsView, btn)
        End Select
    End Sub

    ' --- VIEW SWITCHING ENGINE ---
    Private Sub SwitchView(activePanel As Panel, activeBtn As Button)
        If activePanel Is Nothing Then Exit Sub

        For Each ctrl As Control In pnlMainContent.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.Visible = False
            End If
        Next

        activePanel.Visible = True
        activePanel.BringToFront()

        ' Highlight active button
        ResetSidebarButtonColors()
        If activeBtn IsNot Nothing Then
            activeBtn.BackColor = ColorTranslator.FromHtml("#102A5C") ' Dark Navy highlight
            activeBtn.ForeColor = ColorTranslator.FromHtml("#F5C21B") ' Gold text highlight
        End If
    End Sub

    Private Sub ResetSidebarButtonColors()
        Dim sidebarButtons As Button() = {
            btnDashboard,
            btnInventory, btnSalaryDeduction,
            btnReports, btnSettings
        }

        For Each btn In sidebarButtons
            If btn IsNot Nothing Then
                btn.BackColor = ColorTranslator.FromHtml("#F5C21B") ' Original Gold
                btn.ForeColor = Color.Black
            End If
        Next
        ' Ensure Reports view (pnlReportsView) stays Navy Blue and does not turn Yellow/Gold
        If pnlReportsView IsNot Nothing Then
            pnlReportsView.BackColor = Color.FromArgb(0, 0, 64)
        End If
    End Sub

    ' --- NATIVE CHART STYLING ---
    Private Sub StyleNativeDashboardChart()
        If Chart1 Is Nothing Then Exit Sub

        Chart1.BackColor = ColorTranslator.FromHtml("#102A5C")
        If Chart1.Legends.Count > 0 Then Chart1.Legends(0).Enabled = False

        Dim ca As ChartArea = Chart1.ChartAreas(0)
        ca.BackColor = ColorTranslator.FromHtml("#102A5C")

        ca.AxisX.LabelStyle.ForeColor = Color.White
        ca.AxisY.LabelStyle.ForeColor = Color.White
        ca.AxisX.LineColor = ColorTranslator.FromHtml("#1E3A70")
        ca.AxisY.LineColor = ColorTranslator.FromHtml("#1E3A70")
        ca.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#1E3A70")
        ca.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#1E3A70")
        ca.AxisX.Interval = 1
        ca.AxisX.Minimum = 1
        ca.AxisX.Maximum = 8

        Chart1.Series.Clear()

        ' Gold Sales Trend
        Dim seriesGold As New Series("Sales") With {
            .ChartType = SeriesChartType.SplineArea,
            .Color = Color.FromArgb(120, 245, 194, 27),
            .BorderColor = ColorTranslator.FromHtml("#F5C21B"),
            .BorderWidth = 2
        }

        ' Cyan Transaction Trend
        Dim seriesCyan As New Series("Transactions") With {
            .ChartType = SeriesChartType.SplineArea,
            .Color = Color.FromArgb(100, 0, 210, 255),
            .BorderColor = ColorTranslator.FromHtml("#00D2FF"),
            .BorderWidth = 2
        }

        Chart1.Series.Add(seriesGold)
        Chart1.Series.Add(seriesCyan)
    End Sub

    ' --- PHASE 6: Mon–Sat sales chart from the database (current week) ---
    Private Sub UpdateDashboardChart()
        If Chart1 Is Nothing Then Exit Sub
        If Chart1.Series.Count < 2 Then Exit Sub

        Dim dayNames() As String = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}
        Dim gold(5) As Double
        Dim cyan(5) As Double
        Try
            ' Monday 00:00 of the current week (canteen runs Mon–Sat; Sunday ignored).
            Dim dow As Integer = (CInt(DateTime.Today.DayOfWeek) + 6) Mod 7
            Dim monday As DateTime = DateTime.Today.AddDays(-dow)
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT WEEKDAY(transaction_date) AS wd, COALESCE(SUM(total_amount), 0) AS sales, COUNT(*) AS txns FROM transactions WHERE status = 'Completed' AND transaction_date >= @mon AND transaction_date < @next GROUP BY wd", conn)
                    cmd.Parameters.AddWithValue("@mon", monday)
                    cmd.Parameters.AddWithValue("@next", monday.AddDays(7))
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim wd As Integer = Convert.ToInt32(rdr("wd"))
                            If wd >= 0 AndAlso wd <= 5 Then
                                gold(wd) = Convert.ToDouble(rdr("sales"))
                                cyan(wd) = Convert.ToDouble(rdr("txns"))
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("UpdateDashboardChart failed: " & ex.Message)
        End Try

        Chart1.Series("Sales").Points.DataBindY(gold)
        Chart1.Series("Transactions").Points.DataBindY(cyan)
        For i As Integer = 0 To 5
            If Chart1.Series("Sales").Points.Count > i Then Chart1.Series("Sales").Points(i).AxisLabel = dayNames(i)
            If Chart1.Series("Transactions").Points.Count > i Then Chart1.Series("Transactions").Points(i).AxisLabel = dayNames(i)
        Next

        Chart1.Invalidate()
    End Sub

    ' --- CARD GOLD BORDER DRAWING ---
    Private Sub DrawCardGoldBorders(sender As Object, e As PaintEventArgs)
        Dim pnl As Panel = TryCast(sender, Panel)
        If pnl Is Nothing Then Exit Sub

        If pnl.Height < 150 Then
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Using goldPen As New Pen(ColorTranslator.FromHtml("#F5C21B"), 2)
                e.Graphics.DrawRectangle(goldPen, 1, 1, pnl.Width - 3, pnl.Height - 3)
            End Using
        End If
    End Sub

    Private Sub dgvTextBoxColumn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTextBoxColumn.CellContentClick

    End Sub

    Private Sub dgvTextBoxColumn_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTextBoxColumn.CellValueChanged
        ' PENDING/COMPLETE toggle. The choice is PERSISTED to the database so it
        ' survives reloads; a failed write rolls the combo back instead of lying.
        If suppressDeductionEvent Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If dgvTextBoxColumn.Columns(e.ColumnIndex).Name <> "DeductionStatus" Then Exit Sub
        Dim row As DataGridViewRow = dgvTextBoxColumn.Rows(e.RowIndex)
        If row.IsNewRow Then Exit Sub

        Dim cellValue As String = ""
        Try
            Dim valObj = row.Cells("DeductionStatus").Value
            If valObj IsNot Nothing Then cellValue = valObj.ToString()
        Catch
            cellValue = ""
        End Try
        Dim normalizedValue As String = If(String.IsNullOrWhiteSpace(cellValue), "PENDING", cellValue.Trim().ToUpper())
        If normalizedValue <> "COMPLETE" Then normalizedValue = "PENDING"

        Dim empNoObj = row.Cells("colEmpNo").Value
        Dim empNo As String = If(empNoObj IsNot Nothing, empNoObj.ToString(), "")
        If String.IsNullOrEmpty(empNo) Then Exit Sub

        If normalizedValue = "COMPLETE" Then
            ' Period close: settle open rows + flag + period_end in one transaction.
            Dim settled As Integer = SalaryService.SettlePeriod(empNo)
            If settled < 0 Then
                MessageBox.Show("Could not close the period. The value was reverted.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RevertDeductionCombo(row, "PENDING")
                Exit Sub
            End If
        ElseIf Not SalaryService.SetEmployeeStatus(empNo, normalizedValue) Then
            MessageBox.Show("Could not save the status change. The value was reverted.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RevertDeductionCombo(row, "COMPLETE")
            Exit Sub
        End If

        suppressDeductionEvent = True
        Try
            If normalizedValue = "COMPLETE" Then
                row.Cells("colPeriodEnd").Value = DateTime.Now.ToString("yyyy-MM-dd")
                ' SettlePeriod moved every open row: both peso columns are now 0.
                If dgvTextBoxColumn.Columns.Contains("colPendingAmt") Then row.Cells("colPendingAmt").Value = "₱0.00"
                If dgvTextBoxColumn.Columns.Contains("colDeductedAmt") Then row.Cells("colDeductedAmt").Value = "₱0.00"
            End If
            If row.Cells("DeductionStatus").Value Is Nothing OrElse row.Cells("DeductionStatus").Value.ToString() <> normalizedValue Then
                row.Cells("DeductionStatus").Value = normalizedValue
            End If
        Catch
        Finally
            suppressDeductionEvent = False
        End Try

        For Each emp As SalesTracker.Employee In SalesTracker.Employees
            If emp.EmpNo = empNo Then
                emp.DeductionStatus = normalizedValue
                Exit For
            End If
        Next
    End Sub

    Private Sub RevertDeductionCombo(row As DataGridViewRow, value As String)
        suppressDeductionEvent = True
        Try
            row.Cells("DeductionStatus").Value = value
        Catch
        Finally
            suppressDeductionEvent = False
        End Try
    End Sub

    Private Sub dgvTextBoxColumn_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvTextBoxColumn.DataError
        ' Suppress default DataGridView error dialog
        If e.Context = DataGridViewDataErrorContexts.Commit OrElse
           e.Context = DataGridViewDataErrorContexts.CurrentCellChange Then
            e.ThrowException = False
            e.Cancel = True

            ' If it's the DeductionStatus column, force to PENDING
            If e.ColumnIndex >= 0 AndAlso dgvTextBoxColumn.Columns(e.ColumnIndex).Name = "DeductionStatus" Then
                Try
                    dgvTextBoxColumn.Rows(e.RowIndex).Cells("DeductionStatus").Value = "PENDING"
                Catch
                End Try
            End If
        End If
    End Sub

    ' Add new employee to the salary deduction grid
    ' PHASE 5: POS calls this after SalesTracker.AddEmployee (DB already written),
    ' so the grid simply reloads from the database with fresh aggregates.
    Public Sub AddEmployee(empNo As String, username As String, fullName As String, position As String, empStatus As String, deductionStatus As String)
        LoadSalaryGrid()
    End Sub

#Region "Salary Deduction View - Search & Filter"

    Private Const SALARY_SEARCH_PLACEHOLDER As String = "🔍 Search employee name or ID..."

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = SALARY_SEARCH_PLACEHOLDER Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.White
        End If
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = SALARY_SEARCH_PLACEHOLDER
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySalaryFilter()
    End Sub

    Private Sub cmbRoleFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRoleFilter.SelectedIndexChanged
        ApplySalaryFilter()
    End Sub

    Private Sub ApplySalaryFilter()
        If dgvTextBoxColumn Is Nothing Then Exit Sub

        Dim searchText As String = txtSearch.Text.Trim().ToLower()
        If searchText = SALARY_SEARCH_PLACEHOLDER.ToLower() Then searchText = ""

        Dim roleFilter As String = ""
        If cmbRoleFilter.SelectedItem IsNot Nothing Then
            roleFilter = cmbRoleFilter.SelectedItem.ToString().Trim()
        ElseIf Not String.IsNullOrWhiteSpace(cmbRoleFilter.Text) Then
            roleFilter = cmbRoleFilter.Text.Trim()
        End If
        If roleFilter = "All Roles" Then roleFilter = ""

        Dim dedFilter As String = ""
        If cmbDeductionFilter IsNot Nothing AndAlso cmbDeductionFilter.SelectedItem IsNot Nothing Then
            dedFilter = cmbDeductionFilter.SelectedItem.ToString()
        End If
        If dedFilter = "All Deductions" Then dedFilter = ""

        For Each row As DataGridViewRow In dgvTextBoxColumn.Rows
            If row.IsNewRow Then Continue For
            Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString().ToLower(), "")
            Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString().ToLower(), "")
            Dim posVal As String = If(row.Cells("colPosition").Value IsNot Nothing, row.Cells("colPosition").Value.ToString(), "")

            Dim matchesSearch As Boolean = String.IsNullOrEmpty(searchText) OrElse empNo.Contains(searchText) OrElse nameVal.Contains(searchText)
            Dim matchesRole As Boolean = String.IsNullOrEmpty(roleFilter) OrElse posVal.Equals(roleFilter, StringComparison.OrdinalIgnoreCase)
            Dim matchesDed As Boolean = True
            If dedFilter <> "" AndAlso dgvTextBoxColumn.Columns.Contains("colPendingAmt") Then
                Dim pend As Decimal = 0
                If row.Cells("colPendingAmt").Value IsNot Nothing Then
                    Decimal.TryParse(row.Cells("colPendingAmt").Value.ToString().Replace("₱", "").Replace(",", "").Trim(), pend)
                End If
                If dedFilter = "With Pending" Then
                    matchesDed = (pend > 0)
                ElseIf dedFilter = "Fully Settled" Then
                    matchesDed = (pend <= 0)
                End If
            End If

            Dim isVisible As Boolean = matchesSearch AndAlso matchesRole AndAlso matchesDed
            Try
                row.Visible = isVisible
            Catch
                ' CurrencyManager may throw if all rows hidden - ignore
            End Try
        Next
    End Sub

    Private Function GetSelectedSalaryRow() As DataGridViewRow
        If dgvTextBoxColumn Is Nothing Then Return Nothing
        If dgvTextBoxColumn.SelectedRows.Count > 0 Then Return dgvTextBoxColumn.SelectedRows(0)
        If dgvTextBoxColumn.CurrentRow IsNot Nothing AndAlso Not dgvTextBoxColumn.CurrentRow.IsNewRow Then Return dgvTextBoxColumn.CurrentRow
        Return Nothing
    End Function

    ' True when at least one real employee row exists (excludes the
    ' new-row placeholder). Used to give a sensible message on empty grids
    ' instead of "please select" when there is nothing to select.
    Private Function SalaryHasDataRows() As Boolean
        Try
            If dgvTextBoxColumn Is Nothing Then Return False
            For Each row As DataGridViewRow In dgvTextBoxColumn.Rows
                If Not row.IsNewRow Then Return True
            Next
        Catch
        End Try
        Return False
    End Function

#End Region

#Region "Salary Deduction View - Button Actions"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' btnEdit is the ADD button in pnlSalaryDeductionView - just show signup
        Dim signup As New frmEmployeeSignUp()
        If signup.ShowDialog() = DialogResult.OK Then
            Dim empNo As String = signup.EmployeeNumber
            Dim username As String = signup.Username
            Dim fullName As String = signup.FullName
            Dim pos As String = signup.Position
            Dim empStatus As String = "Available"
            Dim dedStatus As String = "PENDING"
            Try
                System.IO.File.AppendAllText(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "canteen_debug_signup.log"), $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} DASHBOARD btnAdd empNo='{empNo}' username='{username}' fullName='{fullName}'" & vbCrLf)
            Catch
            End Try

            SalesTracker.AddEmployee(empNo, username, fullName, pos, empStatus, dedStatus)
            LoadEmployees()
            ApplySalaryFilter()
            MessageBox.Show($"Employee {empNo} - {fullName} added successfully!" & vbCrLf & $"Username: {username}", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEdit1_Click(sender As Object, e As EventArgs) Handles btnEdit1.Click
        If Not SalaryHasDataRows() Then
            MessageBox.Show("There are no employees to edit.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim curName As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim curPos As String = If(row.Cells("colPosition").Value IsNot Nothing, row.Cells("colPosition").Value.ToString(), "")

        Dim newName As String = frmThemedPrompt.Ask($"Edit Full Name for {empNo}:", "Edit Employee", curName)
        If newName Is Nothing Then Exit Sub
        If String.IsNullOrWhiteSpace(newName) Then Exit Sub
        newName = newName.Trim()

        Dim newPos As String = frmThemedPrompt.Ask($"Edit Position for {empNo}:" & vbCrLf & "Options: Teacher, Staff, Admin, Security, etc.", "Edit Position", curPos)
        If newPos Is Nothing Then newPos = curPos
        If String.IsNullOrWhiteSpace(newPos) Then newPos = curPos
        newPos = newPos.Trim()

        ' Update grid
        row.Cells("colName").Value = newName
        row.Cells("colPosition").Value = newPos

        ' Update SalesTracker and DB
        SalesTracker.UpdateEmployee(empNo, newName, newPos)
        ApplySalaryFilter()
        MessageBox.Show("Employee updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If Not SalaryHasDataRows() Then
            MessageBox.Show("There are no employees to view.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim posVal As String = If(row.Cells("colPosition").Value IsNot Nothing, row.Cells("colPosition").Value.ToString(), "")
        Dim statusVal As String = If(dgvTextBoxColumn.Columns.Contains("colStatus") AndAlso row.Cells("colStatus").Value IsNot Nothing, row.Cells("colStatus").Value.ToString(), "")
        Dim dedStatus As String = If(row.Cells("DeductionStatus").Value IsNot Nothing, row.Cells("DeductionStatus").Value.ToString(), "")
        Dim pStart As String = If(row.Cells("colPeriodStart").Value IsNot Nothing, row.Cells("colPeriodStart").Value.ToString(), "")
        Dim pEnd As String = If(row.Cells("colPeriodEnd").Value IsNot Nothing, row.Cells("colPeriodEnd").Value.ToString(), "")

        ' Try to get username and created_at from SalesTracker
        Dim usernameVal As String = ""
        Dim createdAtVal As String = ""
        For Each emp As SalesTracker.Employee In SalesTracker.Employees
            If emp.EmpNo = empNo Then
                usernameVal = emp.Username
                If emp.CreatedAt <> DateTime.MinValue Then createdAtVal = emp.CreatedAt.ToString("yyyy-MM-dd HH:mm")
                Exit For
            End If
        Next

        Dim pendAmt As String = If(dgvTextBoxColumn.Columns.Contains("colPendingAmt") AndAlso row.Cells("colPendingAmt").Value IsNot Nothing, row.Cells("colPendingAmt").Value.ToString(), "₱0.00")
        Dim dedAmt As String = If(dgvTextBoxColumn.Columns.Contains("colDeductedAmt") AndAlso row.Cells("colDeductedAmt").Value IsNot Nothing, row.Cells("colDeductedAmt").Value.ToString(), "₱0.00")

        Dim details As String = $"Employee No: {empNo}" & vbCrLf &
                                $"Username: {usernameVal}" & vbCrLf &
                                $"Full Name: {nameVal}" & vbCrLf &
                                 $"Position: {posVal}" & vbCrLf &
                                 $"Status: {statusVal}" & vbCrLf &
                                $"Deduction Status: {dedStatus}" & vbCrLf &
                                $"Pending Deductions: {pendAmt}" & vbCrLf &
                                $"Deducted Total: {dedAmt}" & vbCrLf &
                                $"Period Start: {pStart}" & vbCrLf &
                                $"Period End: {pEnd}" & vbCrLf &
                                $"Created At: {createdAtVal}"
        MessageBox.Show(details, "Employee Details - " & empNo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not SalaryHasDataRows() Then
            MessageBox.Show("There are no employees to delete.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim empActive As Boolean = True
        If dgvTextBoxColumn.Columns.Contains("colEmpStatus") AndAlso row.Cells("colEmpStatus").Value IsNot Nothing Then
            empActive = (row.Cells("colEmpStatus").Value.ToString().Trim().ToUpper() <> "INACTIVE")
        End If
        If Not empActive Then
            ' Deactivated staff: cascade is allowed but destroys their payroll
            ' history — require typing the employee number to proceed.
            Dim typed As String = frmThemedPrompt.Ask($"Type {empNo} to PERMANENTLY delete this deactivated employee." & vbCrLf & "All of their salary deduction records will also be deleted.", "Confirm Cascade Delete", "")
            If typed Is Nothing Then Exit Sub
            If Not String.Equals(typed.Trim(), empNo, StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Employee number did not match. Nothing was deleted.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim rowsGone As Integer = SalesTracker.DeleteEmployeeCascade(empNo)
            If rowsGone < 0 Then Exit Sub ' error already shown
            LoadSalaryGrid()
            MessageBox.Show($"Employee deleted with {rowsGone} deduction record(s).", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim confirm = MessageBox.Show($"Are you sure you want to delete employee {empNo} - {nameVal}?" & vbCrLf & "This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Exit Sub

        If SalesTracker.DeleteEmployee(empNo) Then
            LoadSalaryGrid() ' reloads grid + KPIs from the database
            MessageBox.Show("Employee deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("This employee cannot be deleted because salary deduction records exist for them." & vbCrLf & "Payroll history must be preserved — deactivate the employee instead if they left.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDeactivate_Click(sender As Object, e As EventArgs) Handles btnDeactivate.Click
        If Not SalaryHasDataRows() Then
            MessageBox.Show("There are no employees to deactivate.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to deactivate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim curStatus As String = ""
        If dgvTextBoxColumn.Columns.Contains("colEmpStatus") AndAlso row.Cells("colEmpStatus").Value IsNot Nothing Then
            curStatus = row.Cells("colEmpStatus").Value.ToString()
        End If
        Dim toInactive As Boolean = (curStatus.Trim().ToUpper() <> "INACTIVE")
        Dim verb As String = If(toInactive, "deactivate (block salary logins)", "reactivate")
        If MessageBox.Show($"Are you sure you want to {verb} '{empNo} - {nameVal}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub
        If Not SalaryService.SetActiveStatus(empNo, Not toInactive) Then
            MessageBox.Show("Could not save the status change.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        LoadSalaryGrid()
        MessageBox.Show($"Employee is now {If(toInactive, "Inactive", "Active")}.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecentTransactions.CellContentClick

    End Sub

    Private Sub cardSalaryDeduction_Paint(sender As Object, e As PaintEventArgs) Handles cardSalaryDeduction.Paint

    End Sub

    Private Sub pnlDashboardView_Paint(sender As Object, e As PaintEventArgs) Handles pnlDashboardView.Paint

    End Sub

    Private Sub lblItemsSoldVal_Click(sender As Object, e As EventArgs) Handles lblItemsSoldVal.Click

    End Sub

    Private Sub lblCompletedDeductionTitle_Click(sender As Object, e As EventArgs) Handles lblCompletedDeductionTitle.Click

    End Sub




    Private Sub pnlReportsView_Paint(sender As Object, e As PaintEventArgs) Handles pnlReportsView.Paint

    End Sub

#Region "PHASE 1 — Inventory (products master)"

    Private Const PRODUCT_SEARCH_PLACEHOLDER As String = "Search product..."
    Private Const CATEGORY_ALL As String = "All Categories"
    ' name -> category_id map, rebuilt from DB so ids are never hardcoded
    Private categoryIds As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
    Private suppressCategoryReload As Boolean = False

    Private Function AuditUserId() As Integer
        Try
            If Session.CurrentUserId > 0 Then Return Session.CurrentUserId
        Catch
        End Try
        Return 1 ' seed admin row; Session is set on login in Phase 0
    End Function

    Private Sub WriteAudit(action As String, description As String)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, @action, @d", conn)
                    cmd.Parameters.AddWithValue("@uid", AuditUserId())
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@d", If(description, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("WriteAudit failed: " & ex.Message)
        End Try
    End Sub

    Private Sub AddStockMovement(productId As Integer, movementType As String, qty As Integer, remarks As String)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO stock_movements (product_id, user_id, movement_type, quantity, remarks) VALUES (@pid, @uid, @type, @qty, @rem)", conn)
                    cmd.Parameters.AddWithValue("@pid", productId)
                    cmd.Parameters.AddWithValue("@uid", AuditUserId())
                    cmd.Parameters.AddWithValue("@type", movementType)
                    cmd.Parameters.AddWithValue("@qty", qty)
                    cmd.Parameters.AddWithValue("@rem", If(remarks, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("AddStockMovement failed: " & ex.Message)
        End Try
    End Sub

    ' Inventory refresh is Designer-visible (btnRefreshInventory in FlowLayoutPanel1).
    Private Sub EnsureInventoryRefresh()
        Try
            If FlowLayoutPanel1 Is Nothing OrElse btnRefreshInventory Is Nothing Then Exit Sub
            ' Scale-proof single row: divide the real panel width evenly
            ' so all five fit whatever the display scaling is.
            Dim n As Integer = FlowLayoutPanel1.Controls.Count
            If n > 0 Then
                Dim avail As Integer = FlowLayoutPanel1.ClientSize.Width - FlowLayoutPanel1.Padding.Horizontal - n * 6
                Dim w As Integer = Math.Max(60, avail \ n)
                For Each bb As Button In FlowLayoutPanel1.Controls.OfType(Of Button)()
                    bb.Width = w
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine("EnsureInventoryRefresh failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshInventory_Click(sender As Object, e As EventArgs) Handles btnRefreshInventory.Click
        LoadProducts()
    End Sub

    ' Fill category filter from DB (replaces wrong Designer items like "Food"/"Other").
    Private Sub LoadCategoriesIntoFilter()
        If cboCategory Is Nothing Then Exit Sub
        suppressCategoryReload = True
        Try
            categoryIds.Clear()
            cboCategory.Items.Clear()
            cboCategory.Items.Add(CATEGORY_ALL)
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT category_id, category_name FROM categories WHERE status='Active' ORDER BY category_name", conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim cid As Integer = Convert.ToInt32(rdr("category_id"))
                            Dim cname As String = rdr("category_name").ToString()
                            categoryIds(cname) = cid
                            cboCategory.Items.Add(cname)
                        End While
                    End Using
                End Using
            End Using
            cboCategory.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Failed to load categories: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            suppressCategoryReload = False
        End Try
    End Sub

    Private Function ProductSearchText() As String
        If txtSearchProducts Is Nothing Then Return ""
        Dim t As String = txtSearchProducts.Text.Trim()
        If t = PRODUCT_SEARCH_PLACEHOLDER Then Return ""
        Return t
    End Function

    Private Function ProductCategoryFilter() As String
        If cboCategory Is Nothing Then Return ""
        Dim sel As String = ""
        If cboCategory.SelectedItem IsNot Nothing Then sel = cboCategory.SelectedItem.ToString()
        If String.IsNullOrWhiteSpace(sel) OrElse sel = CATEGORY_ALL Then Return ""
        Return sel
    End Function

    ' Master product list: products JOIN categories, filtered in SQL.
    Public Sub LoadProducts()
        If dgvInventoryHistory Is Nothing Then Exit Sub
        EnsureInventoryRefresh()
        EnsureInventoryGridScroll()
        Try
            dgvInventoryHistory.Rows.Clear()
            Dim q As String = ProductSearchText()
            Dim cat As String = ProductCategoryFilter()
            Dim sql As String =
                "SELECT p.product_id, p.product_name, c.category_name, p.price, p.stock_quantity, p.reorder_level, p.status, p.created_at " &
                "FROM products p JOIN categories c ON c.category_id = p.category_id " &
                "WHERE (@q = '' OR p.product_name LIKE CONCAT('%', @q, '%')) " &
                "AND (@cat = '' OR c.category_name = @cat) " &
                "ORDER BY p.product_name"
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@q", q)
                    cmd.Parameters.AddWithValue("@cat", cat)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            dgvInventoryHistory.Rows.Add(
                                Convert.ToInt32(rdr("product_id")),
                                rdr("product_name").ToString(),
                                rdr("category_name").ToString(),
                                Convert.ToDecimal(rdr("price")).ToString("N2"),
                                Convert.ToInt32(rdr("stock_quantity")),
                                Convert.ToInt32(rdr("reorder_level")),
                                rdr("status").ToString(),
                                Convert.ToDateTime(rdr("created_at")).ToString("yyyy-MM-dd HH:mm"))
                        End While
                    End Using
                End Using
            End Using
            UpdateInventoryKpis()
        Catch ex As Exception
            MessageBox.Show("Failed to load products: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateInventoryKpis()
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) AS total, SUM(stock_quantity = 0) AS oos, SUM(stock_quantity > 0 AND stock_quantity <= reorder_level) AS low FROM products", conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim total As Integer = Convert.ToInt32(rdr("total"))
                            Dim oos As Integer = If(rdr("oos") Is DBNull.Value, 0, Convert.ToInt32(rdr("oos")))
                            Dim low As Integer = If(rdr("low") Is DBNull.Value, 0, Convert.ToInt32(rdr("low")))
                            If lblTotalItemsValue IsNot Nothing Then lblTotalItemsValue.Text = total.ToString()
                            If lblOutOfStockValue IsNot Nothing Then lblOutOfStockValue.Text = oos.ToString()
                            If lblLowStockValue IsNot Nothing Then lblLowStockValue.Text = low.ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("UpdateInventoryKpis failed: " & ex.Message)
        End Try
    End Sub

    Private Sub txtSearchProducts_GotFocus(sender As Object, e As EventArgs) Handles txtSearchProducts.GotFocus
        If txtSearchProducts.Text = PRODUCT_SEARCH_PLACEHOLDER Then
            txtSearchProducts.Text = ""
            txtSearchProducts.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearchProducts_LostFocus(sender As Object, e As EventArgs) Handles txtSearchProducts.LostFocus
        If String.IsNullOrWhiteSpace(txtSearchProducts.Text) Then
            txtSearchProducts.Text = PRODUCT_SEARCH_PLACEHOLDER
            txtSearchProducts.ForeColor = SystemColors.AppWorkspace
        End If
    End Sub

    Private Sub txtSearchProducts_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProducts.TextChanged
        If txtSearchProducts.Focused Then LoadProducts()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If suppressCategoryReload Then Exit Sub
        LoadProducts()
    End Sub

    Private Function GetSelectedProductRow() As DataGridViewRow
        If dgvInventoryHistory Is Nothing Then Return Nothing
        If dgvInventoryHistory.SelectedRows.Count > 0 Then Return dgvInventoryHistory.SelectedRows(0)
        If dgvInventoryHistory.CurrentRow IsNot Nothing AndAlso Not dgvInventoryHistory.CurrentRow.IsNewRow Then Return dgvInventoryHistory.CurrentRow
        Return Nothing
    End Function

    Private Function SelectedProductId(row As DataGridViewRow) As Integer
        Dim idObj = row.Cells("product_id").Value
        Dim id As Integer = 0
        Integer.TryParse(If(idObj IsNot Nothing, idObj.ToString(), ""), id)
        Return id
    End Function

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Dim prodName As String = frmThemedPrompt.Ask("Product name:", "Add Product", "")
        If prodName Is Nothing Then Exit Sub
        prodName = prodName.Trim()
        If String.IsNullOrWhiteSpace(prodName) Then Exit Sub

        If categoryIds.Count = 0 Then LoadCategoriesIntoFilter()
        Dim catName As String = frmCategoryPicker.Pick("Add Product — Category", categoryIds.Keys.ToList())
        If String.IsNullOrWhiteSpace(catName) Then Exit Sub

        Dim priceTxt As String = frmThemedPrompt.Ask("Price (₱):", "Add Product", "0.00")
        If priceTxt Is Nothing Then Exit Sub
        priceTxt = priceTxt.Trim()
        Dim price As Decimal = 0
        If Not Decimal.TryParse(priceTxt, price) OrElse price < 0 Then
            MessageBox.Show("Invalid price. Product not added.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim stockTxt As String = frmThemedPrompt.Ask("Initial stock quantity:", "Add Product", "0")
        If stockTxt Is Nothing Then Exit Sub
        stockTxt = stockTxt.Trim()
        Dim stock As Integer = 0
        If Not Integer.TryParse(stockTxt, stock) OrElse stock < 0 Then
            MessageBox.Show("Invalid stock quantity. Product not added.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim reorderTxt As String = frmThemedPrompt.Ask("Reorder level (low-stock warning at/below this):", "Add Product", "10")
        If reorderTxt Is Nothing Then Exit Sub
        reorderTxt = reorderTxt.Trim()
        Dim reorder As Integer = 10
        If Not Integer.TryParse(reorderTxt, reorder) OrElse reorder < 0 Then
            MessageBox.Show("Invalid reorder level. Product not added.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim newId As Integer = 0
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO products (product_name, category_id, price, stock_quantity, reorder_level, status) VALUES (@n, @cid, @p, @s, @r, 'Active')", conn)
                    cmd.Parameters.AddWithValue("@n", prodName)
                    cmd.Parameters.AddWithValue("@cid", categoryIds(catName))
                    cmd.Parameters.AddWithValue("@p", price)
                    cmd.Parameters.AddWithValue("@s", stock)
                    cmd.Parameters.AddWithValue("@r", reorder)
                    cmd.ExecuteNonQuery()
                    newId = CInt(cmd.LastInsertedId)
                End Using
            End Using
            If stock > 0 Then AddStockMovement(newId, "Stock In", stock, "Initial stock on product creation")
            WriteAudit("Add Product", $"Added '{prodName}' ({catName}) ₱{price:N2} stock={stock}")
            LoadProducts()
            MessageBox.Show($"Product '{prodName}' added successfully.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to add product: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditProduct_Click(sender As Object, e As EventArgs) Handles btnEditProduct.Click
        Dim row As DataGridViewRow = GetSelectedProductRow()
        If row Is Nothing Then
            MessageBox.Show("Please select a product to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim pid As Integer = SelectedProductId(row)
        If pid <= 0 Then Exit Sub
        Dim curName As String = row.Cells("product_name").Value.ToString()
        Dim curPrice As String = row.Cells("price").Value.ToString()
        Dim curReorder As String = row.Cells("reorder_level").Value.ToString()

        Dim newName As String = frmThemedPrompt.Ask("Product name:", "Edit Product", curName)
        If newName Is Nothing Then Exit Sub
        newName = newName.Trim()
        If String.IsNullOrWhiteSpace(newName) Then Exit Sub
        Dim priceTxt As String = frmThemedPrompt.Ask("Price (₱):", "Edit Product", curPrice)
        If priceTxt Is Nothing Then Exit Sub
        priceTxt = priceTxt.Trim()
        Dim price As Decimal = 0
        If Not Decimal.TryParse(priceTxt, price) OrElse price < 0 Then
            MessageBox.Show("Invalid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim reorderTxt As String = frmThemedPrompt.Ask("Reorder level:", "Edit Product", curReorder)
        If reorderTxt Is Nothing Then Exit Sub
        reorderTxt = reorderTxt.Trim()
        Dim reorder As Integer = 0
        If Not Integer.TryParse(reorderTxt, reorder) OrElse reorder < 0 Then
            MessageBox.Show("Invalid reorder level.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE products SET product_name=@n, price=@p, reorder_level=@r WHERE product_id=@id", conn)
                    cmd.Parameters.AddWithValue("@n", newName)
                    cmd.Parameters.AddWithValue("@p", price)
                    cmd.Parameters.AddWithValue("@r", reorder)
                    cmd.Parameters.AddWithValue("@id", pid)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            WriteAudit("Edit Product", $"Edited #{pid} '{curName}' → '{newName}' ₱{price:N2}")
            LoadProducts()
            MessageBox.Show("Product updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to update product: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRestock_Click(sender As Object, e As EventArgs) Handles btnRestock.Click
        Dim row As DataGridViewRow = GetSelectedProductRow()
        If row Is Nothing Then
            MessageBox.Show("Please select a product to restock.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim pid As Integer = SelectedProductId(row)
        If pid <= 0 Then Exit Sub
        Dim qtyTxt As String = frmThemedPrompt.Ask($"Add stock for '{row.Cells("product_name").Value}' (current: {row.Cells("stock_quantity").Value}):", "Restock", "10")
        If qtyTxt Is Nothing Then Exit Sub
        qtyTxt = qtyTxt.Trim()
        Dim qty As Integer = 0
        If Not Integer.TryParse(qtyTxt, qty) OrElse qty <= 0 Then
            MessageBox.Show("Enter a positive quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE products SET stock_quantity = stock_quantity + @qty WHERE product_id=@id", conn)
                    cmd.Parameters.AddWithValue("@qty", qty)
                    cmd.Parameters.AddWithValue("@id", pid)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            AddStockMovement(pid, "Stock In", qty, "Manual restock from Inventory")
            WriteAudit("Restock", $"Restocked #{pid} +{qty}")
            LoadProducts()
            MessageBox.Show("Stock updated successfully.", "Restocked", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to restock: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeactivateProduct_Click(sender As Object, e As EventArgs) Handles btnDeactivateProduct.Click
        Dim row As DataGridViewRow = GetSelectedProductRow()
        If row Is Nothing Then
            MessageBox.Show("Please select a product.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim pid As Integer = SelectedProductId(row)
        If pid <= 0 Then Exit Sub
        Dim curStatus As String = row.Cells("status").Value.ToString()
        Dim newStatus As String = If(curStatus = "Active", "Inactive", "Active")
        Dim verb As String = If(newStatus = "Inactive", "deactivate (hide from POS/Kiosk)", "reactivate")
        If MessageBox.Show($"Are you sure you want to {verb} '{row.Cells("product_name").Value}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub

        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE products SET status=@s WHERE product_id=@id", conn)
                    cmd.Parameters.AddWithValue("@s", newStatus)
                    cmd.Parameters.AddWithValue("@id", pid)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            WriteAudit(If(newStatus = "Inactive", "Deactivate Product", "Reactivate Product"), $"#{pid} → {newStatus}")
            LoadProducts()
            MessageBox.Show($"Product is now {newStatus}.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to update status: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "PHASE 7 — Reports (generate + export + print)"

    Private reportInitDone As Boolean = False

    ' Recent Transactions "View All →" jumps to a pre-filtered Sales report.
    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        InitReportControls()
        If ComboBox1 IsNot Nothing AndAlso ComboBox1.Items.Contains("Sales Summary") Then
            ComboBox1.SelectedItem = "Sales Summary"
        End If
        GenerateReport()
        If pnlReportsView IsNot Nothing Then SwitchView(pnlReportsView, btnReports)
    End Sub

    ' Reports grid keeps its designed width; horizontal scrolling (wheel)
    ' reveals clipped columns instead. Window is only centered here.
    Private reportWheelFilter As GridWheel.WheelFilter

    Private Sub ExpandReportsArea()
        Try
            Me.CenterToScreen()
            If dgvReport IsNot Nothing AndAlso reportWheelFilter Is Nothing Then
                reportWheelFilter = New GridWheel.WheelFilter(dgvReport, "reports")
                Application.AddMessageFilter(reportWheelFilter)
            End If
        Catch ex As Exception
            Debug.WriteLine("ExpandReportsArea failed: " & ex.Message)
        End Try
    End Sub

    Private Sub frmDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            If reportWheelFilter IsNot Nothing Then
                Application.RemoveMessageFilter(reportWheelFilter)
                reportWheelFilter = Nothing
            End If
        Catch
        End Try
    End Sub

    ' Manual refresh for the dashboard view (auto-refresh already runs on
    ' load/activate/nav; this is the on-demand button).
    ' (Designer-visible: btnDashRefresh lives in pnlRecentTransactions.)
    Private Sub AddDashboardRefresh()
        Try
            If pnlRecentTransactions Is Nothing OrElse btnDashRefresh Is Nothing Then Exit Sub
            btnDashRefresh.BringToFront()
        Catch ex As Exception
            Debug.WriteLine("AddDashboardRefresh failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDashRefresh_Click(sender As Object, e As EventArgs) Handles btnDashRefresh.Click
        RefreshDashboardStats()
    End Sub

    Private Sub InitReportControls()
        If reportInitDone Then Exit Sub
        Try
            If ComboBox1 IsNot Nothing AndAlso ComboBox1.Items.Count = 0 Then
                ComboBox1.Items.AddRange(New Object() {"Stock Movements", "Sales Summary", "Salary Deductions"})
                ComboBox1.SelectedIndex = 0
            End If
            ' Guarantee scrollability with FIXED widths: any auto-fit mode
            ' (Fill or AllCells) makes total width track the grid, so overflow
            ' — and therefore scrolling — becomes mathematically impossible.
            ' Fixed widths always overflow on clipped content. Values below
            ' were measured against real report rows (TRN numbers, datetimes).
            If dgvReport IsNot Nothing Then
                dgvReport.ScrollBars = ScrollBars.Both
                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                SetReportColWidth("movement_id", 90)
                SetReportColWidth("colDate", 130)
                SetReportColWidth("colProduct", 200)
                SetReportColWidth("colMovementType", 120)
                SetReportColWidth("colQuantity", 150)
                SetReportColWidth("colUser", 110)
                SetReportColWidth("colRemarks", 220)
            End If
            If dtpReportFrom IsNot Nothing Then dtpReportFrom.Value = DateTime.Today.AddDays(-30)
            If dtpReportto IsNot Nothing Then dtpReportto.Value = DateTime.Today
            ' Designer-visible: btnReportRefresh/btnRepScrollL/btnRepScrollR
            ' live in Panel13. Just ensure z-order.
            If btnReportRefresh IsNot Nothing Then btnReportRefresh.BringToFront()
            If btnRepScrollL IsNot Nothing Then btnRepScrollL.BringToFront()
            If btnRepScrollR IsNot Nothing Then btnRepScrollR.BringToFront()
            reportInitDone = True
        Catch ex As Exception
            Debug.WriteLine("InitReportControls failed: " & ex.Message)
        End Try
    End Sub

    Private Sub SetReportColWidth(name As String, w As Integer)
        Try
            If dgvReport IsNot Nothing AndAlso dgvReport.Columns.Contains(name) Then
                dgvReport.Columns(name).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvReport.Columns(name).Width = w
            End If
        Catch ex As Exception
            Debug.WriteLine("SetReportColWidth failed: " & ex.Message)
        End Try
    End Sub

    ' Inventory grid horizontal scroll: Fill mode squeezes columns to the grid
    ' width so overflow (and the scrollbar) can never exist — fixed widths
    ' totaling past the grid width make left-right scrolling real.
    ' Measured against live rows (longest name/category/datetime).
    Private Sub EnsureInventoryGridScroll()
        Try
            If dgvInventoryHistory Is Nothing Then Exit Sub
            dgvInventoryHistory.ScrollBars = ScrollBars.Both
            dgvInventoryHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            SetInventoryColWidth("product_id", 70)
            SetInventoryColWidth("product_name", 150)
            SetInventoryColWidth("category_name", 130)
            SetInventoryColWidth("price", 80)
            SetInventoryColWidth("stock_quantity", 80)
            SetInventoryColWidth("reorder_level", 80)
            SetInventoryColWidth("status", 80)
            SetInventoryColWidth("created_at", 140)
        Catch ex As Exception
            Debug.WriteLine("EnsureInventoryGridScroll failed: " & ex.Message)
        End Try
    End Sub

    Private Sub SetInventoryColWidth(name As String, w As Integer)
        Try
            If dgvInventoryHistory IsNot Nothing AndAlso dgvInventoryHistory.Columns.Contains(name) Then
                dgvInventoryHistory.Columns(name).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvInventoryHistory.Columns(name).Width = w
            End If
        Catch ex As Exception
            Debug.WriteLine("SetInventoryColWidth failed: " & ex.Message)
        End Try
    End Sub

    Private Function CurrentReportType() As String
        If ComboBox1 IsNot Nothing AndAlso ComboBox1.SelectedItem IsNot Nothing Then
            Return ComboBox1.SelectedItem.ToString()
        End If
        Return "Stock Movements"
    End Function

    Private Sub ReportRange(ByRef fromD As Date, ByRef toD As Date)
        fromD = If(dtpReportFrom IsNot Nothing, dtpReportFrom.Value.Date, DateTime.Today.AddDays(-30))
        toD = If(dtpReportto IsNot Nothing, dtpReportto.Value.Date.AddDays(1), DateTime.Today.AddDays(1))
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateReport()
    End Sub

    Private Sub btnReportRefresh_Click(sender As Object, e As EventArgs) Handles btnReportRefresh.Click
        GenerateReport()
    End Sub

    Private Sub btnRepScrollL_Click(sender As Object, e As EventArgs) Handles btnRepScrollL.Click
        If dgvReport IsNot Nothing Then GridWheel.ScrollHorizontal(dgvReport, "reports", -1)
    End Sub

    Private Sub btnRepScrollR_Click(sender As Object, e As EventArgs) Handles btnRepScrollR.Click
        If dgvReport IsNot Nothing Then GridWheel.ScrollHorizontal(dgvReport, "reports", 1)
    End Sub

    Public Sub GenerateReport()
        If dgvReport Is Nothing Then Exit Sub
        Try
            dgvReport.Rows.Clear()
            Dim fromD As Date, toD As Date
            ReportRange(fromD, toD)
            Select Case CurrentReportType()
                Case "Sales Summary"
                    GenerateSalesReport(fromD, toD)
                Case "Salary Deductions"
                    GenerateSalaryReport(fromD, toD)
                Case Else
                    GenerateMovementReport(fromD, toD)
            End Select
            If lblReportSubtitle IsNot Nothing Then
                lblReportSubtitle.Text = $"{CurrentReportType()}  •  {fromD:yyyy-MM-dd} to {toD.AddDays(-1):yyyy-MM-dd}  •  {dgvReport.Rows.Count} row(s)"
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to generate report: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateMovementReport(fromD As Date, toD As Date)
        Using conn As MySqlConnection = DbHelper.GetConnection()
            conn.Open()
            Dim sql As String =
                "SELECT sm.movement_id, sm.movement_date, p.product_name, sm.movement_type, sm.quantity, u.username, sm.remarks " &
                "FROM stock_movements sm JOIN products p ON p.product_id = sm.product_id " &
                "JOIN users u ON u.id = sm.user_id " &
                "WHERE sm.movement_date >= @f AND sm.movement_date < @t ORDER BY sm.movement_date DESC LIMIT 1000"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@f", fromD)
                cmd.Parameters.AddWithValue("@t", toD)
                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        dgvReport.Rows.Add(
                            Convert.ToInt32(rdr("movement_id")),
                            Convert.ToDateTime(rdr("movement_date")).ToString("yyyy-MM-dd HH:mm"),
                            rdr("product_name").ToString(),
                            rdr("movement_type").ToString(),
                            Convert.ToInt32(rdr("quantity")),
                            rdr("username").ToString(),
                            If(rdr("remarks") Is DBNull.Value, "", rdr("remarks").ToString()))
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub GenerateSalesReport(fromD As Date, toD As Date)
        Using conn As MySqlConnection = DbHelper.GetConnection()
            conn.Open()
            Dim sql As String =
                "SELECT t.transaction_id, t.transaction_date, COALESCE(t.transaction_number, CONCAT('#', t.transaction_id)) AS tno, " &
                "t.payment_method, COUNT(td.detail_id) AS items, COALESCE(SUM(td.quantity), 0) AS qty, " &
                "t.total_amount, t.status, u.username " &
                "FROM transactions t LEFT JOIN transaction_details td ON td.transaction_id = t.transaction_id " &
                "LEFT JOIN users u ON u.id = t.user_id " &
                "WHERE t.transaction_date >= @f AND t.transaction_date < @t " &
                "GROUP BY t.transaction_id ORDER BY t.transaction_date DESC LIMIT 1000"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@f", fromD)
                cmd.Parameters.AddWithValue("@t", toD)
                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        dgvReport.Rows.Add(
                            Convert.ToInt32(rdr("transaction_id")),
                            Convert.ToDateTime(rdr("transaction_date")).ToString("yyyy-MM-dd HH:mm"),
                            rdr("tno").ToString(),
                            rdr("payment_method").ToString(),
                            $"{rdr("items")} items / {rdr("qty")} pcs",
                            If(rdr("username") Is DBNull.Value, "", rdr("username").ToString()),
                            $"₱{Convert.ToDecimal(rdr("total_amount")).ToString("N2")} • {rdr("status")}")
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub GenerateSalaryReport(fromD As Date, toD As Date)
        Using conn As MySqlConnection = DbHelper.GetConnection()
            conn.Open()
            Dim sql As String =
                "SELECT sd.deduction_id, sd.deduction_date, sd.employee_number, e.full_name, " &
                "sd.deduction_amount, sd.deduction_status, COALESCE(t.transaction_number, CONCAT('#', sd.transaction_id)) AS tno, u.username " &
                "FROM salary_deductions sd JOIN employees e ON e.employee_number = sd.employee_number " &
                "LEFT JOIN transactions t ON t.transaction_id = sd.transaction_id " &
                "LEFT JOIN users u ON u.id = t.user_id " &
                "WHERE sd.deduction_date >= @f AND sd.deduction_date < @t ORDER BY sd.deduction_date DESC LIMIT 1000"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@f", fromD)
                cmd.Parameters.AddWithValue("@t", toD)
                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        dgvReport.Rows.Add(
                            Convert.ToInt32(rdr("deduction_id")),
                            Convert.ToDateTime(rdr("deduction_date")).ToString("yyyy-MM-dd HH:mm"),
                            $"{rdr("employee_number")} - {rdr("full_name")}",
                            rdr("deduction_status").ToString(),
                            $"₱{Convert.ToDecimal(rdr("deduction_amount")).ToString("N2")}",
                            If(rdr("username") Is DBNull.Value, "", rdr("username").ToString()),
                            If(rdr("tno") Is DBNull.Value, "", rdr("tno").ToString()))
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Function ReportHeaders() As List(Of String)
        Dim hs As New List(Of String)
        If dgvReport IsNot Nothing Then
            For Each c As DataGridViewColumn In dgvReport.Columns
                hs.Add(c.HeaderText)
            Next
        End If
        Return hs
    End Function

    Private Function ReportRows() As List(Of List(Of String))
        Dim rs As New List(Of List(Of String))
        If dgvReport IsNot Nothing Then
            For Each row As DataGridViewRow In dgvReport.Rows
                If row.IsNewRow Then Continue For
                Dim cells As New List(Of String)
                For Each c As DataGridViewColumn In dgvReport.Columns
                    Dim v As Object = row.Cells(c.Name).Value
                    cells.Add(If(v Is Nothing, "", v.ToString()))
                Next
                rs.Add(cells)
            Next
        End If
        Return rs
    End Function

    Private Function ReportTitle() As String
        Dim fromD As Date, toD As Date
        ReportRange(fromD, toD)
        Return $"LYCEUM OF ALABANG CANTEEN — {CurrentReportType().ToUpper()} ({fromD:yyyy-MM-dd} to {toD.AddDays(-1):yyyy-MM-dd})"
    End Function

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvReport Is Nothing OrElse ReportRows().Count = 0 Then
            MessageBox.Show("Generate a report first — there is nothing to export.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Using dlg As New SaveFileDialog()
            dlg.Filter = "CSV files (*.csv)|*.csv"
            dlg.FileName = $"canteen_report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If dlg.ShowDialog() = DialogResult.OK Then
                Try
                    Using w As New System.IO.StreamWriter(dlg.FileName, False, System.Text.Encoding.UTF8)
                        Dim esc As Func(Of String, String) = Function(s As String) """" & s.Replace("""", """""") & """"
                        w.WriteLine(String.Join(",", ReportHeaders().Select(Function(h) esc(h))))
                        For Each r In ReportRows()
                            w.WriteLine(String.Join(",", r.Select(Function(c) esc(c))))
                        Next
                    End Using
                    MessageBox.Show($"Exported {ReportRows().Count} row(s) to:{vbCrLf}{dlg.FileName}", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvReport Is Nothing OrElse ReportRows().Count = 0 Then
            MessageBox.Show("Generate a report first — there is nothing to export.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Using dlg As New SaveFileDialog()
            dlg.Filter = "PDF files (*.pdf)|*.pdf"
            dlg.FileName = $"canteen_report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            If dlg.ShowDialog() = DialogResult.OK Then
                If ReportPdf.SaveGrid("LYCEUM OF ALABANG — CANTEEN REPORTS", ReportTitle(), ReportHeaders(), ReportRows(), dlg.FileName) Then
                    MessageBox.Show($"PDF saved to:{vbCrLf}{dlg.FileName}", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("PDF export failed. See debug output for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Using
    End Sub

    ' ---- Grid printing ----
    Private printRowIndex As Integer = 0
    Private printPageNo As Integer = 0
    Private WithEvents printDoc As System.Drawing.Printing.PrintDocument

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dgvReport Is Nothing OrElse ReportRows().Count = 0 Then
            MessageBox.Show("Generate a report first — there is nothing to print.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        printRowIndex = 0
        printPageNo = 0
        printDoc = New System.Drawing.Printing.PrintDocument()
        printDoc.DocumentName = ReportTitle()
        Using dlg As New PrintDialog()
            dlg.Document = printDoc
            If dlg.ShowDialog() = DialogResult.OK Then
                Try
                    printDoc.Print()
                Catch ex As Exception
                    MessageBox.Show("Print failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        Dim g As Graphics = e.Graphics
        Dim left As Integer = e.MarginBounds.Left
        Dim y As Integer = e.MarginBounds.Top
        Dim titleFont As New Font("Segoe UI", 13, FontStyle.Bold)
        Dim headFont As New Font("Segoe UI", 8, FontStyle.Bold)
        Dim bodyFont As New Font("Segoe UI", 8)
        printPageNo += 1
        g.DrawString("LYCEUM OF ALABANG — CANTEEN REPORTS", titleFont, Brushes.Black, left, y)
        y += 26
        g.DrawString($"{ReportTitle()}   |   Page {printPageNo}", bodyFont, Brushes.Black, left, y)
        y += 24
        Dim cols As DataGridViewColumn() = dgvReport.Columns.Cast(Of DataGridViewColumn)().ToArray()
        Dim totalW As Integer = e.MarginBounds.Width
        Dim widths(cols.Length - 1) As Integer
        Dim rel() As Double = {0.1, 0.16, 0.24, 0.14, 0.1, 0.12, 0.14}
        For i As Integer = 0 To cols.Length - 1
            widths(i) = CInt(totalW * If(i < rel.Length, rel(i), 0.12))
        Next
        Dim drawRow As Action(Of String(), Font, Boolean) =
            Sub(vals As String(), f As Font, underline As Boolean)
                Dim x As Integer = left
                For i As Integer = 0 To cols.Length - 1
                    Dim t As String = If(i < vals.Length AndAlso vals(i) IsNot Nothing, vals(i), "")
                    g.DrawString(t, f, Brushes.Black, New RectangleF(x, y, widths(i) - 4, f.Height + 6))
                    x += widths(i)
                Next
                y += f.Height + 8
                If underline Then
                    g.DrawLine(Pens.Black, left, y, left + totalW, y)
                    y += 6
                End If
            End Sub
        drawRow(cols.Select(Function(c) c.HeaderText).ToArray(), headFont, True)
        While printRowIndex < dgvReport.Rows.Count
            Dim row As DataGridViewRow = dgvReport.Rows(printRowIndex)
            printRowIndex += 1
            If row.IsNewRow Then Continue While
            If y + 30 > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Exit Sub
            End If
            drawRow(cols.Select(Function(c) If(row.Cells(c.Name).Value Is Nothing, "", row.Cells(c.Name).Value.ToString())).ToArray(), bodyFont, False)
        End While
        e.HasMorePages = False
    End Sub

#End Region

#Region "PHASE 7 — Settings (profile + password + backup)"

    Private settingsBuilt As Boolean = False
    Private txtOldPass As TextBox
    Private txtNewPass As TextBox
    Private txtConfirmPass As TextBox

    Private Sub BuildSettingsControls()
        If settingsBuilt Then Exit Sub
        Try
            If pnlSettingsView Is Nothing Then Exit Sub
            Dim title As New Label()
            title.Text = "⚙  SETTINGS"
            title.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            title.ForeColor = Color.FromArgb(11, 27, 61)
            title.Location = New Point(30, 20)
            title.AutoSize = True
            pnlSettingsView.Controls.Add(title)

            Dim meName As String = "", meRole As String = "", meUser As String = ""
            Try
                meName = Session.CurrentFullName
                meRole = Session.CurrentRole
                meUser = Session.CurrentUsername
            Catch
            End Try
            Dim profile As New Label()
            profile.Text = $"Logged in as: {meName} ({meUser})" & vbCrLf & $"Role: {meRole}"
            profile.Font = New Font("Segoe UI", 11)
            profile.ForeColor = Color.FromArgb(11, 27, 61)
            profile.Location = New Point(30, 60)
            profile.AutoSize = True
            pnlSettingsView.Controls.Add(profile)

            Dim grp As New GroupBox()
            grp.Text = "Change Password"
            grp.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            grp.Location = New Point(30, 130)
            grp.Size = New Size(360, 210)
            pnlSettingsView.Controls.Add(grp)

            Dim mkLabel As Func(Of String, Integer, Label) =
                Function(t As String, yy As Integer) As Label
                    Dim l As New Label()
                    l.Text = t
                    l.Location = New Point(20, yy)
                    l.AutoSize = True
                    grp.Controls.Add(l)
                    Return l
                End Function
            Dim mkBox As Func(Of Integer, TextBox) =
                Function(yy As Integer) As TextBox
                    Dim b As New TextBox()
                    b.Location = New Point(150, yy - 3)
                    b.Size = New Size(180, 24)
                    b.UseSystemPasswordChar = True
                    grp.Controls.Add(b)
                    Return b
                End Function
            mkLabel("Current:", 30)
            txtOldPass = mkBox(30)
            mkLabel("New:", 65)
            txtNewPass = mkBox(65)
            mkLabel("Confirm:", 100)
            txtConfirmPass = mkBox(100)
            ' Designer-visible: btnChangePassword already exists.
            ' Reparent into the runtime GroupBox so layout matches.
            If btnChangePassword IsNot Nothing Then
                If btnChangePassword.Parent IsNot grp Then
                    If btnChangePassword.Parent IsNot Nothing Then btnChangePassword.Parent.Controls.Remove(btnChangePassword)
                    grp.Controls.Add(btnChangePassword)
                End If
                btnChangePassword.Location = New Point(20, 140)
                btnChangePassword.BringToFront()
            End If

            ' Designer-visible: btnBackup already in pnlSettingsView.
            If btnBackup IsNot Nothing Then btnBackup.BringToFront()

            settingsBuilt = True
        Catch ex As Exception
            Debug.WriteLine("BuildSettingsControls failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim oldP As String = If(txtOldPass IsNot Nothing, txtOldPass.Text, "")
        Dim newP As String = If(txtNewPass IsNot Nothing, txtNewPass.Text, "")
        Dim confP As String = If(txtConfirmPass IsNot Nothing, txtConfirmPass.Text, "")
        If String.IsNullOrWhiteSpace(oldP) OrElse String.IsNullOrWhiteSpace(newP) Then
            MessageBox.Show("Fill in all password fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If newP.Length < 4 Then
            MessageBox.Show("New password must be at least 4 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If newP <> confP Then
            MessageBox.Show("New password and confirmation do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim uid As Integer = 0
        Try
            uid = Session.CurrentUserId
        Catch
        End Try
        If uid <= 0 Then
            MessageBox.Show("No logged-in user found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using chk As New MySqlCommand("SELECT password FROM users WHERE id=@id LIMIT 1", conn)
                    chk.Parameters.AddWithValue("@id", uid)
                    Dim dbPass As Object = chk.ExecuteScalar()
                    If dbPass Is Nothing OrElse dbPass.ToString() <> oldP Then
                        MessageBox.Show("Current password is incorrect.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
                Using upd As New MySqlCommand("UPDATE users SET password=@p WHERE id=@id", conn)
                    upd.Parameters.AddWithValue("@p", newP)
                    upd.Parameters.AddWithValue("@id", uid)
                    upd.ExecuteNonQuery()
                End Using
            End Using
            txtOldPass.Text = ""
            txtNewPass.Text = ""
            txtConfirmPass.Text = ""
            AuditLog.Log(uid, "Change Password", $"{Session.CurrentUsername} changed their password")
            MessageBox.Show("Password updated successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Password change failed: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Try
            Dim dumpExe As String = "C:\xampp\mysql\bin\mysqldump.exe"
            If Not System.IO.File.Exists(dumpExe) Then dumpExe = "mysqldump"
            Dim target As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"school_canteen_db_backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql")
            Dim psi As New ProcessStartInfo(dumpExe, $" -u root school_canteen_db --result-file=""{target}""")
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            psi.RedirectStandardError = True
            Using proc As Process = Process.Start(psi)
                If Not proc.WaitForExit(60000) Then
                    proc.Kill()
                    MessageBox.Show("Backup timed out.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If proc.ExitCode <> 0 Then
                    MessageBox.Show("Backup failed:" & vbCrLf & proc.StandardError.ReadToEnd(), "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using
            Dim uid As Integer = 0
            Try
                uid = Session.CurrentUserId
            Catch
            End Try
            AuditLog.Log(uid, "Database Backup", $"Backup written to {target}")
            MessageBox.Show($"Backup saved to:{vbCrLf}{target}", "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Backup failed: " & ex.Message & vbCrLf & "Make sure MySQL is running.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region
End Class