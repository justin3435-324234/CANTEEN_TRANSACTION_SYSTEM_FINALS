<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint25 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint26 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint27 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint28 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint29 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint30 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlMainContent = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.movement_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMovementType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpReportto = New System.Windows.Forms.DateTimePicker()
        Me.dtpReportFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.pnlReportHeader = New System.Windows.Forms.Panel()
        Me.lblReportSubtitle = New System.Windows.Forms.Label()
        Me.lblReportTitle = New System.Windows.Forms.Label()
        Me.lblSystemTitle = New System.Windows.Forms.Label()
        Me.pnlDashboardView = New System.Windows.Forms.Panel()
        Me.pnlInventoryAlerts = New System.Windows.Forms.Panel()
        Me.lblOutStockVal = New System.Windows.Forms.Label()
        Me.lblLowSValue = New System.Windows.Forms.Label()
        Me.lblInStockValue = New System.Windows.Forms.Label()
        Me.lblOut = New System.Windows.Forms.Label()
        Me.lblLowStockIcon = New System.Windows.Forms.Label()
        Me.lblInStockIcon = New System.Windows.Forms.Label()
        Me.lblInventoryAlerts = New System.Windows.Forms.Label()
        Me.pnlRecentTransactions = New System.Windows.Forms.Panel()
        Me.btnViewAll = New System.Windows.Forms.Label()
        Me.dgvRecentTransactions = New System.Windows.Forms.DataGridView()
        Me.colTransactionNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransactionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentMethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cardSalaryDeduction = New System.Windows.Forms.Panel()
        Me.lblSalaryDeductionVal = New System.Windows.Forms.Label()
        Me.lblDeductTitle = New System.Windows.Forms.Label()
        Me.cardItemsSold = New System.Windows.Forms.Panel()
        Me.lblItemsSoldVal = New System.Windows.Forms.Label()
        Me.lblDeductionTitle = New System.Windows.Forms.Label()
        Me.cardTransactions = New System.Windows.Forms.Panel()
        Me.lblTransactionsVal = New System.Windows.Forms.Label()
        Me.lblTransTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTodaySalesVal = New System.Windows.Forms.Label()
        Me.lblSalesTitle = New System.Windows.Forms.Label()
        Me.pnlInventoryView = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvInventoryHistory = New System.Windows.Forms.DataGridView()
        Me.product_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reorder_level = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.txtSearchProducts = New System.Windows.Forms.TextBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.pnlOutOfStock = New System.Windows.Forms.Panel()
        Me.lblOutOfStockValue = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.pnlLowStock = New System.Windows.Forms.Panel()
        Me.lblLowStockValue = New System.Windows.Forms.Label()
        Me.lblLowStockTitle = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.pnlTotalItems = New System.Windows.Forms.Panel()
        Me.lblTotalItemsValue = New System.Windows.Forms.Label()
        Me.lblTotalItemsTitle = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnEditProduct = New System.Windows.Forms.Button()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.btnRestock = New System.Windows.Forms.Button()
        Me.btnDeactivateProduct = New System.Windows.Forms.Button()
        Me.pnlSalaryDeductionView = New System.Windows.Forms.Panel()
        Me.flowLayoutPanelActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnEdit1 = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlLimitReached = New System.Windows.Forms.Panel()
        Me.lblCompletedDeduction = New System.Windows.Forms.Label()
        Me.lblCompletedDeductionTitle = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblPendingCount = New System.Windows.Forms.Label()
        Me.pnlPendingDeductions = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlTotalEmployees = New System.Windows.Forms.Panel()
        Me.lblTotalEmployeesCount = New System.Windows.Forms.Label()
        Me.lblTotalEmployees = New System.Windows.Forms.Label()
        Me.dgvTextBoxColumn = New System.Windows.Forms.DataGridView()
        Me.colEmpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeductionStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPeriodStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPeriodEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbRoleFilter = New System.Windows.Forms.ComboBox()
        Me.pnlSettingsView = New System.Windows.Forms.Panel()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnSalaryDeduction = New System.Windows.Forms.Button()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.pnlMainContent.SuspendLayout()
        Me.btnPrint.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlReportHeader.SuspendLayout()
        Me.pnlDashboardView.SuspendLayout()
        Me.pnlInventoryAlerts.SuspendLayout()
        Me.pnlRecentTransactions.SuspendLayout()
        CType(Me.dgvRecentTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardSalaryDeduction.SuspendLayout()
        Me.cardItemsSold.SuspendLayout()
        Me.cardTransactions.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlInventoryView.SuspendLayout()
        CType(Me.dgvInventoryHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.pnlOutOfStock.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.pnlLowStock.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlTotalItems.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlSalaryDeductionView.SuspendLayout()
        Me.flowLayoutPanelActions.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlLimitReached.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlTotalEmployees.SuspendLayout()
        CType(Me.dgvTextBoxColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMainContent
        '
        Me.pnlMainContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlMainContent.Controls.Add(Me.btnPrint)
        Me.pnlMainContent.Controls.Add(Me.pnlSalaryDeductionView)
        Me.pnlMainContent.Controls.Add(Me.pnlInventoryView)
        Me.pnlMainContent.Controls.Add(Me.pnlDashboardView)
        Me.pnlMainContent.Controls.Add(Me.pnlSettingsView)
        Me.pnlMainContent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlMainContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainContent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlMainContent.Name = "pnlMainContent"
        Me.pnlMainContent.Size = New System.Drawing.Size(1067, 554)
        Me.pnlMainContent.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Controls.Add(Me.Button2)
        Me.btnPrint.Controls.Add(Me.btnExportExcel)
        Me.btnPrint.Controls.Add(Me.Button1)
        Me.btnPrint.Controls.Add(Me.dgvReport)
        Me.btnPrint.Controls.Add(Me.Panel13)
        Me.btnPrint.Controls.Add(Me.pnlReportHeader)
        Me.btnPrint.Controls.Add(Me.lblSystemTitle)
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(0, 0)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(1067, 554)
        Me.btnPrint.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gold
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(747, 502)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 37)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Print"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BackColor = System.Drawing.Color.Green
        Me.btnExportExcel.FlatAppearance.BorderSize = 0
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.ForeColor = System.Drawing.Color.White
        Me.btnExportExcel.Location = New System.Drawing.Point(609, 502)
        Me.btnExportExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(127, 37)
        Me.btnExportExcel.TabIndex = 16
        Me.btnExportExcel.Text = "Export to Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(475, 501)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 37)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Export to PDF"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReport.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(104, Byte), Integer))
        DataGridViewCellStyle41.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle41
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.movement_id, Me.colDate, Me.colProduct, Me.colMovementType, Me.colQuantity, Me.colUser, Me.colRemarks})
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle42.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle42.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle42.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReport.DefaultCellStyle = DataGridViewCellStyle42
        Me.dgvReport.GridColor = System.Drawing.Color.Gray
        Me.dgvReport.Location = New System.Drawing.Point(297, 178)
        Me.dgvReport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvReport.MultiSelect = False
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersVisible = False
        Me.dgvReport.RowHeadersWidth = 51
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.Size = New System.Drawing.Size(764, 308)
        Me.dgvReport.TabIndex = 14
        '
        'movement_id
        '
        Me.movement_id.HeaderText = "Movement ID"
        Me.movement_id.MinimumWidth = 6
        Me.movement_id.Name = "movement_id"
        Me.movement_id.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 6
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        '
        'colProduct
        '
        Me.colProduct.HeaderText = "Product"
        Me.colProduct.MinimumWidth = 6
        Me.colProduct.Name = "colProduct"
        Me.colProduct.ReadOnly = True
        '
        'colMovementType
        '
        Me.colMovementType.HeaderText = "Movement Type"
        Me.colMovementType.MinimumWidth = 6
        Me.colMovementType.Name = "colMovementType"
        Me.colMovementType.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.MinimumWidth = 6
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        '
        'colUser
        '
        Me.colUser.HeaderText = "User"
        Me.colUser.MinimumWidth = 6
        Me.colUser.Name = "colUser"
        Me.colUser.ReadOnly = True
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.MinimumWidth = 6
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gold
        Me.Panel13.Controls.Add(Me.Panel14)
        Me.Panel13.Location = New System.Drawing.Point(320, 65)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(729, 106)
        Me.Panel13.TabIndex = 1
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel14.Controls.Add(Me.btnGenerate)
        Me.Panel14.Controls.Add(Me.Label8)
        Me.Panel14.Controls.Add(Me.Label7)
        Me.Panel14.Controls.Add(Me.dtpReportto)
        Me.Panel14.Controls.Add(Me.dtpReportFrom)
        Me.Panel14.Controls.Add(Me.Label6)
        Me.Panel14.Controls.Add(Me.ComboBox1)
        Me.Panel14.Location = New System.Drawing.Point(7, 5)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(719, 96)
        Me.Panel14.TabIndex = 2
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.Gold
        Me.btnGenerate.FlatAppearance.BorderSize = 0
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGenerate.Location = New System.Drawing.Point(345, 42)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(219, 31)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "Generate Report"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gold
        Me.Label8.Location = New System.Drawing.Point(453, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "TO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gold
        Me.Label7.Location = New System.Drawing.Point(261, 10)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 23)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "FROM"
        '
        'dtpReportto
        '
        Me.dtpReportto.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReportto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReportto.Location = New System.Drawing.Point(488, 6)
        Me.dtpReportto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpReportto.Name = "dtpReportto"
        Me.dtpReportto.Size = New System.Drawing.Size(117, 26)
        Me.dtpReportto.TabIndex = 3
        '
        'dtpReportFrom
        '
        Me.dtpReportFrom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReportFrom.Location = New System.Drawing.Point(323, 7)
        Me.dtpReportFrom.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpReportFrom.Name = "dtpReportFrom"
        Me.dtpReportFrom.Size = New System.Drawing.Size(117, 26)
        Me.dtpReportFrom.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gold
        Me.Label6.Location = New System.Drawing.Point(16, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "REPORT TYPE"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 21)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(232, 27)
        Me.ComboBox1.TabIndex = 0
        '
        'pnlReportHeader
        '
        Me.pnlReportHeader.BackColor = System.Drawing.Color.Gold
        Me.pnlReportHeader.Controls.Add(Me.lblReportSubtitle)
        Me.pnlReportHeader.Controls.Add(Me.lblReportTitle)
        Me.pnlReportHeader.Location = New System.Drawing.Point(293, -2)
        Me.pnlReportHeader.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlReportHeader.Name = "pnlReportHeader"
        Me.pnlReportHeader.Size = New System.Drawing.Size(816, 65)
        Me.pnlReportHeader.TabIndex = 0
        '
        'lblReportSubtitle
        '
        Me.lblReportSubtitle.AutoSize = True
        Me.lblReportSubtitle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReportSubtitle.Location = New System.Drawing.Point(9, 44)
        Me.lblReportSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReportSubtitle.Name = "lblReportSubtitle"
        Me.lblReportSubtitle.Size = New System.Drawing.Size(231, 19)
        Me.lblReportSubtitle.TabIndex = 1
        Me.lblReportSubtitle.Text = "Generate and export system reports"
        '
        'lblReportTitle
        '
        Me.lblReportTitle.AutoSize = True
        Me.lblReportTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReportTitle.Location = New System.Drawing.Point(12, 7)
        Me.lblReportTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Size = New System.Drawing.Size(134, 37)
        Me.lblReportTitle.TabIndex = 0
        Me.lblReportTitle.Text = "REPORTS"
        '
        'lblSystemTitle
        '
        Me.lblSystemTitle.AutoSize = True
        Me.lblSystemTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemTitle.Location = New System.Drawing.Point(101, 10)
        Me.lblSystemTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemTitle.Name = "lblSystemTitle"
        Me.lblSystemTitle.Size = New System.Drawing.Size(192, 19)
        Me.lblSystemTitle.TabIndex = 0
        Me.lblSystemTitle.Text = "LYCEUM OF ALABANG"
        '
        'pnlDashboardView
        '
        Me.pnlDashboardView.Controls.Add(Me.pnlInventoryAlerts)
        Me.pnlDashboardView.Controls.Add(Me.pnlRecentTransactions)
        Me.pnlDashboardView.Controls.Add(Me.Chart1)
        Me.pnlDashboardView.Controls.Add(Me.cardSalaryDeduction)
        Me.pnlDashboardView.Controls.Add(Me.cardItemsSold)
        Me.pnlDashboardView.Controls.Add(Me.cardTransactions)
        Me.pnlDashboardView.Controls.Add(Me.Panel1)
        Me.pnlDashboardView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboardView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pnlDashboardView.Location = New System.Drawing.Point(0, 0)
        Me.pnlDashboardView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlDashboardView.Name = "pnlDashboardView"
        Me.pnlDashboardView.Size = New System.Drawing.Size(1067, 554)
        Me.pnlDashboardView.TabIndex = 0
        '
        'pnlInventoryAlerts
        '
        Me.pnlInventoryAlerts.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.pnlInventoryAlerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInventoryAlerts.Controls.Add(Me.lblOutStockVal)
        Me.pnlInventoryAlerts.Controls.Add(Me.lblLowSValue)
        Me.pnlInventoryAlerts.Controls.Add(Me.lblInStockValue)
        Me.pnlInventoryAlerts.Controls.Add(Me.lblOut)
        Me.pnlInventoryAlerts.Controls.Add(Me.lblLowStockIcon)
        Me.pnlInventoryAlerts.Controls.Add(Me.lblInStockIcon)
        Me.pnlInventoryAlerts.Controls.Add(Me.lblInventoryAlerts)
        Me.pnlInventoryAlerts.Location = New System.Drawing.Point(687, 121)
        Me.pnlInventoryAlerts.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlInventoryAlerts.Name = "pnlInventoryAlerts"
        Me.pnlInventoryAlerts.Size = New System.Drawing.Size(363, 211)
        Me.pnlInventoryAlerts.TabIndex = 7
        '
        'lblOutStockVal
        '
        Me.lblOutStockVal.AutoSize = True
        Me.lblOutStockVal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutStockVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOutStockVal.Location = New System.Drawing.Point(203, 126)
        Me.lblOutStockVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOutStockVal.Name = "lblOutStockVal"
        Me.lblOutStockVal.Size = New System.Drawing.Size(28, 32)
        Me.lblOutStockVal.TabIndex = 6
        Me.lblOutStockVal.Text = "0"
        '
        'lblLowSValue
        '
        Me.lblLowSValue.AutoSize = True
        Me.lblLowSValue.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowSValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLowSValue.Location = New System.Drawing.Point(200, 44)
        Me.lblLowSValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLowSValue.Name = "lblLowSValue"
        Me.lblLowSValue.Size = New System.Drawing.Size(28, 32)
        Me.lblLowSValue.TabIndex = 5
        Me.lblLowSValue.Text = "0"
        '
        'lblInStockValue
        '
        Me.lblInStockValue.AutoSize = True
        Me.lblInStockValue.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInStockValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInStockValue.Location = New System.Drawing.Point(200, 87)
        Me.lblInStockValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInStockValue.Name = "lblInStockValue"
        Me.lblInStockValue.Size = New System.Drawing.Size(28, 32)
        Me.lblInStockValue.TabIndex = 4
        Me.lblInStockValue.Text = "0"
        '
        'lblOut
        '
        Me.lblOut.AutoSize = True
        Me.lblOut.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOut.Location = New System.Drawing.Point(15, 133)
        Me.lblOut.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOut.Name = "lblOut"
        Me.lblOut.Size = New System.Drawing.Size(165, 23)
        Me.lblOut.TabIndex = 3
        Me.lblOut.Text = "🟠  OUT OF STOCK"
        '
        'lblLowStockIcon
        '
        Me.lblLowStockIcon.AutoSize = True
        Me.lblLowStockIcon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowStockIcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLowStockIcon.Location = New System.Drawing.Point(15, 95)
        Me.lblLowStockIcon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLowStockIcon.Name = "lblLowStockIcon"
        Me.lblLowStockIcon.Size = New System.Drawing.Size(152, 23)
        Me.lblLowStockIcon.TabIndex = 2
        Me.lblLowStockIcon.Text = "🟠  LOW STOCK  "
        '
        'lblInStockIcon
        '
        Me.lblInStockIcon.AutoSize = True
        Me.lblInStockIcon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInStockIcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInStockIcon.Location = New System.Drawing.Point(15, 53)
        Me.lblInStockIcon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInStockIcon.Name = "lblInStockIcon"
        Me.lblInStockIcon.Size = New System.Drawing.Size(116, 23)
        Me.lblInStockIcon.TabIndex = 1
        Me.lblInStockIcon.Text = "🟢 IN STOCK"
        '
        'lblInventoryAlerts
        '
        Me.lblInventoryAlerts.AutoSize = True
        Me.lblInventoryAlerts.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventoryAlerts.ForeColor = System.Drawing.Color.Gold
        Me.lblInventoryAlerts.Location = New System.Drawing.Point(80, 15)
        Me.lblInventoryAlerts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInventoryAlerts.Name = "lblInventoryAlerts"
        Me.lblInventoryAlerts.Size = New System.Drawing.Size(170, 23)
        Me.lblInventoryAlerts.TabIndex = 0
        Me.lblInventoryAlerts.Text = "INVENTORY ALERTS"
        '
        'pnlRecentTransactions
        '
        Me.pnlRecentTransactions.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.pnlRecentTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRecentTransactions.Controls.Add(Me.btnViewAll)
        Me.pnlRecentTransactions.Controls.Add(Me.dgvRecentTransactions)
        Me.pnlRecentTransactions.Location = New System.Drawing.Point(271, 346)
        Me.pnlRecentTransactions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlRecentTransactions.Name = "pnlRecentTransactions"
        Me.pnlRecentTransactions.Size = New System.Drawing.Size(790, 206)
        Me.pnlRecentTransactions.TabIndex = 6
        '
        'btnViewAll
        '
        Me.btnViewAll.AutoSize = True
        Me.btnViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnViewAll.Location = New System.Drawing.Point(687, 11)
        Me.btnViewAll.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(83, 20)
        Me.btnViewAll.TabIndex = 1
        Me.btnViewAll.Text = "View All →"
        '
        'dgvRecentTransactions
        '
        Me.dgvRecentTransactions.AllowUserToAddRows = False
        Me.dgvRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecentTransactions.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(104, Byte), Integer))
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecentTransactions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle43
        Me.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecentTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTransactionNo, Me.colTransactionDate, Me.colPaymentMethod, Me.colAmount, Me.colStatus1})
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecentTransactions.DefaultCellStyle = DataGridViewCellStyle44
        Me.dgvRecentTransactions.GridColor = System.Drawing.Color.Gray
        Me.dgvRecentTransactions.Location = New System.Drawing.Point(9, 33)
        Me.dgvRecentTransactions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvRecentTransactions.MultiSelect = False
        Me.dgvRecentTransactions.Name = "dgvRecentTransactions"
        Me.dgvRecentTransactions.ReadOnly = True
        Me.dgvRecentTransactions.RowHeadersVisible = False
        Me.dgvRecentTransactions.RowHeadersWidth = 51
        Me.dgvRecentTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecentTransactions.Size = New System.Drawing.Size(764, 167)
        Me.dgvRecentTransactions.TabIndex = 0
        '
        'colTransactionNo
        '
        Me.colTransactionNo.HeaderText = "Transaction No."
        Me.colTransactionNo.MinimumWidth = 6
        Me.colTransactionNo.Name = "colTransactionNo"
        Me.colTransactionNo.ReadOnly = True
        '
        'colTransactionDate
        '
        Me.colTransactionDate.HeaderText = "Date"
        Me.colTransactionDate.MinimumWidth = 6
        Me.colTransactionDate.Name = "colTransactionDate"
        Me.colTransactionDate.ReadOnly = True
        '
        'colPaymentMethod
        '
        Me.colPaymentMethod.HeaderText = "Payment"
        Me.colPaymentMethod.MinimumWidth = 6
        Me.colPaymentMethod.Name = "colPaymentMethod"
        Me.colPaymentMethod.ReadOnly = True
        '
        'colAmount
        '
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MinimumWidth = 6
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'colStatus1
        '
        Me.colStatus1.HeaderText = "Status"
        Me.colStatus1.MinimumWidth = 6
        Me.colStatus1.Name = "colStatus1"
        Me.colStatus1.ReadOnly = True
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea5.AxisX.IsLabelAutoFit = False
        ChartArea5.AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea5.AxisX.Title = "Day"
        ChartArea5.AxisX.TitleFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea5.AxisX.TitleForeColor = System.Drawing.Color.White
        ChartArea5.AxisY.IsLabelAutoFit = False
        ChartArea5.AxisY.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea5.AxisY.Title = "Sales (₱)"
        ChartArea5.AxisY.TitleFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea5.AxisY.TitleForeColor = System.Drawing.Color.White
        ChartArea5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        ChartArea5.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea5)
        Legend5.Enabled = False
        Legend5.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend5)
        Me.Chart1.Location = New System.Drawing.Point(284, 121)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart1.Name = "Chart1"
        Series5.BorderWidth = 0
        Series5.ChartArea = "ChartArea1"
        Series5.Color = System.Drawing.Color.SlateBlue
        Series5.Legend = "Legend1"
        Series5.Name = "Daily Sales"
        DataPoint25.AxisLabel = "Mon"
        DataPoint26.AxisLabel = "Tue"
        DataPoint27.AxisLabel = "Wed"
        DataPoint28.AxisLabel = "Thur"
        DataPoint29.AxisLabel = "Fri"
        DataPoint30.AxisLabel = "Sat"
        Series5.Points.Add(DataPoint25)
        Series5.Points.Add(DataPoint26)
        Series5.Points.Add(DataPoint27)
        Series5.Points.Add(DataPoint28)
        Series5.Points.Add(DataPoint29)
        Series5.Points.Add(DataPoint30)
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Size = New System.Drawing.Size(389, 212)
        Me.Chart1.TabIndex = 5
        Me.Chart1.Text = "Chart1"
        '
        'cardSalaryDeduction
        '
        Me.cardSalaryDeduction.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cardSalaryDeduction.Controls.Add(Me.lblSalaryDeductionVal)
        Me.cardSalaryDeduction.Controls.Add(Me.lblDeductTitle)
        Me.cardSalaryDeduction.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cardSalaryDeduction.Location = New System.Drawing.Point(855, 15)
        Me.cardSalaryDeduction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cardSalaryDeduction.Name = "cardSalaryDeduction"
        Me.cardSalaryDeduction.Size = New System.Drawing.Size(191, 98)
        Me.cardSalaryDeduction.TabIndex = 4
        '
        'lblSalaryDeductionVal
        '
        Me.lblSalaryDeductionVal.AutoSize = True
        Me.lblSalaryDeductionVal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalaryDeductionVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblSalaryDeductionVal.Location = New System.Drawing.Point(49, 50)
        Me.lblSalaryDeductionVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSalaryDeductionVal.Name = "lblSalaryDeductionVal"
        Me.lblSalaryDeductionVal.Size = New System.Drawing.Size(96, 41)
        Me.lblSalaryDeductionVal.TabIndex = 1
        Me.lblSalaryDeductionVal.Text = "₱0.00"
        '
        'lblDeductTitle
        '
        Me.lblDeductTitle.AutoSize = True
        Me.lblDeductTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeductTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblDeductTitle.Location = New System.Drawing.Point(27, 11)
        Me.lblDeductTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeductTitle.Name = "lblDeductTitle"
        Me.lblDeductTitle.Size = New System.Drawing.Size(124, 46)
        Me.lblDeductTitle.TabIndex = 0
        Me.lblDeductTitle.Text = "SALARY" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " DEDUCTIONS"
        '
        'cardItemsSold
        '
        Me.cardItemsSold.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cardItemsSold.Controls.Add(Me.lblItemsSoldVal)
        Me.cardItemsSold.Controls.Add(Me.lblDeductionTitle)
        Me.cardItemsSold.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cardItemsSold.Location = New System.Drawing.Point(656, 15)
        Me.cardItemsSold.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cardItemsSold.Name = "cardItemsSold"
        Me.cardItemsSold.Size = New System.Drawing.Size(191, 98)
        Me.cardItemsSold.TabIndex = 3
        '
        'lblItemsSoldVal
        '
        Me.lblItemsSoldVal.AutoSize = True
        Me.lblItemsSoldVal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemsSoldVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblItemsSoldVal.Location = New System.Drawing.Point(61, 50)
        Me.lblItemsSoldVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemsSoldVal.Name = "lblItemsSoldVal"
        Me.lblItemsSoldVal.Size = New System.Drawing.Size(35, 41)
        Me.lblItemsSoldVal.TabIndex = 1
        Me.lblItemsSoldVal.Text = "0"
        '
        'lblDeductionTitle
        '
        Me.lblDeductionTitle.AutoSize = True
        Me.lblDeductionTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeductionTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblDeductionTitle.Location = New System.Drawing.Point(37, 11)
        Me.lblDeductionTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeductionTitle.Name = "lblDeductionTitle"
        Me.lblDeductionTitle.Size = New System.Drawing.Size(110, 23)
        Me.lblDeductionTitle.TabIndex = 0
        Me.lblDeductionTitle.Text = "ITEMS SOLD"
        '
        'cardTransactions
        '
        Me.cardTransactions.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cardTransactions.Controls.Add(Me.lblTransactionsVal)
        Me.cardTransactions.Controls.Add(Me.lblTransTitle)
        Me.cardTransactions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cardTransactions.Location = New System.Drawing.Point(460, 15)
        Me.cardTransactions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cardTransactions.Name = "cardTransactions"
        Me.cardTransactions.Size = New System.Drawing.Size(188, 98)
        Me.cardTransactions.TabIndex = 2
        '
        'lblTransactionsVal
        '
        Me.lblTransactionsVal.AutoSize = True
        Me.lblTransactionsVal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionsVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblTransactionsVal.Location = New System.Drawing.Point(71, 50)
        Me.lblTransactionsVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTransactionsVal.Name = "lblTransactionsVal"
        Me.lblTransactionsVal.Size = New System.Drawing.Size(35, 41)
        Me.lblTransactionsVal.TabIndex = 1
        Me.lblTransactionsVal.Text = "0"
        '
        'lblTransTitle
        '
        Me.lblTransTitle.AutoSize = True
        Me.lblTransTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblTransTitle.Location = New System.Drawing.Point(25, 11)
        Me.lblTransTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTransTitle.Name = "lblTransTitle"
        Me.lblTransTitle.Size = New System.Drawing.Size(140, 23)
        Me.lblTransTitle.TabIndex = 0
        Me.lblTransTitle.Text = "TRANSACTIONS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblTodaySalesVal)
        Me.Panel1.Controls.Add(Me.lblSalesTitle)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(275, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(177, 98)
        Me.Panel1.TabIndex = 0
        '
        'lblTodaySalesVal
        '
        Me.lblTodaySalesVal.AutoSize = True
        Me.lblTodaySalesVal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodaySalesVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblTodaySalesVal.Location = New System.Drawing.Point(31, 50)
        Me.lblTodaySalesVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTodaySalesVal.Name = "lblTodaySalesVal"
        Me.lblTodaySalesVal.Size = New System.Drawing.Size(96, 41)
        Me.lblTodaySalesVal.TabIndex = 1
        Me.lblTodaySalesVal.Text = "₱0.00"
        '
        'lblSalesTitle
        '
        Me.lblSalesTitle.AutoSize = True
        Me.lblSalesTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblSalesTitle.Location = New System.Drawing.Point(28, 11)
        Me.lblSalesTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSalesTitle.Name = "lblSalesTitle"
        Me.lblSalesTitle.Size = New System.Drawing.Size(126, 23)
        Me.lblSalesTitle.TabIndex = 0
        Me.lblSalesTitle.Text = "TODAY'S SALE"
        '
        'pnlInventoryView
        '
        Me.pnlInventoryView.Controls.Add(Me.Label4)
        Me.pnlInventoryView.Controls.Add(Me.dgvInventoryHistory)
        Me.pnlInventoryView.Controls.Add(Me.cboCategory)
        Me.pnlInventoryView.Controls.Add(Me.txtSearchProducts)
        Me.pnlInventoryView.Controls.Add(Me.Panel12)
        Me.pnlInventoryView.Controls.Add(Me.Panel11)
        Me.pnlInventoryView.Controls.Add(Me.Panel10)
        Me.pnlInventoryView.Controls.Add(Me.Panel7)
        Me.pnlInventoryView.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlInventoryView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInventoryView.Location = New System.Drawing.Point(0, 0)
        Me.pnlInventoryView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlInventoryView.Name = "pnlInventoryView"
        Me.pnlInventoryView.Size = New System.Drawing.Size(1067, 554)
        Me.pnlInventoryView.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(536, 82)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "CATEGORY:"
        '
        'dgvInventoryHistory
        '
        Me.dgvInventoryHistory.AllowUserToAddRows = False
        Me.dgvInventoryHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventoryHistory.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(104, Byte), Integer))
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle45
        Me.dgvInventoryHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.product_id, Me.product_name, Me.category_name, Me.price, Me.stock_quantity, Me.reorder_level, Me.status, Me.created_at})
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle46.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle46.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle46.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle46.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventoryHistory.DefaultCellStyle = DataGridViewCellStyle46
        Me.dgvInventoryHistory.GridColor = System.Drawing.Color.Gray
        Me.dgvInventoryHistory.Location = New System.Drawing.Point(271, 116)
        Me.dgvInventoryHistory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvInventoryHistory.MultiSelect = False
        Me.dgvInventoryHistory.Name = "dgvInventoryHistory"
        Me.dgvInventoryHistory.ReadOnly = True
        Me.dgvInventoryHistory.RowHeadersVisible = False
        Me.dgvInventoryHistory.RowHeadersWidth = 51
        Me.dgvInventoryHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInventoryHistory.Size = New System.Drawing.Size(581, 378)
        Me.dgvInventoryHistory.TabIndex = 15
        '
        'product_id
        '
        Me.product_id.HeaderText = "Product ID"
        Me.product_id.MinimumWidth = 6
        Me.product_id.Name = "product_id"
        Me.product_id.ReadOnly = True
        '
        'product_name
        '
        Me.product_name.HeaderText = "Product Name"
        Me.product_name.MinimumWidth = 6
        Me.product_name.Name = "product_name"
        Me.product_name.ReadOnly = True
        '
        'category_name
        '
        Me.category_name.HeaderText = "Category"
        Me.category_name.MinimumWidth = 6
        Me.category_name.Name = "category_name"
        Me.category_name.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.MinimumWidth = 6
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'stock_quantity
        '
        Me.stock_quantity.HeaderText = "Quantity"
        Me.stock_quantity.MinimumWidth = 6
        Me.stock_quantity.Name = "stock_quantity"
        Me.stock_quantity.ReadOnly = True
        '
        'reorder_level
        '
        Me.reorder_level.HeaderText = "Reorder Level"
        Me.reorder_level.MinimumWidth = 6
        Me.reorder_level.Name = "reorder_level"
        Me.reorder_level.ReadOnly = True
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'created_at
        '
        Me.created_at.HeaderText = "Created At"
        Me.created_at.MinimumWidth = 6
        Me.created_at.Name = "created_at"
        Me.created_at.ReadOnly = True
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"All Categories", "", "Food", "", "Drinks", "", "Snacks", "", "Desserts", "", "Other"})
        Me.cboCategory.Location = New System.Drawing.Point(629, 79)
        Me.cboCategory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(221, 24)
        Me.cboCategory.TabIndex = 8
        '
        'txtSearchProducts
        '
        Me.txtSearchProducts.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtSearchProducts.Location = New System.Drawing.Point(281, 76)
        Me.txtSearchProducts.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearchProducts.Name = "txtSearchProducts"
        Me.txtSearchProducts.Size = New System.Drawing.Size(231, 22)
        Me.txtSearchProducts.TabIndex = 7
        Me.txtSearchProducts.Text = "Search product..."
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Gold
        Me.Panel12.Controls.Add(Me.pnlOutOfStock)
        Me.Panel12.Location = New System.Drawing.Point(860, 346)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(207, 103)
        Me.Panel12.TabIndex = 6
        '
        'pnlOutOfStock
        '
        Me.pnlOutOfStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlOutOfStock.Controls.Add(Me.lblOutOfStockValue)
        Me.pnlOutOfStock.Controls.Add(Me.lblTitle)
        Me.pnlOutOfStock.Location = New System.Drawing.Point(5, 4)
        Me.pnlOutOfStock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlOutOfStock.Name = "pnlOutOfStock"
        Me.pnlOutOfStock.Size = New System.Drawing.Size(192, 96)
        Me.pnlOutOfStock.TabIndex = 3
        '
        'lblOutOfStockValue
        '
        Me.lblOutOfStockValue.AutoSize = True
        Me.lblOutOfStockValue.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutOfStockValue.ForeColor = System.Drawing.Color.Gold
        Me.lblOutOfStockValue.Location = New System.Drawing.Point(65, 38)
        Me.lblOutOfStockValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOutOfStockValue.Name = "lblOutOfStockValue"
        Me.lblOutOfStockValue.Size = New System.Drawing.Size(40, 46)
        Me.lblOutOfStockValue.TabIndex = 1
        Me.lblOutOfStockValue.Text = "0"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Gold
        Me.lblTitle.Location = New System.Drawing.Point(21, 14)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(144, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "OUT OF STOCK"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Gold
        Me.Panel11.Controls.Add(Me.pnlLowStock)
        Me.Panel11.Location = New System.Drawing.Point(860, 224)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(207, 103)
        Me.Panel11.TabIndex = 6
        '
        'pnlLowStock
        '
        Me.pnlLowStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlLowStock.Controls.Add(Me.lblLowStockValue)
        Me.pnlLowStock.Controls.Add(Me.lblLowStockTitle)
        Me.pnlLowStock.Location = New System.Drawing.Point(8, 4)
        Me.pnlLowStock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlLowStock.Name = "pnlLowStock"
        Me.pnlLowStock.Size = New System.Drawing.Size(192, 96)
        Me.pnlLowStock.TabIndex = 2
        '
        'lblLowStockValue
        '
        Me.lblLowStockValue.AutoSize = True
        Me.lblLowStockValue.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowStockValue.ForeColor = System.Drawing.Color.Gold
        Me.lblLowStockValue.Location = New System.Drawing.Point(61, 43)
        Me.lblLowStockValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLowStockValue.Name = "lblLowStockValue"
        Me.lblLowStockValue.Size = New System.Drawing.Size(40, 46)
        Me.lblLowStockValue.TabIndex = 1
        Me.lblLowStockValue.Text = "0"
        '
        'lblLowStockTitle
        '
        Me.lblLowStockTitle.AutoSize = True
        Me.lblLowStockTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowStockTitle.ForeColor = System.Drawing.Color.Gold
        Me.lblLowStockTitle.Location = New System.Drawing.Point(21, 18)
        Me.lblLowStockTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLowStockTitle.Name = "lblLowStockTitle"
        Me.lblLowStockTitle.Size = New System.Drawing.Size(119, 25)
        Me.lblLowStockTitle.TabIndex = 0
        Me.lblLowStockTitle.Text = "LOW STOCK"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Gold
        Me.Panel10.Controls.Add(Me.pnlTotalItems)
        Me.Panel10.Location = New System.Drawing.Point(860, 106)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(207, 103)
        Me.Panel10.TabIndex = 5
        '
        'pnlTotalItems
        '
        Me.pnlTotalItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlTotalItems.Controls.Add(Me.lblTotalItemsValue)
        Me.pnlTotalItems.Controls.Add(Me.lblTotalItemsTitle)
        Me.pnlTotalItems.Location = New System.Drawing.Point(8, 4)
        Me.pnlTotalItems.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlTotalItems.Name = "pnlTotalItems"
        Me.pnlTotalItems.Size = New System.Drawing.Size(192, 96)
        Me.pnlTotalItems.TabIndex = 0
        '
        'lblTotalItemsValue
        '
        Me.lblTotalItemsValue.AutoSize = True
        Me.lblTotalItemsValue.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalItemsValue.ForeColor = System.Drawing.Color.Gold
        Me.lblTotalItemsValue.Location = New System.Drawing.Point(65, 46)
        Me.lblTotalItemsValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalItemsValue.Name = "lblTotalItemsValue"
        Me.lblTotalItemsValue.Size = New System.Drawing.Size(40, 46)
        Me.lblTotalItemsValue.TabIndex = 1
        Me.lblTotalItemsValue.Text = "0"
        '
        'lblTotalItemsTitle
        '
        Me.lblTotalItemsTitle.AutoSize = True
        Me.lblTotalItemsTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalItemsTitle.ForeColor = System.Drawing.Color.Gold
        Me.lblTotalItemsTitle.Location = New System.Drawing.Point(21, 18)
        Me.lblTotalItemsTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalItemsTitle.Name = "lblTotalItemsTitle"
        Me.lblTotalItemsTitle.Size = New System.Drawing.Size(134, 25)
        Me.lblTotalItemsTitle.TabIndex = 0
        Me.lblTotalItemsTitle.Text = "TOTAL ITEMS "
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gold
        Me.Panel7.Controls.Add(Me.Panel9)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Location = New System.Drawing.Point(271, 1)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(812, 62)
        Me.Panel7.TabIndex = 4
        '
        'Panel9
        '
        Me.Panel9.Location = New System.Drawing.Point(39, 62)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(267, 102)
        Me.Panel9.TabIndex = 5
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Location = New System.Drawing.Point(4, 5)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(803, 50)
        Me.Panel8.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Manage products and stock levels"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "INVENTORY MANAGEMENT"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEditProduct)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAddProduct)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRestock)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDeactivateProduct)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(489, 501)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(481, 38)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btnEditProduct
        '
        Me.btnEditProduct.BackColor = System.Drawing.Color.SeaGreen
        Me.btnEditProduct.FlatAppearance.BorderSize = 0
        Me.btnEditProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.btnEditProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen
        Me.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditProduct.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditProduct.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnEditProduct.Location = New System.Drawing.Point(4, 4)
        Me.btnEditProduct.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEditProduct.Name = "btnEditProduct"
        Me.btnEditProduct.Size = New System.Drawing.Size(108, 31)
        Me.btnEditProduct.TabIndex = 3
        Me.btnEditProduct.Text = "EDIT"
        Me.btnEditProduct.UseVisualStyleBackColor = False
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnAddProduct.FlatAppearance.BorderSize = 0
        Me.btnAddProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.ForeColor = System.Drawing.Color.White
        Me.btnAddProduct.Location = New System.Drawing.Point(120, 4)
        Me.btnAddProduct.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(108, 31)
        Me.btnAddProduct.TabIndex = 1
        Me.btnAddProduct.Text = "ADD"
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'btnRestock
        '
        Me.btnRestock.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.btnRestock.FlatAppearance.BorderSize = 0
        Me.btnRestock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.btnRestock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnRestock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestock.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnRestock.Location = New System.Drawing.Point(236, 4)
        Me.btnRestock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestock.Name = "btnRestock"
        Me.btnRestock.Size = New System.Drawing.Size(108, 31)
        Me.btnRestock.TabIndex = 2
        Me.btnRestock.Text = "RESTOCK"
        Me.btnRestock.UseVisualStyleBackColor = False
        '
        'btnDeactivateProduct
        '
        Me.btnDeactivateProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnDeactivateProduct.FlatAppearance.BorderSize = 0
        Me.btnDeactivateProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.btnDeactivateProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnDeactivateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeactivateProduct.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeactivateProduct.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnDeactivateProduct.Location = New System.Drawing.Point(352, 4)
        Me.btnDeactivateProduct.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDeactivateProduct.Name = "btnDeactivateProduct"
        Me.btnDeactivateProduct.Size = New System.Drawing.Size(119, 31)
        Me.btnDeactivateProduct.TabIndex = 4
        Me.btnDeactivateProduct.Text = "DEACTIVATE"
        Me.btnDeactivateProduct.UseVisualStyleBackColor = False
        '
        'pnlSalaryDeductionView
        '
        Me.pnlSalaryDeductionView.AutoSize = True
        Me.pnlSalaryDeductionView.Controls.Add(Me.flowLayoutPanelActions)
        Me.pnlSalaryDeductionView.Controls.Add(Me.Panel6)
        Me.pnlSalaryDeductionView.Controls.Add(Me.Panel4)
        Me.pnlSalaryDeductionView.Controls.Add(Me.Panel3)
        Me.pnlSalaryDeductionView.Controls.Add(Me.Panel2)
        Me.pnlSalaryDeductionView.Controls.Add(Me.dgvTextBoxColumn)
        Me.pnlSalaryDeductionView.Controls.Add(Me.txtSearch)
        Me.pnlSalaryDeductionView.Controls.Add(Me.cmbRoleFilter)
        Me.pnlSalaryDeductionView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSalaryDeductionView.Location = New System.Drawing.Point(0, 0)
        Me.pnlSalaryDeductionView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlSalaryDeductionView.Name = "pnlSalaryDeductionView"
        Me.pnlSalaryDeductionView.Size = New System.Drawing.Size(1067, 554)
        Me.pnlSalaryDeductionView.TabIndex = 0
        '
        'flowLayoutPanelActions
        '
        Me.flowLayoutPanelActions.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.flowLayoutPanelActions.Controls.Add(Me.btnEdit1)
        Me.flowLayoutPanelActions.Controls.Add(Me.btnAdd)
        Me.flowLayoutPanelActions.Controls.Add(Me.btnView)
        Me.flowLayoutPanelActions.Controls.Add(Me.btnDelete)
        Me.flowLayoutPanelActions.Location = New System.Drawing.Point(312, 217)
        Me.flowLayoutPanelActions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.flowLayoutPanelActions.Name = "flowLayoutPanelActions"
        Me.flowLayoutPanelActions.Size = New System.Drawing.Size(481, 38)
        Me.flowLayoutPanelActions.TabIndex = 9
        '
        'btnEdit1
        '
        Me.btnEdit1.BackColor = System.Drawing.Color.SeaGreen
        Me.btnEdit1.FlatAppearance.BorderSize = 0
        Me.btnEdit1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.btnEdit1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen
        Me.btnEdit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnEdit1.Location = New System.Drawing.Point(4, 4)
        Me.btnEdit1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEdit1.Name = "btnEdit1"
        Me.btnEdit1.Size = New System.Drawing.Size(108, 31)
        Me.btnEdit1.TabIndex = 3
        Me.btnEdit1.Text = "EDIT"
        Me.btnEdit1.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(120, 4)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(108, 31)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnView
        '
        Me.btnView.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.btnView.FlatAppearance.BorderSize = 0
        Me.btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnView.Location = New System.Drawing.Point(236, 4)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(108, 31)
        Me.btnView.TabIndex = 2
        Me.btnView.Text = "VIEW"
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnDelete.Location = New System.Drawing.Point(352, 4)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(123, 31)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gold
        Me.Panel6.Controls.Add(Me.pnlHeader)
        Me.Panel6.Location = New System.Drawing.Point(271, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(791, 65)
        Me.Panel6.TabIndex = 8
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Location = New System.Drawing.Point(4, 4)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(783, 58)
        Me.pnlHeader.TabIndex = 12
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.ForeColor = System.Drawing.Color.White
        Me.lblSubtitle.Location = New System.Drawing.Point(9, 32)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(295, 20)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Manage employees and salary deductions  "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(467, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMPLOYEE SALARY DEDUCTION MANAGEMENT"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Controls.Add(Me.pnlLimitReached)
        Me.Panel4.Location = New System.Drawing.Point(799, 71)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(255, 123)
        Me.Panel4.TabIndex = 7
        '
        'pnlLimitReached
        '
        Me.pnlLimitReached.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlLimitReached.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLimitReached.Controls.Add(Me.lblCompletedDeduction)
        Me.pnlLimitReached.Controls.Add(Me.lblCompletedDeductionTitle)
        Me.pnlLimitReached.Location = New System.Drawing.Point(4, 4)
        Me.pnlLimitReached.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlLimitReached.Name = "pnlLimitReached"
        Me.pnlLimitReached.Size = New System.Drawing.Size(246, 115)
        Me.pnlLimitReached.TabIndex = 11
        '
        'lblCompletedDeduction
        '
        Me.lblCompletedDeduction.AutoSize = True
        Me.lblCompletedDeduction.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletedDeduction.ForeColor = System.Drawing.Color.Gold
        Me.lblCompletedDeduction.Location = New System.Drawing.Point(101, 50)
        Me.lblCompletedDeduction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCompletedDeduction.Name = "lblCompletedDeduction"
        Me.lblCompletedDeduction.Size = New System.Drawing.Size(35, 41)
        Me.lblCompletedDeduction.TabIndex = 4
        Me.lblCompletedDeduction.Text = "0"
        '
        'lblCompletedDeductionTitle
        '
        Me.lblCompletedDeductionTitle.AutoSize = True
        Me.lblCompletedDeductionTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletedDeductionTitle.ForeColor = System.Drawing.Color.White
        Me.lblCompletedDeductionTitle.Location = New System.Drawing.Point(17, 12)
        Me.lblCompletedDeductionTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCompletedDeductionTitle.Name = "lblCompletedDeductionTitle"
        Me.lblCompletedDeductionTitle.Size = New System.Drawing.Size(214, 23)
        Me.lblCompletedDeductionTitle.TabIndex = 0
        Me.lblCompletedDeductionTitle.Text = "COMPLETED DEDUCTION"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Location = New System.Drawing.Point(531, 71)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(260, 123)
        Me.Panel3.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblPendingCount)
        Me.Panel5.Controls.Add(Me.pnlPendingDeductions)
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(251, 114)
        Me.Panel5.TabIndex = 10
        '
        'lblPendingCount
        '
        Me.lblPendingCount.AutoSize = True
        Me.lblPendingCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingCount.ForeColor = System.Drawing.Color.Gold
        Me.lblPendingCount.Location = New System.Drawing.Point(104, 52)
        Me.lblPendingCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPendingCount.Name = "lblPendingCount"
        Me.lblPendingCount.Size = New System.Drawing.Size(35, 41)
        Me.lblPendingCount.TabIndex = 3
        Me.lblPendingCount.Text = "0"
        '
        'pnlPendingDeductions
        '
        Me.pnlPendingDeductions.AutoSize = True
        Me.pnlPendingDeductions.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPendingDeductions.ForeColor = System.Drawing.Color.White
        Me.pnlPendingDeductions.Location = New System.Drawing.Point(15, 12)
        Me.pnlPendingDeductions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pnlPendingDeductions.Name = "pnlPendingDeductions"
        Me.pnlPendingDeductions.Size = New System.Drawing.Size(199, 23)
        Me.pnlPendingDeductions.TabIndex = 2
        Me.pnlPendingDeductions.Text = "PENDING DEDUCTIONS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Controls.Add(Me.pnlTotalEmployees)
        Me.Panel2.Location = New System.Drawing.Point(284, 70)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(239, 123)
        Me.Panel2.TabIndex = 6
        '
        'pnlTotalEmployees
        '
        Me.pnlTotalEmployees.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlTotalEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotalEmployees.Controls.Add(Me.lblTotalEmployeesCount)
        Me.pnlTotalEmployees.Controls.Add(Me.lblTotalEmployees)
        Me.pnlTotalEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlTotalEmployees.Location = New System.Drawing.Point(4, 4)
        Me.pnlTotalEmployees.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlTotalEmployees.Name = "pnlTotalEmployees"
        Me.pnlTotalEmployees.Size = New System.Drawing.Size(230, 115)
        Me.pnlTotalEmployees.TabIndex = 9
        '
        'lblTotalEmployeesCount
        '
        Me.lblTotalEmployeesCount.AutoSize = True
        Me.lblTotalEmployeesCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEmployeesCount.ForeColor = System.Drawing.Color.Gold
        Me.lblTotalEmployeesCount.Location = New System.Drawing.Point(85, 52)
        Me.lblTotalEmployeesCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalEmployeesCount.Name = "lblTotalEmployeesCount"
        Me.lblTotalEmployeesCount.Size = New System.Drawing.Size(35, 41)
        Me.lblTotalEmployeesCount.TabIndex = 1
        Me.lblTotalEmployeesCount.Text = "0"
        '
        'lblTotalEmployees
        '
        Me.lblTotalEmployees.AutoSize = True
        Me.lblTotalEmployees.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEmployees.ForeColor = System.Drawing.Color.White
        Me.lblTotalEmployees.Location = New System.Drawing.Point(17, 14)
        Me.lblTotalEmployees.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalEmployees.Name = "lblTotalEmployees"
        Me.lblTotalEmployees.Size = New System.Drawing.Size(180, 25)
        Me.lblTotalEmployees.TabIndex = 0
        Me.lblTotalEmployees.Text = "TOTAL EMPLOYEES"
        '
        'dgvTextBoxColumn
        '
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvTextBoxColumn.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle47
        Me.dgvTextBoxColumn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTextBoxColumn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgvTextBoxColumn.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(11, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.dgvTextBoxColumn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTextBoxColumn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(91, Byte), Integer))
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTextBoxColumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dgvTextBoxColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTextBoxColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEmpNo, Me.colName, Me.colPosition, Me.DeductionStatus, Me.colPeriodStart, Me.colPeriodEnd})
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle49
        Me.dgvTextBoxColumn.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvTextBoxColumn.Location = New System.Drawing.Point(284, 262)
        Me.dgvTextBoxColumn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvTextBoxColumn.Name = "dgvTextBoxColumn"
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTextBoxColumn.RowHeadersDefaultCellStyle = DataGridViewCellStyle50
        Me.dgvTextBoxColumn.RowHeadersVisible = False
        Me.dgvTextBoxColumn.RowHeadersWidth = 51
        Me.dgvTextBoxColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTextBoxColumn.Size = New System.Drawing.Size(779, 277)
        Me.dgvTextBoxColumn.TabIndex = 5
        '
        'colEmpNo
        '
        Me.colEmpNo.HeaderText = "Employee No"
        Me.colEmpNo.MinimumWidth = 6
        Me.colEmpNo.Name = "colEmpNo"
        Me.colEmpNo.Width = 142
        '
        'colName
        '
        Me.colName.HeaderText = "Full Name"
        Me.colName.MinimumWidth = 6
        Me.colName.Name = "colName"
        Me.colName.Width = 117
        '
        'colPosition
        '
        Me.colPosition.HeaderText = "Position"
        Me.colPosition.MinimumWidth = 6
        Me.colPosition.Name = "colPosition"
        Me.colPosition.Width = 99
        '
        'DeductionStatus
        '
        Me.DeductionStatus.HeaderText = "Deduction Status"
        Me.DeductionStatus.Items.AddRange(New Object() {"PENDING", "COMPLETE"})
        Me.DeductionStatus.MinimumWidth = 6
        Me.DeductionStatus.Name = "DeductionStatus"
        Me.DeductionStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeductionStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DeductionStatus.Width = 170
        '
        'colPeriodStart
        '
        Me.colPeriodStart.HeaderText = "Period Start"
        Me.colPeriodStart.MinimumWidth = 6
        Me.colPeriodStart.Name = "colPeriodStart"
        Me.colPeriodStart.Width = 128
        '
        'colPeriodEnd
        '
        Me.colPeriodEnd.HeaderText = "Period End"
        Me.colPeriodEnd.MinimumWidth = 6
        Me.colPeriodEnd.Name = "colPeriodEnd"
        Me.colPeriodEnd.Width = 121
        '
        'txtSearch
        '
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtSearch.Location = New System.Drawing.Point(840, 230)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(204, 22)
        Me.txtSearch.TabIndex = 3
        Me.txtSearch.Text = "🔍 Search employee name or ID..."
        '
        'cmbRoleFilter
        '
        Me.cmbRoleFilter.BackColor = System.Drawing.Color.White
        Me.cmbRoleFilter.ForeColor = System.Drawing.Color.White
        Me.cmbRoleFilter.FormattingEnabled = True
        Me.cmbRoleFilter.Items.AddRange(New Object() {"All Roles ", "Teacher", "Staff"})
        Me.cmbRoleFilter.Location = New System.Drawing.Point(840, 197)
        Me.cmbRoleFilter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbRoleFilter.Name = "cmbRoleFilter"
        Me.cmbRoleFilter.Size = New System.Drawing.Size(204, 24)
        Me.cmbRoleFilter.TabIndex = 2
        '
        'pnlSettingsView
        '
        Me.pnlSettingsView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsView.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlSettingsView.Name = "pnlSettingsView"
        Me.pnlSettingsView.Size = New System.Drawing.Size(1067, 554)
        Me.pnlSettingsView.TabIndex = 0
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.Gold
        Me.pnlSidebar.Controls.Add(Me.Label5)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnSettings)
        Me.pnlSidebar.Controls.Add(Me.btnReports)
        Me.pnlSidebar.Controls.Add(Me.btnSalaryDeduction)
        Me.pnlSidebar.Controls.Add(Me.btnInventory)
        Me.pnlSidebar.Controls.Add(Me.btnDashboard)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(263, 554)
        Me.pnlSidebar.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 8)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(219, 22)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "LYCEUM OF ALABANG"
        '
        'btnLogout
        '
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(24, 507)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(216, 28)
        Me.btnLogout.TabIndex = 30
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.Location = New System.Drawing.Point(24, 471)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(216, 28)
        Me.btnSettings.TabIndex = 29
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnReports
        '
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Location = New System.Drawing.Point(24, 235)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(216, 28)
        Me.btnReports.TabIndex = 28
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'btnSalaryDeduction
        '
        Me.btnSalaryDeduction.FlatAppearance.BorderSize = 0
        Me.btnSalaryDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalaryDeduction.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalaryDeduction.Location = New System.Drawing.Point(24, 271)
        Me.btnSalaryDeduction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalaryDeduction.Name = "btnSalaryDeduction"
        Me.btnSalaryDeduction.Size = New System.Drawing.Size(224, 31)
        Me.btnSalaryDeduction.TabIndex = 27
        Me.btnSalaryDeduction.Text = "Employee Salary Deduction"
        Me.btnSalaryDeduction.UseVisualStyleBackColor = True
        '
        'btnInventory
        '
        Me.btnInventory.FlatAppearance.BorderSize = 0
        Me.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInventory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.Location = New System.Drawing.Point(24, 197)
        Me.btnInventory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(216, 28)
        Me.btnInventory.TabIndex = 25
        Me.btnInventory.Text = "Inventory"
        Me.btnInventory.UseVisualStyleBackColor = True
        '
        'btnDashboard
        '
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.Location = New System.Drawing.Point(24, 161)
        Me.btnDashboard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(216, 28)
        Me.btnDashboard.TabIndex = 21
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.UseVisualStyleBackColor = True
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.pnlMainContent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDashboard"
        Me.pnlMainContent.ResumeLayout(False)
        Me.pnlMainContent.PerformLayout()
        Me.btnPrint.ResumeLayout(False)
        Me.btnPrint.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel13.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlReportHeader.ResumeLayout(False)
        Me.pnlReportHeader.PerformLayout()
        Me.pnlDashboardView.ResumeLayout(False)
        Me.pnlInventoryAlerts.ResumeLayout(False)
        Me.pnlInventoryAlerts.PerformLayout()
        Me.pnlRecentTransactions.ResumeLayout(False)
        Me.pnlRecentTransactions.PerformLayout()
        CType(Me.dgvRecentTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardSalaryDeduction.ResumeLayout(False)
        Me.cardSalaryDeduction.PerformLayout()
        Me.cardItemsSold.ResumeLayout(False)
        Me.cardItemsSold.PerformLayout()
        Me.cardTransactions.ResumeLayout(False)
        Me.cardTransactions.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlInventoryView.ResumeLayout(False)
        Me.pnlInventoryView.PerformLayout()
        CType(Me.dgvInventoryHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.pnlOutOfStock.ResumeLayout(False)
        Me.pnlOutOfStock.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.pnlLowStock.ResumeLayout(False)
        Me.pnlLowStock.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.pnlTotalItems.ResumeLayout(False)
        Me.pnlTotalItems.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlSalaryDeductionView.ResumeLayout(False)
        Me.pnlSalaryDeductionView.PerformLayout()
        Me.flowLayoutPanelActions.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pnlLimitReached.ResumeLayout(False)
        Me.pnlLimitReached.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlTotalEmployees.ResumeLayout(False)
        Me.pnlTotalEmployees.PerformLayout()
        CType(Me.dgvTextBoxColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnSalaryDeduction As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents pnlDashboardView As Panel
    Friend WithEvents pnlInventoryView As Panel
    Friend WithEvents pnlSalaryDeductionView As Panel
    Friend WithEvents btnPrint As Panel
    Friend WithEvents pnlSettingsView As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblSalesTitle As Label
    Friend WithEvents cardTransactions As Panel
    Friend WithEvents lblTransactionsVal As Label
    Friend WithEvents lblTransTitle As Label
    Friend WithEvents lblTodaySalesVal As Label
    Friend WithEvents cardSalaryDeduction As Panel
    Friend WithEvents lblSalaryDeductionVal As Label
    Friend WithEvents lblDeductTitle As Label
    Friend WithEvents cardItemsSold As Panel
    Friend WithEvents lblItemsSoldVal As Label
    Friend WithEvents lblDeductionTitle As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents lblSystemTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cmbRoleFilter As ComboBox
    Friend WithEvents dgvTextBoxColumn As DataGridView
    Friend WithEvents pnlRecentTransactions As Panel
    Friend WithEvents dgvRecentTransactions As DataGridView
    Friend WithEvents colTransactionNo As DataGridViewTextBoxColumn
    Friend WithEvents colTransactionDate As DataGridViewTextBoxColumn
    Friend WithEvents colPaymentMethod As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
    Friend WithEvents colStatus1 As DataGridViewTextBoxColumn
    Friend WithEvents pnlInventoryAlerts As Panel
    Friend WithEvents btnViewAll As Label
    Friend WithEvents lblInventoryAlerts As Label
    Friend WithEvents colEmpNo As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colPosition As DataGridViewTextBoxColumn
    Friend WithEvents DeductionStatus As DataGridViewComboBoxColumn
    Friend WithEvents colPeriodStart As DataGridViewTextBoxColumn
    Friend WithEvents colPeriodEnd As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlTotalEmployees As Panel
    Friend WithEvents lblTotalEmployeesCount As Label
    Friend WithEvents lblTotalEmployees As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblPendingCount As Label
    Friend WithEvents pnlPendingDeductions As Label
    Friend WithEvents pnlLimitReached As Panel
    Friend WithEvents lblCompletedDeduction As Label
    Friend WithEvents lblCompletedDeductionTitle As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents flowLayoutPanelActions As FlowLayoutPanel
    Friend WithEvents btnEdit1 As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnEditProduct As Button
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents btnRestock As Button
    Friend WithEvents btnDeactivateProduct As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlTotalItems As Panel
    Friend WithEvents lblTotalItemsValue As Label
    Friend WithEvents lblTotalItemsTitle As Label
    Friend WithEvents pnlOutOfStock As Panel
    Friend WithEvents lblOutOfStockValue As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlLowStock As Panel
    Friend WithEvents lblLowStockValue As Label
    Friend WithEvents lblLowStockTitle As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents txtSearchProducts As TextBox
    Friend WithEvents dgvInventoryHistory As DataGridView
    Friend WithEvents product_id As DataGridViewTextBoxColumn
    Friend WithEvents product_name As DataGridViewTextBoxColumn
    Friend WithEvents category_name As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents stock_quantity As DataGridViewTextBoxColumn
    Friend WithEvents reorder_level As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents created_at As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents lblOut As Label
    Friend WithEvents lblLowStockIcon As Label
    Friend WithEvents lblInStockIcon As Label
    Friend WithEvents lblOutStockVal As Label
    Friend WithEvents lblLowSValue As Label
     Friend WithEvents lblInStockValue As Label
    Friend WithEvents pnlReportHeader As Panel
    Friend WithEvents lblReportTitle As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblReportSubtitle As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpReportto As DateTimePicker
    Friend WithEvents dtpReportFrom As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents movement_id As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colProduct As DataGridViewTextBoxColumn
    Friend WithEvents colMovementType As DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colUser As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents btnExportExcel As Button
End Class
