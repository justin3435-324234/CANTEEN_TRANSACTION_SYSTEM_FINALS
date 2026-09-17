Imports MySql.Data.MySqlClient

Public Class frmKiosk

    ' Flicker-free child painting (panel switching + dynamic buttons).
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    ' PHASE 2: menu comes from the database (ProductCatalog). Cart + panel
    ' navigation implemented here; order persistence (kiosk_orders) lands in Phase 4.
    Private orderType As String = "DineIn"
    Private kioskCategoryKey As String = "ALL"

    Private Sub frmKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True ' smoothens panel switching
        LockCartGrid()
        dgvCart.Rows.Clear()
        UpdateKioskTotals()
        ' Designer-visible: btnKioskStaffExit/btnKioskProceed/
        ' btnKioskEditItem/btnKioskReturn all live in frmKiosk.Designer.vb.
        EnsureKioskDesignerButtons()
        ShowKioskPanel(pnlWelcome)
    End Sub

    ' Designer buttons: just ensure z-order on their parents.
    Private Sub EnsureKioskDesignerButtons()
        Try
            If btnKioskStaffExit IsNot Nothing Then btnKioskStaffExit.BringToFront()
            If btnKioskProceed IsNot Nothing Then btnKioskProceed.BringToFront()
            If btnKioskReturn IsNot Nothing Then btnKioskReturn.BringToFront()
        Catch ex As Exception
            Debug.WriteLine("EnsureKioskDesignerButtons failed: " & ex.Message)
        End Try
    End Sub

    ' Kept as no-op shims for compatibility.
    Private Sub AddReturnButton()
        EnsureKioskDesignerButtons()
    End Sub

    Private Sub btnKioskReturn_Click(sender As Object, e As EventArgs) Handles btnKioskReturn.Click
        Navigator.ReturnToSystemSelect(Me)
    End Sub

    ' Prices/qty/subtotal must only change through code — free typing here
    ' once let customers invent their own prices.
    Private Sub LockCartGrid()
        Try
            If dgvCart Is Nothing Then Exit Sub
            For Each c As DataGridViewColumn In dgvCart.Columns
                If TypeOf c Is DataGridViewTextBoxColumn Then c.ReadOnly = True
            Next
        Catch ex As Exception
            Debug.WriteLine("LockCartGrid failed: " & ex.Message)
        End Try
    End Sub

    ' Customer is done with the slip: PROCEED hands the terminal to the
    ' next customer via the front door (cart is already cleared on save).
    ' (Designer-visible: btnKioskProceed lives in the designer.)
    Private Sub AddProceedButton()
        EnsureKioskDesignerButtons()
    End Sub

    ' PROCEED hands the terminal to the NEXT CUSTOMER: back to the welcome
    ' screen, staying inside the kiosk loop (staff exit is the corner button).
    Private Sub btnKioskProceed_Click(sender As Object, e As EventArgs) Handles btnKioskProceed.Click
        If dgvCart IsNot Nothing AndAlso dgvCart.Rows.Count > 0 Then
            If MessageBox.Show("Leave without placing this order? The cart will be cleared.", "Proceed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub
            ClearKioskCart()
        End If
        kioskCategoryKey = "ALL"
        ShowKioskPanel(pnlWelcome)
    End Sub

    ' EDIT ITEM sits between ADD MORE and PLACE ORDER.
    ' (Designer-visible: btnKioskEditItem lives in the designer.)
    Private Sub AddEditItemButton()
        EnsureKioskDesignerButtons()
    End Sub

    Private Sub btnKioskEditItem_Click(sender As Object, e As EventArgs) Handles btnKioskEditItem.Click
        Dim row As DataGridViewRow = Nothing
        If dgvCart.SelectedRows.Count > 0 Then row = dgvCart.SelectedRows(0)
        If row Is Nothing AndAlso dgvCart.CurrentRow IsNot Nothing AndAlso Not dgvCart.CurrentRow.IsNewRow Then row = dgvCart.CurrentRow
        If row Is Nothing Then
            MessageBox.Show("Select an item in your order first.", "Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim itemName As String = If(row.Cells("colItem").Value IsNot Nothing, row.Cells("colItem").Value.ToString(), "")
        Dim price As Decimal = 0
        Decimal.TryParse(If(row.Cells("colPrice").Value IsNot Nothing, row.Cells("colPrice").Value.ToString(), ""), price)
        Dim qty As Integer = 0
        Integer.TryParse(If(row.Cells("colQty").Value IsNot Nothing, row.Cells("colQty").Value.ToString(), ""), qty)
        If qty <= 0 Then qty = 1
        Dim pid As Integer = 0
        If row.Tag IsNot Nothing Then Integer.TryParse(row.Tag.ToString(), pid)

        Dim picked As Integer? = EditKioskItemDialog(itemName, price, qty, GetLiveStock(pid, qty))
        If Not picked.HasValue Then Exit Sub ' cancelled
        If picked.Value <= 0 Then
            dgvCart.Rows.Remove(row)
        Else
            row.Cells("colQty").Value = picked.Value
            row.Cells("colSubtotal").Value = picked.Value * price
        End If
        UpdateKioskTotals()
    End Sub

    Private Function GetLiveStock(productId As Integer, fallback As Integer) As Integer
        If productId <= 0 Then Return Math.Max(fallback, 99)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT stock_quantity FROM products WHERE product_id=@id LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@id", productId)
                    Dim obj As Object = cmd.ExecuteScalar()
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then Return Convert.ToInt32(obj)
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("GetLiveStock failed: " & ex.Message)
        End Try
        Return Math.Max(fallback, 99)
    End Function

    ' Returns Nothing = cancel, 0 = remove item, N = new quantity.
    ' Plus is capped at live stock so the cart can never exceed supply.
    ' (Designer-visible: frmEditKioskItem with btnMinus/Plus/Save/Remove/Cancel.)
    Private Function EditKioskItemDialog(itemName As String, unitPrice As Decimal, curQty As Integer, maxQty As Integer) As Integer?
        Using dlg As New frmEditKioskItem(itemName, unitPrice, curQty, maxQty)
            If dlg.ShowDialog(Me) = DialogResult.Cancel Then Return Nothing
            Return dlg.ResultQty
        End Using
    End Function

    ' Unobtrusive staff exit (corner of the form, visible on every panel).
    ' Closing (not hiding) guarantees the next customer starts with a clean cart.
    ' (Designer-visible: btnKioskStaffExit lives in the designer.)
    Private Sub AddStaffExitButton()
        EnsureKioskDesignerButtons()
    End Sub

    Private Sub btnKioskStaffExit_Click(sender As Object, e As EventArgs) Handles btnKioskStaffExit.Click
        If dgvCart IsNot Nothing AndAlso dgvCart.Rows.Count > 0 Then
            If MessageBox.Show("Exit kiosk mode and clear the current order?", "Staff Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub
        End If
        Navigator.ReturnToSystemSelect(Me)
    End Sub

    Private Sub ShowKioskPanel(active As Panel)
        For Each p As Panel In {pnlWelcome, pnlOrderType, pnlMenu, pnlCart, pnlPayment, pnlQueue}
            If p IsNot Nothing Then p.Visible = (p Is active)
        Next
        If active IsNot Nothing Then active.BringToFront()
    End Sub

#Region "Order-type & menu navigation"

    Private Sub btnStartOrder_Click(sender As Object, e As EventArgs) Handles btnStartOrder.Click
        ShowKioskPanel(pnlOrderType)
    End Sub

    Private Sub btnDineIn_Click(sender As Object, e As EventArgs) Handles btnDineIn.Click
        orderType = "DineIn"
        EnterMenu()
    End Sub

    Private Sub btnTakeOut_Click(sender As Object, e As EventArgs) Handles btnTakeOut.Click
        orderType = "TakeOut"
        EnterMenu()
    End Sub

    Private Sub EnterMenu()
        kioskCategoryKey = "ALL"
        LoadKioskProducts()
        ShowKioskPanel(pnlMenu)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

#End Region

#Region "Dynamic menu (PHASE 2)"

    Private Sub LoadKioskProducts()
        flpProducts.SuspendLayout()
        ' Drop design-time placeholders (Designer-visible samples).
        For Each ph In flpProducts.Controls.OfType(Of Button)().Where(Function(b) CStr(b.Tag) = "PLACEHOLDER_DESIGNONLY").ToList()
            flpProducts.Controls.Remove(ph)
            ph.Dispose()
        Next
        ' Drop UserControl product cards (Phase C) on refresh.
        For Each uc In flpProducts.Controls.OfType(Of ucProductButton)().ToList()
            RemoveHandler uc.CardClicked, AddressOf KioskProductCard_Click
            flpProducts.Controls.Remove(uc)
            uc.Dispose()
        Next
        For Each dyn In flpProducts.Controls.OfType(Of Button)().Where(Function(b) b.Name.StartsWith("dynProd_")).ToList()
            RemoveHandler dyn.Click, AddressOf KioskProductButton_Click
            flpProducts.Controls.Remove(dyn)
            dyn.Dispose()
        Next

        For Each item In ProductCatalog.GetActiveProducts()
            Dim c As New ucProductButton()
            c.Bind(item)
            c.Size = New Size(100, 60)
            c.Margin = New Padding(4)
            c.Cursor = Cursors.Hand
            AddHandler c.CardClicked, AddressOf KioskProductCard_Click
            flpProducts.Controls.Add(c)
        Next
        flpProducts.ResumeLayout(True)

        ApplyKioskCategoryFilter()
    End Sub

    Private Sub KioskProductButton_Click(sender As Object, e As EventArgs)
        Dim b As Button = TryCast(sender, Button)
        Dim item As ProductCatalog.ProductItem = TryCast(If(b IsNot Nothing, b.Tag, Nothing), ProductCatalog.ProductItem)
        If item Is Nothing OrElse item.IsOutOfStock Then Exit Sub
        AddToKioskCart(item.ProductId, item.ProductName, item.Price)
    End Sub

    ' Phase C: UserControl card click forwards the bound ProductItem.
    Private Sub KioskProductCard_Click(sender As Object, e As EventArgs)
        Dim uc As ucProductButton = TryCast(sender, ucProductButton)
        If uc Is Nothing OrElse uc.BoundItem Is Nothing Then Exit Sub
        Dim item As ProductCatalog.ProductItem = uc.BoundItem
        If item.IsOutOfStock Then Exit Sub
        AddToKioskCart(item.ProductId, item.ProductName, item.Price)
    End Sub

    Private Sub ApplyKioskCategoryFilter()
        flpProducts.SuspendLayout()
        For Each ctrl As Control In flpProducts.Controls
            Dim uc As ucProductButton = TryCast(ctrl, ucProductButton)
            If uc IsNot Nothing Then
                If uc.BoundItem IsNot Nothing Then uc.Visible = ProductCatalog.MatchesCategory(uc.BoundItem.CategoryName, kioskCategoryKey)
                Continue For
            End If
            Dim b As Button = TryCast(ctrl, Button)
            If b Is Nothing Then Continue For
            Dim item As ProductCatalog.ProductItem = TryCast(b.Tag, ProductCatalog.ProductItem)
            If item Is Nothing Then Continue For
            b.Visible = ProductCatalog.MatchesCategory(item.CategoryName, kioskCategoryKey)
        Next
        flpProducts.ResumeLayout()
    End Sub

    Private Sub KioskCategory_Click(key As String)
        kioskCategoryKey = key
        ApplyKioskCategoryFilter()
    End Sub

    Private Sub btnAllItems_Click(sender As Object, e As EventArgs) Handles btnAllItems.Click
        KioskCategory_Click("ALL")
    End Sub

    Private Sub btnMeals_Click(sender As Object, e As EventArgs) Handles btnMeals.Click
        KioskCategory_Click("Meals")
    End Sub

    Private Sub btnSnacks_Click(sender As Object, e As EventArgs) Handles btnSnacks.Click
        KioskCategory_Click("Snacks")
    End Sub

    Private Sub btnDrinks_Click(sender As Object, e As EventArgs) Handles btnDrinks.Click
        KioskCategory_Click("Drinks")
    End Sub

    Private Sub btnDesserts_Click(sender As Object, e As EventArgs) Handles btnDesserts.Click
        KioskCategory_Click("Desserts")
    End Sub

    Private Sub btnInstant_Click(sender As Object, e As EventArgs) Handles btnInstant.Click
        KioskCategory_Click("Instant")
    End Sub

#End Region

#Region "Kiosk cart"

    Private Sub AddToKioskCart(productId As Integer, itemName As String, price As Decimal)
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colItem").Value IsNot Nothing AndAlso row.Cells("colItem").Value.ToString() = itemName Then
                Dim qty As Integer = Convert.ToInt32(row.Cells("colQty").Value) + 1
                row.Cells("colQty").Value = qty
                row.Cells("colSubtotal").Value = qty * price
                UpdateKioskTotals()
                Exit Sub
            End If
        Next
        Dim idx As Integer = dgvCart.Rows.Add(itemName, 1, price, price, "❌")
        If idx >= 0 Then dgvCart.Rows(idx).Tag = productId
        UpdateKioskTotals()
    End Sub

    Private Function KioskGrandTotal() As Decimal
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colSubtotal").Value IsNot Nothing Then
                total += Convert.ToDecimal(row.Cells("colSubtotal").Value)
            End If
        Next
        Return total
    End Function

    Private Sub UpdateKioskTotals()
        Dim total As Decimal = KioskGrandTotal()
        If lblCartTotal IsNot Nothing Then lblCartTotal.Text = "TOTAL: ₱" & total.ToString("N2")
        If lblPaymentTotal IsNot Nothing Then lblPaymentTotal.Text = "₱" & total.ToString("N2")
    End Sub

    Private Sub dgvCart_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvCart.Columns(e.ColumnIndex).Name = "colDelete" Then
            dgvCart.Rows.RemoveAt(e.RowIndex)
            UpdateKioskTotals()
        End If
    End Sub

    Private Sub ClearKioskCart()
        dgvCart.Rows.Clear()
        UpdateKioskTotals()
    End Sub

#End Region

#Region "Cart → payment → queue navigation (persistence in Phase 4)"

    Private Sub btnViewOrder_Click(sender As Object, e As EventArgs) Handles btnViewOrder.Click
        UpdateKioskTotals()
        ShowKioskPanel(pnlCart)
    End Sub

    Private Sub btnAddMore_Click(sender As Object, e As EventArgs) Handles btnAddMore.Click
        ShowKioskPanel(pnlMenu)
    End Sub

    Private Sub btnStartOver_Click(sender As Object, e As EventArgs) Handles btnStartOver.Click
        ClearKioskCart()
        ShowKioskPanel(pnlWelcome)
    End Sub

    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("Your order is empty. Please add items first.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        UpdateKioskTotals()
        ShowKioskPanel(pnlPayment)
    End Sub

    Private Sub btnPaymentBack_Click(sender As Object, e As EventArgs) Handles btnPaymentBack.Click
        ShowKioskPanel(pnlCart)
    End Sub

    Private Sub btnPaymentCancel_Click(sender As Object, e As EventArgs) Handles btnPaymentCancel.Click
        ClearKioskCart()
        ShowKioskPanel(pnlWelcome)
    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        PersistKioskOrder("Cash", "")
    End Sub

    Private Sub btnSalaryDeduction_Click(sender As Object, e As EventArgs) Handles btnSalaryDeduction.Click
        ' Same as POS: new employees register first, existing ones log in.
        Dim isNew As DialogResult = MessageBox.Show("Are you a new employee for salary deduction?", "New Employee?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If isNew = DialogResult.Cancel Then Exit Sub
        If isNew = DialogResult.Yes Then
            Dim signup As New frmEmployeeSignUp()
            If signup.ShowDialog() = DialogResult.OK Then
                ' The salary row at POS completion FKs to employees, so the
                ' new record must exist now (order save is the commit point).
                SalesTracker.AddEmployee(signup.EmployeeNumber, If(String.IsNullOrWhiteSpace(signup.Username), signup.EmployeeNumber, signup.Username), signup.FullName, signup.Position, "Active", "PENDING")
                PersistKioskOrder("Salary Deduction", signup.EmployeeNumber)
            Else
                MessageBox.Show("Registration cancelled. Order was not placed.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Dim login As New frmEmployeeLogin()
            If login.ShowDialog() = DialogResult.OK AndAlso login.IsValidLogin Then
                PersistKioskOrder("Salary Deduction", login.EmployeeNumber)
            Else
                MessageBox.Show("Employee login cancelled. Order was not placed.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    ' PHASE 4: the order is saved the moment a payment method is chosen.
    Private Sub PersistKioskOrder(paymentMethod As String, employeeNumber As String)
        Dim lines As List(Of TransactionService.CartLine) = BuildKioskLines()
        If lines.Count = 0 Then
            MessageBox.Show("Your order is empty.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ShowKioskPanel(pnlMenu)
            Exit Sub
        End If

        btnCash.Enabled = False
        btnSalaryDeduction.Enabled = False
        Dim res As TransactionService.KioskOrderResult = TransactionService.SaveKioskOrder(lines, orderType, paymentMethod, employeeNumber)
        btnCash.Enabled = True
        btnSalaryDeduction.Enabled = True

        If Not res.Success Then
            MessageBox.Show("Order could not be saved (nothing was recorded):" & vbCrLf & vbCrLf & res.Message, "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ShowQueueSlip(paymentMethod, res.OrderNumber)
        ClearKioskCart()
    End Sub

    Private Function BuildKioskLines() As List(Of TransactionService.CartLine)
        Dim lines As New List(Of TransactionService.CartLine)
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colItem").Value Is Nothing Then Continue For
            Dim pid As Integer = 0
            If row.Tag IsNot Nothing Then Integer.TryParse(row.Tag.ToString(), pid)
            Dim qty As Integer = 0
            Integer.TryParse(row.Cells("colQty").Value.ToString(), qty)
            Dim price As Decimal = 0
            Decimal.TryParse(row.Cells("colPrice").Value.ToString(), price)
            If pid <= 0 OrElse qty <= 0 Then Continue For
            Dim cl As New TransactionService.CartLine With {
                .ProductId = pid,
                .ProductName = row.Cells("colItem").Value.ToString(),
                .Quantity = qty,
                .UnitPrice = price
            }
            lines.Add(cl)
        Next
        Return lines
    End Function

    Private Sub ShowQueueSlip(paymentMethod As String, orderNumber As String)
        Dim total As Decimal = KioskGrandTotal()
        If lblQueueNumber IsNot Nothing Then lblQueueNumber.Text = orderNumber
        If lblQueuePayment IsNot Nothing Then lblQueuePayment.Text = "PAYMENT: " & paymentMethod
        If lblQueueTotal IsNot Nothing Then lblQueueTotal.Text = "TOTAL: ₱" & total.ToString("N2")
        ArrangeQueueSlip()
        ShowKioskPanel(pnlQueue)
    End Sub

    ' Real order numbers (K-YYYYMMDD-###) are far wider than the designed
    ' "A-023" sample: shrink-to-fit + center every slip line in the card.
    Private Sub ArrangeQueueSlip()
        Try
            If Panel4 Is Nothing Then Exit Sub
            Dim maxW As Integer = Panel4.Width - 40
            If lblQueueNumber IsNot Nothing Then
                Dim size As Single = lblQueueNumber.Font.Size
                While size > 12
                    Dim w As Integer = TextRenderer.MeasureText(lblQueueNumber.Text, New Font(lblQueueNumber.Font.FontFamily, size, FontStyle.Bold)).Width
                    If w <= maxW Then Exit While
                    size -= 2
                End While
                lblQueueNumber.Font = New Font(lblQueueNumber.Font.FontFamily, size, FontStyle.Bold)
                CenterInCard(lblQueueNumber)
            End If
            If lblQueuePayment IsNot Nothing Then CenterInCard(lblQueuePayment)
            If lblQueueTotal IsNot Nothing Then CenterInCard(lblQueueTotal)
            If lblQueueMessage IsNot Nothing Then CenterInCard(lblQueueMessage)
        Catch ex As Exception
            Debug.WriteLine("ArrangeQueueSlip failed: " & ex.Message)
        End Try
    End Sub

    Private Sub CenterInCard(lbl As Label)
        If lbl Is Nothing OrElse Panel4 Is Nothing Then Exit Sub
        lbl.Left = Math.Max(0, (Panel4.Width - lbl.Width) \ 2)
    End Sub

#End Region
End Class
