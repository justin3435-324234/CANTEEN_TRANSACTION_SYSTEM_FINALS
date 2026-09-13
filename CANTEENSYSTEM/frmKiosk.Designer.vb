<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKiosk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKiosk))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.pnlOrderType = New System.Windows.Forms.Panel()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDesserts = New System.Windows.Forms.Button()
        Me.btnInstant = New System.Windows.Forms.Button()
        Me.btnAllItems = New System.Windows.Forms.Button()
        Me.btnSnacks = New System.Windows.Forms.Button()
        Me.btnMeals = New System.Windows.Forms.Button()
        Me.btnDrinks = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnTakeOut = New System.Windows.Forms.Button()
        Me.btnDineIn = New System.Windows.Forms.Button()
        Me.btnStartOrder = New System.Windows.Forms.Button()
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
        Me.flpProducts = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnStartOver = New System.Windows.Forms.Button()
        Me.btnViewOrder = New System.Windows.Forms.Button()
        Me.pnlCart = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCartItems = New System.Windows.Forms.Panel()
        Me.pnlCartBottom = New System.Windows.Forms.Panel()
        Me.btnAddMore = New System.Windows.Forms.Button()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.lblCartTotal = New System.Windows.Forms.Label()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlPayment = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblPaymentTotal = New System.Windows.Forms.Label()
        Me.btnSalaryDeduction = New System.Windows.Forms.Button()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnPaymentBack = New System.Windows.Forms.Button()
        Me.btnPaymentCancel = New System.Windows.Forms.Button()
        Me.pnlQueue = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblQueueNumber = New System.Windows.Forms.Label()
        Me.lblQueuePayment = New System.Windows.Forms.Label()
        Me.lblQueueTotal = New System.Windows.Forms.Label()
        Me.lblQueueMessage = New System.Windows.Forms.Label()
        Me.pnlWelcome.SuspendLayout()
        Me.pnlOrderType.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpProducts.SuspendLayout()
        Me.pnlCart.SuspendLayout()
        Me.pnlCartItems.SuspendLayout()
        Me.pnlCartBottom.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPayment.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlQueue.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWelcome
        '
        Me.pnlWelcome.BackgroundImage = CType(resources.GetObject("pnlWelcome.BackgroundImage"), System.Drawing.Image)
        Me.pnlWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWelcome.Controls.Add(Me.btnStartOrder)
        Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWelcome.Location = New System.Drawing.Point(0, 0)
        Me.pnlWelcome.Name = "pnlWelcome"
        Me.pnlWelcome.Size = New System.Drawing.Size(800, 450)
        Me.pnlWelcome.TabIndex = 0
        '
        'pnlOrderType
        '
        Me.pnlOrderType.BackgroundImage = CType(resources.GetObject("pnlOrderType.BackgroundImage"), System.Drawing.Image)
        Me.pnlOrderType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlOrderType.Controls.Add(Me.PictureBox2)
        Me.pnlOrderType.Controls.Add(Me.PictureBox1)
        Me.pnlOrderType.Controls.Add(Me.btnTakeOut)
        Me.pnlOrderType.Controls.Add(Me.btnDineIn)
        Me.pnlOrderType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOrderType.Location = New System.Drawing.Point(0, 0)
        Me.pnlOrderType.Name = "pnlOrderType"
        Me.pnlOrderType.Size = New System.Drawing.Size(800, 450)
        Me.pnlOrderType.TabIndex = 2
        Me.pnlOrderType.Visible = False
        '
        'pnlMenu
        '
        Me.pnlMenu.BackgroundImage = CType(resources.GetObject("pnlMenu.BackgroundImage"), System.Drawing.Image)
        Me.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMenu.Controls.Add(Me.btnViewOrder)
        Me.pnlMenu.Controls.Add(Me.btnStartOver)
        Me.pnlMenu.Controls.Add(Me.flpProducts)
        Me.pnlMenu.Controls.Add(Me.Panel1)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(800, 450)
        Me.pnlMenu.TabIndex = 6
        Me.pnlMenu.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.btnDesserts)
        Me.Panel1.Controls.Add(Me.btnInstant)
        Me.Panel1.Controls.Add(Me.btnAllItems)
        Me.Panel1.Controls.Add(Me.btnSnacks)
        Me.Panel1.Controls.Add(Me.btnMeals)
        Me.Panel1.Controls.Add(Me.btnDrinks)
        Me.Panel1.Location = New System.Drawing.Point(-5, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 450)
        Me.Panel1.TabIndex = 0
        '
        'btnDesserts
        '
        Me.btnDesserts.BackColor = System.Drawing.Color.Gold
        Me.btnDesserts.FlatAppearance.BorderSize = 0
        Me.btnDesserts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesserts.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesserts.Location = New System.Drawing.Point(17, 297)
        Me.btnDesserts.Name = "btnDesserts"
        Me.btnDesserts.Size = New System.Drawing.Size(159, 40)
        Me.btnDesserts.TabIndex = 6
        Me.btnDesserts.Text = "🍦 DESSERTS"
        Me.btnDesserts.UseVisualStyleBackColor = False
        '
        'btnInstant
        '
        Me.btnInstant.BackColor = System.Drawing.Color.Gold
        Me.btnInstant.FlatAppearance.BorderSize = 0
        Me.btnInstant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstant.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstant.Location = New System.Drawing.Point(17, 251)
        Me.btnInstant.Name = "btnInstant"
        Me.btnInstant.Size = New System.Drawing.Size(159, 40)
        Me.btnInstant.TabIndex = 5
        Me.btnInstant.Text = "🍜 INSTANT"
        Me.btnInstant.UseVisualStyleBackColor = False
        '
        'btnAllItems
        '
        Me.btnAllItems.BackColor = System.Drawing.Color.Gold
        Me.btnAllItems.FlatAppearance.BorderSize = 0
        Me.btnAllItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllItems.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllItems.Location = New System.Drawing.Point(17, 57)
        Me.btnAllItems.Name = "btnAllItems"
        Me.btnAllItems.Size = New System.Drawing.Size(159, 40)
        Me.btnAllItems.TabIndex = 4
        Me.btnAllItems.Text = "🍽 ALL ITEMS"
        Me.btnAllItems.UseVisualStyleBackColor = False
        '
        'btnSnacks
        '
        Me.btnSnacks.BackColor = System.Drawing.Color.Gold
        Me.btnSnacks.FlatAppearance.BorderSize = 0
        Me.btnSnacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSnacks.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSnacks.Location = New System.Drawing.Point(17, 149)
        Me.btnSnacks.Name = "btnSnacks"
        Me.btnSnacks.Size = New System.Drawing.Size(159, 40)
        Me.btnSnacks.TabIndex = 3
        Me.btnSnacks.Text = "🍟 SNACKS"
        Me.btnSnacks.UseVisualStyleBackColor = False
        '
        'btnMeals
        '
        Me.btnMeals.BackColor = System.Drawing.Color.Gold
        Me.btnMeals.FlatAppearance.BorderSize = 0
        Me.btnMeals.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMeals.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeals.Location = New System.Drawing.Point(17, 103)
        Me.btnMeals.Name = "btnMeals"
        Me.btnMeals.Size = New System.Drawing.Size(159, 40)
        Me.btnMeals.TabIndex = 2
        Me.btnMeals.Text = "🍛 MEALS"
        Me.btnMeals.UseVisualStyleBackColor = False
        '
        'btnDrinks
        '
        Me.btnDrinks.BackColor = System.Drawing.Color.Gold
        Me.btnDrinks.FlatAppearance.BorderSize = 0
        Me.btnDrinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDrinks.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrinks.Location = New System.Drawing.Point(17, 195)
        Me.btnDrinks.Name = "btnDrinks"
        Me.btnDrinks.Size = New System.Drawing.Size(159, 40)
        Me.btnDrinks.TabIndex = 1
        Me.btnDrinks.Text = "🥤 DRINKS"
        Me.btnDrinks.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gold
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.Location = New System.Drawing.Point(481, 198)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gold
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(232, 198)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnTakeOut
        '
        Me.btnTakeOut.BackColor = System.Drawing.Color.Gold
        Me.btnTakeOut.FlatAppearance.BorderSize = 0
        Me.btnTakeOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTakeOut.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTakeOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnTakeOut.Location = New System.Drawing.Point(429, 168)
        Me.btnTakeOut.Name = "btnTakeOut"
        Me.btnTakeOut.Size = New System.Drawing.Size(209, 123)
        Me.btnTakeOut.TabIndex = 3
        Me.btnTakeOut.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Take Out"
        Me.btnTakeOut.UseVisualStyleBackColor = False
        '
        'btnDineIn
        '
        Me.btnDineIn.BackColor = System.Drawing.Color.Gold
        Me.btnDineIn.FlatAppearance.BorderSize = 0
        Me.btnDineIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDineIn.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDineIn.ForeColor = System.Drawing.Color.Black
        Me.btnDineIn.Location = New System.Drawing.Point(177, 168)
        Me.btnDineIn.Name = "btnDineIn"
        Me.btnDineIn.Size = New System.Drawing.Size(209, 123)
        Me.btnDineIn.TabIndex = 2
        Me.btnDineIn.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dine-in"
        Me.btnDineIn.UseVisualStyleBackColor = False
        '
        'btnStartOrder
        '
        Me.btnStartOrder.BackColor = System.Drawing.Color.Gold
        Me.btnStartOrder.FlatAppearance.BorderSize = 0
        Me.btnStartOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartOrder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartOrder.Location = New System.Drawing.Point(282, 336)
        Me.btnStartOrder.Name = "btnStartOrder"
        Me.btnStartOrder.Size = New System.Drawing.Size(190, 41)
        Me.btnStartOrder.TabIndex = 1
        Me.btnStartOrder.Text = "START ORDER ->"
        Me.btnStartOrder.UseVisualStyleBackColor = False
        '
        'btnProdAdobo
        '
        Me.btnProdAdobo.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnProdAdobo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdAdobo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnProdAdobo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProdAdobo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProdAdobo.ForeColor = System.Drawing.Color.White
        Me.btnProdAdobo.Location = New System.Drawing.Point(3, 3)
        Me.btnProdAdobo.Name = "btnProdAdobo"
        Me.btnProdAdobo.Size = New System.Drawing.Size(75, 55)
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
        Me.btnProdLongganisa.Location = New System.Drawing.Point(84, 3)
        Me.btnProdLongganisa.Name = "btnProdLongganisa"
        Me.btnProdLongganisa.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdSpam.Location = New System.Drawing.Point(167, 3)
        Me.btnProdSpam.Name = "btnProdSpam"
        Me.btnProdSpam.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdShanghai.Location = New System.Drawing.Point(250, 3)
        Me.btnProdShanghai.Name = "btnProdShanghai"
        Me.btnProdShanghai.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdRice.Location = New System.Drawing.Point(333, 3)
        Me.btnProdRice.Name = "btnProdRice"
        Me.btnProdRice.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdSiomaiBig.Location = New System.Drawing.Point(416, 3)
        Me.btnProdSiomaiBig.Name = "btnProdSiomaiBig"
        Me.btnProdSiomaiBig.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdSiomaiSmall.Location = New System.Drawing.Point(3, 64)
        Me.btnProdSiomaiSmall.Name = "btnProdSiomaiSmall"
        Me.btnProdSiomaiSmall.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdSiopao.Location = New System.Drawing.Point(86, 64)
        Me.btnProdSiopao.Name = "btnProdSiopao"
        Me.btnProdSiopao.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdTuron.Location = New System.Drawing.Point(169, 64)
        Me.btnProdTuron.Name = "btnProdTuron"
        Me.btnProdTuron.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdCorndog.Location = New System.Drawing.Point(252, 64)
        Me.btnProdCorndog.Name = "btnProdCorndog"
        Me.btnProdCorndog.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdMineralWater.Location = New System.Drawing.Point(335, 64)
        Me.btnProdMineralWater.Name = "btnProdMineralWater"
        Me.btnProdMineralWater.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdLiptonIceTea.Location = New System.Drawing.Point(418, 64)
        Me.btnProdLiptonIceTea.Name = "btnProdLiptonIceTea"
        Me.btnProdLiptonIceTea.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdMilo.Location = New System.Drawing.Point(3, 125)
        Me.btnProdMilo.Name = "btnProdMilo"
        Me.btnProdMilo.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdKopiko.Location = New System.Drawing.Point(86, 125)
        Me.btnProdKopiko.Name = "btnProdKopiko"
        Me.btnProdKopiko.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdIcedCoffee.Location = New System.Drawing.Point(169, 125)
        Me.btnProdIcedCoffee.Name = "btnProdIcedCoffee"
        Me.btnProdIcedCoffee.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdIceCream.Location = New System.Drawing.Point(252, 125)
        Me.btnProdIceCream.Name = "btnProdIceCream"
        Me.btnProdIceCream.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdFudgeeBar.Location = New System.Drawing.Point(335, 125)
        Me.btnProdFudgeeBar.Name = "btnProdFudgeeBar"
        Me.btnProdFudgeeBar.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdDoweeDonut.Location = New System.Drawing.Point(418, 125)
        Me.btnProdDoweeDonut.Name = "btnProdDoweeDonut"
        Me.btnProdDoweeDonut.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdOreo.Location = New System.Drawing.Point(3, 186)
        Me.btnProdOreo.Name = "btnProdOreo"
        Me.btnProdOreo.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdChocolateCake.Location = New System.Drawing.Point(86, 186)
        Me.btnProdChocolateCake.Name = "btnProdChocolateCake"
        Me.btnProdChocolateCake.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdNoodlesBulalo.Location = New System.Drawing.Point(169, 186)
        Me.btnProdNoodlesBulalo.Name = "btnProdNoodlesBulalo"
        Me.btnProdNoodlesBulalo.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdNoodlesSeafood.Location = New System.Drawing.Point(252, 186)
        Me.btnProdNoodlesSeafood.Name = "btnProdNoodlesSeafood"
        Me.btnProdNoodlesSeafood.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdPancitCanton.Location = New System.Drawing.Point(335, 186)
        Me.btnProdPancitCanton.Name = "btnProdPancitCanton"
        Me.btnProdPancitCanton.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdLuckyMeNoodles.Location = New System.Drawing.Point(418, 186)
        Me.btnProdLuckyMeNoodles.Name = "btnProdLuckyMeNoodles"
        Me.btnProdLuckyMeNoodles.Size = New System.Drawing.Size(77, 55)
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
        Me.btnProdLuckyMeCanton.Location = New System.Drawing.Point(3, 247)
        Me.btnProdLuckyMeCanton.Name = "btnProdLuckyMeCanton"
        Me.btnProdLuckyMeCanton.Size = New System.Drawing.Size(77, 55)
        Me.btnProdLuckyMeCanton.TabIndex = 24
        Me.btnProdLuckyMeCanton.Tag = "INSTANT"
        Me.btnProdLuckyMeCanton.Text = "Lucky Me Canton ₱20.00"
        Me.btnProdLuckyMeCanton.UseVisualStyleBackColor = False
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
        Me.flpProducts.Location = New System.Drawing.Point(203, 76)
        Me.flpProducts.Name = "flpProducts"
        Me.flpProducts.Size = New System.Drawing.Size(519, 301)
        Me.flpProducts.TabIndex = 3
        '
        'btnStartOver
        '
        Me.btnStartOver.BackColor = System.Drawing.Color.Gold
        Me.btnStartOver.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnStartOver.FlatAppearance.BorderSize = 0
        Me.btnStartOver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartOver.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartOver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnStartOver.Location = New System.Drawing.Point(203, 398)
        Me.btnStartOver.Name = "btnStartOver"
        Me.btnStartOver.Size = New System.Drawing.Size(183, 40)
        Me.btnStartOver.TabIndex = 5
        Me.btnStartOver.Text = "START OVER"
        Me.btnStartOver.UseVisualStyleBackColor = False
        '
        'btnViewOrder
        '
        Me.btnViewOrder.BackColor = System.Drawing.Color.Gold
        Me.btnViewOrder.FlatAppearance.BorderSize = 0
        Me.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewOrder.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewOrder.Location = New System.Drawing.Point(529, 398)
        Me.btnViewOrder.Name = "btnViewOrder"
        Me.btnViewOrder.Size = New System.Drawing.Size(183, 40)
        Me.btnViewOrder.TabIndex = 6
        Me.btnViewOrder.Text = "VIEW ORDER "
        Me.btnViewOrder.UseVisualStyleBackColor = False
        '
        'pnlCart
        '
        Me.pnlCart.BackgroundImage = CType(resources.GetObject("pnlCart.BackgroundImage"), System.Drawing.Image)
        Me.pnlCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCart.Controls.Add(Me.pnlCartBottom)
        Me.pnlCart.Controls.Add(Me.pnlCartItems)
        Me.pnlCart.Controls.Add(Me.Label1)
        Me.pnlCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCart.Location = New System.Drawing.Point(0, 0)
        Me.pnlCart.Name = "pnlCart"
        Me.pnlCart.Size = New System.Drawing.Size(800, 450)
        Me.pnlCart.TabIndex = 2
        Me.pnlCart.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(281, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "YOUR ORDER"
        '
        'pnlCartItems
        '
        Me.pnlCartItems.BackColor = System.Drawing.Color.White
        Me.pnlCartItems.Controls.Add(Me.dgvCart)
        Me.pnlCartItems.Location = New System.Drawing.Point(208, 113)
        Me.pnlCartItems.Name = "pnlCartItems"
        Me.pnlCartItems.Size = New System.Drawing.Size(386, 193)
        Me.pnlCartItems.TabIndex = 1
        '
        'pnlCartBottom
        '
        Me.pnlCartBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.pnlCartBottom.Controls.Add(Me.lblCartTotal)
        Me.pnlCartBottom.Controls.Add(Me.btnPlaceOrder)
        Me.pnlCartBottom.Controls.Add(Me.btnAddMore)
        Me.pnlCartBottom.Location = New System.Drawing.Point(208, 333)
        Me.pnlCartBottom.Name = "pnlCartBottom"
        Me.pnlCartBottom.Size = New System.Drawing.Size(386, 101)
        Me.pnlCartBottom.TabIndex = 2
        '
        'btnAddMore
        '
        Me.btnAddMore.BackColor = System.Drawing.Color.Gold
        Me.btnAddMore.FlatAppearance.BorderSize = 0
        Me.btnAddMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMore.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMore.ForeColor = System.Drawing.Color.White
        Me.btnAddMore.Location = New System.Drawing.Point(8, 46)
        Me.btnAddMore.Name = "btnAddMore"
        Me.btnAddMore.Size = New System.Drawing.Size(148, 38)
        Me.btnAddMore.TabIndex = 0
        Me.btnAddMore.Text = " ← ADD MORE ITEMS"
        Me.btnAddMore.UseVisualStyleBackColor = False
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPlaceOrder.FlatAppearance.BorderSize = 0
        Me.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlaceOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaceOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnPlaceOrder.Location = New System.Drawing.Point(231, 46)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(152, 38)
        Me.btnPlaceOrder.TabIndex = 1
        Me.btnPlaceOrder.Text = "PLACE ORDER →"
        Me.btnPlaceOrder.UseVisualStyleBackColor = False
        '
        'lblCartTotal
        '
        Me.lblCartTotal.AutoSize = True
        Me.lblCartTotal.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartTotal.ForeColor = System.Drawing.Color.White
        Me.lblCartTotal.Location = New System.Drawing.Point(105, 8)
        Me.lblCartTotal.Name = "lblCartTotal"
        Me.lblCartTotal.Size = New System.Drawing.Size(143, 30)
        Me.lblCartTotal.TabIndex = 2
        Me.lblCartTotal.Text = "TOTAL: ₱0.00"
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCart.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colQty, Me.colPrice, Me.colSubtotal, Me.colDelete})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCart.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCart.EnableHeadersVisualStyles = False
        Me.dgvCart.GridColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCart.Location = New System.Drawing.Point(0, 0)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersVisible = False
        Me.dgvCart.RowHeadersWidth = 51
        Me.dgvCart.Size = New System.Drawing.Size(386, 214)
        Me.dgvCart.TabIndex = 2
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
        'pnlPayment
        '
        Me.pnlPayment.BackgroundImage = CType(resources.GetObject("pnlPayment.BackgroundImage"), System.Drawing.Image)
        Me.pnlPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlPayment.Controls.Add(Me.Panel2)
        Me.pnlPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPayment.Location = New System.Drawing.Point(0, 0)
        Me.pnlPayment.Name = "pnlPayment"
        Me.pnlPayment.Size = New System.Drawing.Size(800, 450)
        Me.pnlPayment.TabIndex = 2
        Me.pnlPayment.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnPaymentCancel)
        Me.Panel2.Controls.Add(Me.btnPaymentBack)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.btnCash)
        Me.Panel2.Controls.Add(Me.btnSalaryDeduction)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(49, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(673, 374)
        Me.Panel2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(120, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(455, 45)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SELECT PAYMENT METHOD"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(85, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "TOTAL AMOUNT"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblPaymentTotal)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(183, 63)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(312, 73)
        Me.Panel3.TabIndex = 2
        '
        'lblPaymentTotal
        '
        Me.lblPaymentTotal.AutoSize = True
        Me.lblPaymentTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPaymentTotal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTotal.ForeColor = System.Drawing.Color.Gold
        Me.lblPaymentTotal.Location = New System.Drawing.Point(114, 32)
        Me.lblPaymentTotal.Name = "lblPaymentTotal"
        Me.lblPaymentTotal.Size = New System.Drawing.Size(62, 25)
        Me.lblPaymentTotal.TabIndex = 2
        Me.lblPaymentTotal.Text = "₱0.00"
        '
        'btnSalaryDeduction
        '
        Me.btnSalaryDeduction.BackColor = System.Drawing.Color.Gold
        Me.btnSalaryDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalaryDeduction.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalaryDeduction.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalaryDeduction.Location = New System.Drawing.Point(141, 153)
        Me.btnSalaryDeduction.Name = "btnSalaryDeduction"
        Me.btnSalaryDeduction.Size = New System.Drawing.Size(142, 125)
        Me.btnSalaryDeduction.TabIndex = 3
        Me.btnSalaryDeduction.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SALARY DEDUCTION"
        Me.btnSalaryDeduction.UseVisualStyleBackColor = False
        '
        'btnCash
        '
        Me.btnCash.BackColor = System.Drawing.Color.Gold
        Me.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCash.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCash.Location = New System.Drawing.Point(367, 152)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(142, 125)
        Me.btnCash.TabIndex = 4
        Me.btnCash.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CASH"
        Me.btnCash.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gold
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox3.Location = New System.Drawing.Point(159, 163)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 56)
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Gold
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox4.Location = New System.Drawing.Point(383, 163)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(100, 56)
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'btnPaymentBack
        '
        Me.btnPaymentBack.BackColor = System.Drawing.Color.Gold
        Me.btnPaymentBack.FlatAppearance.BorderSize = 0
        Me.btnPaymentBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaymentBack.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentBack.Location = New System.Drawing.Point(34, 324)
        Me.btnPaymentBack.Name = "btnPaymentBack"
        Me.btnPaymentBack.Size = New System.Drawing.Size(127, 33)
        Me.btnPaymentBack.TabIndex = 7
        Me.btnPaymentBack.Text = "← BACK TO CART"
        Me.btnPaymentBack.UseVisualStyleBackColor = False
        '
        'btnPaymentCancel
        '
        Me.btnPaymentCancel.BackColor = System.Drawing.Color.Gold
        Me.btnPaymentCancel.FlatAppearance.BorderSize = 0
        Me.btnPaymentCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaymentCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentCancel.Location = New System.Drawing.Point(489, 324)
        Me.btnPaymentCancel.Name = "btnPaymentCancel"
        Me.btnPaymentCancel.Size = New System.Drawing.Size(174, 33)
        Me.btnPaymentCancel.TabIndex = 8
        Me.btnPaymentCancel.Text = "✕ CANCEL ORDER"
        Me.btnPaymentCancel.UseVisualStyleBackColor = False
        '
        'pnlQueue
        '
        Me.pnlQueue.BackgroundImage = CType(resources.GetObject("pnlQueue.BackgroundImage"), System.Drawing.Image)
        Me.pnlQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlQueue.Controls.Add(Me.Panel4)
        Me.pnlQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlQueue.Location = New System.Drawing.Point(0, 0)
        Me.pnlQueue.Name = "pnlQueue"
        Me.pnlQueue.Size = New System.Drawing.Size(800, 450)
        Me.pnlQueue.TabIndex = 2
        Me.pnlQueue.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Controls.Add(Me.lblQueueMessage)
        Me.Panel4.Controls.Add(Me.lblQueueTotal)
        Me.Panel4.Controls.Add(Me.lblQueuePayment)
        Me.Panel4.Controls.Add(Me.lblQueueNumber)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Location = New System.Drawing.Point(190, 103)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(453, 266)
        Me.Panel4.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(122, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(240, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "YOUR QUEUE NUMBER"
        '
        'lblQueueNumber
        '
        Me.lblQueueNumber.AutoSize = True
        Me.lblQueueNumber.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueNumber.Location = New System.Drawing.Point(187, 63)
        Me.lblQueueNumber.Name = "lblQueueNumber"
        Me.lblQueueNumber.Size = New System.Drawing.Size(119, 47)
        Me.lblQueueNumber.TabIndex = 2
        Me.lblQueueNumber.Text = "A-023"
        '
        'lblQueuePayment
        '
        Me.lblQueuePayment.AutoSize = True
        Me.lblQueuePayment.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueuePayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueuePayment.Location = New System.Drawing.Point(51, 140)
        Me.lblQueuePayment.Name = "lblQueuePayment"
        Me.lblQueuePayment.Size = New System.Drawing.Size(162, 25)
        Me.lblQueuePayment.TabIndex = 3
        Me.lblQueuePayment.Text = "PAYMENT: CASH"
        '
        'lblQueueTotal
        '
        Me.lblQueueTotal.AutoSize = True
        Me.lblQueueTotal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueTotal.Location = New System.Drawing.Point(51, 172)
        Me.lblQueueTotal.Name = "lblQueueTotal"
        Me.lblQueueTotal.Size = New System.Drawing.Size(150, 25)
        Me.lblQueueTotal.TabIndex = 4
        Me.lblQueueTotal.Text = "TOTAL: ₱125.00"
        '
        'lblQueueMessage
        '
        Me.lblQueueMessage.AutoSize = True
        Me.lblQueueMessage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueMessage.Location = New System.Drawing.Point(137, 214)
        Me.lblQueueMessage.Name = "lblQueueMessage"
        Me.lblQueueMessage.Size = New System.Drawing.Size(209, 21)
        Me.lblQueueMessage.TabIndex = 5
        Me.lblQueueMessage.Text = "Please wait for your order."
        '
        'frmKiosk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlWelcome)
        Me.Controls.Add(Me.pnlQueue)
        Me.Controls.Add(Me.pnlPayment)
        Me.Controls.Add(Me.pnlCart)
        Me.Controls.Add(Me.pnlOrderType)
        Me.Controls.Add(Me.pnlMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmKiosk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlOrderType.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpProducts.ResumeLayout(False)
        Me.pnlCart.ResumeLayout(False)
        Me.pnlCart.PerformLayout()
        Me.pnlCartItems.ResumeLayout(False)
        Me.pnlCartBottom.ResumeLayout(False)
        Me.pnlCartBottom.PerformLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPayment.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlQueue.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents btnStartOrder As Button
    Friend WithEvents pnlOrderType As Panel
    Friend WithEvents btnTakeOut As Button
    Friend WithEvents btnDineIn As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMeals As Button
    Friend WithEvents btnDrinks As Button
    Friend WithEvents btnDesserts As Button
    Friend WithEvents btnInstant As Button
    Friend WithEvents btnAllItems As Button
    Friend WithEvents btnSnacks As Button
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
    Friend WithEvents btnViewOrder As Button
    Friend WithEvents btnStartOver As Button
    Friend WithEvents pnlCart As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlCartItems As Panel
    Friend WithEvents pnlCartBottom As Panel
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents btnAddMore As Button
    Friend WithEvents lblCartTotal As Label
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents colItem As DataGridViewTextBoxColumn
    Friend WithEvents colQty As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents colDelete As DataGridViewButtonColumn
    Friend WithEvents pnlPayment As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCash As Button
    Friend WithEvents btnSalaryDeduction As Button
    Friend WithEvents lblPaymentTotal As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnPaymentBack As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnPaymentCancel As Button
    Friend WithEvents pnlQueue As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblQueueNumber As Label
    Friend WithEvents lblQueueMessage As Label
    Friend WithEvents lblQueueTotal As Label
    Friend WithEvents lblQueuePayment As Label
End Class
