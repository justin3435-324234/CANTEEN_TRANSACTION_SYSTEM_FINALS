<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHistory
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlTotalMovements = New System.Windows.Forms.Panel()
        Me.lblTotalMovementsValue = New System.Windows.Forms.Label()
        Me.lblTotalMovements = New System.Windows.Forms.Label()
        Me.pnlStockOut = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblStockOutValue = New System.Windows.Forms.Label()
        Me.lblStockOut = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblStockInValue = New System.Windows.Forms.Label()
        Me.lblStockIn = New System.Windows.Forms.Label()
        Me.pnlStockIn = New System.Windows.Forms.Panel()
        Me.txtSearchHistory = New System.Windows.Forms.TextBox()
        Me.cboMovementType = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.btnHistoryRefresh = New System.Windows.Forms.Button()
        Me.dgvInventoryHistory = New System.Windows.Forms.DataGridView()
        Me.movement_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMovementType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlTotalMovements.SuspendLayout()
        Me.pnlStockOut.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlStockIn.SuspendLayout()
        CType(Me.dgvInventoryHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1065, 66)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(4, 7)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1057, 55)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(4, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(387, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Track all stock movements and inventory changes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INVENTORY HISTORY"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Controls.Add(Me.pnlTotalMovements)
        Me.Panel3.Location = New System.Drawing.Point(824, 135)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(227, 103)
        Me.Panel3.TabIndex = 1
        '
        'pnlTotalMovements
        '
        Me.pnlTotalMovements.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlTotalMovements.Controls.Add(Me.lblTotalMovementsValue)
        Me.pnlTotalMovements.Controls.Add(Me.lblTotalMovements)
        Me.pnlTotalMovements.Location = New System.Drawing.Point(4, 4)
        Me.pnlTotalMovements.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlTotalMovements.Name = "pnlTotalMovements"
        Me.pnlTotalMovements.Size = New System.Drawing.Size(219, 96)
        Me.pnlTotalMovements.TabIndex = 2
        '
        'lblTotalMovementsValue
        '
        Me.lblTotalMovementsValue.AutoSize = True
        Me.lblTotalMovementsValue.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMovementsValue.ForeColor = System.Drawing.Color.Gold
        Me.lblTotalMovementsValue.Location = New System.Drawing.Point(75, 36)
        Me.lblTotalMovementsValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalMovementsValue.Name = "lblTotalMovementsValue"
        Me.lblTotalMovementsValue.Size = New System.Drawing.Size(40, 46)
        Me.lblTotalMovementsValue.TabIndex = 1
        Me.lblTotalMovementsValue.Text = "0"
        '
        'lblTotalMovements
        '
        Me.lblTotalMovements.AutoSize = True
        Me.lblTotalMovements.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMovements.ForeColor = System.Drawing.Color.Gold
        Me.lblTotalMovements.Location = New System.Drawing.Point(12, 11)
        Me.lblTotalMovements.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalMovements.Name = "lblTotalMovements"
        Me.lblTotalMovements.Size = New System.Drawing.Size(193, 25)
        Me.lblTotalMovements.TabIndex = 0
        Me.lblTotalMovements.Text = "TOTAL MOVEMENTS"
        '
        'pnlStockOut
        '
        Me.pnlStockOut.BackColor = System.Drawing.Color.Gold
        Me.pnlStockOut.Controls.Add(Me.Panel7)
        Me.pnlStockOut.Location = New System.Drawing.Point(824, 357)
        Me.pnlStockOut.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlStockOut.Name = "pnlStockOut"
        Me.pnlStockOut.Size = New System.Drawing.Size(227, 103)
        Me.pnlStockOut.TabIndex = 3
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel7.Controls.Add(Me.lblStockOutValue)
        Me.Panel7.Controls.Add(Me.lblStockOut)
        Me.Panel7.Location = New System.Drawing.Point(4, 4)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(219, 96)
        Me.Panel7.TabIndex = 2
        '
        'lblStockOutValue
        '
        Me.lblStockOutValue.AutoSize = True
        Me.lblStockOutValue.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockOutValue.ForeColor = System.Drawing.Color.Gold
        Me.lblStockOutValue.Location = New System.Drawing.Point(75, 37)
        Me.lblStockOutValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockOutValue.Name = "lblStockOutValue"
        Me.lblStockOutValue.Size = New System.Drawing.Size(40, 46)
        Me.lblStockOutValue.TabIndex = 3
        Me.lblStockOutValue.Text = "0"
        '
        'lblStockOut
        '
        Me.lblStockOut.AutoSize = True
        Me.lblStockOut.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockOut.ForeColor = System.Drawing.Color.Gold
        Me.lblStockOut.Location = New System.Drawing.Point(56, 12)
        Me.lblStockOut.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockOut.Name = "lblStockOut"
        Me.lblStockOut.Size = New System.Drawing.Size(115, 25)
        Me.lblStockOut.TabIndex = 0
        Me.lblStockOut.Text = "STOCK OUT"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.Controls.Add(Me.lblStockInValue)
        Me.Panel5.Controls.Add(Me.lblStockIn)
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(219, 96)
        Me.Panel5.TabIndex = 2
        '
        'lblStockInValue
        '
        Me.lblStockInValue.AutoSize = True
        Me.lblStockInValue.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockInValue.ForeColor = System.Drawing.Color.Gold
        Me.lblStockInValue.Location = New System.Drawing.Point(75, 36)
        Me.lblStockInValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockInValue.Name = "lblStockInValue"
        Me.lblStockInValue.Size = New System.Drawing.Size(40, 46)
        Me.lblStockInValue.TabIndex = 2
        Me.lblStockInValue.Text = "0"
        '
        'lblStockIn
        '
        Me.lblStockIn.AutoSize = True
        Me.lblStockIn.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockIn.ForeColor = System.Drawing.Color.Gold
        Me.lblStockIn.Location = New System.Drawing.Point(56, 11)
        Me.lblStockIn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockIn.Name = "lblStockIn"
        Me.lblStockIn.Size = New System.Drawing.Size(97, 25)
        Me.lblStockIn.TabIndex = 0
        Me.lblStockIn.Text = "STOCK IN"
        '
        'pnlStockIn
        '
        Me.pnlStockIn.BackColor = System.Drawing.Color.Gold
        Me.pnlStockIn.Controls.Add(Me.Panel5)
        Me.pnlStockIn.Location = New System.Drawing.Point(824, 246)
        Me.pnlStockIn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlStockIn.Name = "pnlStockIn"
        Me.pnlStockIn.Size = New System.Drawing.Size(227, 103)
        Me.pnlStockIn.TabIndex = 3
        '
        'txtSearchHistory
        '
        Me.txtSearchHistory.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtSearchHistory.Location = New System.Drawing.Point(16, 90)
        Me.txtSearchHistory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearchHistory.Name = "txtSearchHistory"
        Me.txtSearchHistory.Size = New System.Drawing.Size(284, 22)
        Me.txtSearchHistory.TabIndex = 4
        Me.txtSearchHistory.Text = "🔍 Search product...     "
        '
        'cboMovementType
        '
        Me.cboMovementType.FormattingEnabled = True
        Me.cboMovementType.Items.AddRange(New Object() {"All", "Stock In", "Stock Out", "Adjustment", "Sale"})
        Me.cboMovementType.Location = New System.Drawing.Point(84, 122)
        Me.cboMovementType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboMovementType.Name = "cboMovementType"
        Me.cboMovementType.Size = New System.Drawing.Size(216, 24)
        Me.cboMovementType.TabIndex = 5
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.Gold
        Me.lblType.Location = New System.Drawing.Point(28, 126)
        Me.lblType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(46, 19)
        Me.lblType.TabIndex = 7
        Me.lblType.Text = "TYPE:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(321, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "FROM:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(385, 90)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(141, 27)
        Me.dtpFrom.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(345, 132)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TO:"
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(385, 126)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(141, 27)
        Me.dtpTo.TabIndex = 11
        '
        'btnClearFilters
        '
        Me.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClearFilters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClearFilters.FlatAppearance.BorderSize = 0
        Me.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilters.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFilters.ForeColor = System.Drawing.SystemColors.Info
        Me.btnClearFilters.Location = New System.Drawing.Point(677, 107)
        Me.btnClearFilters.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(115, 34)
        Me.btnClearFilters.TabIndex = 12
        Me.btnClearFilters.Text = "Clear "
        Me.btnClearFilters.UseVisualStyleBackColor = False
        '
        'btnHistoryRefresh
        '
        Me.btnHistoryRefresh.BackColor = System.Drawing.Color.Gold
        Me.btnHistoryRefresh.FlatAppearance.BorderSize = 0
        Me.btnHistoryRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistoryRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistoryRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnHistoryRefresh.Location = New System.Drawing.Point(536, 107)
        Me.btnHistoryRefresh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnHistoryRefresh.Name = "btnHistoryRefresh"
        Me.btnHistoryRefresh.Size = New System.Drawing.Size(133, 34)
        Me.btnHistoryRefresh.TabIndex = 14
        Me.btnHistoryRefresh.Text = "↻ REFRESH"
        Me.btnHistoryRefresh.UseVisualStyleBackColor = False
        '
        'dgvInventoryHistory
        '
        Me.dgvInventoryHistory.AllowUserToAddRows = False
        Me.dgvInventoryHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventoryHistory.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(104, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInventoryHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.movement_id, Me.colDate, Me.colProduct, Me.colMovementType, Me.colQuantity, Me.colUser, Me.colRemarks})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventoryHistory.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInventoryHistory.GridColor = System.Drawing.Color.Gray
        Me.dgvInventoryHistory.Location = New System.Drawing.Point(16, 158)
        Me.dgvInventoryHistory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvInventoryHistory.MultiSelect = False
        Me.dgvInventoryHistory.Name = "dgvInventoryHistory"
        Me.dgvInventoryHistory.ReadOnly = True
        Me.dgvInventoryHistory.RowHeadersVisible = False
        Me.dgvInventoryHistory.RowHeadersWidth = 51
        Me.dgvInventoryHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInventoryHistory.Size = New System.Drawing.Size(764, 382)
        Me.dgvInventoryHistory.TabIndex = 13
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
        'frmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.dgvInventoryHistory)
        Me.Controls.Add(Me.btnHistoryRefresh)
        Me.Controls.Add(Me.btnClearFilters)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.cboMovementType)
        Me.Controls.Add(Me.txtSearchHistory)
        Me.Controls.Add(Me.pnlStockOut)
        Me.Controls.Add(Me.pnlStockIn)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlTotalMovements.ResumeLayout(False)
        Me.pnlTotalMovements.PerformLayout()
        Me.pnlStockOut.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlStockIn.ResumeLayout(False)
        CType(Me.dgvInventoryHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlTotalMovements As Panel
    Friend WithEvents lblTotalMovements As Label
    Friend WithEvents pnlStockOut As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblStockOut As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblStockIn As Label
    Friend WithEvents pnlStockIn As Panel
    Friend WithEvents txtSearchHistory As TextBox
    Friend WithEvents cboMovementType As ComboBox
    Friend WithEvents lblType As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents btnHistoryRefresh As Button
    Friend WithEvents dgvInventoryHistory As DataGridView
    Friend WithEvents movement_id As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colProduct As DataGridViewTextBoxColumn
    Friend WithEvents colMovementType As DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colUser As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
    Friend WithEvents lblTotalMovementsValue As Label
    Friend WithEvents lblStockOutValue As Label
    Friend WithEvents lblStockInValue As Label
End Class
