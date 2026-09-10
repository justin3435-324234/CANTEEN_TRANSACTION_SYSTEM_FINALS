Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmDashboard
    Private userRole As String

    Public Sub New(role As String)
        InitializeComponent()
        Me.userRole = role
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            ' 6. Load employees into salary deduction grid
            LoadEmployees()

            ' 7. Set default active view
            SwitchView(pnlDashboardView, btnDashboard)

        Catch ex As Exception
            MessageBox.Show("Dashboard Load Error: " & ex.Message, "Design Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub LoadEmployees()
        If dgvTextBoxColumn IsNot Nothing Then
            dgvTextBoxColumn.Rows.Clear()
            For Each emp As SalesTracker.Employee In SalesTracker.Employees
                ' Load saved DeductionStatus (PENDING or COMPLETE) - must match ComboBox items exactly
                Dim savedDeductionStatus As String = If(String.IsNullOrWhiteSpace(emp.DeductionStatus), "PENDING", emp.DeductionStatus.Trim().ToUpper())
                ' Validate against allowed values
                If savedDeductionStatus <> "PENDING" AndAlso savedDeductionStatus <> "COMPLETE" Then
                    savedDeductionStatus = "PENDING"
                End If
                Dim pStart As String = If(String.IsNullOrWhiteSpace(emp.PeriodStart), "", emp.PeriodStart)
                Dim pEnd As String = If(String.IsNullOrWhiteSpace(emp.PeriodEnd), "", emp.PeriodEnd)
                dgvTextBoxColumn.Rows.Add(emp.EmpNo, emp.FullName, emp.Position, "₱" & emp.SDRemaining.ToString("N2"), emp.Status, savedDeductionStatus, pStart, pEnd)
            Next
            ApplySalaryFilter()
        End If
    End Sub

    Private Sub frmDashboard_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshDashboardStats()
    End Sub

    Private Sub RefreshDashboardStats()
        lblTodaySalesVal.Text = "₱" & SalesTracker.TotalSales.ToString("N2")
        lblItemsSoldVal.Text = SalesTracker.ItemsSold.ToString()
        UpdateDashboardChart()
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
                Dim loginForm As New frmLogin()
                loginForm.Show()
                Me.Close()
            End If
            Exit Sub
        End If

        ' View switching
        Select Case btn.Name
            Case "btnDashboard"
                SwitchView(pnlDashboardView, btn)



            Case "btnInventory"
                If pnlInventoryView IsNot Nothing Then SwitchView(pnlInventoryView, btn)
            Case "btnSalaryDeduction"
                If pnlSalaryDeductionView IsNot Nothing Then SwitchView(pnlSalaryDeductionView, btn)
            Case "btnReports"
                If Me.btnPrint IsNot Nothing Then SwitchView(Me.btnPrint, btn)
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
        ' Ensure Reports view (btnPrint) stays Navy Blue and does not turn Yellow/Gold
        If btnPrint IsNot Nothing Then
            btnPrint.BackColor = Color.FromArgb(0, 0, 64)
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

    ' --- UPDATE CHART WITH TRACKED SALES (rolling window of 8) ---
    Private Sub UpdateDashboardChart()
        If Chart1 Is Nothing Then Exit Sub
        If Chart1.Series.Count < 2 Then Exit Sub

        Dim slots As Integer = 8
        Dim gold(8) As Double
        Dim cyan(8) As Double

        Dim saleCount As Integer = SalesTracker.SaleAmounts.Count
        For i As Integer = 0 To slots - 1
            Dim idx As Integer = saleCount - slots + i
            If idx >= 0 AndAlso idx < saleCount Then
                gold(i) = CDbl(SalesTracker.SaleAmounts(idx))
                cyan(i) = CDbl(SalesTracker.TransactionItems(idx))
            Else
                gold(i) = 0
                cyan(i) = 0
            End If
        Next

        Chart1.Series("Sales").Points.DataBindY(gold)
        Chart1.Series("Transactions").Points.DataBindY(cyan)

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
        ' Force DeductionStatus to always be PENDING unless explicitly set to COMPLETE
        ' If changed to COMPLETE, reset SD Remaining to 2500
        If e.RowIndex >= 0 AndAlso dgvTextBoxColumn.Columns(e.ColumnIndex).Name = "DeductionStatus" Then
            Dim cellValue As String = ""
            Try
                Dim valObj = dgvTextBoxColumn.Rows(e.RowIndex).Cells("DeductionStatus").Value
                If valObj IsNot Nothing Then cellValue = valObj.ToString()
            Catch
                cellValue = ""
            End Try

            ' Normalize the value
            Dim normalizedValue As String = If(String.IsNullOrWhiteSpace(cellValue), "PENDING", cellValue.Trim().ToUpper())

            If normalizedValue = "COMPLETE" Then
                ' Reset SD Remaining to 2500
                dgvTextBoxColumn.Rows(e.RowIndex).Cells("colSDRemaining").Value = "₱2,500.00"

                ' Set period end date to current date when SD resets
                dgvTextBoxColumn.Rows(e.RowIndex).Cells("colPeriodEnd").Value = DateTime.Now.ToString("yyyy-MM-dd")

                ' Update in SalesTracker
                Dim empNoObj = dgvTextBoxColumn.Rows(e.RowIndex).Cells("colEmpNo").Value
                Dim empNo As String = If(empNoObj IsNot Nothing, empNoObj.ToString(), "")
                If Not String.IsNullOrEmpty(empNo) Then
                    For Each emp As SalesTracker.Employee In SalesTracker.Employees
                        If emp.EmpNo = empNo Then
                            emp.SDRemaining = 2500
                            emp.DeductionStatus = "COMPLETE"
                            Exit For
                        End If
                    Next
                End If
            Else
                ' Revert to PENDING and update SalesTracker
                Try
                    dgvTextBoxColumn.Rows(e.RowIndex).Cells("DeductionStatus").Value = "PENDING"
                Catch
                End Try

                Dim empNoObj = dgvTextBoxColumn.Rows(e.RowIndex).Cells("colEmpNo").Value
                Dim empNo As String = If(empNoObj IsNot Nothing, empNoObj.ToString(), "")
                If Not String.IsNullOrEmpty(empNo) Then
                    For Each emp As SalesTracker.Employee In SalesTracker.Employees
                        If emp.EmpNo = empNo Then
                            emp.DeductionStatus = "PENDING"
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
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
    Public Sub AddEmployee(empNo As String, username As String, fullName As String, position As String, sdRemaining As Decimal, empStatus As String, deductionStatus As String)
        If dgvTextBoxColumn IsNot Nothing Then
            ' Always set DeductionStatus to PENDING
            ' Set period_start to today's date when employee is first added (also auto for created_at in DB)
            Dim periodStart As String = DateTime.Now.ToString("yyyy-MM-dd")
            ' Add values for all 8 columns including Period Start and Period End
            dgvTextBoxColumn.Rows.Add(empNo, fullName, position, "₱" & sdRemaining.ToString("N2"), empStatus, "PENDING", periodStart, "")
            ApplySalaryFilter()
        End If
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

        For Each row As DataGridViewRow In dgvTextBoxColumn.Rows
            If row.IsNewRow Then Continue For
            Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString().ToLower(), "")
            Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString().ToLower(), "")
            Dim posVal As String = If(row.Cells("colPosition").Value IsNot Nothing, row.Cells("colPosition").Value.ToString(), "")

            Dim matchesSearch As Boolean = String.IsNullOrEmpty(searchText) OrElse empNo.Contains(searchText) OrElse nameVal.Contains(searchText)
            Dim matchesRole As Boolean = String.IsNullOrEmpty(roleFilter) OrElse posVal.Equals(roleFilter, StringComparison.OrdinalIgnoreCase)

            Dim isVisible As Boolean = matchesSearch AndAlso matchesRole
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

#End Region

#Region "Salary Deduction View - Button Actions"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' btnEdit is the ADD button in pnlSalaryDeductionView - just show signup
        Dim signup As New frmEmployeeSignUp()
        If signup.ShowDialog() = DialogResult.OK Then
            Dim empNo As String = signup.EmployeeNumber
            Dim username As String = signup.Username
            Dim fullName As String = signup.FullName
            Dim pos As String = signup.Position
            Dim empStatus As String = "Available"
            Dim dedStatus As String = "PENDING"
            Dim sdRem As Decimal = 2500
            Try
                System.IO.File.AppendAllText("C:\Users\Justin\Desktop\CANTEEN_TRANSACTION_MANAGEMENT_SYSTEM\debug_signup.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} DASHBOARD btnAdd empNo='{empNo}' username='{username}' fullName='{fullName}'" & vbCrLf)
            Catch
            End Try

            SalesTracker.AddEmployee(empNo, username, fullName, pos, sdRem, empStatus, dedStatus)
            LoadEmployees()
            ApplySalaryFilter()
            MessageBox.Show($"Employee {empNo} - {fullName} added successfully!" & vbCrLf & $"Username: {username}", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEdit1_Click(sender As Object, e As EventArgs)
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim curName As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim curPos As String = If(row.Cells("colPosition").Value IsNot Nothing, row.Cells("colPosition").Value.ToString(), "")

        Dim newName As String = InputBox($"Edit Full Name for {empNo}:", "Edit Employee", curName)
        If String.IsNullOrWhiteSpace(newName) Then Exit Sub
        newName = newName.Trim()

        Dim newPos As String = InputBox($"Edit Position for {empNo}:" & vbCrLf & "Options: Teacher, Staff, Admin, Security, etc.", "Edit Position", curPos)
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

    Private Sub btnView_Click(sender As Object, e As EventArgs)
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim posVal As String = If(row.Cells("colPosition").Value IsNot Nothing, row.Cells("colPosition").Value.ToString(), "")
        Dim sdRem As String = If(row.Cells("colSDRemaining").Value IsNot Nothing, row.Cells("colSDRemaining").Value.ToString(), "")
        Dim statusVal As String = If(row.Cells("colStatus").Value IsNot Nothing, row.Cells("colStatus").Value.ToString(), "")
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

        Dim details As String = $"Employee No: {empNo}" & vbCrLf &
                                $"Username: {usernameVal}" & vbCrLf &
                                $"Full Name: {nameVal}" & vbCrLf &
                                $"Position: {posVal}" & vbCrLf &
                                $"SD Remaining: {sdRem}" & vbCrLf &
                                $"Status: {statusVal}" & vbCrLf &
                                $"Deduction Status: {dedStatus}" & vbCrLf &
                                $"Period Start: {pStart}" & vbCrLf &
                                $"Period End: {pEnd}" & vbCrLf &
                                $"Created At: {createdAtVal}"
        MessageBox.Show(details, "Employee Details - " & empNo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim row As DataGridViewRow = GetSelectedSalaryRow()
        If row Is Nothing Then
            MessageBox.Show("Please select an employee to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim empNo As String = If(row.Cells("colEmpNo").Value IsNot Nothing, row.Cells("colEmpNo").Value.ToString(), "")
        Dim nameVal As String = If(row.Cells("colName").Value IsNot Nothing, row.Cells("colName").Value.ToString(), "")
        Dim confirm = MessageBox.Show($"Are you sure you want to delete employee {empNo} - {nameVal}?" & vbCrLf & "This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Exit Sub

        SalesTracker.DeleteEmployee(empNo)
        Try
            dgvTextBoxColumn.Rows.Remove(row)
        Catch
            LoadEmployees()
        End Try
        ApplySalaryFilter()
        MessageBox.Show("Employee deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
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




    Private Sub pnlReportsView_Paint(sender As Object, e As PaintEventArgs) Handles btnPrint.Paint

    End Sub
End Class