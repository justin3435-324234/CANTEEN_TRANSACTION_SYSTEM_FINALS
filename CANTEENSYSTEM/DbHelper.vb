Imports MySql.Data.MySqlClient

' ============================================================
' PHASE 0 — DbHelper: single place for the MySQL connection string.
' All forms/modules must use DbHelper.GetConnection() instead of
' hardcoding "Server=localhost;...".
' Reads App.config <connectionStrings name="CanteenDb"> first,
' falls back to localhost default so existing installs keep working.
' ============================================================
Public Module DbHelper
    Private Const FallbackConnectionString As String = "Server=localhost;Database=school_canteen_db;Uid=root;Pwd=;"

    Public Function GetConnectionString() As String
        Try
            Dim cs = System.Configuration.ConfigurationManager.ConnectionStrings("CanteenDb")
            If cs IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cs.ConnectionString) Then
                Return cs.ConnectionString
            End If
        Catch
            ' ConfigurationManager unavailable — use fallback
        End Try
        Return FallbackConnectionString
    End Function

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(WithTimeout(GetConnectionString()))
    End Function

    ' Fail fast (5s) so a stopped MySQL never hangs the UI.
    Private Function WithTimeout(cs As String) As String
        If cs.ToLower().Contains("connection timeout") OrElse cs.ToLower().Contains("connect timeout") Then Return cs
        Dim sep As String = If(cs.TrimEnd().EndsWith(";"), "", ";")
        Return cs & sep & "Connection Timeout=5;"
    End Function

    ' Front-door health check: True when MySQL answers. Never throws.
    Public Function TestConnection(ByRef message As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT 1", conn)
                    cmd.ExecuteScalar()
                End Using
            End Using
            message = "Database connected."
            Return True
        Catch ex As Exception
            message = ex.Message
            Return False
        End Try
    End Function
End Module
