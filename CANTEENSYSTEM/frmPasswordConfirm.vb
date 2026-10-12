''' <summary>Admin re-authentication dialog: masked password prompt with OK/Cancel.
''' Code-only form (no Designer/resx) in the navy/gold theme. Shared Ask()
''' returns the entered password, or Nothing when cancelled.</summary>
Public Class frmPasswordConfirm
    Inherits System.Windows.Forms.Form

    Private ReadOnly lblPrompt As New System.Windows.Forms.Label()
    Private ReadOnly txtPassword As New System.Windows.Forms.TextBox()
    Private ReadOnly btnOK As New System.Windows.Forms.Button()
    Private ReadOnly btnCancel As New System.Windows.Forms.Button()

    Public Sub New(prompt As String, title As String)
        Me.Text = title
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ClientSize = New System.Drawing.Size(320, 125)
        Me.BackColor = System.Drawing.Color.FromArgb(11, 27, 61)

        lblPrompt.AutoSize = False
        lblPrompt.Location = New System.Drawing.Point(15, 12)
        lblPrompt.Size = New System.Drawing.Size(290, 20)
        lblPrompt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        lblPrompt.ForeColor = System.Drawing.Color.White
        lblPrompt.Text = prompt

        txtPassword.Location = New System.Drawing.Point(15, 36)
        txtPassword.Size = New System.Drawing.Size(290, 25)
        txtPassword.PasswordChar = ChrW(9679) ' ●
        txtPassword.UseSystemPasswordChar = False

        btnOK.Text = "OK"
        btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnOK.FlatAppearance.BorderSize = 0
        btnOK.BackColor = System.Drawing.Color.FromArgb(245, 194, 27)
        btnOK.ForeColor = System.Drawing.Color.FromArgb(11, 27, 61)
        btnOK.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        btnOK.Location = New System.Drawing.Point(145, 78)
        btnOK.Size = New System.Drawing.Size(75, 30)

        btnCancel.Text = "Cancel"
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        btnCancel.ForeColor = System.Drawing.Color.White
        btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        btnCancel.Location = New System.Drawing.Point(230, 78)
        btnCancel.Size = New System.Drawing.Size(75, 30)

        Me.AcceptButton = btnOK
        Me.CancelButton = btnCancel
        Me.Controls.Add(lblPrompt)
        Me.Controls.Add(txtPassword)
        Me.Controls.Add(btnOK)
        Me.Controls.Add(btnCancel)
    End Sub

    ''' <summary>Shows the modal password prompt. Returns password, or Nothing on Cancel/close.</summary>
    Public Shared Function Ask(prompt As String, Optional title As String = "Admin Confirmation") As String
        Using d As New frmPasswordConfirm(prompt, title)
            If d.ShowDialog() = System.Windows.Forms.DialogResult.OK Then Return d.txtPassword.Text
            Return Nothing
        End Using
    End Function

End Class
