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
        Me.btnProdAdobo = New System.Windows.Forms.Button()
        Me.btnProdLongganisa = New System.Windows.Forms.Button()
        Me.btnProdSpam = New System.Windows.Forms.Button()
        Me.btnProdShanghai = New System.Windows.Forms.Button()
        Me.btnProdRice = New System.Windows.Forms.Button()
        Me.btnProdSiomaiBig = New System.Windows.Forms.Button()
        Me.btnProdSiomaiSmall = New System.Windows.Forms.Button()
        Me.btnProdSiopao = New System.Windows.Forms.Button()
        Me.btnProdTuron = New System.Windows.Forms.Button()
        Me.btnProdCorndog = New System.Windows.Forms.Button()
        Me.btnProdMineralWater = New System.Windows.Forms.Button()
        Me.btnProdLiptonIceTea = New System.Windows.Forms.Button()
        Me.btnProdMilo = New System.Windows.Forms.Button()
        Me.btnProdKopiko = New System.Windows.Forms.Button()
        Me.btnProdIcedCoffee = New System.Windows.Forms.Button()
        Me.btnProdIceCream = New System.Windows.Forms.Button()
        Me.btnProdFudgeeBar = New System.Windows.Forms.Button()
        Me.btnProdDoweeDonut = New System.Windows.Forms.Button()
        Me.btnProdOreo = New System.Windows.Forms.Button()
        Me.btnProdChocolateCake = New System.Windows.Forms.Button()
        Me.btnProdNoodlesBulalo = New System.Windows.Forms.Button()
        Me.btnProdNoodlesSeafood = New System.Windows.Forms.Button()
        Me.btnProdPancitCanton = New System.Windows.Forms.Button()
        Me.btnProdLuckyMeNoodles = New System.Windows.Forms.Button()
        Me.btnProdLuckyMeCanton = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCatAll = New System.Windows.Forms.Button()
        Me.btnCatDrinks = New System.Windows.Forms.Button()
        Me.btnCatSnacks = New System.Windows.Forms.Button()
        Me.btnCatDesserts = New System.Windows.Forms.Button()
        Me.btnCatInstant = New System.Windows.Forms.Button()
        Me.btnCatMeals = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
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
        'pnlCartContainer
        '
        Me.pnlCartContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
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
        Me.pnlCartContainer.Size = New System.Drawing.Size(383, 690)
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
        Me.btnLogout.Location = New System.Drawing.Point(29, 644)
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
        Me.btnCancelPayment.Location = New System.Drawing.Point(29, 601)
        Me.btnCancelPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelPayment.Name = "btnCancelPayment"
        Me.btnCancelPayment.Size = New System.Drawing.Size(343, 37)
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
        Me.btnOpenPayment.Location = New System.Drawing.Point(29, 560)
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
        Me.flpProducts.Controls.Add(Me.btnProdAdobo)
        Me.flpProducts.Controls.Add(Me.btnProdLongganisa)
        Me.flpProducts.Controls.Add(Me.btnProdSpam)
        Me.flpProducts.Controls.Add(Me.btnProdShanghai)
        Me.flpProducts.Controls.Add(Me.btnProdRice)
        Me.flpProducts.Controls.Add(Me.btnProdSiomaiBig)
        Me.flpProducts.Controls.Add(Me.btnProdSiomaiSmall)
        Me.flpProducts.Controls.Add(Me.btnProdSiopao)
        Me.flpProducts.Controls.Add(Me.btnProdTuron)
        Me.flpProducts.Controls.Add(Me.btnProdCorndog)
        Me.flpProducts.Controls.Add(Me.btnProdMineralWater)
        Me.flpProducts.Controls.Add(Me.btnProdLiptonIceTea)
        Me.flpProducts.Controls.Add(Me.btnProdMilo)
        Me.flpProducts.Controls.Add(Me.btnProdKopiko)
        Me.flpProducts.Controls.Add(Me.btnProdIcedCoffee)
        Me.flpProducts.Controls.Add(Me.btnProdIceCream)
        Me.flpProducts.Controls.Add(Me.btnProdFudgeeBar)
        Me.flpProducts.Controls.Add(Me.btnProdDoweeDonut)
        Me.flpProducts.Controls.Add(Me.btnProdOreo)
        Me.flpProducts.Controls.Add(Me.btnProdChocolateCake)
        Me.flpProducts.Controls.Add(Me.btnProdNoodlesBulalo)
        Me.flpProducts.Controls.Add(Me.btnProdNoodlesSeafood)
        Me.flpProducts.Controls.Add(Me.btnProdPancitCanton)
        Me.flpProducts.Controls.Add(Me.btnProdLuckyMeNoodles)
        Me.flpProducts.Controls.Add(Me.btnProdLuckyMeCanton)
        Me.flpProducts.Location = New System.Drawing.Point(19, 148)
        Me.flpProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.flpProducts.Name = "flpProducts"
        Me.flpProducts.Size = New System.Drawing.Size(692, 420)
        Me.flpProducts.TabIndex = 2
        '
        'btnProdAdobo
        '
        Me.btnProdAdobo.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdAdobo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdAdobo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdAdobo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdAdobo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdAdobo.ForeColor = System.Drawing.Color.White
        Me.btnProdAdobo.Location = New System.Drawing.Point(4, 4)
        Me.btnProdAdobo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdAdobo.Name = "btnProdAdobo"
        Me.btnProdAdobo.Size = New System.Drawing.Size(100, 68)
        Me.btnProdAdobo.TabIndex = 0
        Me.btnProdAdobo.Tag = "MEALS"
        Me.btnProdAdobo.Text = "Chicken Adobo ₱65.00"
        Me.btnProdAdobo.UseVisualStyleBackColor = False
        '
        'btnProdLongganisa
        '
        Me.btnProdLongganisa.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdLongganisa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLongganisa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdLongganisa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLongganisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdLongganisa.ForeColor = System.Drawing.Color.White
        Me.btnProdLongganisa.Location = New System.Drawing.Point(112, 4)
        Me.btnProdLongganisa.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdLongganisa.Name = "btnProdLongganisa"
        Me.btnProdLongganisa.Size = New System.Drawing.Size(103, 68)
        Me.btnProdLongganisa.TabIndex = 1
        Me.btnProdLongganisa.Tag = "MEALS"
        Me.btnProdLongganisa.Text = "Longganisa ₱45.00"
        Me.btnProdLongganisa.UseVisualStyleBackColor = False
        '
        'btnProdSpam
        '
        Me.btnProdSpam.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdSpam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSpam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdSpam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSpam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdSpam.ForeColor = System.Drawing.Color.White
        Me.btnProdSpam.Location = New System.Drawing.Point(223, 4)
        Me.btnProdSpam.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdSpam.Name = "btnProdSpam"
        Me.btnProdSpam.Size = New System.Drawing.Size(103, 68)
        Me.btnProdSpam.TabIndex = 2
        Me.btnProdSpam.Tag = "MEALS"
        Me.btnProdSpam.Text = "Spam ₱45.00"
        Me.btnProdSpam.UseVisualStyleBackColor = False
        '
        'btnProdShanghai
        '
        Me.btnProdShanghai.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdShanghai.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdShanghai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdShanghai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdShanghai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdShanghai.ForeColor = System.Drawing.Color.White
        Me.btnProdShanghai.Location = New System.Drawing.Point(334, 4)
        Me.btnProdShanghai.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdShanghai.Name = "btnProdShanghai"
        Me.btnProdShanghai.Size = New System.Drawing.Size(103, 68)
        Me.btnProdShanghai.TabIndex = 3
        Me.btnProdShanghai.Tag = "MEALS"
        Me.btnProdShanghai.Text = "Shanghai ₱20.00"
        Me.btnProdShanghai.UseVisualStyleBackColor = False
        '
        'btnProdRice
        '
        Me.btnProdRice.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdRice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdRice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdRice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdRice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdRice.ForeColor = System.Drawing.Color.White
        Me.btnProdRice.Location = New System.Drawing.Point(445, 4)
        Me.btnProdRice.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdRice.Name = "btnProdRice"
        Me.btnProdRice.Size = New System.Drawing.Size(103, 68)
        Me.btnProdRice.TabIndex = 4
        Me.btnProdRice.Tag = "MEALS"
        Me.btnProdRice.Text = "Rice ₱15.00"
        Me.btnProdRice.UseVisualStyleBackColor = False
        '
        'btnProdSiomaiBig
        '
        Me.btnProdSiomaiBig.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdSiomaiBig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSiomaiBig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdSiomaiBig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSiomaiBig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdSiomaiBig.ForeColor = System.Drawing.Color.White
        Me.btnProdSiomaiBig.Location = New System.Drawing.Point(556, 4)
        Me.btnProdSiomaiBig.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdSiomaiBig.Name = "btnProdSiomaiBig"
        Me.btnProdSiomaiBig.Size = New System.Drawing.Size(103, 68)
        Me.btnProdSiomaiBig.TabIndex = 5
        Me.btnProdSiomaiBig.Tag = "SNACKS"
        Me.btnProdSiomaiBig.Text = "SIOMAI BIG ₱10.00"
        Me.btnProdSiomaiBig.UseVisualStyleBackColor = False
        '
        'btnProdSiomaiSmall
        '
        Me.btnProdSiomaiSmall.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdSiomaiSmall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSiomaiSmall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdSiomaiSmall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSiomaiSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdSiomaiSmall.ForeColor = System.Drawing.Color.White
        Me.btnProdSiomaiSmall.Location = New System.Drawing.Point(4, 80)
        Me.btnProdSiomaiSmall.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdSiomaiSmall.Name = "btnProdSiomaiSmall"
        Me.btnProdSiomaiSmall.Size = New System.Drawing.Size(103, 68)
        Me.btnProdSiomaiSmall.TabIndex = 6
        Me.btnProdSiomaiSmall.Tag = "SNACKS"
        Me.btnProdSiomaiSmall.Text = "SIOMAI SMALL ₱6.00"
        Me.btnProdSiomaiSmall.UseVisualStyleBackColor = False
        '
        'btnProdSiopao
        '
        Me.btnProdSiopao.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdSiopao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSiopao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdSiopao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdSiopao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdSiopao.ForeColor = System.Drawing.Color.White
        Me.btnProdSiopao.Location = New System.Drawing.Point(115, 80)
        Me.btnProdSiopao.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdSiopao.Name = "btnProdSiopao"
        Me.btnProdSiopao.Size = New System.Drawing.Size(103, 68)
        Me.btnProdSiopao.TabIndex = 7
        Me.btnProdSiopao.Tag = "SNACKS"
        Me.btnProdSiopao.Text = "SIOPAO ₱25.00"
        Me.btnProdSiopao.UseVisualStyleBackColor = False
        '
        'btnProdTuron
        '
        Me.btnProdTuron.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdTuron.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdTuron.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdTuron.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdTuron.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdTuron.ForeColor = System.Drawing.Color.White
        Me.btnProdTuron.Location = New System.Drawing.Point(226, 80)
        Me.btnProdTuron.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdTuron.Name = "btnProdTuron"
        Me.btnProdTuron.Size = New System.Drawing.Size(103, 68)
        Me.btnProdTuron.TabIndex = 8
        Me.btnProdTuron.Tag = "SNACKS"
        Me.btnProdTuron.Text = "Turon ₱15.00"
        Me.btnProdTuron.UseVisualStyleBackColor = False
        '
        'btnProdCorndog
        '
        Me.btnProdCorndog.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdCorndog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdCorndog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdCorndog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdCorndog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdCorndog.ForeColor = System.Drawing.Color.White
        Me.btnProdCorndog.Location = New System.Drawing.Point(337, 80)
        Me.btnProdCorndog.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdCorndog.Name = "btnProdCorndog"
        Me.btnProdCorndog.Size = New System.Drawing.Size(103, 68)
        Me.btnProdCorndog.TabIndex = 9
        Me.btnProdCorndog.Tag = "SNACKS"
        Me.btnProdCorndog.Text = "Corndog ₱25.00"
        Me.btnProdCorndog.UseVisualStyleBackColor = False
        '
        'btnProdMineralWater
        '
        Me.btnProdMineralWater.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdMineralWater.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdMineralWater.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdMineralWater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdMineralWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdMineralWater.ForeColor = System.Drawing.Color.White
        Me.btnProdMineralWater.Location = New System.Drawing.Point(448, 80)
        Me.btnProdMineralWater.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdMineralWater.Name = "btnProdMineralWater"
        Me.btnProdMineralWater.Size = New System.Drawing.Size(103, 68)
        Me.btnProdMineralWater.TabIndex = 10
        Me.btnProdMineralWater.Tag = "DRINKS"
        Me.btnProdMineralWater.Text = "MINERAL ₱15.00"
        Me.btnProdMineralWater.UseVisualStyleBackColor = False
        '
        'btnProdLiptonIceTea
        '
        Me.btnProdLiptonIceTea.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdLiptonIceTea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLiptonIceTea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdLiptonIceTea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLiptonIceTea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdLiptonIceTea.ForeColor = System.Drawing.Color.White
        Me.btnProdLiptonIceTea.Location = New System.Drawing.Point(559, 80)
        Me.btnProdLiptonIceTea.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdLiptonIceTea.Name = "btnProdLiptonIceTea"
        Me.btnProdLiptonIceTea.Size = New System.Drawing.Size(103, 68)
        Me.btnProdLiptonIceTea.TabIndex = 11
        Me.btnProdLiptonIceTea.Tag = "DRINKS"
        Me.btnProdLiptonIceTea.Text = "LIPTON ₱30.00"
        Me.btnProdLiptonIceTea.UseVisualStyleBackColor = False
        '
        'btnProdMilo
        '
        Me.btnProdMilo.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdMilo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdMilo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdMilo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdMilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdMilo.ForeColor = System.Drawing.Color.White
        Me.btnProdMilo.Location = New System.Drawing.Point(4, 156)
        Me.btnProdMilo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdMilo.Name = "btnProdMilo"
        Me.btnProdMilo.Size = New System.Drawing.Size(103, 68)
        Me.btnProdMilo.TabIndex = 12
        Me.btnProdMilo.Tag = "DRINKS"
        Me.btnProdMilo.Text = "MILO ₱18.00"
        Me.btnProdMilo.UseVisualStyleBackColor = False
        '
        'btnProdKopiko
        '
        Me.btnProdKopiko.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdKopiko.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdKopiko.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdKopiko.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdKopiko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdKopiko.ForeColor = System.Drawing.Color.White
        Me.btnProdKopiko.Location = New System.Drawing.Point(115, 156)
        Me.btnProdKopiko.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdKopiko.Name = "btnProdKopiko"
        Me.btnProdKopiko.Size = New System.Drawing.Size(103, 68)
        Me.btnProdKopiko.TabIndex = 13
        Me.btnProdKopiko.Tag = "DRINKS"
        Me.btnProdKopiko.Text = "KOPIKO ₱18.00"
        Me.btnProdKopiko.UseVisualStyleBackColor = False
        '
        'btnProdIcedCoffee
        '
        Me.btnProdIcedCoffee.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdIcedCoffee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdIcedCoffee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdIcedCoffee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdIcedCoffee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdIcedCoffee.ForeColor = System.Drawing.Color.White
        Me.btnProdIcedCoffee.Location = New System.Drawing.Point(226, 156)
        Me.btnProdIcedCoffee.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdIcedCoffee.Name = "btnProdIcedCoffee"
        Me.btnProdIcedCoffee.Size = New System.Drawing.Size(103, 68)
        Me.btnProdIcedCoffee.TabIndex = 14
        Me.btnProdIcedCoffee.Tag = "DRINKS"
        Me.btnProdIcedCoffee.Text = "ICED KOPIKO ₱26.00"
        Me.btnProdIcedCoffee.UseVisualStyleBackColor = False
        '
        'btnProdIceCream
        '
        Me.btnProdIceCream.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdIceCream.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdIceCream.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdIceCream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdIceCream.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdIceCream.ForeColor = System.Drawing.Color.White
        Me.btnProdIceCream.Location = New System.Drawing.Point(337, 156)
        Me.btnProdIceCream.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdIceCream.Name = "btnProdIceCream"
        Me.btnProdIceCream.Size = New System.Drawing.Size(103, 68)
        Me.btnProdIceCream.TabIndex = 15
        Me.btnProdIceCream.Tag = "DESSERTS"
        Me.btnProdIceCream.Text = "Ice Cream ₱20.00"
        Me.btnProdIceCream.UseVisualStyleBackColor = False
        '
        'btnProdFudgeeBar
        '
        Me.btnProdFudgeeBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdFudgeeBar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdFudgeeBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdFudgeeBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdFudgeeBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdFudgeeBar.ForeColor = System.Drawing.Color.White
        Me.btnProdFudgeeBar.Location = New System.Drawing.Point(448, 156)
        Me.btnProdFudgeeBar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdFudgeeBar.Name = "btnProdFudgeeBar"
        Me.btnProdFudgeeBar.Size = New System.Drawing.Size(103, 68)
        Me.btnProdFudgeeBar.TabIndex = 16
        Me.btnProdFudgeeBar.Tag = "DESSERTS"
        Me.btnProdFudgeeBar.Text = "Fudgee Bar ₱12.00"
        Me.btnProdFudgeeBar.UseVisualStyleBackColor = False
        '
        'btnProdDoweeDonut
        '
        Me.btnProdDoweeDonut.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdDoweeDonut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdDoweeDonut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdDoweeDonut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdDoweeDonut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdDoweeDonut.ForeColor = System.Drawing.Color.White
        Me.btnProdDoweeDonut.Location = New System.Drawing.Point(559, 156)
        Me.btnProdDoweeDonut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdDoweeDonut.Name = "btnProdDoweeDonut"
        Me.btnProdDoweeDonut.Size = New System.Drawing.Size(103, 68)
        Me.btnProdDoweeDonut.TabIndex = 17
        Me.btnProdDoweeDonut.Tag = "DESSERTS"
        Me.btnProdDoweeDonut.Text = "Dowee Donut ₱15.00"
        Me.btnProdDoweeDonut.UseVisualStyleBackColor = False
        '
        'btnProdOreo
        '
        Me.btnProdOreo.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdOreo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdOreo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdOreo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdOreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdOreo.ForeColor = System.Drawing.Color.White
        Me.btnProdOreo.Location = New System.Drawing.Point(4, 232)
        Me.btnProdOreo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdOreo.Name = "btnProdOreo"
        Me.btnProdOreo.Size = New System.Drawing.Size(103, 68)
        Me.btnProdOreo.TabIndex = 18
        Me.btnProdOreo.Tag = "DESSERTS"
        Me.btnProdOreo.Text = "Oreo ₱12.00"
        Me.btnProdOreo.UseVisualStyleBackColor = False
        '
        'btnProdChocolateCake
        '
        Me.btnProdChocolateCake.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdChocolateCake.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdChocolateCake.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdChocolateCake.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdChocolateCake.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdChocolateCake.ForeColor = System.Drawing.Color.White
        Me.btnProdChocolateCake.Location = New System.Drawing.Point(115, 232)
        Me.btnProdChocolateCake.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdChocolateCake.Name = "btnProdChocolateCake"
        Me.btnProdChocolateCake.Size = New System.Drawing.Size(103, 68)
        Me.btnProdChocolateCake.TabIndex = 19
        Me.btnProdChocolateCake.Tag = "DESSERTS"
        Me.btnProdChocolateCake.Text = "Chocolate Cake ₱25.00"
        Me.btnProdChocolateCake.UseVisualStyleBackColor = False
        '
        'btnProdNoodlesBulalo
        '
        Me.btnProdNoodlesBulalo.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdNoodlesBulalo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdNoodlesBulalo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdNoodlesBulalo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdNoodlesBulalo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdNoodlesBulalo.ForeColor = System.Drawing.Color.White
        Me.btnProdNoodlesBulalo.Location = New System.Drawing.Point(226, 232)
        Me.btnProdNoodlesBulalo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdNoodlesBulalo.Name = "btnProdNoodlesBulalo"
        Me.btnProdNoodlesBulalo.Size = New System.Drawing.Size(103, 68)
        Me.btnProdNoodlesBulalo.TabIndex = 20
        Me.btnProdNoodlesBulalo.Tag = "INSTANT"
        Me.btnProdNoodlesBulalo.Text = "Noodles Bulalo ₱30.00"
        Me.btnProdNoodlesBulalo.UseVisualStyleBackColor = False
        '
        'btnProdNoodlesSeafood
        '
        Me.btnProdNoodlesSeafood.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdNoodlesSeafood.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdNoodlesSeafood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdNoodlesSeafood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdNoodlesSeafood.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdNoodlesSeafood.ForeColor = System.Drawing.Color.White
        Me.btnProdNoodlesSeafood.Location = New System.Drawing.Point(337, 232)
        Me.btnProdNoodlesSeafood.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdNoodlesSeafood.Name = "btnProdNoodlesSeafood"
        Me.btnProdNoodlesSeafood.Size = New System.Drawing.Size(103, 68)
        Me.btnProdNoodlesSeafood.TabIndex = 21
        Me.btnProdNoodlesSeafood.Tag = "INSTANT"
        Me.btnProdNoodlesSeafood.Text = "Noodles Seafood ₱30.00"
        Me.btnProdNoodlesSeafood.UseVisualStyleBackColor = False
        '
        'btnProdPancitCanton
        '
        Me.btnProdPancitCanton.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdPancitCanton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdPancitCanton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdPancitCanton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdPancitCanton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdPancitCanton.ForeColor = System.Drawing.Color.White
        Me.btnProdPancitCanton.Location = New System.Drawing.Point(448, 232)
        Me.btnProdPancitCanton.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdPancitCanton.Name = "btnProdPancitCanton"
        Me.btnProdPancitCanton.Size = New System.Drawing.Size(103, 68)
        Me.btnProdPancitCanton.TabIndex = 22
        Me.btnProdPancitCanton.Tag = "INSTANT"
        Me.btnProdPancitCanton.Text = "Pancit Canton ₱20.00"
        Me.btnProdPancitCanton.UseVisualStyleBackColor = False
        '
        'btnProdLuckyMeNoodles
        '
        Me.btnProdLuckyMeNoodles.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdLuckyMeNoodles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLuckyMeNoodles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdLuckyMeNoodles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLuckyMeNoodles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdLuckyMeNoodles.ForeColor = System.Drawing.Color.White
        Me.btnProdLuckyMeNoodles.Location = New System.Drawing.Point(559, 232)
        Me.btnProdLuckyMeNoodles.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdLuckyMeNoodles.Name = "btnProdLuckyMeNoodles"
        Me.btnProdLuckyMeNoodles.Size = New System.Drawing.Size(103, 68)
        Me.btnProdLuckyMeNoodles.TabIndex = 23
        Me.btnProdLuckyMeNoodles.Tag = "INSTANT"
        Me.btnProdLuckyMeNoodles.Text = "LuckyNoodles ₱18.00"
        Me.btnProdLuckyMeNoodles.UseVisualStyleBackColor = False
        '
        'btnProdLuckyMeCanton
        '
        Me.btnProdLuckyMeCanton.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdLuckyMeCanton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLuckyMeCanton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdLuckyMeCanton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdLuckyMeCanton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdLuckyMeCanton.ForeColor = System.Drawing.Color.White
        Me.btnProdLuckyMeCanton.Location = New System.Drawing.Point(4, 308)
        Me.btnProdLuckyMeCanton.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdLuckyMeCanton.Name = "btnProdLuckyMeCanton"
        Me.btnProdLuckyMeCanton.Size = New System.Drawing.Size(103, 68)
        Me.btnProdLuckyMeCanton.TabIndex = 24
        Me.btnProdLuckyMeCanton.Tag = "INSTANT"
        Me.btnProdLuckyMeCanton.Text = "Lucky Me Canton ₱20.00"
        Me.btnProdLuckyMeCanton.UseVisualStyleBackColor = False
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
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1149, 738)
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
    Friend WithEvents btnProdAdobo As Button
    Friend WithEvents btnProdLongganisa As Button
    Friend WithEvents btnProdSpam As Button
    Friend WithEvents btnProdShanghai As Button
    Friend WithEvents btnProdRice As Button
    Friend WithEvents btnProdSiomaiBig As Button
    Friend WithEvents btnProdSiomaiSmall As Button
    Friend WithEvents btnProdSiopao As Button
    Friend WithEvents btnProdTuron As Button
    Friend WithEvents btnProdCorndog As Button
    Friend WithEvents btnProdMineralWater As Button
    Friend WithEvents btnProdLiptonIceTea As Button
    Friend WithEvents btnProdMilo As Button
    Friend WithEvents btnProdKopiko As Button
    Friend WithEvents btnProdIcedCoffee As Button
    Friend WithEvents btnProdIceCream As Button
    Friend WithEvents btnProdFudgeeBar As Button
    Friend WithEvents btnProdDoweeDonut As Button
    Friend WithEvents btnProdOreo As Button
    Friend WithEvents btnProdChocolateCake As Button
    Friend WithEvents btnProdNoodlesBulalo As Button
    Friend WithEvents btnProdNoodlesSeafood As Button
    Friend WithEvents btnProdPancitCanton As Button
    Friend WithEvents btnProdLuckyMeNoodles As Button
    Friend WithEvents btnProdLuckyMeCanton As Button
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
End Class
