<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingOrders
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlPendingHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPendingOrders = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelOrder = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.colQueueNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItems = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPendingHeader.SuspendLayout()
        CType(Me.dgvPendingOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPendingHeader
        '
        Me.pnlPendingHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlPendingHeader.Controls.Add(Me.Label1)
        Me.pnlPendingHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPendingHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlPendingHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlPendingHeader.Name = "pnlPendingHeader"
        Me.pnlPendingHeader.Size = New System.Drawing.Size(800, 100)
        Me.pnlPendingHeader.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(21, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PENDING KIOSK ORDERS"
        '
        'dgvPendingOrders
        '
        Me.dgvPendingOrders.AllowUserToAddRows = False
        Me.dgvPendingOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPendingOrders.BackgroundColor = System.Drawing.Color.White
        Me.dgvPendingOrders.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingOrders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colQueueNumber, Me.colOrderType, Me.colItems, Me.colTotal, Me.colPayment, Me.colStatus, Me.colAction})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPendingOrders.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingOrders.EnableHeadersVisualStyles = False
        Me.dgvPendingOrders.Location = New System.Drawing.Point(0, 100)
        Me.dgvPendingOrders.MultiSelect = False
        Me.dgvPendingOrders.Name = "dgvPendingOrders"
        Me.dgvPendingOrders.ReadOnly = True
        Me.dgvPendingOrders.RowHeadersVisible = False
        Me.dgvPendingOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPendingOrders.Size = New System.Drawing.Size(800, 350)
        Me.dgvPendingOrders.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnCancelOrder)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 350)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 100)
        Me.Panel1.TabIndex = 2
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelOrder.FlatAppearance.BorderSize = 0
        Me.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelOrder.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelOrder.ForeColor = System.Drawing.Color.White
        Me.btnCancelOrder.Location = New System.Drawing.Point(304, 32)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(171, 23)
        Me.btnCancelOrder.TabIndex = 0
        Me.btnCancelOrder.Text = "✕ CANCEL ORDER"
        Me.btnCancelOrder.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gold
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(304, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "↻ REFRESH ORDERS"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'colQueueNumber
        '
        Me.colQueueNumber.HeaderText = "QUEUE No."
        Me.colQueueNumber.Name = "colQueueNumber"
        Me.colQueueNumber.ReadOnly = True
        '
        'colOrderType
        '
        Me.colOrderType.HeaderText = "ORDER TYPE"
        Me.colOrderType.Name = "colOrderType"
        Me.colOrderType.ReadOnly = True
        '
        'colItems
        '
        Me.colItems.HeaderText = "ITEMS"
        Me.colItems.Name = "colItems"
        Me.colItems.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.HeaderText = "TOTAL"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'colPayment
        '
        Me.colPayment.HeaderText = "PAYMENT"
        Me.colPayment.Name = "colPayment"
        Me.colPayment.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "STATUS"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'colAction
        '
        Me.colAction.HeaderText = "ACTION"
        Me.colAction.Name = "colAction"
        Me.colAction.ReadOnly = True
        '
        'frmPendingOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvPendingOrders)
        Me.Controls.Add(Me.pnlPendingHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPendingOrders"
        Me.Text = "Pending Orders"
        Me.pnlPendingHeader.ResumeLayout(False)
        Me.pnlPendingHeader.PerformLayout()
        CType(Me.dgvPendingOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPendingHeader As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvPendingOrders As DataGridView
    Friend WithEvents btnCancelOrder As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents colQueueNumber As DataGridViewTextBoxColumn
    Friend WithEvents colOrderType As DataGridViewTextBoxColumn
    Friend WithEvents colItems As DataGridViewTextBoxColumn
    Friend WithEvents colTotal As DataGridViewTextBoxColumn
    Friend WithEvents colPayment As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colAction As DataGridViewTextBoxColumn
End Class
