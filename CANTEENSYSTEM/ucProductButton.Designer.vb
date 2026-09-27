<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucProductButton
    Inherits System.Windows.Forms.UserControl

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCard
        '
        Me.btnCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.btnCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCard.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCard.ForeColor = System.Drawing.Color.White
        Me.btnCard.Location = New System.Drawing.Point(0, 0)
        Me.btnCard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(100, 68)
        Me.btnCard.TabIndex = 0
        Me.btnCard.Text = "SAMPLE ₱00.00"
        Me.btnCard.UseVisualStyleBackColor = False
        '
        'ucProductButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCard)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ucProductButton"
        Me.Size = New System.Drawing.Size(100, 68)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCard As Button
End Class
