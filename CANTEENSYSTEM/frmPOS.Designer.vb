<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnPendingOrders = New System.Windows.Forms.Button()
        Me.pnlCartContainer = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.btnCancelPayment = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoSalaryDeduction = New System.Windows.Forms.RadioButton()
        Me.rdoCash = New System.Windows.Forms.RadioButton()
        Me.btnOpenPayment = New System.Windows.Forms.Button()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblCartHeader = New System.Windows.Forms.Label()
        Me.pnlProductsContainer = New System.Windows.Forms.Panel()
        Me.flpProducts = New System.Windows.Forms.FlowLayoutPanel()
        Me.ucPhPOS1 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS2 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS3 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS4 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS5 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS6 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS7 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS8 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS9 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS10 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS11 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS12 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS13 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS14 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS15 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS16 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS17 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS18 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS19 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS20 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS21 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS22 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS23 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS24 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhPOS25 = New CANTEENSYSTEM.ucProductButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCatAll = New System.Windows.Forms.Button()
        Me.btnCatDrinks = New System.Windows.Forms.Button()
        Me.btnCatSnacks = New System.Windows.Forms.Button()
        Me.btnCatDesserts = New System.Windows.Forms.Button()
        Me.btnCatInstant = New System.Windows.Forms.Button()
        Me.btnCatMeals = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102 = New System.Windows.Forms.Panel()
        Me.pnlHeader.SuspendLayout()
        Me.pnlCartContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProductsContainer.SuspendLayout()
        Me.flpProducts.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1149, 46)
        Me.pnlHeader.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(963, 7)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 28)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(37, 11)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "CANTEEN POS TERMINAL"
        '
        'btnPendingOrders
        '
        Me.btnPendingOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPendingOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnPendingOrders.FlatAppearance.BorderSize = 0
        Me.btnPendingOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingOrders.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendingOrders.ForeColor = System.Drawing.Color.Black
        Me.btnPendingOrders.Location = New System.Drawing.Point(29, 565)
        Me.btnPendingOrders.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPendingOrders.Name = "btnPendingOrders"
        Me.btnPendingOrders.Size = New System.Drawing.Size(343, 35)
        Me.btnPendingOrders.TabIndex = 5
        Me.btnPendingOrders.Text = "⏳ PENDING ORDERS"
        Me.btnPendingOrders.UseVisualStyleBackColor = False
        '
        'pnlCartContainer
        '
        Me.pnlCartContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pnlCartContainer.Controls.Add(Me.btnPendingOrders)
        Me.pnlCartContainer.Controls.Add(Me.btnLogout)
        Me.pnlCartContainer.Controls.Add(Me.Panel1)
        Me.pnlCartContainer.Controls.Add(Me.btnCancelPayment)
        Me.pnlCartContainer.Controls.Add(Me.GroupBox2)
        Me.pnlCartContainer.Controls.Add(Me.GroupBox1)
        Me.pnlCartContainer.Controls.Add(Me.btnOpenPayment)
        Me.pnlCartContainer.Controls.Add(Me.dgvCart)
        Me.pnlCartContainer.Controls.Add(Me.lblCartHeader)
        Me.pnlCartContainer.Location = New System.Drawing.Point(731, 46)
        Me.pnlCartContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCartContainer.Name = "pnlCartContainer"
        Me.pnlCartContainer.Size = New System.Drawing.Size(414, 755)
        Me.pnlCartContainer.TabIndex = 2
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.Firebrick
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed
        Me.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(29, 692)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(343, 36)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblChange)
        Me.Panel1.Controls.Add(Me.txtAmountPaid)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblAmount)
        Me.Panel1.Location = New System.Drawing.Point(29, 375)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(343, 174)
        Me.Panel1.TabIndex = 6
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.ForeColor = System.Drawing.Color.Gold
        Me.lblChange.Location = New System.Drawing.Point(115, 105)
        Me.lblChange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(96, 41)
        Me.lblChange.TabIndex = 3
        Me.lblChange.Text = "₱0.00"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountPaid.Location = New System.Drawing.Point(149, 38)
        Me.txtAmountPaid.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.Size = New System.Drawing.Size(171, 29)
        Me.txtAmountPaid.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(31, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Change:"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.White
        Me.lblAmount.Location = New System.Drawing.Point(19, 42)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(121, 23)
        Me.lblAmount.TabIndex = 0
        Me.lblAmount.Text = "Amount paid:"
        '
        'btnCancelPayment
        '
        Me.btnCancelPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnCancelPayment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelPayment.FlatAppearance.BorderSize = 0
        Me.btnCancelPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnCancelPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancelPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelPayment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelPayment.Location = New System.Drawing.Point(29, 648)
        Me.btnCancelPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelPayment.Name = "btnCancelPayment"
        Me.btnCancelPayment.Size = New System.Drawing.Size(343, 38)
        Me.btnCancelPayment.TabIndex = 5
        Me.btnCancelPayment.Text = "CANCEL PAYMENT"
        Me.btnCancelPayment.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblGrandTotal)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(29, 282)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(343, 86)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GRAND TOTAL"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblGrandTotal.Location = New System.Drawing.Point(109, 25)
        Me.lblGrandTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(111, 46)
        Me.lblGrandTotal.TabIndex = 0
        Me.lblGrandTotal.Text = "₱0.00"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoSalaryDeduction)
        Me.GroupBox1.Controls.Add(Me.rdoCash)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(29, 203)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(343, 71)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PAYMENT METHOD"
        '
        'rdoSalaryDeduction
        '
        Me.rdoSalaryDeduction.AutoSize = True
        Me.rdoSalaryDeduction.Checked = True
        Me.rdoSalaryDeduction.Location = New System.Drawing.Point(141, 36)
        Me.rdoSalaryDeduction.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoSalaryDeduction.Name = "rdoSalaryDeduction"
        Me.rdoSalaryDeduction.Size = New System.Drawing.Size(175, 24)
        Me.rdoSalaryDeduction.TabIndex = 1
        Me.rdoSalaryDeduction.TabStop = True
        Me.rdoSalaryDeduction.Text = "💳 Salary Deduction"
        Me.rdoSalaryDeduction.UseVisualStyleBackColor = True
        '
        'rdoCash
        '
        Me.rdoCash.AutoSize = True
        Me.rdoCash.Checked = True
        Me.rdoCash.Location = New System.Drawing.Point(35, 36)
        Me.rdoCash.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoCash.Name = "rdoCash"
        Me.rdoCash.Size = New System.Drawing.Size(89, 24)
        Me.rdoCash.TabIndex = 0
        Me.rdoCash.TabStop = True
        Me.rdoCash.Text = "💵 Cash"
        Me.rdoCash.UseVisualStyleBackColor = True
        '
        'btnOpenPayment
        '
        Me.btnOpenPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnOpenPayment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenPayment.FlatAppearance.BorderSize = 0
        Me.btnOpenPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnOpenPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnOpenPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenPayment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenPayment.Location = New System.Drawing.Point(29, 608)
        Me.btnOpenPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenPayment.Name = "btnOpenPayment"
        Me.btnOpenPayment.Size = New System.Drawing.Size(343, 37)
        Me.btnOpenPayment.TabIndex = 2
        Me.btnOpenPayment.Text = "PROCESS PAYMENT"
        Me.btnOpenPayment.UseVisualStyleBackColor = False
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colQty, Me.colPrice, Me.colSubtotal, Me.colDelete})
        Me.dgvCart.Location = New System.Drawing.Point(17, 33)
        Me.dgvCart.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersWidth = 51
        Me.dgvCart.Size = New System.Drawing.Size(355, 160)
        Me.dgvCart.TabIndex = 1
        '
        'colItem
        '
        Me.colItem.HeaderText = "Item Name"
        Me.colItem.MinimumWidth = 6
        Me.colItem.Name = "colItem"
        '
        'colQty
        '
        Me.colQty.HeaderText = "Qty"
        Me.colQty.MinimumWidth = 6
        Me.colQty.Name = "colQty"
        '
        'colPrice
        '
        Me.colPrice.HeaderText = "Price"
        Me.colPrice.MinimumWidth = 6
        Me.colPrice.Name = "colPrice"
        '
        'colSubtotal
        '
        Me.colSubtotal.HeaderText = "Subtotal"
        Me.colSubtotal.MinimumWidth = 6
        Me.colSubtotal.Name = "colSubtotal"
        '
        'colDelete
        '
        Me.colDelete.HeaderText = ""
        Me.colDelete.MinimumWidth = 6
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Text = "❌"
        Me.colDelete.UseColumnTextForButtonValue = True
        '
        'lblCartHeader
        '
        Me.lblCartHeader.AutoSize = True
        Me.lblCartHeader.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartHeader.ForeColor = System.Drawing.Color.White
        Me.lblCartHeader.Location = New System.Drawing.Point(72, 4)
        Me.lblCartHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCartHeader.Name = "lblCartHeader"
        Me.lblCartHeader.Size = New System.Drawing.Size(187, 28)
        Me.lblCartHeader.TabIndex = 0
        Me.lblCartHeader.Text = "ORDER SUMMARY"
        '
        'pnlProductsContainer
        '
        Me.pnlProductsContainer.Controls.Add(Me.flpProducts)
        Me.pnlProductsContainer.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlProductsContainer.Controls.Add(Me.txtSearch)
        Me.pnlProductsContainer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlProductsContainer.Location = New System.Drawing.Point(0, 46)
        Me.pnlProductsContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlProductsContainer.Name = "pnlProductsContainer"
        Me.pnlProductsContainer.Size = New System.Drawing.Size(723, 567)
        Me.pnlProductsContainer.TabIndex = 3
        '
        'flpProducts
        '
        Me.flpProducts.AutoScroll = True
        Me.flpProducts.Controls.Add(Me.ucPhPOS1)
        Me.flpProducts.Controls.Add(Me.ucPhPOS2)
        Me.flpProducts.Controls.Add(Me.ucPhPOS3)
        Me.flpProducts.Controls.Add(Me.ucPhPOS4)
        Me.flpProducts.Controls.Add(Me.ucPhPOS5)
        Me.flpProducts.Controls.Add(Me.ucPhPOS6)
        Me.flpProducts.Controls.Add(Me.ucPhPOS7)
        Me.flpProducts.Controls.Add(Me.ucPhPOS8)
        Me.flpProducts.Controls.Add(Me.ucPhPOS9)
        Me.flpProducts.Controls.Add(Me.ucPhPOS10)
        Me.flpProducts.Controls.Add(Me.ucPhPOS11)
        Me.flpProducts.Controls.Add(Me.ucPhPOS12)
        Me.flpProducts.Controls.Add(Me.ucPhPOS13)
        Me.flpProducts.Controls.Add(Me.ucPhPOS14)
        Me.flpProducts.Controls.Add(Me.ucPhPOS15)
        Me.flpProducts.Controls.Add(Me.ucPhPOS16)
        Me.flpProducts.Controls.Add(Me.ucPhPOS17)
        Me.flpProducts.Controls.Add(Me.ucPhPOS18)
        Me.flpProducts.Controls.Add(Me.ucPhPOS19)
        Me.flpProducts.Controls.Add(Me.ucPhPOS20)
        Me.flpProducts.Controls.Add(Me.ucPhPOS21)
        Me.flpProducts.Controls.Add(Me.ucPhPOS22)
        Me.flpProducts.Controls.Add(Me.ucPhPOS23)
        Me.flpProducts.Controls.Add(Me.ucPhPOS24)
        Me.flpProducts.Controls.Add(Me.ucPhPOS25)
        Me.flpProducts.Location = New System.Drawing.Point(19, 148)
        Me.flpProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.flpProducts.Name = "flpProducts"
        Me.flpProducts.Size = New System.Drawing.Size(692, 420)
        Me.flpProducts.TabIndex = 2
        '
        'ucPhPOS1
        '
        Me.ucPhPOS1.ItemName = ""
        Me.ucPhPOS1.Location = New System.Drawing.Point(4, 4)
        Me.ucPhPOS1.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS1.Name = "ucPhPOS1"
        Me.ucPhPOS1.PreviewEnabled = True
        Me.ucPhPOS1.PreviewText = "Adobo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱65.00"
        Me.ucPhPOS1.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS1.ProductId = 0
        Me.ucPhPOS1.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS1.Stock = 0
        Me.ucPhPOS1.TabIndex = 0
        Me.ucPhPOS1.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS2
        '
        Me.ucPhPOS2.ItemName = ""
        Me.ucPhPOS2.Location = New System.Drawing.Point(112, 4)
        Me.ucPhPOS2.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS2.Name = "ucPhPOS2"
        Me.ucPhPOS2.PreviewEnabled = True
        Me.ucPhPOS2.PreviewText = "Longganisa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱45.00"
        Me.ucPhPOS2.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS2.ProductId = 0
        Me.ucPhPOS2.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS2.Stock = 0
        Me.ucPhPOS2.TabIndex = 1
        Me.ucPhPOS2.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS3
        '
        Me.ucPhPOS3.ItemName = ""
        Me.ucPhPOS3.Location = New System.Drawing.Point(220, 4)
        Me.ucPhPOS3.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS3.Name = "ucPhPOS3"
        Me.ucPhPOS3.PreviewEnabled = True
        Me.ucPhPOS3.PreviewText = "Rice" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱15.00"
        Me.ucPhPOS3.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS3.ProductId = 0
        Me.ucPhPOS3.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS3.Stock = 0
        Me.ucPhPOS3.TabIndex = 2
        Me.ucPhPOS3.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS4
        '
        Me.ucPhPOS4.ItemName = ""
        Me.ucPhPOS4.Location = New System.Drawing.Point(328, 4)
        Me.ucPhPOS4.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS4.Name = "ucPhPOS4"
        Me.ucPhPOS4.PreviewEnabled = True
        Me.ucPhPOS4.PreviewText = "Spam" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱45.00"
        Me.ucPhPOS4.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS4.ProductId = 0
        Me.ucPhPOS4.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS4.Stock = 0
        Me.ucPhPOS4.TabIndex = 3
        Me.ucPhPOS4.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS5
        '
        Me.ucPhPOS5.ItemName = ""
        Me.ucPhPOS5.Location = New System.Drawing.Point(436, 4)
        Me.ucPhPOS5.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS5.Name = "ucPhPOS5"
        Me.ucPhPOS5.PreviewEnabled = True
        Me.ucPhPOS5.PreviewText = "Shanghai" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhPOS5.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS5.ProductId = 0
        Me.ucPhPOS5.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS5.Stock = 0
        Me.ucPhPOS5.TabIndex = 4
        Me.ucPhPOS5.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS6
        '
        Me.ucPhPOS6.ItemName = ""
        Me.ucPhPOS6.Location = New System.Drawing.Point(544, 4)
        Me.ucPhPOS6.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS6.Name = "ucPhPOS6"
        Me.ucPhPOS6.PreviewEnabled = True
        Me.ucPhPOS6.PreviewText = "Siomai Big" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱10.00"
        Me.ucPhPOS6.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS6.ProductId = 0
        Me.ucPhPOS6.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS6.Stock = 0
        Me.ucPhPOS6.TabIndex = 5
        Me.ucPhPOS6.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS7
        '
        Me.ucPhPOS7.ItemName = ""
        Me.ucPhPOS7.Location = New System.Drawing.Point(4, 80)
        Me.ucPhPOS7.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS7.Name = "ucPhPOS7"
        Me.ucPhPOS7.PreviewEnabled = True
        Me.ucPhPOS7.PreviewText = "Siomai Small" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱6.00"
        Me.ucPhPOS7.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS7.ProductId = 0
        Me.ucPhPOS7.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS7.Stock = 0
        Me.ucPhPOS7.TabIndex = 6
        Me.ucPhPOS7.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS8
        '
        Me.ucPhPOS8.ItemName = ""
        Me.ucPhPOS8.Location = New System.Drawing.Point(112, 80)
        Me.ucPhPOS8.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS8.Name = "ucPhPOS8"
        Me.ucPhPOS8.PreviewEnabled = True
        Me.ucPhPOS8.PreviewText = "Siopao" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱35.00"
        Me.ucPhPOS8.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS8.ProductId = 0
        Me.ucPhPOS8.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS8.Stock = 0
        Me.ucPhPOS8.TabIndex = 7
        Me.ucPhPOS8.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS9
        '
        Me.ucPhPOS9.ItemName = ""
        Me.ucPhPOS9.Location = New System.Drawing.Point(220, 80)
        Me.ucPhPOS9.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS9.Name = "ucPhPOS9"
        Me.ucPhPOS9.PreviewEnabled = True
        Me.ucPhPOS9.PreviewText = "Turon" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhPOS9.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS9.ProductId = 0
        Me.ucPhPOS9.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS9.Stock = 0
        Me.ucPhPOS9.TabIndex = 8
        Me.ucPhPOS9.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS10
        '
        Me.ucPhPOS10.ItemName = ""
        Me.ucPhPOS10.Location = New System.Drawing.Point(328, 80)
        Me.ucPhPOS10.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS10.Name = "ucPhPOS10"
        Me.ucPhPOS10.PreviewEnabled = True
        Me.ucPhPOS10.PreviewText = "Corndog" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱35.00"
        Me.ucPhPOS10.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS10.ProductId = 0
        Me.ucPhPOS10.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS10.Stock = 0
        Me.ucPhPOS10.TabIndex = 9
        Me.ucPhPOS10.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS11
        '
        Me.ucPhPOS11.ItemName = ""
        Me.ucPhPOS11.Location = New System.Drawing.Point(436, 80)
        Me.ucPhPOS11.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS11.Name = "ucPhPOS11"
        Me.ucPhPOS11.PreviewEnabled = True
        Me.ucPhPOS11.PreviewText = "Mineral Water" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱15.00"
        Me.ucPhPOS11.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS11.ProductId = 0
        Me.ucPhPOS11.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS11.Stock = 0
        Me.ucPhPOS11.TabIndex = 10
        Me.ucPhPOS11.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS12
        '
        Me.ucPhPOS12.ItemName = ""
        Me.ucPhPOS12.Location = New System.Drawing.Point(544, 80)
        Me.ucPhPOS12.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS12.Name = "ucPhPOS12"
        Me.ucPhPOS12.PreviewEnabled = True
        Me.ucPhPOS12.PreviewText = "Lipton Ice Tea" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱25.00"
        Me.ucPhPOS12.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS12.ProductId = 0
        Me.ucPhPOS12.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS12.Stock = 0
        Me.ucPhPOS12.TabIndex = 11
        Me.ucPhPOS12.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS13
        '
        Me.ucPhPOS13.ItemName = ""
        Me.ucPhPOS13.Location = New System.Drawing.Point(4, 156)
        Me.ucPhPOS13.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS13.Name = "ucPhPOS13"
        Me.ucPhPOS13.PreviewEnabled = True
        Me.ucPhPOS13.PreviewText = "Milo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱18.00"
        Me.ucPhPOS13.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS13.ProductId = 0
        Me.ucPhPOS13.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS13.Stock = 0
        Me.ucPhPOS13.TabIndex = 12
        Me.ucPhPOS13.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS14
        '
        Me.ucPhPOS14.ItemName = ""
        Me.ucPhPOS14.Location = New System.Drawing.Point(112, 156)
        Me.ucPhPOS14.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS14.Name = "ucPhPOS14"
        Me.ucPhPOS14.PreviewEnabled = True
        Me.ucPhPOS14.PreviewText = "Kopiko" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱18.00"
        Me.ucPhPOS14.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS14.ProductId = 0
        Me.ucPhPOS14.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS14.Stock = 0
        Me.ucPhPOS14.TabIndex = 13
        Me.ucPhPOS14.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS15
        '
        Me.ucPhPOS15.ItemName = ""
        Me.ucPhPOS15.Location = New System.Drawing.Point(220, 156)
        Me.ucPhPOS15.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS15.Name = "ucPhPOS15"
        Me.ucPhPOS15.PreviewEnabled = True
        Me.ucPhPOS15.PreviewText = "Iced Kopiko" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱26.00"
        Me.ucPhPOS15.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS15.ProductId = 0
        Me.ucPhPOS15.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS15.Stock = 0
        Me.ucPhPOS15.TabIndex = 14
        Me.ucPhPOS15.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS16
        '
        Me.ucPhPOS16.ItemName = ""
        Me.ucPhPOS16.Location = New System.Drawing.Point(328, 156)
        Me.ucPhPOS16.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS16.Name = "ucPhPOS16"
        Me.ucPhPOS16.PreviewEnabled = True
        Me.ucPhPOS16.PreviewText = "Ice Cream" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhPOS16.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS16.ProductId = 0
        Me.ucPhPOS16.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS16.Stock = 0
        Me.ucPhPOS16.TabIndex = 15
        Me.ucPhPOS16.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS17
        '
        Me.ucPhPOS17.ItemName = ""
        Me.ucPhPOS17.Location = New System.Drawing.Point(436, 156)
        Me.ucPhPOS17.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS17.Name = "ucPhPOS17"
        Me.ucPhPOS17.PreviewEnabled = True
        Me.ucPhPOS17.PreviewText = "Fudgee Bar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱12.00"
        Me.ucPhPOS17.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS17.ProductId = 0
        Me.ucPhPOS17.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS17.Stock = 0
        Me.ucPhPOS17.TabIndex = 16
        Me.ucPhPOS17.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS18
        '
        Me.ucPhPOS18.ItemName = ""
        Me.ucPhPOS18.Location = New System.Drawing.Point(544, 156)
        Me.ucPhPOS18.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS18.Name = "ucPhPOS18"
        Me.ucPhPOS18.PreviewEnabled = True
        Me.ucPhPOS18.PreviewText = "Dowee Donut" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhPOS18.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS18.ProductId = 0
        Me.ucPhPOS18.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS18.Stock = 0
        Me.ucPhPOS18.TabIndex = 17
        Me.ucPhPOS18.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS19
        '
        Me.ucPhPOS19.ItemName = ""
        Me.ucPhPOS19.Location = New System.Drawing.Point(4, 232)
        Me.ucPhPOS19.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS19.Name = "ucPhPOS19"
        Me.ucPhPOS19.PreviewEnabled = True
        Me.ucPhPOS19.PreviewText = "Oreo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱12.00"
        Me.ucPhPOS19.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS19.ProductId = 0
        Me.ucPhPOS19.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS19.Stock = 0
        Me.ucPhPOS19.TabIndex = 18
        Me.ucPhPOS19.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS20
        '
        Me.ucPhPOS20.ItemName = ""
        Me.ucPhPOS20.Location = New System.Drawing.Point(112, 232)
        Me.ucPhPOS20.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS20.Name = "ucPhPOS20"
        Me.ucPhPOS20.PreviewEnabled = True
        Me.ucPhPOS20.PreviewText = "Chocolate Cake" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱25.00"
        Me.ucPhPOS20.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS20.ProductId = 0
        Me.ucPhPOS20.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS20.Stock = 0
        Me.ucPhPOS20.TabIndex = 19
        Me.ucPhPOS20.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS21
        '
        Me.ucPhPOS21.ItemName = ""
        Me.ucPhPOS21.Location = New System.Drawing.Point(220, 232)
        Me.ucPhPOS21.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS21.Name = "ucPhPOS21"
        Me.ucPhPOS21.PreviewEnabled = True
        Me.ucPhPOS21.PreviewText = "Cup Noodles Bulalo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱30.00"
        Me.ucPhPOS21.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS21.ProductId = 0
        Me.ucPhPOS21.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS21.Stock = 0
        Me.ucPhPOS21.TabIndex = 20
        Me.ucPhPOS21.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS22
        '
        Me.ucPhPOS22.ItemName = ""
        Me.ucPhPOS22.Location = New System.Drawing.Point(328, 232)
        Me.ucPhPOS22.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS22.Name = "ucPhPOS22"
        Me.ucPhPOS22.PreviewEnabled = True
        Me.ucPhPOS22.PreviewText = "Cup Noodles Seafood" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱30.00"
        Me.ucPhPOS22.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS22.ProductId = 0
        Me.ucPhPOS22.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS22.Stock = 0
        Me.ucPhPOS22.TabIndex = 21
        Me.ucPhPOS22.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS23
        '
        Me.ucPhPOS23.ItemName = ""
        Me.ucPhPOS23.Location = New System.Drawing.Point(436, 232)
        Me.ucPhPOS23.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS23.Name = "ucPhPOS23"
        Me.ucPhPOS23.PreviewEnabled = True
        Me.ucPhPOS23.PreviewText = "Pancit Canton" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhPOS23.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS23.ProductId = 0
        Me.ucPhPOS23.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS23.Stock = 0
        Me.ucPhPOS23.TabIndex = 22
        Me.ucPhPOS23.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS24
        '
        Me.ucPhPOS24.ItemName = ""
        Me.ucPhPOS24.Location = New System.Drawing.Point(544, 232)
        Me.ucPhPOS24.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS24.Name = "ucPhPOS24"
        Me.ucPhPOS24.PreviewEnabled = True
        Me.ucPhPOS24.PreviewText = "Lucky Me Noodles" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱18.00"
        Me.ucPhPOS24.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS24.ProductId = 0
        Me.ucPhPOS24.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS24.Stock = 0
        Me.ucPhPOS24.TabIndex = 23
        Me.ucPhPOS24.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhPOS25
        '
        Me.ucPhPOS25.ItemName = ""
        Me.ucPhPOS25.Location = New System.Drawing.Point(4, 308)
        Me.ucPhPOS25.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhPOS25.Name = "ucPhPOS25"
        Me.ucPhPOS25.PreviewEnabled = True
        Me.ucPhPOS25.PreviewText = "Lucky Me Pancit Canton" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱25.00"
        Me.ucPhPOS25.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhPOS25.ProductId = 0
        Me.ucPhPOS25.Size = New System.Drawing.Size(100, 68)
        Me.ucPhPOS25.Stock = 0
        Me.ucPhPOS25.TabIndex = 24
        Me.ucPhPOS25.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCatAll)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCatDrinks)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCatSnacks)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCatDesserts)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCatInstant)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCatMeals)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(348, 22)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(384, 98)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btnCatAll
        '
        Me.btnCatAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnCatAll.FlatAppearance.BorderSize = 0
        Me.btnCatAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnCatAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCatAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatAll.Location = New System.Drawing.Point(4, 4)
        Me.btnCatAll.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCatAll.Name = "btnCatAll"
        Me.btnCatAll.Size = New System.Drawing.Size(117, 37)
        Me.btnCatAll.TabIndex = 2
        Me.btnCatAll.Text = "ALL ITEMS"
        Me.btnCatAll.UseVisualStyleBackColor = False
        '
        'btnCatDrinks
        '
        Me.btnCatDrinks.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatDrinks.FlatAppearance.BorderSize = 0
        Me.btnCatDrinks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatDrinks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCatDrinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatDrinks.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatDrinks.ForeColor = System.Drawing.Color.White
        Me.btnCatDrinks.Location = New System.Drawing.Point(129, 4)
        Me.btnCatDrinks.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCatDrinks.Name = "btnCatDrinks"
        Me.btnCatDrinks.Size = New System.Drawing.Size(132, 37)
        Me.btnCatDrinks.TabIndex = 6
        Me.btnCatDrinks.Text = "DRINKS"
        Me.btnCatDrinks.UseVisualStyleBackColor = False
        '
        'btnCatSnacks
        '
        Me.btnCatSnacks.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatSnacks.FlatAppearance.BorderSize = 0
        Me.btnCatSnacks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatSnacks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCatSnacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatSnacks.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatSnacks.ForeColor = System.Drawing.Color.White
        Me.btnCatSnacks.Location = New System.Drawing.Point(269, 4)
        Me.btnCatSnacks.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCatSnacks.Name = "btnCatSnacks"
        Me.btnCatSnacks.Size = New System.Drawing.Size(93, 39)
        Me.btnCatSnacks.TabIndex = 5
        Me.btnCatSnacks.Text = "SNACKS"
        Me.btnCatSnacks.UseVisualStyleBackColor = False
        '
        'btnCatDesserts
        '
        Me.btnCatDesserts.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatDesserts.FlatAppearance.BorderSize = 0
        Me.btnCatDesserts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatDesserts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCatDesserts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatDesserts.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatDesserts.ForeColor = System.Drawing.Color.White
        Me.btnCatDesserts.Location = New System.Drawing.Point(4, 51)
        Me.btnCatDesserts.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCatDesserts.Name = "btnCatDesserts"
        Me.btnCatDesserts.Size = New System.Drawing.Size(113, 37)
        Me.btnCatDesserts.TabIndex = 7
        Me.btnCatDesserts.Text = "DESSERTS"
        Me.btnCatDesserts.UseVisualStyleBackColor = False
        '
        'btnCatInstant
        '
        Me.btnCatInstant.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatInstant.FlatAppearance.BorderSize = 0
        Me.btnCatInstant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatInstant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCatInstant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatInstant.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatInstant.ForeColor = System.Drawing.Color.White
        Me.btnCatInstant.Location = New System.Drawing.Point(125, 51)
        Me.btnCatInstant.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCatInstant.Name = "btnCatInstant"
        Me.btnCatInstant.Size = New System.Drawing.Size(111, 37)
        Me.btnCatInstant.TabIndex = 8
        Me.btnCatInstant.Text = "INSTANT FOOD"
        Me.btnCatInstant.UseVisualStyleBackColor = False
        '
        'btnCatMeals
        '
        Me.btnCatMeals.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatMeals.FlatAppearance.BorderSize = 0
        Me.btnCatMeals.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnCatMeals.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCatMeals.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatMeals.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatMeals.ForeColor = System.Drawing.Color.White
        Me.btnCatMeals.Location = New System.Drawing.Point(244, 51)
        Me.btnCatMeals.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCatMeals.Name = "btnCatMeals"
        Me.btnCatMeals.Size = New System.Drawing.Size(116, 39)
        Me.btnCatMeals.TabIndex = 4
        Me.btnCatMeals.Text = "MEALS"
        Me.btnCatMeals.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(16, 22)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(295, 27)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.Text = "Search item name..."
        '
        'object_1ab29191_8921_45b5_8bec_8dbb7c11c102
        '
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.Location = New System.Drawing.Point(731, 46)
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.Margin = New System.Windows.Forms.Padding(4)
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.Name = "object_1ab29191_8921_45b5_8bec_8dbb7c11c102"
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.Size = New System.Drawing.Size(390, 755)
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.TabIndex = 2
        Me.object_1ab29191_8921_45b5_8bec_8dbb7c11c102.Visible = False
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1149, 807)
        Me.Controls.Add(Me.pnlProductsContainer)
        Me.Controls.Add(Me.pnlCartContainer)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPOS"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlCartContainer.ResumeLayout(False)
        Me.pnlCartContainer.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProductsContainer.ResumeLayout(False)
        Me.pnlProductsContainer.PerformLayout()
        Me.flpProducts.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlCartContainer As Panel
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents lblCartHeader As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPendingOrders As Button
    Friend WithEvents btnOpenPayment As Button
    Friend WithEvents pnlProductsContainer As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnCatAll As Button
    Friend WithEvents btnCatMeals As Button
    Friend WithEvents btnCatSnacks As Button
    Friend WithEvents btnCatDrinks As Button
    Friend WithEvents btnCatDesserts As Button
    Friend WithEvents btnCatInstant As Button
    Friend WithEvents flpProducts As FlowLayoutPanel
    Friend WithEvents ucPhPOS1 As ucProductButton
    Friend WithEvents ucPhPOS2 As ucProductButton
    Friend WithEvents ucPhPOS3 As ucProductButton
    Friend WithEvents ucPhPOS4 As ucProductButton
    Friend WithEvents ucPhPOS5 As ucProductButton
    Friend WithEvents ucPhPOS6 As ucProductButton
    Friend WithEvents ucPhPOS7 As ucProductButton
    Friend WithEvents ucPhPOS8 As ucProductButton
    Friend WithEvents ucPhPOS9 As ucProductButton
    Friend WithEvents ucPhPOS10 As ucProductButton
    Friend WithEvents ucPhPOS11 As ucProductButton
    Friend WithEvents ucPhPOS12 As ucProductButton
    Friend WithEvents ucPhPOS13 As ucProductButton
    Friend WithEvents ucPhPOS14 As ucProductButton
    Friend WithEvents ucPhPOS15 As ucProductButton
    Friend WithEvents ucPhPOS16 As ucProductButton
    Friend WithEvents ucPhPOS17 As ucProductButton
    Friend WithEvents ucPhPOS18 As ucProductButton
    Friend WithEvents ucPhPOS19 As ucProductButton
    Friend WithEvents ucPhPOS20 As ucProductButton
    Friend WithEvents ucPhPOS21 As ucProductButton
    Friend WithEvents ucPhPOS22 As ucProductButton
    Friend WithEvents ucPhPOS23 As ucProductButton
    Friend WithEvents ucPhPOS24 As ucProductButton
    Friend WithEvents ucPhPOS25 As ucProductButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoCash As RadioButton
    Friend WithEvents colItem As DataGridViewTextBoxColumn
    Friend WithEvents colQty As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents colDelete As DataGridViewButtonColumn
    Friend WithEvents rdoSalaryDeduction As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents btnCancelPayment As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents lblChange As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents object_1ab29191_8921_45b5_8bec_8dbb7c11c102 As Panel
End Class
