Imports MySql.Data.MySqlClient

' ============================================================
' PHASE 7 — AuditLog: shared audit trail writer.
' Prefer this over inline INSERTs for new code. userId must be a
' real users.id (FK); calls with unknown users are skipped, not
' misattributed.
' ============================================================
Public Module AuditLog

    Public Sub Log(userId As Integer, action As String, description As String)
        If userId <= 0 Then Return
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, @action, @d)", conn)
                    cmd.Parameters.AddWithValue("@uid", userId)
                    cmd.Parameters.AddWithValue("@action", If(action, ""))
                    cmd.Parameters.AddWithValue("@d", If(description, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("AuditLog.Log failed: " & ex.Message)
        End Try
    End Sub

End Module
