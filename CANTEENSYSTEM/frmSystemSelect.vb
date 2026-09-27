Public Class frmSystemSelect

    ' Front door of the system: customers go to the Kiosk, staff go to Login.
    ' This form is the application's MainForm — it stays alive (hidden) for
    ' the whole session; children only Hide/Close themselves.
    '
    ' No entry without a live database: connectivity is checked on load,
    ' on every return, and again inside each button before navigating.
    Private dbOnline As Boolean = False

    ' Returns True when MySQL answers. No on-screen indicator by design:
    ' silent checks run on Load/return; the buttons pop the error when offline.
    Private Function CheckDatabase(silent As Boolean) As Boolean
        Dim msg As String = ""
        dbOnline = DbHelper.TestConnection(msg)
        If (Not dbOnline) AndAlso (Not silent) Then
            MessageBox.Show("Cannot reach the database. Please start MySQL in the XAMPP Control Panel, then try again." & vbCrLf & vbCrLf & "Details: " & msg, "Database Offline", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return dbOnline
    End Function

    Private Sub frmSystemSelect_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        CheckDatabase(True) ' re-verify whenever returning (MySQL may have stopped)
    End Sub

    Private Sub btnkiosk_Click(sender As Object, e As EventArgs) Handles btnkiosk.Click
        If Not CheckDatabase(False) Then Exit Sub
        Dim kiosk As New frmKiosk()
        kiosk.StartPosition = FormStartPosition.CenterScreen
        kiosk.Show()
        Me.Hide()
    End Sub

    Private Sub btnStaffSystem_Click(sender As Object, e As EventArgs) Handles btnStaffSystem.Click
        If Not CheckDatabase(False) Then Exit Sub
        Dim login As New frmLogin()
        login.Show()
        Me.Hide()
    End Sub

    ' Borderless front door has no X button — this is the clean way out.
    ' (Designer-visible: btnExitApp lives in frmSystemSelect.Designer.vb)
    Private Sub frmSystemSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        CheckDatabase(True)
        btnExitApp.BringToFront()
    End Sub

    Private Sub btnExitApp_Click(sender As Object, e As EventArgs) Handles btnExitApp.Click
        If MessageBox.Show("Exit the canteen system?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class
