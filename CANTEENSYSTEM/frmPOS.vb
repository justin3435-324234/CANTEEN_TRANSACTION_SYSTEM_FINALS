Imports System.Text
Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient

Public Class frmPOS

    Private connectionString As String =
        "Server=localhost;Database=school_canteen_db;Uid=root;Pwd=;"

    Private activeCatButton As Button = Nothing
    Private Const SEARCH_PLACEHOLDER As String = "Search item name..."

#Region "Form Load & Search Placeholder Events"

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        ConfigureProductButtons()
        dgvCart.Rows.Clear()
        UpdateGrandTotal()

        ' Setup Search Placeholder
        ResetSearchPlaceholder()

        SetActiveCategoryButton(btnCatAll)
        ApplyButtonHoverEffects()

        ' Initialize payment method state
        If rdoSalaryDeduction.Checked Then
            txtAmountPaid.Enabled = False
        Else
            txtAmountPaid.Enabled = True
        End If
    End Sub

    Private Sub ConfigureProductButtons()
        btnProdAdobo.Text = "Chicken Adobo" & vbCrLf & "₱65.00"
        btnProdLongganisa.Text = "Longganisa" & vbCrLf & "₱45.00"
        btnProdSpam.Text = "Spam" & vbCrLf & "₱45.00"
        btnProdShanghai.Text = "Shanghai" & vbCrLf & "₱20.00"
        btnProdRice.Text = "Rice" & vbCrLf & "₱15.00"
        btnProdSiomaiBig.Text = "SIOMAI BIG " & vbCrLf & "₱10.00"
        btnProdSiomaiSmall.Text = "SIOMAI SMALL" & vbCrLf & "₱6.00"
        btnProdSiopao.Text = "SIOPAO" & vbCrLf & "₱25.00"
        btnProdTuron.Text = "Turon" & vbCrLf & "₱15.00"
        btnProdCorndog.Text = "Corndog" & vbTab & "₱25.00"
        btnProdMineralWater.Text = "MINERAL" & vbCrLf & "₱15.00"
        btnProdLiptonIceTea.Text = "LIPTON" & vbCrLf & "₱30.00"
        btnProdMilo.Text = "MILO" & vbCrLf & "₱18.00"
        btnProdKopiko.Text = "KOPIKO" & vbCrLf & "₱18.00"
        btnProdIcedCoffee.Text = "ICED KOPIKO" & vbCrLf & "₱26.00"
        btnProdIceCream.Text = "Ice Cream" & vbTab & vbCrLf & "₱20.00"
        btnProdFudgeeBar.Text = "Fudgee Bar" & vbCrLf & "₱12.00"
        btnProdDoweeDonut.Text = "Dowee Donut" & vbCrLf & "₱15.00"
        btnProdOreo.Text = "Oreo" & vbCrLf & "₱12.00"
        btnProdChocolateCake.Text = "Chocolate Cake" & vbTab & "₱25.00"
        btnProdNoodlesBulalo.Text = "Noodles Bulalo" & vbTab & "₱30.00"
        btnProdNoodlesSeafood.Text = "Noodles Seafood" & vbTab & "₱30.00"
        btnProdPancitCanton.Text = "Pancit Canton" & vbTab & "₱20.00"
        btnProdLuckyMeNoodles.Text = "LuckyNoodles" & vbTab & "₱18.00"
        btnProdLuckyMeCanton.Text = "Lucky Me Canton" & vbTab & "₱20.00"
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
            If TypeOf ctrl Is Button Then
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
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region "Category Filtering & Real-Time Search Logic"

    Private Sub FilterProducts(categoryTag As String, clickedBtn As Button)
        SetActiveCategoryButton(clickedBtn)

        flpProducts.SuspendLayout()
        For Each ctrl As Control In flpProducts.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name.StartsWith("btnProd") Then
                Dim btnTag As String = If(ctrl.Tag IsNot Nothing, ctrl.Tag.ToString().ToUpper(), "")
                Dim filterTag As String = categoryTag.ToUpper()

                If filterTag = "ALL" OrElse btnTag = filterTag OrElse (filterTag.StartsWith("DESSERT") AndAlso btnTag.StartsWith("DESSERT")) Then
                    ctrl.Visible = True
                Else
                    ctrl.Visible = False
                End If
            End If
        Next
        flpProducts.ResumeLayout()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Huwag mag-filter kung nakatapat pa ang placeholder text
        If txtSearch.Text = SEARCH_PLACEHOLDER Then Exit Sub

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        flpProducts.SuspendLayout()
        For Each ctrl As Control In flpProducts.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name.StartsWith("btnProd") Then
                If String.IsNullOrEmpty(searchText) OrElse ctrl.Text.ToLower().Contains(searchText) Then
                    ctrl.Visible = True
                Else
                    ctrl.Visible = False
                End If
            End If
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

    Private Sub AddToCart(itemName As String, price As Decimal)
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

#Region "Product Button Clicks"

    ' --- MEALS / ULAM ---
    Private Sub btnProdAdobo_Click(sender As Object, e As EventArgs) Handles btnProdAdobo.Click
        AddToCart("Adobo", 65.0)
    End Sub

    Private Sub btnProdLongganisa_Click(sender As Object, e As EventArgs) Handles btnProdLongganisa.Click
        AddToCart("Longganisa", 45.0)
    End Sub

    Private Sub btnProdSpam_Click(sender As Object, e As EventArgs) Handles btnProdSpam.Click
        AddToCart("Spam", 45.0)
    End Sub

    Private Sub btnProdShanghai_Click(sender As Object, e As EventArgs) Handles btnProdShanghai.Click
        AddToCart("Shanghai", 20.0)
    End Sub

    Private Sub btnProdRice_Click(sender As Object, e As EventArgs) Handles btnProdRice.Click
        AddToCart("Rice", 15.0)
    End Sub

    ' --- SNACKS ---
    Private Sub btnProdSiomaiBig_Click(sender As Object, e As EventArgs) Handles btnProdSiomaiBig.Click
        AddToCart("Siomai Big", 10.0)
    End Sub

    Private Sub btnProdSiomaiSmall_Click(sender As Object, e As EventArgs) Handles btnProdSiomaiSmall.Click
        AddToCart("Siomai Small", 6.0)
    End Sub

    Private Sub btnProdSiopao_Click(sender As Object, e As EventArgs) Handles btnProdSiopao.Click
        AddToCart("Siopao", 25.0)
    End Sub

    Private Sub btnProdTuron_Click(sender As Object, e As EventArgs) Handles btnProdTuron.Click
        AddToCart("Turon", 15.0)
    End Sub

    Private Sub btnProdCorndog_Click(sender As Object, e As EventArgs) Handles btnProdCorndog.Click
        AddToCart("Corndog", 25.0)
    End Sub

    ' --- DRINKS ---
    Private Sub btnProdMineralWater_Click(sender As Object, e As EventArgs) Handles btnProdMineralWater.Click
        AddToCart("Mineral Water", 15.0)
    End Sub

    Private Sub btnProdLiptonIceTea_Click(sender As Object, e As EventArgs) Handles btnProdLiptonIceTea.Click
        AddToCart("Lipton Ice Tea", 30.0)
    End Sub

    Private Sub btnProdMilo_Click(sender As Object, e As EventArgs) Handles btnProdMilo.Click
        AddToCart("Milo", 18.0)
    End Sub

    Private Sub btnProdKopiko_Click(sender As Object, e As EventArgs) Handles btnProdKopiko.Click
        AddToCart("Kopiko", 18.0)
    End Sub

    Private Sub btnProdIcedCoffee_Click(sender As Object, e As EventArgs) Handles btnProdIcedCoffee.Click
        AddToCart("Iced Kopiko", 26.0)
    End Sub

    ' --- DESSERTS ---
    Private Sub btnProdIceCream_Click(sender As Object, e As EventArgs) Handles btnProdIceCream.Click
        AddToCart("Ice Cream", 20.0)
    End Sub

    Private Sub btnProdFudgeeBar_Click(sender As Object, e As EventArgs) Handles btnProdFudgeeBar.Click
        AddToCart("Fudgee Bar", 12.0)
    End Sub

    Private Sub btnProdDoweeDonut_Click(sender As Object, e As EventArgs) Handles btnProdDoweeDonut.Click
        AddToCart("Dowee Donut", 15.0)
    End Sub

    Private Sub btnProdOreo_Click(sender As Object, e As EventArgs) Handles btnProdOreo.Click
        AddToCart("Oreo", 12.0)
    End Sub

    Private Sub btnProdChocolateCake_Click(sender As Object, e As EventArgs) Handles btnProdChocolateCake.Click
        AddToCart("Chocolate Cake", 25.0)
    End Sub

    ' --- INSTANT FOOD ---
    Private Sub btnProdNoodlesBulalo_Click(sender As Object, e As EventArgs) Handles btnProdNoodlesBulalo.Click
        AddToCart("Cup Noodles Bulalo", 30.0)
    End Sub

    Private Sub btnProdNoodlesSeafood_Click(sender As Object, e As EventArgs) Handles btnProdNoodlesSeafood.Click
        AddToCart("Cup Noodles Seafood", 30.0)
    End Sub

    Private Sub btnProdPancitCanton_Click(sender As Object, e As EventArgs) Handles btnProdPancitCanton.Click
        AddToCart("Pancit Canton", 20.0)
    End Sub

    Private Sub btnProdLuckyMeNoodles_Click(sender As Object, e As EventArgs) Handles btnProdLuckyMeNoodles.Click
        AddToCart("Lucky Me Noodles", 18.0)
    End Sub

    Private Sub btnProdLuckyMeCanton_Click(sender As Object, e As EventArgs) Handles btnProdLuckyMeCanton.Click
        AddToCart("Lucky Me Pancit Canton", 25.0)
    End Sub

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
        Dim sdRemaining As Decimal = 2500
        Dim empStatus As String = "Available"
        Dim deductionStatus As String = "PENDING" ' Default to PENDING
        Dim signupUsername As String = ""

        ' Calculate grand total once
        Dim grandTotal As Decimal = 0
        Decimal.TryParse(lblGrandTotal.Text.Replace("₱", "").Replace(",", ""), grandTotal)

        If rdoSalaryDeduction.Checked Then
            paymentMethod = "Salary Deduction"

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
                    Try
                        System.IO.File.AppendAllText("C:\Users\Justin\Desktop\CANTEEN_TRANSACTION_MANAGEMENT_SYSTEM\debug_signup.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} POS after dialog empNo='{empNo}' signupUsername='{signupUsername}' UsernameProp='{signupForm.Username}' EmpNoProp='{signupForm.EmployeeNumber}'" & vbCrLf)
                    Catch
                    End Try

                    ' Set default values for new employee
                    sdRemaining = 2500
                    empStatus = "Available"
                    deductionStatus = "Active"

                    empID = empNo & " - " & empName
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
                    sdRemaining = loginForm.EmployeeSDRemaining
                    empStatus = loginForm.EmployeeStatus
                    deductionStatus = loginForm.EmployeeDeductionStatus
                    empID = empNo & " - " & empName
                Else
                    PlaySoftSound("error")
                    MessageBox.Show("Login cancelled or invalid credentials.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            ' Deduct grand total from SD Remaining for salary deduction
            sdRemaining = sdRemaining - grandTotal
            If sdRemaining < 0 Then sdRemaining = 0

            ' Add new employee to persistent storage (if new employee signup)
            If isNewResult = DialogResult.Yes AndAlso Not String.IsNullOrWhiteSpace(empNo) Then
                Try
                    System.IO.File.AppendAllText("C:\Users\Justin\Desktop\CANTEEN_TRANSACTION_MANAGEMENT_SYSTEM\debug_signup.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} POS before AddEmployee empNo='{empNo}' signupUsername='{signupUsername}' empName='{empName}'" & vbCrLf)
                Catch
                End Try
                If String.IsNullOrWhiteSpace(signupUsername) Then signupUsername = empNo
                SalesTracker.AddEmployee(empNo, signupUsername, empName, empPosition, sdRemaining, empStatus, deductionStatus)

                ' Also add to open Dashboard if available
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is frmDashboard Then
                        CType(f, frmDashboard).AddEmployee(empNo, signupUsername, empName, empPosition, sdRemaining, empStatus, deductionStatus)
                        Exit For
                    End If
                Next
            Else
                ' Update existing employee's SD Remaining
                For Each emp As SalesTracker.Employee In SalesTracker.Employees
                    If emp.EmpNo = empNo Then
                        emp.SDRemaining = sdRemaining
                        Exit For
                    End If
                Next
                SalesTracker.UpdateSDRemaining(empNo, sdRemaining)
                ' Update Dashboard if open
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is frmDashboard Then
                        CType(f, frmDashboard).LoadEmployees()
                        Exit For
                    End If
                Next
            End If
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

        Dim receiptText As String = GenerateReceipt(paymentMethod, empID, empNo, empName, empPosition, sdRemaining, empStatus, deductionStatus, amountPaid)

        PlaySoftSound("success")
        MessageBox.Show(receiptText, "CANTEEN OFFICIAL RECEIPT", MessageBoxButtons.OK, MessageBoxIcon.Information)

        UpdateProductStock()

        Dim saleTotal As Decimal = 0
        Dim saleItems As Integer = 0
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colItem").Value IsNot Nothing Then
                saleTotal += Convert.ToDecimal(row.Cells("colSubtotal").Value)
                saleItems += Convert.ToInt32(row.Cells("colQty").Value)
            End If
        Next
        SalesTracker.RecordSale(saleTotal, saleItems)

        dgvCart.Rows.Clear()
        UpdateGrandTotal()
        ResetSearchPlaceholder()
    End Sub

    Private Sub UpdateProductStock()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                For Each row As DataGridViewRow In dgvCart.Rows
                    If row.Cells("colItem").Value IsNot Nothing Then
                        Dim itemName As String = row.Cells("colItem").Value.ToString()
                        Dim qty As Integer = Convert.ToInt32(row.Cells("colQty").Value)

                        Dim query As String =
                            "UPDATE products SET stock_quantity = stock_quantity - @qty " &
                            "WHERE product_name = @name"

                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@qty", qty)
                            cmd.Parameters.AddWithValue("@name", itemName)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to update product stock: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Custom Function para sa InputBox na masked ang character ('*') para sa PIN Security
    Private Function InputBoxMasked(Prompt As String, Title As String) As String
        Dim inputForm As New Form()
        Dim lblPrompt As New Label()
        Dim txtPin As New TextBox()
        Dim btnOK As New Button()
        Dim btnCancel As New Button()

        inputForm.Text = Title
        inputForm.Size = New Size(320, 160)
        inputForm.StartPosition = FormStartPosition.CenterParent
        inputForm.FormBorderStyle = FormBorderStyle.FixedDialog
        inputForm.MaximizeBox = False
        inputForm.MinimizeBox = False

        lblPrompt.Text = Prompt
        lblPrompt.SetBounds(15, 12, 280, 20)

        txtPin.SetBounds(15, 35, 275, 25)
        txtPin.PasswordChar = "*"c ' Masking characters
        txtPin.MaxLength = 4

        btnOK.Text = "OK"
        btnOK.DialogResult = DialogResult.OK
        btnOK.SetBounds(130, 75, 75, 30)

        btnCancel.Text = "Cancel"
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.SetBounds(215, 75, 75, 30)

        inputForm.Controls.AddRange(New Control() {lblPrompt, txtPin, btnOK, btnCancel})
        inputForm.AcceptButton = btnOK
        inputForm.CancelButton = btnCancel

        If inputForm.ShowDialog() = DialogResult.OK Then
            Return txtPin.Text.Trim()
        Else
            Return ""
        End If
    End Function

    ' Redesigned Clean Receipt Function - Thermal Printer Style
    Private Function GenerateReceipt(paymentMethod As String, Optional empInfo As String = "", Optional empNo As String = "", Optional empName As String = "", Optional empPosition As String = "", Optional sdRemaining As Decimal = 0, Optional empStatus As String = "", Optional deductionStatus As String = "", Optional amountPaid As Decimal = 0) As String
        Dim sb As New StringBuilder()
        Dim hasSalaryDeduction As Boolean = paymentMethod.ToLower().Contains("salary") OrElse paymentMethod.ToLower().Contains("deduction")
        Dim lineWidth As Integer = 40

        Dim singleLine As String = New String("-"c, lineWidth)
        Dim doubleLine As String = New String("="c, lineWidth)

        ' Generate receipt number
        Dim receiptNo As String = "#" & DateTime.Now.ToString("yyyy-MMdd-HHmmss")

        ' Header
        sb.AppendLine(doubleLine)
        sb.AppendLine(CenterText("CANTEEN OFFICIAL RECEIPT", lineWidth))
        sb.AppendLine(doubleLine)
        sb.AppendLine(FormatReceiptLine("DATE/TIME:", DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")))
        sb.AppendLine(FormatReceiptLine("PAYMENT:", paymentMethod))
        If Not String.IsNullOrEmpty(empInfo) Then sb.AppendLine(FormatReceiptLine("CHARGE TO:", empInfo))

        If hasSalaryDeduction Then
            If Not String.IsNullOrEmpty(empNo) Then sb.AppendLine(FormatReceiptLine("EMP NO:", empNo))
            If Not String.IsNullOrEmpty(empName) Then sb.AppendLine(FormatReceiptLine("NAME:", empName))
            If Not String.IsNullOrEmpty(empPosition) Then sb.AppendLine(FormatReceiptLine("POSITION:", empPosition))
            If sdRemaining > 0 Then sb.AppendLine(FormatReceiptLine("SD REMAIN:", "₱ " & sdRemaining.ToString("N2")))
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

    Private Sub btnCancelPayment_Click(sender As Object, e As EventArgs) Handles btnCancelPayment.Click
        If dgvCart.Rows.Count = 0 Then
            PlaySoftSound("error")
            MessageBox.Show("No selected product.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to cancel this payment?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            dgvCart.Rows.Clear()
            UpdateGrandTotal()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        frmLogin.Show()
    End Sub

#End Region

End Class