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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.btnKioskReturn = New System.Windows.Forms.Button()
        Me.btnStartOrder = New System.Windows.Forms.Button()
        Me.pnlOrderType = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnTakeOut = New System.Windows.Forms.Button()
        Me.btnDineIn = New System.Windows.Forms.Button()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.btnViewOrder = New System.Windows.Forms.Button()
        Me.btnStartOver = New System.Windows.Forms.Button()
        Me.flpProducts = New System.Windows.Forms.FlowLayoutPanel()
        Me.ucPhKiosk1 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk2 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk3 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk4 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk5 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk6 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk7 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk8 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk9 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk10 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk11 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk12 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk13 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk14 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk15 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk16 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk17 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk18 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk19 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk20 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk21 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk22 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk23 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk24 = New CANTEENSYSTEM.ucProductButton()
        Me.ucPhKiosk25 = New CANTEENSYSTEM.ucProductButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDesserts = New System.Windows.Forms.Button()
        Me.btnInstant = New System.Windows.Forms.Button()
        Me.btnAllItems = New System.Windows.Forms.Button()
        Me.btnSnacks = New System.Windows.Forms.Button()
        Me.btnMeals = New System.Windows.Forms.Button()
        Me.btnDrinks = New System.Windows.Forms.Button()
        Me.pnlCart = New System.Windows.Forms.Panel()
        Me.pnlCartBottom = New System.Windows.Forms.Panel()
        Me.lblCartTotal = New System.Windows.Forms.Label()
        Me.btnKioskEditItem = New System.Windows.Forms.Button()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.btnAddMore = New System.Windows.Forms.Button()
        Me.pnlCartItems = New System.Windows.Forms.Panel()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPayment = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPaymentCancel = New System.Windows.Forms.Button()
        Me.btnPaymentBack = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.btnSalaryDeduction = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblPaymentTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlQueue = New System.Windows.Forms.Panel()
        Me.btnKioskProceed = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblQueueMessage = New System.Windows.Forms.Label()
        Me.lblQueueTotal = New System.Windows.Forms.Label()
        Me.lblQueuePayment = New System.Windows.Forms.Label()
        Me.lblQueueNumber = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnKioskStaffExit = New System.Windows.Forms.Button()
        Me.pnlWelcome.SuspendLayout()
        Me.pnlOrderType.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMenu.SuspendLayout()
        Me.flpProducts.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCart.SuspendLayout()
        Me.pnlCartBottom.SuspendLayout()
        Me.pnlCartItems.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPayment.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlQueue.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWelcome
        '
        Me.pnlWelcome.BackgroundImage = CType(resources.GetObject("pnlWelcome.BackgroundImage"), System.Drawing.Image)
        Me.pnlWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWelcome.Controls.Add(Me.btnKioskReturn)
        Me.pnlWelcome.Controls.Add(Me.btnStartOrder)
        Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWelcome.Location = New System.Drawing.Point(0, 0)
        Me.pnlWelcome.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlWelcome.Name = "pnlWelcome"
        Me.pnlWelcome.Size = New System.Drawing.Size(1067, 554)
        Me.pnlWelcome.TabIndex = 0
        '
        'btnKioskReturn
        '
        Me.btnKioskReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnKioskReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnKioskReturn.FlatAppearance.BorderSize = 0
        Me.btnKioskReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKioskReturn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKioskReturn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnKioskReturn.Location = New System.Drawing.Point(16, 25)
        Me.btnKioskReturn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnKioskReturn.Name = "btnKioskReturn"
        Me.btnKioskReturn.Size = New System.Drawing.Size(147, 37)
        Me.btnKioskReturn.TabIndex = 2
        Me.btnKioskReturn.Text = "← RETURN"
        Me.btnKioskReturn.UseVisualStyleBackColor = False
        '
        'btnStartOrder
        '
        Me.btnStartOrder.BackColor = System.Drawing.Color.Gold
        Me.btnStartOrder.FlatAppearance.BorderSize = 0
        Me.btnStartOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartOrder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartOrder.Location = New System.Drawing.Point(376, 414)
        Me.btnStartOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStartOrder.Name = "btnStartOrder"
        Me.btnStartOrder.Size = New System.Drawing.Size(253, 50)
        Me.btnStartOrder.TabIndex = 1
        Me.btnStartOrder.Text = "START ORDER ->"
        Me.btnStartOrder.UseVisualStyleBackColor = False
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
        Me.pnlOrderType.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlOrderType.Name = "pnlOrderType"
        Me.pnlOrderType.Size = New System.Drawing.Size(1067, 554)
        Me.pnlOrderType.TabIndex = 2
        Me.pnlOrderType.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gold
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.Location = New System.Drawing.Point(641, 244)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(133, 62)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gold
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(309, 244)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 62)
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
        Me.btnTakeOut.Location = New System.Drawing.Point(572, 207)
        Me.btnTakeOut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTakeOut.Name = "btnTakeOut"
        Me.btnTakeOut.Size = New System.Drawing.Size(279, 151)
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
        Me.btnDineIn.Location = New System.Drawing.Point(236, 207)
        Me.btnDineIn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDineIn.Name = "btnDineIn"
        Me.btnDineIn.Size = New System.Drawing.Size(279, 151)
        Me.btnDineIn.TabIndex = 2
        Me.btnDineIn.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dine-in"
        Me.btnDineIn.UseVisualStyleBackColor = False
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
        Me.pnlMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(1067, 554)
        Me.pnlMenu.TabIndex = 6
        Me.pnlMenu.Visible = False
        '
        'btnViewOrder
        '
        Me.btnViewOrder.BackColor = System.Drawing.Color.Gold
        Me.btnViewOrder.FlatAppearance.BorderSize = 0
        Me.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewOrder.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewOrder.Location = New System.Drawing.Point(705, 490)
        Me.btnViewOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewOrder.Name = "btnViewOrder"
        Me.btnViewOrder.Size = New System.Drawing.Size(244, 49)
        Me.btnViewOrder.TabIndex = 6
        Me.btnViewOrder.Text = "VIEW ORDER "
        Me.btnViewOrder.UseVisualStyleBackColor = False
        '
        'btnStartOver
        '
        Me.btnStartOver.BackColor = System.Drawing.Color.Gold
        Me.btnStartOver.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnStartOver.FlatAppearance.BorderSize = 0
        Me.btnStartOver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartOver.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartOver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnStartOver.Location = New System.Drawing.Point(271, 490)
        Me.btnStartOver.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStartOver.Name = "btnStartOver"
        Me.btnStartOver.Size = New System.Drawing.Size(244, 49)
        Me.btnStartOver.TabIndex = 5
        Me.btnStartOver.Text = "START OVER"
        Me.btnStartOver.UseVisualStyleBackColor = False
        '
        'flpProducts
        '
        Me.flpProducts.AutoScroll = True
        Me.flpProducts.Controls.Add(Me.ucPhKiosk1)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk2)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk3)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk4)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk5)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk6)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk7)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk8)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk9)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk10)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk11)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk12)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk13)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk14)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk15)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk16)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk17)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk18)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk19)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk20)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk21)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk22)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk23)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk24)
        Me.flpProducts.Controls.Add(Me.ucPhKiosk25)
        Me.flpProducts.Location = New System.Drawing.Point(271, 94)
        Me.flpProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.flpProducts.Name = "flpProducts"
        Me.flpProducts.Size = New System.Drawing.Size(692, 370)
        Me.flpProducts.TabIndex = 3
        '
        'ucPhKiosk1
        '
        Me.ucPhKiosk1.ItemName = ""
        Me.ucPhKiosk1.Location = New System.Drawing.Point(4, 4)
        Me.ucPhKiosk1.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk1.Name = "ucPhKiosk1"
        Me.ucPhKiosk1.PreviewEnabled = True
        Me.ucPhKiosk1.PreviewText = "Adobo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱65.00"
        Me.ucPhKiosk1.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk1.ProductId = 0
        Me.ucPhKiosk1.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk1.Stock = 0
        Me.ucPhKiosk1.TabIndex = 0
        Me.ucPhKiosk1.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk2
        '
        Me.ucPhKiosk2.ItemName = ""
        Me.ucPhKiosk2.Location = New System.Drawing.Point(112, 4)
        Me.ucPhKiosk2.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk2.Name = "ucPhKiosk2"
        Me.ucPhKiosk2.PreviewEnabled = True
        Me.ucPhKiosk2.PreviewText = "Longganisa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱45.00"
        Me.ucPhKiosk2.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk2.ProductId = 0
        Me.ucPhKiosk2.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk2.Stock = 0
        Me.ucPhKiosk2.TabIndex = 1
        Me.ucPhKiosk2.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk3
        '
        Me.ucPhKiosk3.ItemName = ""
        Me.ucPhKiosk3.Location = New System.Drawing.Point(220, 4)
        Me.ucPhKiosk3.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk3.Name = "ucPhKiosk3"
        Me.ucPhKiosk3.PreviewEnabled = True
        Me.ucPhKiosk3.PreviewText = "Rice" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱15.00"
        Me.ucPhKiosk3.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk3.ProductId = 0
        Me.ucPhKiosk3.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk3.Stock = 0
        Me.ucPhKiosk3.TabIndex = 2
        Me.ucPhKiosk3.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk4
        '
        Me.ucPhKiosk4.ItemName = ""
        Me.ucPhKiosk4.Location = New System.Drawing.Point(328, 4)
        Me.ucPhKiosk4.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk4.Name = "ucPhKiosk4"
        Me.ucPhKiosk4.PreviewEnabled = True
        Me.ucPhKiosk4.PreviewText = "Spam" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱45.00"
        Me.ucPhKiosk4.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk4.ProductId = 0
        Me.ucPhKiosk4.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk4.Stock = 0
        Me.ucPhKiosk4.TabIndex = 3
        Me.ucPhKiosk4.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk5
        '
        Me.ucPhKiosk5.ItemName = ""
        Me.ucPhKiosk5.Location = New System.Drawing.Point(436, 4)
        Me.ucPhKiosk5.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk5.Name = "ucPhKiosk5"
        Me.ucPhKiosk5.PreviewEnabled = True
        Me.ucPhKiosk5.PreviewText = "Shanghai" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhKiosk5.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk5.ProductId = 0
        Me.ucPhKiosk5.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk5.Stock = 0
        Me.ucPhKiosk5.TabIndex = 4
        Me.ucPhKiosk5.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk6
        '
        Me.ucPhKiosk6.ItemName = ""
        Me.ucPhKiosk6.Location = New System.Drawing.Point(544, 4)
        Me.ucPhKiosk6.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk6.Name = "ucPhKiosk6"
        Me.ucPhKiosk6.PreviewEnabled = True
        Me.ucPhKiosk6.PreviewText = "Siomai Big" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱10.00"
        Me.ucPhKiosk6.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk6.ProductId = 0
        Me.ucPhKiosk6.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk6.Stock = 0
        Me.ucPhKiosk6.TabIndex = 5
        Me.ucPhKiosk6.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk7
        '
        Me.ucPhKiosk7.ItemName = ""
        Me.ucPhKiosk7.Location = New System.Drawing.Point(4, 72)
        Me.ucPhKiosk7.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk7.Name = "ucPhKiosk7"
        Me.ucPhKiosk7.PreviewEnabled = True
        Me.ucPhKiosk7.PreviewText = "Siomai Small" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱6.00"
        Me.ucPhKiosk7.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk7.ProductId = 0
        Me.ucPhKiosk7.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk7.Stock = 0
        Me.ucPhKiosk7.TabIndex = 6
        Me.ucPhKiosk7.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk8
        '
        Me.ucPhKiosk8.ItemName = ""
        Me.ucPhKiosk8.Location = New System.Drawing.Point(112, 72)
        Me.ucPhKiosk8.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk8.Name = "ucPhKiosk8"
        Me.ucPhKiosk8.PreviewEnabled = True
        Me.ucPhKiosk8.PreviewText = "Siopao" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱35.00"
        Me.ucPhKiosk8.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk8.ProductId = 0
        Me.ucPhKiosk8.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk8.Stock = 0
        Me.ucPhKiosk8.TabIndex = 7
        Me.ucPhKiosk8.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk9
        '
        Me.ucPhKiosk9.ItemName = ""
        Me.ucPhKiosk9.Location = New System.Drawing.Point(220, 72)
        Me.ucPhKiosk9.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk9.Name = "ucPhKiosk9"
        Me.ucPhKiosk9.PreviewEnabled = True
        Me.ucPhKiosk9.PreviewText = "Turon" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhKiosk9.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk9.ProductId = 0
        Me.ucPhKiosk9.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk9.Stock = 0
        Me.ucPhKiosk9.TabIndex = 8
        Me.ucPhKiosk9.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk10
        '
        Me.ucPhKiosk10.ItemName = ""
        Me.ucPhKiosk10.Location = New System.Drawing.Point(328, 72)
        Me.ucPhKiosk10.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk10.Name = "ucPhKiosk10"
        Me.ucPhKiosk10.PreviewEnabled = True
        Me.ucPhKiosk10.PreviewText = "Corndog" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱35.00"
        Me.ucPhKiosk10.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk10.ProductId = 0
        Me.ucPhKiosk10.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk10.Stock = 0
        Me.ucPhKiosk10.TabIndex = 9
        Me.ucPhKiosk10.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk11
        '
        Me.ucPhKiosk11.ItemName = ""
        Me.ucPhKiosk11.Location = New System.Drawing.Point(436, 72)
        Me.ucPhKiosk11.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk11.Name = "ucPhKiosk11"
        Me.ucPhKiosk11.PreviewEnabled = True
        Me.ucPhKiosk11.PreviewText = "Mineral Water" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱15.00"
        Me.ucPhKiosk11.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk11.ProductId = 0
        Me.ucPhKiosk11.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk11.Stock = 0
        Me.ucPhKiosk11.TabIndex = 10
        Me.ucPhKiosk11.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk12
        '
        Me.ucPhKiosk12.ItemName = ""
        Me.ucPhKiosk12.Location = New System.Drawing.Point(544, 72)
        Me.ucPhKiosk12.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk12.Name = "ucPhKiosk12"
        Me.ucPhKiosk12.PreviewEnabled = True
        Me.ucPhKiosk12.PreviewText = "Lipton Ice Tea" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱25.00"
        Me.ucPhKiosk12.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk12.ProductId = 0
        Me.ucPhKiosk12.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk12.Stock = 0
        Me.ucPhKiosk12.TabIndex = 11
        Me.ucPhKiosk12.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk13
        '
        Me.ucPhKiosk13.ItemName = ""
        Me.ucPhKiosk13.Location = New System.Drawing.Point(4, 140)
        Me.ucPhKiosk13.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk13.Name = "ucPhKiosk13"
        Me.ucPhKiosk13.PreviewEnabled = True
        Me.ucPhKiosk13.PreviewText = "Milo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱18.00"
        Me.ucPhKiosk13.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk13.ProductId = 0
        Me.ucPhKiosk13.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk13.Stock = 0
        Me.ucPhKiosk13.TabIndex = 12
        Me.ucPhKiosk13.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk14
        '
        Me.ucPhKiosk14.ItemName = ""
        Me.ucPhKiosk14.Location = New System.Drawing.Point(112, 140)
        Me.ucPhKiosk14.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk14.Name = "ucPhKiosk14"
        Me.ucPhKiosk14.PreviewEnabled = True
        Me.ucPhKiosk14.PreviewText = "Kopiko" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱18.00"
        Me.ucPhKiosk14.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk14.ProductId = 0
        Me.ucPhKiosk14.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk14.Stock = 0
        Me.ucPhKiosk14.TabIndex = 13
        Me.ucPhKiosk14.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk15
        '
        Me.ucPhKiosk15.ItemName = ""
        Me.ucPhKiosk15.Location = New System.Drawing.Point(220, 140)
        Me.ucPhKiosk15.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk15.Name = "ucPhKiosk15"
        Me.ucPhKiosk15.PreviewEnabled = True
        Me.ucPhKiosk15.PreviewText = "Iced Kopiko" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱26.00"
        Me.ucPhKiosk15.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk15.ProductId = 0
        Me.ucPhKiosk15.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk15.Stock = 0
        Me.ucPhKiosk15.TabIndex = 14
        Me.ucPhKiosk15.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk16
        '
        Me.ucPhKiosk16.ItemName = ""
        Me.ucPhKiosk16.Location = New System.Drawing.Point(328, 140)
        Me.ucPhKiosk16.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk16.Name = "ucPhKiosk16"
        Me.ucPhKiosk16.PreviewEnabled = True
        Me.ucPhKiosk16.PreviewText = "Ice Cream" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhKiosk16.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk16.ProductId = 0
        Me.ucPhKiosk16.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk16.Stock = 0
        Me.ucPhKiosk16.TabIndex = 15
        Me.ucPhKiosk16.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk17
        '
        Me.ucPhKiosk17.ItemName = ""
        Me.ucPhKiosk17.Location = New System.Drawing.Point(436, 140)
        Me.ucPhKiosk17.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk17.Name = "ucPhKiosk17"
        Me.ucPhKiosk17.PreviewEnabled = True
        Me.ucPhKiosk17.PreviewText = "Fudgee Bar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱12.00"
        Me.ucPhKiosk17.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk17.ProductId = 0
        Me.ucPhKiosk17.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk17.Stock = 0
        Me.ucPhKiosk17.TabIndex = 16
        Me.ucPhKiosk17.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk18
        '
        Me.ucPhKiosk18.ItemName = ""
        Me.ucPhKiosk18.Location = New System.Drawing.Point(544, 140)
        Me.ucPhKiosk18.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk18.Name = "ucPhKiosk18"
        Me.ucPhKiosk18.PreviewEnabled = True
        Me.ucPhKiosk18.PreviewText = "Dowee Donut" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhKiosk18.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk18.ProductId = 0
        Me.ucPhKiosk18.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk18.Stock = 0
        Me.ucPhKiosk18.TabIndex = 17
        Me.ucPhKiosk18.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk19
        '
        Me.ucPhKiosk19.ItemName = ""
        Me.ucPhKiosk19.Location = New System.Drawing.Point(4, 208)
        Me.ucPhKiosk19.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk19.Name = "ucPhKiosk19"
        Me.ucPhKiosk19.PreviewEnabled = True
        Me.ucPhKiosk19.PreviewText = "Oreo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱12.00"
        Me.ucPhKiosk19.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk19.ProductId = 0
        Me.ucPhKiosk19.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk19.Stock = 0
        Me.ucPhKiosk19.TabIndex = 18
        Me.ucPhKiosk19.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk20
        '
        Me.ucPhKiosk20.ItemName = ""
        Me.ucPhKiosk20.Location = New System.Drawing.Point(112, 208)
        Me.ucPhKiosk20.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk20.Name = "ucPhKiosk20"
        Me.ucPhKiosk20.PreviewEnabled = True
        Me.ucPhKiosk20.PreviewText = "Chocolate Cake" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱25.00"
        Me.ucPhKiosk20.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk20.ProductId = 0
        Me.ucPhKiosk20.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk20.Stock = 0
        Me.ucPhKiosk20.TabIndex = 19
        Me.ucPhKiosk20.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk21
        '
        Me.ucPhKiosk21.ItemName = ""
        Me.ucPhKiosk21.Location = New System.Drawing.Point(220, 208)
        Me.ucPhKiosk21.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk21.Name = "ucPhKiosk21"
        Me.ucPhKiosk21.PreviewEnabled = True
        Me.ucPhKiosk21.PreviewText = "Cup Noodles Bulalo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱30.00"
        Me.ucPhKiosk21.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk21.ProductId = 0
        Me.ucPhKiosk21.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk21.Stock = 0
        Me.ucPhKiosk21.TabIndex = 20
        Me.ucPhKiosk21.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk22
        '
        Me.ucPhKiosk22.ItemName = ""
        Me.ucPhKiosk22.Location = New System.Drawing.Point(328, 208)
        Me.ucPhKiosk22.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk22.Name = "ucPhKiosk22"
        Me.ucPhKiosk22.PreviewEnabled = True
        Me.ucPhKiosk22.PreviewText = "Cup Noodles Seafood" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱30.00"
        Me.ucPhKiosk22.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk22.ProductId = 0
        Me.ucPhKiosk22.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk22.Stock = 0
        Me.ucPhKiosk22.TabIndex = 21
        Me.ucPhKiosk22.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk23
        '
        Me.ucPhKiosk23.ItemName = ""
        Me.ucPhKiosk23.Location = New System.Drawing.Point(436, 208)
        Me.ucPhKiosk23.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk23.Name = "ucPhKiosk23"
        Me.ucPhKiosk23.PreviewEnabled = True
        Me.ucPhKiosk23.PreviewText = "Pancit Canton" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱20.00"
        Me.ucPhKiosk23.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk23.ProductId = 0
        Me.ucPhKiosk23.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk23.Stock = 0
        Me.ucPhKiosk23.TabIndex = 22
        Me.ucPhKiosk23.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk24
        '
        Me.ucPhKiosk24.ItemName = ""
        Me.ucPhKiosk24.Location = New System.Drawing.Point(544, 208)
        Me.ucPhKiosk24.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk24.Name = "ucPhKiosk24"
        Me.ucPhKiosk24.PreviewEnabled = True
        Me.ucPhKiosk24.PreviewText = "Lucky Me Noodles" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱18.00"
        Me.ucPhKiosk24.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk24.ProductId = 0
        Me.ucPhKiosk24.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk24.Stock = 0
        Me.ucPhKiosk24.TabIndex = 23
        Me.ucPhKiosk24.Tag = "PLACEHOLDER_DESIGNONLY"
        '
        'ucPhKiosk25
        '
        Me.ucPhKiosk25.ItemName = ""
        Me.ucPhKiosk25.Location = New System.Drawing.Point(4, 276)
        Me.ucPhKiosk25.Margin = New System.Windows.Forms.Padding(4)
        Me.ucPhKiosk25.Name = "ucPhKiosk25"
        Me.ucPhKiosk25.PreviewEnabled = True
        Me.ucPhKiosk25.PreviewText = "Lucky Me Pancit Canton" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "₱25.00"
        Me.ucPhKiosk25.Price = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucPhKiosk25.ProductId = 0
        Me.ucPhKiosk25.Size = New System.Drawing.Size(100, 60)
        Me.ucPhKiosk25.Stock = 0
        Me.ucPhKiosk25.TabIndex = 24
        Me.ucPhKiosk25.Tag = "PLACEHOLDER_DESIGNONLY"
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
        Me.Panel1.Location = New System.Drawing.Point(-7, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(245, 554)
        Me.Panel1.TabIndex = 0
        '
        'btnDesserts
        '
        Me.btnDesserts.BackColor = System.Drawing.Color.Gold
        Me.btnDesserts.FlatAppearance.BorderSize = 0
        Me.btnDesserts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesserts.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesserts.Location = New System.Drawing.Point(23, 366)
        Me.btnDesserts.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDesserts.Name = "btnDesserts"
        Me.btnDesserts.Size = New System.Drawing.Size(212, 49)
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
        Me.btnInstant.Location = New System.Drawing.Point(23, 309)
        Me.btnInstant.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInstant.Name = "btnInstant"
        Me.btnInstant.Size = New System.Drawing.Size(212, 49)
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
        Me.btnAllItems.Location = New System.Drawing.Point(23, 70)
        Me.btnAllItems.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAllItems.Name = "btnAllItems"
        Me.btnAllItems.Size = New System.Drawing.Size(212, 49)
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
        Me.btnSnacks.Location = New System.Drawing.Point(23, 183)
        Me.btnSnacks.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSnacks.Name = "btnSnacks"
        Me.btnSnacks.Size = New System.Drawing.Size(212, 49)
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
        Me.btnMeals.Location = New System.Drawing.Point(23, 127)
        Me.btnMeals.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMeals.Name = "btnMeals"
        Me.btnMeals.Size = New System.Drawing.Size(212, 49)
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
        Me.btnDrinks.Location = New System.Drawing.Point(23, 240)
        Me.btnDrinks.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDrinks.Name = "btnDrinks"
        Me.btnDrinks.Size = New System.Drawing.Size(212, 49)
        Me.btnDrinks.TabIndex = 1
        Me.btnDrinks.Text = "🥤 DRINKS"
        Me.btnDrinks.UseVisualStyleBackColor = False
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
        Me.pnlCart.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCart.Name = "pnlCart"
        Me.pnlCart.Size = New System.Drawing.Size(1067, 554)
        Me.pnlCart.TabIndex = 2
        Me.pnlCart.Visible = False
        '
        'pnlCartBottom
        '
        Me.pnlCartBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.pnlCartBottom.Controls.Add(Me.lblCartTotal)
        Me.pnlCartBottom.Controls.Add(Me.btnKioskEditItem)
        Me.pnlCartBottom.Controls.Add(Me.btnPlaceOrder)
        Me.pnlCartBottom.Controls.Add(Me.btnAddMore)
        Me.pnlCartBottom.Location = New System.Drawing.Point(257, 398)
        Me.pnlCartBottom.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCartBottom.Name = "pnlCartBottom"
        Me.pnlCartBottom.Size = New System.Drawing.Size(552, 124)
        Me.pnlCartBottom.TabIndex = 2
        '
        'lblCartTotal
        '
        Me.lblCartTotal.AutoSize = True
        Me.lblCartTotal.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartTotal.ForeColor = System.Drawing.Color.White
        Me.lblCartTotal.Location = New System.Drawing.Point(183, 9)
        Me.lblCartTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCartTotal.Name = "lblCartTotal"
        Me.lblCartTotal.Size = New System.Drawing.Size(184, 37)
        Me.lblCartTotal.TabIndex = 2
        Me.lblCartTotal.Text = "TOTAL: ₱0.00"
        '
        'btnKioskEditItem
        '
        Me.btnKioskEditItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnKioskEditItem.FlatAppearance.BorderSize = 0
        Me.btnKioskEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKioskEditItem.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKioskEditItem.ForeColor = System.Drawing.Color.White
        Me.btnKioskEditItem.Location = New System.Drawing.Point(216, 57)
        Me.btnKioskEditItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btnKioskEditItem.Name = "btnKioskEditItem"
        Me.btnKioskEditItem.Size = New System.Drawing.Size(127, 47)
        Me.btnKioskEditItem.TabIndex = 3
        Me.btnKioskEditItem.Text = "✏ EDIT ITEM"
        Me.btnKioskEditItem.UseVisualStyleBackColor = False
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPlaceOrder.FlatAppearance.BorderSize = 0
        Me.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlaceOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaceOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnPlaceOrder.Location = New System.Drawing.Point(341, 57)
        Me.btnPlaceOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(203, 47)
        Me.btnPlaceOrder.TabIndex = 1
        Me.btnPlaceOrder.Text = "PLACE ORDER →"
        Me.btnPlaceOrder.UseVisualStyleBackColor = False
        '
        'btnAddMore
        '
        Me.btnAddMore.BackColor = System.Drawing.Color.Gold
        Me.btnAddMore.FlatAppearance.BorderSize = 0
        Me.btnAddMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMore.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMore.ForeColor = System.Drawing.Color.White
        Me.btnAddMore.Location = New System.Drawing.Point(11, 57)
        Me.btnAddMore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddMore.Name = "btnAddMore"
        Me.btnAddMore.Size = New System.Drawing.Size(197, 47)
        Me.btnAddMore.TabIndex = 0
        Me.btnAddMore.Text = " ← ADD MORE ITEMS"
        Me.btnAddMore.UseVisualStyleBackColor = False
        '
        'pnlCartItems
        '
        Me.pnlCartItems.BackColor = System.Drawing.Color.White
        Me.pnlCartItems.Controls.Add(Me.dgvCart)
        Me.pnlCartItems.Location = New System.Drawing.Point(277, 139)
        Me.pnlCartItems.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCartItems.Name = "pnlCartItems"
        Me.pnlCartItems.Size = New System.Drawing.Size(515, 238)
        Me.pnlCartItems.TabIndex = 1
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCart.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colQty, Me.colPrice, Me.colSubtotal, Me.colDelete})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCart.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCart.EnableHeadersVisualStyles = False
        Me.dgvCart.GridColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCart.Location = New System.Drawing.Point(0, 0)
        Me.dgvCart.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersVisible = False
        Me.dgvCart.RowHeadersWidth = 51
        Me.dgvCart.Size = New System.Drawing.Size(515, 263)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(375, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "YOUR ORDER"
        '
        'pnlPayment
        '
        Me.pnlPayment.BackgroundImage = CType(resources.GetObject("pnlPayment.BackgroundImage"), System.Drawing.Image)
        Me.pnlPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlPayment.Controls.Add(Me.Panel2)
        Me.pnlPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPayment.Location = New System.Drawing.Point(0, 0)
        Me.pnlPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlPayment.Name = "pnlPayment"
        Me.pnlPayment.Size = New System.Drawing.Size(1067, 554)
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
        Me.Panel2.Location = New System.Drawing.Point(65, 74)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(897, 460)
        Me.Panel2.TabIndex = 0
        '
        'btnPaymentCancel
        '
        Me.btnPaymentCancel.BackColor = System.Drawing.Color.Gold
        Me.btnPaymentCancel.FlatAppearance.BorderSize = 0
        Me.btnPaymentCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaymentCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentCancel.Location = New System.Drawing.Point(652, 399)
        Me.btnPaymentCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPaymentCancel.Name = "btnPaymentCancel"
        Me.btnPaymentCancel.Size = New System.Drawing.Size(232, 41)
        Me.btnPaymentCancel.TabIndex = 8
        Me.btnPaymentCancel.Text = "✕ CANCEL ORDER"
        Me.btnPaymentCancel.UseVisualStyleBackColor = False
        '
        'btnPaymentBack
        '
        Me.btnPaymentBack.BackColor = System.Drawing.Color.Gold
        Me.btnPaymentBack.FlatAppearance.BorderSize = 0
        Me.btnPaymentBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaymentBack.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentBack.Location = New System.Drawing.Point(45, 399)
        Me.btnPaymentBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPaymentBack.Name = "btnPaymentBack"
        Me.btnPaymentBack.Size = New System.Drawing.Size(169, 41)
        Me.btnPaymentBack.TabIndex = 7
        Me.btnPaymentBack.Text = "← BACK TO CART"
        Me.btnPaymentBack.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Gold
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox4.Location = New System.Drawing.Point(511, 201)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(133, 69)
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gold
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox3.Location = New System.Drawing.Point(212, 201)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(133, 69)
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'btnCash
        '
        Me.btnCash.BackColor = System.Drawing.Color.Gold
        Me.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCash.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCash.Location = New System.Drawing.Point(489, 187)
        Me.btnCash.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(189, 154)
        Me.btnCash.TabIndex = 4
        Me.btnCash.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CASH"
        Me.btnCash.UseVisualStyleBackColor = False
        '
        'btnSalaryDeduction
        '
        Me.btnSalaryDeduction.BackColor = System.Drawing.Color.Gold
        Me.btnSalaryDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalaryDeduction.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalaryDeduction.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalaryDeduction.Location = New System.Drawing.Point(188, 188)
        Me.btnSalaryDeduction.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalaryDeduction.Name = "btnSalaryDeduction"
        Me.btnSalaryDeduction.Size = New System.Drawing.Size(189, 154)
        Me.btnSalaryDeduction.TabIndex = 3
        Me.btnSalaryDeduction.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SALARY DEDUCTION"
        Me.btnSalaryDeduction.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblPaymentTotal)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(244, 78)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(416, 90)
        Me.Panel3.TabIndex = 2
        '
        'lblPaymentTotal
        '
        Me.lblPaymentTotal.AutoSize = True
        Me.lblPaymentTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPaymentTotal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTotal.ForeColor = System.Drawing.Color.Gold
        Me.lblPaymentTotal.Location = New System.Drawing.Point(152, 39)
        Me.lblPaymentTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPaymentTotal.Name = "lblPaymentTotal"
        Me.lblPaymentTotal.Size = New System.Drawing.Size(78, 32)
        Me.lblPaymentTotal.TabIndex = 2
        Me.lblPaymentTotal.Text = "₱0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(113, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 28)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "TOTAL AMOUNT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(160, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(563, 54)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SELECT PAYMENT METHOD"
        '
        'pnlQueue
        '
        Me.pnlQueue.BackgroundImage = CType(resources.GetObject("pnlQueue.BackgroundImage"), System.Drawing.Image)
        Me.pnlQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlQueue.Controls.Add(Me.btnKioskProceed)
        Me.pnlQueue.Controls.Add(Me.Panel4)
        Me.pnlQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlQueue.Location = New System.Drawing.Point(0, 0)
        Me.pnlQueue.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlQueue.Name = "pnlQueue"
        Me.pnlQueue.Size = New System.Drawing.Size(1067, 554)
        Me.pnlQueue.TabIndex = 2
        Me.pnlQueue.Visible = False
        '
        'btnKioskProceed
        '
        Me.btnKioskProceed.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnKioskProceed.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnKioskProceed.FlatAppearance.BorderSize = 0
        Me.btnKioskProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKioskProceed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKioskProceed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnKioskProceed.Location = New System.Drawing.Point(387, 468)
        Me.btnKioskProceed.Margin = New System.Windows.Forms.Padding(4)
        Me.btnKioskProceed.Name = "btnKioskProceed"
        Me.btnKioskProceed.Size = New System.Drawing.Size(293, 54)
        Me.btnKioskProceed.TabIndex = 1
        Me.btnKioskProceed.Text = "PROCEED  →"
        Me.btnKioskProceed.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Controls.Add(Me.lblQueueMessage)
        Me.Panel4.Controls.Add(Me.lblQueueTotal)
        Me.Panel4.Controls.Add(Me.lblQueuePayment)
        Me.Panel4.Controls.Add(Me.lblQueueNumber)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Location = New System.Drawing.Point(253, 127)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(604, 327)
        Me.Panel4.TabIndex = 0
        '
        'lblQueueMessage
        '
        Me.lblQueueMessage.AutoSize = True
        Me.lblQueueMessage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueMessage.Location = New System.Drawing.Point(183, 263)
        Me.lblQueueMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQueueMessage.Name = "lblQueueMessage"
        Me.lblQueueMessage.Size = New System.Drawing.Size(262, 28)
        Me.lblQueueMessage.TabIndex = 5
        Me.lblQueueMessage.Text = "Please wait for your order."
        '
        'lblQueueTotal
        '
        Me.lblQueueTotal.AutoSize = True
        Me.lblQueueTotal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueTotal.Location = New System.Drawing.Point(68, 212)
        Me.lblQueueTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQueueTotal.Name = "lblQueueTotal"
        Me.lblQueueTotal.Size = New System.Drawing.Size(191, 32)
        Me.lblQueueTotal.TabIndex = 4
        Me.lblQueueTotal.Text = "TOTAL: ₱125.00"
        '
        'lblQueuePayment
        '
        Me.lblQueuePayment.AutoSize = True
        Me.lblQueuePayment.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueuePayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueuePayment.Location = New System.Drawing.Point(68, 172)
        Me.lblQueuePayment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQueuePayment.Name = "lblQueuePayment"
        Me.lblQueuePayment.Size = New System.Drawing.Size(204, 32)
        Me.lblQueuePayment.TabIndex = 3
        Me.lblQueuePayment.Text = "PAYMENT: CASH"
        '
        'lblQueueNumber
        '
        Me.lblQueueNumber.AutoSize = True
        Me.lblQueueNumber.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueNumber.Location = New System.Drawing.Point(249, 78)
        Me.lblQueueNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQueueNumber.Name = "lblQueueNumber"
        Me.lblQueueNumber.Size = New System.Drawing.Size(149, 60)
        Me.lblQueueNumber.TabIndex = 2
        Me.lblQueueNumber.Text = "A-023"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(163, 31)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(308, 37)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "YOUR QUEUE NUMBER"
        '
        'btnKioskStaffExit
        '
        Me.btnKioskStaffExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKioskStaffExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnKioskStaffExit.FlatAppearance.BorderSize = 0
        Me.btnKioskStaffExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKioskStaffExit.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKioskStaffExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnKioskStaffExit.Location = New System.Drawing.Point(931, 7)
        Me.btnKioskStaffExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnKioskStaffExit.Name = "btnKioskStaffExit"
        Me.btnKioskStaffExit.Size = New System.Drawing.Size(120, 32)
        Me.btnKioskStaffExit.TabIndex = 7
        Me.btnKioskStaffExit.Text = "⚙ STAFF"
        Me.btnKioskStaffExit.UseVisualStyleBackColor = False
        '
        'frmKiosk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.pnlCart)
        Me.Controls.Add(Me.pnlWelcome)
        Me.Controls.Add(Me.pnlQueue)
        Me.Controls.Add(Me.pnlPayment)
        Me.Controls.Add(Me.pnlOrderType)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.btnKioskStaffExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmKiosk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlOrderType.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMenu.ResumeLayout(False)
        Me.flpProducts.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlCart.ResumeLayout(False)
        Me.pnlCart.PerformLayout()
        Me.pnlCartBottom.ResumeLayout(False)
        Me.pnlCartBottom.PerformLayout()
        Me.pnlCartItems.ResumeLayout(False)
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPayment.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlQueue.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents btnStartOrder As Button
    Friend WithEvents btnKioskReturn As Button
    Friend WithEvents btnKioskStaffExit As Button
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
    Friend WithEvents ucPhKiosk1 As ucProductButton
    Friend WithEvents ucPhKiosk2 As ucProductButton
    Friend WithEvents ucPhKiosk3 As ucProductButton
    Friend WithEvents ucPhKiosk4 As ucProductButton
    Friend WithEvents ucPhKiosk5 As ucProductButton
    Friend WithEvents ucPhKiosk6 As ucProductButton
    Friend WithEvents ucPhKiosk7 As ucProductButton
    Friend WithEvents ucPhKiosk8 As ucProductButton
    Friend WithEvents ucPhKiosk9 As ucProductButton
    Friend WithEvents ucPhKiosk10 As ucProductButton
    Friend WithEvents ucPhKiosk11 As ucProductButton
    Friend WithEvents ucPhKiosk12 As ucProductButton
    Friend WithEvents ucPhKiosk13 As ucProductButton
    Friend WithEvents ucPhKiosk14 As ucProductButton
    Friend WithEvents ucPhKiosk15 As ucProductButton
    Friend WithEvents ucPhKiosk16 As ucProductButton
    Friend WithEvents ucPhKiosk17 As ucProductButton
    Friend WithEvents ucPhKiosk18 As ucProductButton
    Friend WithEvents ucPhKiosk19 As ucProductButton
    Friend WithEvents ucPhKiosk20 As ucProductButton
    Friend WithEvents ucPhKiosk21 As ucProductButton
    Friend WithEvents ucPhKiosk22 As ucProductButton
    Friend WithEvents ucPhKiosk23 As ucProductButton
    Friend WithEvents ucPhKiosk24 As ucProductButton
    Friend WithEvents ucPhKiosk25 As ucProductButton
    Friend WithEvents btnViewOrder As Button
    Friend WithEvents btnStartOver As Button
    Friend WithEvents pnlCart As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlCartItems As Panel
    Friend WithEvents pnlCartBottom As Panel
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents btnKioskEditItem As Button
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
    Friend WithEvents btnKioskProceed As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblQueueNumber As Label
    Friend WithEvents lblQueueMessage As Label
    Friend WithEvents lblQueueTotal As Label
    Friend WithEvents lblQueuePayment As Label
End Class
