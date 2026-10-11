' ============================================================
' PHASE 0 — Session: who is currently logged in.
' Set once in frmLogin on successful auth, read by POS /
' Dashboard / History for transactions.user_id, stock_movements.user_id,
' audit_logs.user_id. Clear on logout.
' ============================================================
Public Module Session
    Public Property CurrentUserId As Integer = 0
    Public Property CurrentUsername As String = ""
    Public Property CurrentFullName As String = ""
    Public Property CurrentRole As String = ""

    Public ReadOnly Property IsLoggedIn As Boolean
        Get
            Return CurrentUserId > 0
        End Get
    End Property

    Public Sub SetUser(userId As Integer, username As String, fullName As String, role As String)
        CurrentUserId = userId
        CurrentUsername = If(username, "")
        CurrentFullName = If(fullName, "")
        CurrentRole = If(role, "")
    End Sub

    Public Sub Clear()
        CurrentUserId = 0
        CurrentUsername = ""
        CurrentFullName = ""
        CurrentRole = ""
    End Sub
End Module
