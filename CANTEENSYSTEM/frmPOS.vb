Imports System.Text
Imports System.Threading.Tasks
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class frmPOS

    ' Flicker-free child painting (product grid rebuilds + cart repaints).
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    ' PHASE 0: connection string lives in DbHelper (App.config). Do not hardcode here.

    Private activeCatButton As Button = Nothing
    Private currentCategoryKey As String = "ALL"
    Private Const SEARCH_PLACEHOLDER As String = "Search item name..."

    ' PHASE 4: kiosk order currently being processed (0 = walk-in sale).
    Private processingKioskOrderId As Integer = 0
    Private kioskOrderNumber As String = ""
    Private kioskOrderEmpNo As String = ""
    Private kioskOrderEmpName As String = ""
    Private kioskOrderEmpPosition As String = ""

#Region "Form Load & Search Placeholder Events"

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True ' smoothens cart/button repaints
        ExpandCartArea()
        LockPosCartGrid()
        Me.KeyPreview = True
        ConfigureProductButtons()
        dgvCart.Rows.Clear()
        UpdateGrandTotal()

        ' Setup Search Placeholder
        ResetSearchPlaceholder()

        SetActiveCategoryButton(btnCatAll)
        ApplyButtonHoverEffects()

        ' Initialize payment method state.
        ' Designer has BOTH radios Checked=True (last-wins = Salary default, a
        ' mis-charge risk). Enforce Cash default here — no Designer edit per convention.
        rdoCash.Checked = True
        rdoSalaryDeduction.Checked = False
        If rdoSalaryDeduction.Checked Then
            txtAmountPaid.Enabled = False
        Else
            txtAmountPaid.Enabled = True
        End If

        ' POS runs at its designed size, centered (REVERTED: maximizing left
        ' fixed-position inner controls bunched with empty voids).
        Me.StartPosition = FormStartPosition.CenterScreen

        ' PHASE 4: one-click entry to pending kiosk orders (also F6).
        ' (Designer-visible: btnPendingOrders lives in frmPOS.Designer.vb)
        If btnPendingOrders IsNot Nothing Then btnPendingOrders.BringToFront()
    End Sub

    Private Sub btnPendingOrders_Click(sender As Object, e As EventArgs) Handles btnPendingOrders.Click
        OpenPendingOrders()
    End Sub

    Private Sub OpenPendingOrders(sender As Object, e As EventArgs)
        OpenPendingOrders()
    End Sub

    Private Sub OpenPendingOrders()
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frmPendingOrders Then
                CType(f, frmPendingOrders).RefreshOrders()
                f.BringToFront()
                f.Focus()
                Exit Sub
            End If
        Next
        Dim pending As New frmPendingOrders()
        pending.Show()
    End Sub

    ' PHASE 4: receive a kiosk order for counter payment. Payment here
    ' completes the order atomically (see TransactionService.Checkout).
    Public Sub LoadKioskOrder(orderId As Integer, orderNumber As String, lines As List(Of TransactionService.CartLine), payMethod As String, empNumber As String)
        ClearKioskState()
        dgvCart.Rows.Clear()
        For Each ln In lines
            Dim idx As Integer = dgvCart.Rows.Add(ln.ProductName, ln.Quantity, ln.UnitPrice, ln.Subtotal, "❌")
            If idx >= 0 Then dgvCart.Rows(idx).Tag = ln.ProductId
        Next
        processingKioskOrderId = orderId
        kioskOrderNumber = If(orderNumber, "")
        kioskOrderEmpNo = If(empNumber, "")
        kioskOrderEmpName = ""
        kioskOrderEmpPosition = ""
        If Not String.IsNullOrWhiteSpace(kioskOrderEmpNo) Then
            Try
                Using conn As MySqlConnection = DbHelper.GetConnection()
                    conn.Open()
                    Using cmd As New MySqlCommand("SELECT full_name, position FROM employees WHERE employee_number=@e LIMIT 1", conn)
                        cmd.Parameters.AddWithValue("@e", kioskOrderEmpNo)
                        Using rdr As MySqlDataReader = cmd.ExecuteReader()
                            If rdr.Read() Then
                                kioskOrderEmpName = rdr("full_name").ToString()
                                kioskOrderEmpPosition = rdr("position").ToString()
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.WriteLine("LoadKioskOrder employee lookup failed: " & ex.Message)
            End Try
        End If
        If TransactionService.IsSalaryPayment(payMethod) Then
            rdoSalaryDeduction.Checked = True
        Else
            rdoCash.Checked = True
        End If
        UpdateGrandTotal()
        ' NOTE: no MessageBox here — the filled cart + KIOSK REF on the coming
        ' receipt are the confirmation (also keeps this automation-friendly).
    End Sub

    Private Sub ClearKioskState()
        processingKioskOrderId = 0
        kioskOrderNumber = ""
        kioskOrderEmpNo = ""
        kioskOrderEmpName = ""
        kioskOrderEmpPosition = ""
    End Sub

    ' Status snapshot for a kiosk-authenticated employee (skips re-auth at POS).
    ' Returns False when the employee row is missing (orphan kiosk identity) so the
    ' caller can block the salary charge instead of hitting the FK at commit time.
    Private Function EmployeeExistsInDb(empNumber As String) As Boolean
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM employees WHERE employee_number=@e", conn)
                    cmd.Parameters.AddWithValue("@e", empNumber)
                    Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("EmployeeExistsInDb failed: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub LoadKioskEmployeeBalance(empNumber As String, ByRef empStatus As String, ByRef deductionStatus As String)
        empStatus = "Active"
        deductionStatus = "PENDING"
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT status, deduction_status FROM employees WHERE employee_number=@e LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@e", empNumber)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        If rdr.Read() Then
                            If rdr("status") IsNot DBNull.Value Then empStatus = rdr("status").ToString()
                            If rdr("deduction_status") IsNot DBNull.Value Then deductionStatus = rdr("deduction_status").ToString().Trim().ToUpper()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("LoadKioskEmployeeBalance failed: " & ex.Message)
        End Try
    End Sub

    ' The summary grid clipped its columns at design width: grow the window
    ' rightward and hand ALL extra room to the cart side (Designer untouched).
    Private CartExtraWidth As Integer = 0

    Private Sub ExpandCartArea()
        Try
            Const dw As Integer = 120
            CartExtraWidth = dw
            Me.ClientSize = New Size(Me.ClientSize.Width + dw, Me.ClientSize.Height)
            If pnlHeader IsNot Nothing Then pnlHeader.Width = Me.ClientSize.Width
            If pnlCartContainer IsNot Nothing Then pnlCartContainer.Width += dw
            If dgvCart IsNot Nothing Then dgvCart.Width += dw
            If btnClose IsNot Nothing Then btnClose.Left += dw
            ' Center the fixed-width payment column in the widened cart panel.
            CenterCartControls()
            Me.CenterToScreen()
        Catch ex As Exception
            Debug.WriteLine("ExpandCartArea failed: " & ex.Message)
        End Try
    End Sub

    Private Sub CenterCartControls()
        Try
            If pnlCartContainer Is Nothing Then Exit Sub
            Dim centered As Control() = {GroupBox1, GroupBox2, Panel1, btnOpenPayment, btnCancelPayment, btnLogout, btnPendingOrders, lblCartHeader}
            For Each c As Control In centered
                If c IsNot Nothing Then c.Left = (pnlCartContainer.Width - c.Width) \ 2
            Next
        Catch ex As Exception
            Debug.WriteLine("CenterCartControls failed: " & ex.Message)
        End Try
    End Sub

    ' Cart cells are display-only: prices/qty change through code, never typing.
    Private Sub LockPosCartGrid()
        Try
            If dgvCart Is Nothing Then Exit Sub
            For Each c As DataGridViewColumn In dgvCart.Columns
                If TypeOf c Is DataGridViewTextBoxColumn Then c.ReadOnly = True
            Next
        Catch ex As Exception
            Debug.WriteLine("LockPosCartGrid failed: " & ex.Message)
        End Try
    End Sub

    ' PHASE 2: menu comes from the database (ProductCatalog). Anything added,
    ' edited, deactivated, or stocked-out in Inventory is reflected here.
    Private Sub ConfigureProductButtons()
        LoadDynamicProducts()
    End Sub

    Public Sub LoadDynamicProducts()
        flpProducts.SuspendLayout()
        ' Drop design-time placeholders (Designer-visible samples).
        For Each ph In flpProducts.Controls.OfType(Of Button)().Where(Function(b) CStr(b.Tag) = "PLACEHOLDER_DESIGNONLY").ToList()
            flpProducts.Controls.Remove(ph)
            ph.Dispose()
        Next
        ' Drop UserControl product cards (Phase C) on refresh.
        For Each uc In flpProducts.Controls.OfType(Of ucProductButton)().ToList()
            RemoveHandler uc.CardClicked, AddressOf DynamicProductCard_Click
            flpProducts.Controls.Remove(uc)
            uc.Dispose()
        Next
        ' Drop legacy static catalog buttons (Designer leftovers, if still present).
        For Each oldBtn In flpProducts.Controls.OfType(Of Button)().Where(Function(b) b.Name.StartsWith("btnProd")).ToList()
            RemoveHandler oldBtn.Click, AddressOf DynamicProductButton_Click
            flpProducts.Controls.Remove(oldBtn)
            oldBtn.Dispose()
        Next
        ' Drop previously generated buttons on refresh.
        For Each dyn In flpProducts.Controls.OfType(Of Button)().Where(Function(b) b.Name.StartsWith("dynProd_")).ToList()
            RemoveHandler dyn.Click, AddressOf DynamicProductButton_Click
            flpProducts.Controls.Remove(dyn)
            dyn.Dispose()
        Next

        For Each item In ProductCatalog.GetActiveProducts()
            Dim c As New ucProductButton()
            c.Bind(item)
            c.Size = New Size(100, 68)
            c.Margin = New Padding(4)
            c.Cursor = Cursors.Hand
            AddHandler c.CardClicked, AddressOf DynamicProductCard_Click
            flpProducts.Controls.Add(c)
        Next
        flpProducts.ResumeLayout(True)

        ApplyButtonHoverEffects()
        FilterProducts(currentCategoryKey, activeCatButton)
    End Sub

    Private Sub DynamicProductButton_Click(sender As Object, e As EventArgs)
        Dim b As Button = TryCast(sender, Button)
        Dim item As ProductCatalog.ProductItem = TryCast(If(b IsNot Nothing, b.Tag, Nothing), ProductCatalog.ProductItem)
        If item Is Nothing OrElse item.IsOutOfStock Then Exit Sub
        AddToCart(item.ProductId, item.ProductName, item.Price)
    End Sub

    ' Phase C: UserControl card click forwards the bound ProductItem.
    Private Sub DynamicProductCard_Click(sender As Object, e As EventArgs)
        Dim uc As ucProductButton = TryCast(sender, ucProductButton)
        If uc Is Nothing OrElse uc.BoundItem Is Nothing Then Exit Sub
        Dim item As ProductCatalog.ProductItem = uc.BoundItem
        If item.IsOutOfStock Then Exit Sub
        AddToCart(item.ProductId, item.ProductName, item.Price)
    End Sub

    Private Sub ResetSearchPlaceholder()
        txtSearch.Text = SEARCH_PLACEHOLDER
        txtSearch.ForeColor = Color.Gray
    End Sub

    ' Event: Automatic clear kapag pumasok sa Search Bar
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = SEARCH_PLACEHOLDER Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    ' Event: Automatic selection para diretso type kapag cliniclick
    Private Sub txtSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles txtSearch.MouseDown
        If txtSearch.Text = SEARCH_PLACEHOLDER Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    ' Event: Ibalik ang placeholder kapag nawalan ng focus at walang laman
    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            ResetSearchPlaceholder()
        End If
    End Sub

    Private Sub ApplyButtonHoverEffects()
        For Each ctrl As Control In flpProducts.Controls
            If TypeOf ctrl Is Button OrElse TypeOf ctrl Is ucProductButton Then
                ctrl.Cursor = Cursors.Hand
            End If
        Next
    End Sub

    Private Sub SetActiveCategoryButton(clickedBtn As Button)
        If activeCatButton IsNot Nothing Then
            activeCatButton.BackColor = Color.FromArgb(10, 25, 47)
            activeCatButton.ForeColor = Color.White
        End If

        activeCatButton = clickedBtn
        If activeCatButton IsNot Nothing Then
            activeCatButton.BackColor = Color.FromArgb(245, 194, 27)
            activeCatButton.ForeColor = Color.Black
        End If
    End Sub

#End Region

#Region "Soft Audio System"

    Private Sub PlaySoftSound(soundType As String)
        Task.Run(Sub()
                     Try
                         Select Case soundType.ToLower()
                             Case "add"
                                 Console.Beep(1800, 25)
                             Case "delete"
                                 Console.Beep(600, 35)
                             Case "error"
                                 Console.Beep(450, 50)
                             Case "success"
                                 Console.Beep(1200, 30)
                                 Threading.Thread.Sleep(30)
                                 Console.Beep(1600, 40)
                         End Select
                     Catch
                     End Try
                 End Sub)
    End Sub

#End Region

#Region "Keyboard Shortcuts"

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                txtSearch.Clear()
                ResetSearchPlaceholder()
                btnCatAll.Focus()
                Return True
            Case Keys.F1
                btnCatAll.PerformClick()
                Return True
            Case Keys.F2
                btnCatMeals.PerformClick()
                Return True
            Case Keys.F3
                btnCatSnacks.PerformClick()
                Return True
            Case Keys.F4
                btnCatDrinks.PerformClick()
                Return True
            Case Keys.F5
                btnOpenPayment.PerformClick()
                Return True
            Case Keys.F6
                OpenPendingOrders()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region "Category Filtering & Real-Time Search Logic"

    Private Sub FilterProducts(categoryTag As String, clickedBtn As Button)
        SetActiveCategoryButton(clickedBtn)
        currentCategoryKey = If(String.IsNullOrWhiteSpace(categoryTag), "ALL", categoryTag)

        flpProducts.SuspendLayout()
        For Each ctrl As Control In flpProducts.Controls
            Dim uc As ucProductButton = TryCast(ctrl, ucProductButton)
            If uc IsNot Nothing Then
                If uc.BoundItem IsNot Nothing Then uc.Visible = ProductCatalog.MatchesCategory(uc.BoundItem.CategoryName, currentCategoryKey)
                Continue For
            End If
            Dim b As Button = TryCast(ctrl, Button)
            If b Is Nothing Then Continue For
            Dim item As ProductCatalog.ProductItem = TryCast(b.Tag, ProductCatalog.ProductItem)
            If item Is Nothing Then Continue For ' skip non-product buttons
            b.Visible = ProductCatalog.MatchesCategory(item.CategoryName, currentCategoryKey)
        Next
        flpProducts.ResumeLayout()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Huwag mag-filter kung nakatapat pa ang placeholder text
        If txtSearch.Text = SEARCH_PLACEHOLDER Then Exit Sub

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        flpProducts.SuspendLayout()
        For Each ctrl As Control In flpProducts.Controls
            Dim uc As ucProductButton = TryCast(ctrl, ucProductButton)
            If uc IsNot Nothing Then
                If uc.BoundItem IsNot Nothing Then
                    Dim m2 As Boolean = String.IsNullOrEmpty(searchText) OrElse uc.BoundItem.ProductName.ToLower().Contains(searchText)
                    uc.Visible = m2 AndAlso ProductCatalog.MatchesCategory(uc.BoundItem.CategoryName, currentCategoryKey)
                End If
                Continue For
            End If
            Dim b As Button = TryCast(ctrl, Button)
            If b Is Nothing Then Continue For
            Dim item As ProductCatalog.ProductItem = TryCast(b.Tag, ProductCatalog.ProductItem)
            If item Is Nothing Then Continue For
            Dim matchesSearch As Boolean = String.IsNullOrEmpty(searchText) OrElse item.ProductName.ToLower().Contains(searchText)
            b.Visible = matchesSearch AndAlso ProductCatalog.MatchesCategory(item.CategoryName, currentCategoryKey)
        Next
        flpProducts.ResumeLayout()
    End Sub

    Private Sub btnCatAll_Click(sender As Object, e As EventArgs) Handles btnCatAll.Click
        FilterProducts("ALL", CType(sender, Button))
    End Sub

    Private Sub btnCatMeals_Click(sender As Object, e As EventArgs) Handles btnCatMeals.Click
        FilterProducts("MEALS", CType(sender, Button))
    End Sub

    Private Sub btnCatSnacks_Click(sender As Object, e As EventArgs) Handles btnCatSnacks.Click
        FilterProducts("SNACKS", CType(sender, Button))
    End Sub

    Private Sub btnCatDrinks_Click(sender As Object, e As EventArgs) Handles btnCatDrinks.Click
        FilterProducts("DRINKS", CType(sender, Button))
    End Sub

    Private Sub btnCatDesserts_Click(sender As Object, e As EventArgs) Handles btnCatDesserts.Click
        FilterProducts("DESSERTS", CType(sender, Button))
    End Sub

    Private Sub btnCatInstant_Click(sender As Object, e As EventArgs) Handles btnCatInstant.Click
        FilterProducts("INSTANT", CType(sender, Button))
    End Sub

#End Region

#Region "Cart Core Operations & Visual Highlight"

    ' PHASE 2: product_id travels with each cart row (row.Tag) for Phase 3 checkout.
    Private Sub AddToCart(itemName As String, price As Decimal)
        AddToCart(0, itemName, price)
    End Sub

    Private Sub AddToCart(productId As Integer, itemName As String, price As Decimal)
        Dim itemFound As Boolean = False
        Dim targetRowIndex As Integer = -1

        PlaySoftSound("add")

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colItem").Value IsNot Nothing AndAlso row.Cells("colItem").Value.ToString() = itemName Then
                Dim currentQty As Integer = Convert.ToInt32(row.Cells("colQty").Value)
                Dim newQty As Integer = currentQty + 1
                Dim newSubtotal As Decimal = newQty * price

                row.Cells("colQty").Value = newQty
                row.Cells("colSubtotal").Value = newSubtotal
                itemFound = True
                targetRowIndex = row.Index
                Exit For
            End If
        Next

        If Not itemFound Then
            targetRowIndex = dgvCart.Rows.Add(itemName, 1, price, price, "❌")
            If targetRowIndex >= 0 Then dgvCart.Rows(targetRowIndex).Tag = productId
        End If

        If targetRowIndex >= 0 Then
            dgvCart.ClearSelection()
            dgvCart.Rows(targetRowIndex).Selected = True
        End If

        UpdateGrandTotal()
    End Sub

    Private Sub UpdateGrandTotal()
        Dim grandTotal As Decimal = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colSubtotal").Value IsNot Nothing Then
                grandTotal += Convert.ToDecimal(row.Cells("colSubtotal").Value)
            End If
        Next

        lblGrandTotal.Text = "₱" & grandTotal.ToString("N2")
        ComputeChange()
    End Sub

    Private Sub ComputeChange()
        Dim grandTotal As Decimal = 0
        Dim amountPaid As Decimal = 0

        If Decimal.TryParse(lblGrandTotal.Text.Replace("₱", "").Replace(",", ""), grandTotal) = False Then
            grandTotal = 0
        End If

        If Decimal.TryParse(txtAmountPaid.Text.Trim(), amountPaid) = False Then
            amountPaid = 0
        End If

        If amountPaid < grandTotal Then
            lblChange.Text = "₱0.00"
        Else
            lblChange.Text = "₱" & (amountPaid - grandTotal).ToString("N2")
        End If
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        ComputeChange()
    End Sub



    Private Sub dgvCart_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvCart.Columns(e.ColumnIndex).Name = "colDelete" Then
            PlaySoftSound("delete")
            dgvCart.Rows.RemoveAt(e.RowIndex)
            UpdateGrandTotal()
        End If
    End Sub



#End Region

#Region "Product Button Clicks (PHASE 2: dynamic — see LoadDynamicProducts)"

    ' Legacy static handlers removed. Product buttons are generated at runtime
    ' from ProductCatalog.GetActiveProducts() and share DynamicProductButton_Click.

#End Region

#Region "Payment Method Selection"

    Private Sub rdoSalaryDeduction_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSalaryDeduction.CheckedChanged
        If rdoSalaryDeduction.Checked Then
            txtAmountPaid.Enabled = False
            txtAmountPaid.Text = ""
            ComputeChange()
        End If
    End Sub

    Private Sub rdoCash_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCash.CheckedChanged
        If rdoCash.Checked Then
            txtAmountPaid.Enabled = True
            txtAmountPaid.Focus()
        End If
    End Sub

#End Region

#Region "Payment & Secured Salary Deduction Logic"

    Private Sub btnOpenPayment_Click(sender As Object, e As EventArgs) Handles btnOpenPayment.Click
        If dgvCart.Rows.Count = 0 Then
            PlaySoftSound("error")
            MessageBox.Show("No selected product.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim paymentMethod As String = ""
        Dim empID As String = ""
        Dim empName As String = ""
        Dim empPosition As String = ""
        Dim empNo As String = ""
        Dim empStatus As String = "Active"
        Dim deductionStatus As String = "PENDING" ' Default to PENDING
        Dim signupUsername As String = ""
        Dim isNewEmployee As Boolean = False

        ' Calculate grand total once
        Dim grandTotal As Decimal = 0
        Decimal.TryParse(lblGrandTotal.Text.Replace("₱", "").Replace(",", ""), grandTotal)

        If rdoSalaryDeduction.Checked Then
            paymentMethod = "Salary Deduction"

            ' PHASE 4: kiosk orders arrive with the employee already authenticated
            ' at the kiosk — reuse that identity instead of asking again.
            If processingKioskOrderId > 0 AndAlso Not String.IsNullOrWhiteSpace(kioskOrderEmpNo) Then
                empNo = kioskOrderEmpNo
                empName = kioskOrderEmpName
                empPosition = kioskOrderEmpPosition
                LoadKioskEmployeeBalance(empNo, empStatus, deductionStatus)
                empID = empNo & " - " & empName
                isNewEmployee = False
            Else

            ' Step 1: Ask if new employee
            Dim isNewResult As DialogResult = MessageBox.Show("Are you a new employee for salary deduction?", "New Employee?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If isNewResult = DialogResult.Yes Then
                ' Show Sign Up Form
                Dim signupForm As New frmEmployeeSignUp()
                If signupForm.ShowDialog() = DialogResult.OK Then
                    empNo = signupForm.EmployeeNumber
                    signupUsername = signupForm.Username
                    empName = signupForm.FullName
                    empPosition = signupForm.Position

                    ' Set default values for new employee (schema enum: Active/Inactive).
                    empStatus = "Active"
                    deductionStatus = "PENDING"

                    empID = empNo & " - " & empName
                    isNewEmployee = True
                Else
                    PlaySoftSound("error")
                    MessageBox.Show("Registration cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                ' Existing employee - show login form
                Dim loginForm As New frmEmployeeLogin()
                If loginForm.ShowDialog() = DialogResult.OK AndAlso loginForm.IsValidLogin Then
                    empNo = loginForm.EmployeeNumber
                    empName = loginForm.EmployeeName
                    empPosition = loginForm.EmployeePosition
                    empStatus = loginForm.EmployeeStatus
                    deductionStatus = loginForm.EmployeeDeductionStatus
                    empID = empNo & " - " & empName
                    isNewEmployee = False
                Else
                    PlaySoftSound("error")
                    MessageBox.Show("Login cancelled or invalid credentials.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            End If ' end PHASE 4 kiosk-identity skip
        Else
            paymentMethod = "Cash"
        End If

        Dim amountPaid As Decimal = 0
        If paymentMethod.ToLower().Contains("cash") Then
            Decimal.TryParse(txtAmountPaid.Text.Trim(), amountPaid)
            If amountPaid < grandTotal Then
                PlaySoftSound("error")
                MessageBox.Show("Insufficient payment! Amount paid is less than the grand total.", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        ' ---- PHASE 3: build checkout lines (product_id from row.Tag) ----
        Dim lines As New List(Of TransactionService.CartLine)
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colItem").Value Is Nothing Then Continue For
            Dim pid As Integer = 0
            If row.Tag IsNot Nothing Then Integer.TryParse(row.Tag.ToString(), pid)
            If pid <= 0 Then pid = ResolveProductId(row.Cells("colItem").Value.ToString())
            Dim qty As Integer = 0
            Integer.TryParse(row.Cells("colQty").Value.ToString(), qty)
            Dim price As Decimal = 0
            Decimal.TryParse(row.Cells("colPrice").Value.ToString(), price)
            Dim cl As New TransactionService.CartLine With {
                .ProductId = pid,
                .ProductName = row.Cells("colItem").Value.ToString(),
                .Quantity = qty,
                .UnitPrice = price
            }
            lines.Add(cl)
        Next
        If lines.Count = 0 Then
            PlaySoftSound("error")
            MessageBox.Show("No selected product.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim stockCheck As TransactionService.CheckoutResult = TransactionService.ValidateStock(lines)
        If Not stockCheck.Success Then
            PlaySoftSound("error")
            MessageBox.Show(stockCheck.Message, "Cannot Complete Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' FIX (FK fk_deduction_employee): salary_deductions FKs to employees, so a
        ' NEW signup must be persisted BEFORE Checkout — never after. Checkout runs
        ' inside one MySqlTransaction and its salary INSERT fails when the parent
        ' employees row does not exist yet (the screenshot error). Persist here,
        ' verify the row exists, and only then commit the sale.
        If TransactionService.IsSalaryPayment(paymentMethod) AndAlso Not String.IsNullOrWhiteSpace(empNo) Then
            If isNewEmployee Then
                If String.IsNullOrWhiteSpace(signupUsername) Then signupUsername = empNo
                SalesTracker.AddEmployee(empNo, signupUsername, empName, empPosition, empStatus, deductionStatus)
                isNewEmployee = False ' now persisted; post-sale block must not re-insert
            End If
            If Not EmployeeExistsInDb(empNo) Then
                PlaySoftSound("error")
                MessageBox.Show($"Employee '{empNo}' was not found in the database, so the salary charge was blocked and nothing was saved.{vbCrLf}{vbCrLf}Re-register / re-login the employee and retry. Cash sales are unaffected.",
                                "Unknown Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.Equals(empStatus, "Inactive", StringComparison.OrdinalIgnoreCase) Then
                PlaySoftSound("error")
                MessageBox.Show($"Employee '{empNo}' is Inactive, so salary deduction is blocked and nothing was saved.",
                                "Inactive Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        Dim changeAmount As Decimal = 0
        If paymentMethod.ToLower().Contains("cash") Then changeAmount = amountPaid - grandTotal

        btnOpenPayment.Enabled = False ' double-click guard during commit
        ' PHASE 4: a kiosk order id completes atomically with the sale (0 = walk-in).
        Dim result As TransactionService.CheckoutResult = TransactionService.Checkout(lines, paymentMethod, amountPaid, changeAmount, empNo, processingKioskOrderId)
        btnOpenPayment.Enabled = True

        If Not result.Success Then
            PlaySoftSound("error")
            MessageBox.Show("Sale failed and was rolled back (nothing was saved):" & vbCrLf & vbCrLf & result.Message, "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' ---- Salary side-effects, only after a committed sale ----
        ' NOTE: new employees are persisted BEFORE Checkout (FK requirement), so this
        ' block only syncs the open Dashboard view — it must not re-insert.
        If TransactionService.IsSalaryPayment(paymentMethod) AndAlso Not String.IsNullOrWhiteSpace(empNo) Then
            If isNewEmployee Then
                If String.IsNullOrWhiteSpace(signupUsername) Then signupUsername = empNo
                ' Already saved pre-checkout; keep as safety net only if the row is missing.
                If Not EmployeeExistsInDb(empNo) Then
                    SalesTracker.AddEmployee(empNo, signupUsername, empName, empPosition, empStatus, deductionStatus)
                End If
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is frmDashboard Then
                        CType(f, frmDashboard).AddEmployee(empNo, signupUsername, empName, empPosition, empStatus, deductionStatus)
                        Exit For
                    End If
                Next
            Else
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is frmDashboard Then
                        CType(f, frmDashboard).LoadEmployees()
                        Exit For
                    End If
                Next
            End If
        End If

        Dim cashierName As String = ""
        Try
            cashierName = Session.CurrentUsername
        Catch
        End Try
        Dim receiptText As String = GenerateReceipt(paymentMethod, empID, empNo, empName, empPosition, empStatus, deductionStatus, amountPaid, result.TransactionNumber, cashierName, kioskOrderNumber)

        PlaySoftSound("success")
        MessageBox.Show(receiptText, "CANTEEN OFFICIAL RECEIPT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If MessageBox.Show("Print this receipt?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            PrintReceiptText(receiptText, result.TransactionNumber)
        End If

        Dim saleTotal As Decimal = 0
        Dim saleItems As Integer = 0
        For Each ln In lines
            saleTotal += ln.Subtotal
            saleItems += ln.Quantity
        Next
        SalesTracker.RecordSale(saleTotal, saleItems)

        ClearKioskState()
        dgvCart.Rows.Clear()
        UpdateGrandTotal()
        ResetSearchPlaceholder()
    End Sub

    ' Fallback for cart rows created before product_id tracking (row.Tag = 0).
    Private Function ResolveProductId(productName As String) As Integer
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT product_id FROM products WHERE product_name=@n AND status='Active' LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@n", productName)
                    Dim obj As Object = cmd.ExecuteScalar()
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then Return Convert.ToInt32(obj)
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("ResolveProductId failed: " & ex.Message)
        End Try
        Return 0
    End Function

    ' Masked PIN prompt — Designer-visible form (frmPinPrompt with btnOK/btnCancel).
    Private Function InputBoxMasked(Prompt As String, Title As String) As String
        Using d As New frmPinPrompt(Prompt, Title)
            If d.ShowDialog(Me) = DialogResult.OK Then
                Return d.PinText
            End If
            Return ""
        End Using
    End Function

    ' Redesigned Clean Receipt Function - Thermal Printer Style
    Private Function GenerateReceipt(paymentMethod As String, Optional empInfo As String = "", Optional empNo As String = "", Optional empName As String = "", Optional empPosition As String = "", Optional empStatus As String = "", Optional deductionStatus As String = "", Optional amountPaid As Decimal = 0, Optional transactionNumber As String = "", Optional cashierName As String = "", Optional kioskRef As String = "") As String
        Dim sb As New StringBuilder()
        Dim hasSalaryDeduction As Boolean = paymentMethod.ToLower().Contains("salary") OrElse paymentMethod.ToLower().Contains("deduction")
        Dim lineWidth As Integer = 40

        Dim singleLine As String = New String("-"c, lineWidth)
        Dim doubleLine As String = New String("="c, lineWidth)

        ' Receipt number = persisted DB transaction number (Phase 3); legacy fallback kept.
        Dim receiptNo As String = If(String.IsNullOrWhiteSpace(transactionNumber), "#" & DateTime.Now.ToString("yyyy-MMdd-HHmmss"), transactionNumber)

        ' Header
        sb.AppendLine(doubleLine)
        sb.AppendLine(CenterText("CANTEEN OFFICIAL RECEIPT", lineWidth))
        sb.AppendLine(doubleLine)
        sb.AppendLine(FormatReceiptLine("RECEIPT NO:", receiptNo))
        If Not String.IsNullOrWhiteSpace(kioskRef) Then sb.AppendLine(FormatReceiptLine("KIOSK REF:", kioskRef))
        sb.AppendLine(FormatReceiptLine("DATE/TIME:", DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")))
        If Not String.IsNullOrWhiteSpace(cashierName) Then sb.AppendLine(FormatReceiptLine("CASHIER:", cashierName))
        sb.AppendLine(FormatReceiptLine("PAYMENT:", paymentMethod))
        If Not String.IsNullOrEmpty(empInfo) Then sb.AppendLine(FormatReceiptLine("CHARGE TO:", empInfo))

        If hasSalaryDeduction Then
            If Not String.IsNullOrEmpty(empNo) Then sb.AppendLine(FormatReceiptLine("EMP NO:", empNo))
            If Not String.IsNullOrEmpty(empName) Then sb.AppendLine(FormatReceiptLine("NAME:", empName))
            If Not String.IsNullOrEmpty(empPosition) Then sb.AppendLine(FormatReceiptLine("POSITION:", empPosition))
            If Not String.IsNullOrEmpty(empStatus) Then sb.AppendLine(FormatReceiptLine("STATUS:", empStatus))
            If Not String.IsNullOrEmpty(deductionStatus) Then sb.AppendLine(FormatReceiptLine("DEDUCT:", deductionStatus))
        End If

        sb.AppendLine(singleLine)
        sb.AppendLine(FormatReceiptLine("ITEM", "QTY", "PRICE", "TOTAL"))
        sb.AppendLine(singleLine)

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colItem").Value IsNot Nothing Then
                Dim name As String = row.Cells("colItem").Value.ToString()
                Dim qty As Integer = Convert.ToInt32(row.Cells("colQty").Value)
                Dim price As Decimal = Convert.ToDecimal(row.Cells("colPrice").Value)
                Dim subtotal As Decimal = Convert.ToDecimal(row.Cells("colSubtotal").Value)

                ' Item name (may wrap)
                If name.Length > 22 Then
                    sb.AppendLine(name.Substring(0, 22))
                    name = name.Substring(22)
                    While name.Length > 0
                        If name.Length > 22 Then
                            sb.AppendLine(" " & name.Substring(0, 22))
                            name = name.Substring(22)
                        Else
                            sb.AppendLine(" " & name)
                            name = ""
                        End If
                    End While
                End If

                sb.AppendLine(FormatReceiptItem(name, qty, price, subtotal))
            End If
        Next

        sb.AppendLine(singleLine)
        sb.AppendLine(FormatReceiptAmount("TOTAL AMOUNT:", lblGrandTotal.Text))

        ' Cash tendered and change (only for cash payments)
        If paymentMethod.ToLower().Contains("cash") Then
            Dim grandTotal As Decimal
            Decimal.TryParse(lblGrandTotal.Text.Replace("₱", "").Replace(",", ""), grandTotal)
            Dim change As Decimal = amountPaid - grandTotal
            If change < 0 Then change = 0
            sb.AppendLine(FormatReceiptAmount("CASH TENDERED:", "₱ " & amountPaid.ToString("N2")))
            sb.AppendLine(FormatReceiptAmount("CHANGE:", "₱ " & change.ToString("N2")))
        End If

        sb.AppendLine(doubleLine)
        sb.AppendLine("")
        sb.AppendLine(CenterText("Thank you & Enjoy your meal!", lineWidth))
        sb.AppendLine(CenterText("Please keep this copy for reference", lineWidth))
        sb.AppendLine("")
        sb.AppendLine(doubleLine)

        Return sb.ToString()
    End Function

    Private Function FormatReceiptLine(label As String, value As String) As String
        Dim lineWidth As Integer = 40
        Dim labelPart As String = label
        Dim valuePart As String = value
        If (labelPart.Length + valuePart.Length) > (lineWidth - 1) Then
            Return labelPart & " " & valuePart
        End If
        Return labelPart.PadRight(lineWidth - valuePart.Length) & valuePart
    End Function

    Private Function FormatReceiptAmount(label As String, amount As String) As String
        Dim lineWidth As Integer = 40
        Dim labelPart As String = label
        Dim valuePart As String = amount
        Return labelPart.PadRight(lineWidth - valuePart.Length) & valuePart
    End Function

    Private Function FormatReceiptLine(label As String, val1 As String, val2 As String, val3 As String) As String
        Return label.PadRight(18) & val1.PadLeft(4) & val2.PadLeft(8) & val3.PadLeft(10)
    End Function

    Private Function FormatReceiptItem(name As String, qty As Integer, price As Decimal, subtotal As Decimal) As String
        Dim namePart As String = name.PadRight(18).Substring(0, Math.Min(18, name.Length))
        Dim qtyPart As String = qty.ToString().PadLeft(4)
        Dim pricePart As String = "₱ " & price.ToString("N2").PadLeft(7)
        Dim totalPart As String = "₱ " & subtotal.ToString("N2").PadLeft(9)
        Return namePart & qtyPart & pricePart & totalPart
    End Function

    Private Function CenterText(text As String, width As Integer) As String
        If text.Length >= width Then Return text
        Dim pad As Integer = (width - text.Length) \ 2
        Return New String(" "c, pad) & text
    End Function

    ' ---- PHASE 7: thermal-style receipt printing ----
    Private receiptLines As List(Of String)
    Private receiptLineIndex As Integer = 0
    Private WithEvents receiptDoc As PrintDocument

    Private Sub PrintReceiptText(receiptText As String, jobName As String)
        Try
            receiptLines = New List(Of String)(receiptText.Replace(vbCrLf, vbLf).Split(New Char() {ControlChars.Lf}))
            receiptLineIndex = 0
            receiptDoc = New PrintDocument()
            receiptDoc.DocumentName = If(String.IsNullOrWhiteSpace(jobName), "Canteen Receipt", jobName)
            Using dlg As New PrintDialog()
                dlg.Document = receiptDoc
                If dlg.ShowDialog() = DialogResult.OK Then
                    Try
                        receiptDoc.Print()
                    Catch ex As Exception
                        MessageBox.Show("Print failed: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Print failed: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub receiptDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles receiptDoc.PrintPage
        Dim f As New Font("Consolas", 9)
        Dim y As Single = e.MarginBounds.Top
        Dim lineH As Single = f.GetHeight(e.Graphics) + 2
        While receiptLineIndex < receiptLines.Count
            If y + lineH > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Exit Sub
            End If
            e.Graphics.DrawString(receiptLines(receiptLineIndex), f, Brushes.Black, e.MarginBounds.Left, y)
            y += lineH
            receiptLineIndex += 1
        End While
        e.HasMorePages = False
    End Sub

    Private Sub btnCancelPayment_Click(sender As Object, e As EventArgs) Handles btnCancelPayment.Click
        If dgvCart.Rows.Count = 0 Then
            PlaySoftSound("error")
            MessageBox.Show("No selected product.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to cancel this payment?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            ClearKioskState() ' a cleared kiosk cart must not attach to the next sale
            dgvCart.Rows.Clear()
            UpdateGrandTotal()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Try
            AuditLog.Log(Session.CurrentUserId, "Logout", $"{Session.CurrentUsername} logged out (POS)")
        Catch
        End Try
        Session.Clear()
        ClearKioskState()
        Navigator.ReturnToSystemSelect(Me)
    End Sub

    ' Header X button was unwired — it now exits to the front door like Logout.
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Button1_Click(sender, e)
    End Sub

#End Region

End Class