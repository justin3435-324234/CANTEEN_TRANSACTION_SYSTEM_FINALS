<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSystemSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemSelect))
        Me.btnkiosk = New System.Windows.Forms.Button()
        Me.btnStaffSystem = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnkiosk
        '
        Me.btnkiosk.BackColor = System.Drawing.Color.Gold
        Me.btnkiosk.FlatAppearance.BorderSize = 0
        Me.btnkiosk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkiosk.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnkiosk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnkiosk.Location = New System.Drawing.Point(149, 244)
        Me.btnkiosk.Name = "btnkiosk"
        Me.btnkiosk.Size = New System.Drawing.Size(170, 35)
        Me.btnkiosk.TabIndex = 0
        Me.btnkiosk.Text = "🖥️ SELF-SERVICE KIOSK "
        Me.btnkiosk.UseVisualStyleBackColor = False
        '
        'btnStaffSystem
        '
        Me.btnStaffSystem.BackColor = System.Drawing.Color.Gold
        Me.btnStaffSystem.FlatAppearance.BorderSize = 0
        Me.btnStaffSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStaffSystem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStaffSystem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStaffSystem.Location = New System.Drawing.Point(149, 285)
        Me.btnStaffSystem.Name = "btnStaffSystem"
        Me.btnStaffSystem.Size = New System.Drawing.Size(170, 35)
        Me.btnStaffSystem.TabIndex = 1
        Me.btnStaffSystem.Text = "👨‍💼 STAFF SYSTEM"
        Me.btnStaffSystem.UseVisualStyleBackColor = False
        '
        'frmSystemSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(509, 332)
        Me.Controls.Add(Me.btnStaffSystem)
        Me.Controls.Add(Me.btnkiosk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSystemSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSystemSelect"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnkiosk As Button
    Friend WithEvents btnStaffSystem As Button
End Class
