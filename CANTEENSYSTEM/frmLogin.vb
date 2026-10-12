Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class frmLogin

    '=========================================================
    ' DATABASE CONNECTION — PHASE 0: canonical string lives in
    ' DbHelper (App.config <connectionStrings name="CanteenDb">).
    '=========================================================

    '=========================================================
    ' SELECTED LOGIN ROLE
    '=========================================================
    Private selectedRole As String = "Cashier"

    '=========================================================
    ' ANTI-GUESSING: session-level fail counter for UNKNOWN
    ' usernames (no DB row exists to count against). Key =
    ' lowercase username, value = attempts remaining (starts 4).
    ' Capped so random-name spraying cannot grow memory.
    '=========================================================
    Private unknownAttempts As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
    Private Const MaxUnknownEntries As Integer = 500
    Private Const MaxAttempts As Integer = 4

    '=========================================================
    ' LOCK COOLDOWN: after an account locks, the login button
    ' stays disabled for 10 seconds, then the lock is REMOVED
    ' automatically (status back to Active, attempts reset) and
    ' anyone can try again. No admin action needed.
    '=========================================================
    Private Const LockCooldownSeconds As Integer = 10
    Private cooldownEndsAt As DateTime = DateTime.MinValue
    Private WithEvents cooldownTimer As New Timer()
    Private coolUserId As Integer = 0
    Private coolUsername As String = ""


    '=========================================================
    ' FORM LOAD
    '=========================================================
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True

        'Default role = Cashier
        selectedRole = "Cashier"

        'Set Cashier tab appearance
        btnCashierTab.BackColor = Color.FromArgb(140, 130, 115)
        btnAdminTab.BackColor = Color.FromArgb(253, 238, 178)

        'Set labels
        lblUserHeader.Text = "CASHIER ID / USERNAME"
        lblPassHeader.Text = "PIN / PASSWORD"

        'Set button
        btnLogin.Text = "OPEN POS TERMINAL ➔"

        'Password should be hidden
        txtPassword.PasswordChar = "●"c

        cooldownTimer.Interval = 250

    End Sub

    Private Function IsCoolingDown() As Boolean
        Return DateTime.Now < cooldownEndsAt
    End Function

    ' Disabled login + live WAIT countdown; when the 10 seconds
    ' expire the lock is auto-removed, then the button is restored.
    ' userId = 0 means an unknown (session-only) name.
    Private Sub StartLoginCooldown(Optional userId As Integer = 0, Optional username As String = "")
        coolUserId = userId
        coolUsername = If(username, "")
        cooldownEndsAt = DateTime.Now.AddSeconds(LockCooldownSeconds)
        Try
            btnLogin.Enabled = False
            txtUsername.Enabled = False
            txtPassword.Enabled = False
        Catch
        End Try
        cooldownTimer.Stop()
        cooldownTimer.Start()
        UpdateCooldownText()
    End Sub

    Private Sub UpdateCooldownText()
        Try
            Dim secs As Integer = CInt(Math.Ceiling((cooldownEndsAt - DateTime.Now).TotalSeconds))
            If secs < 0 Then secs = 0
            btnLogin.Text = $"WAIT {secs}s..."
        Catch
        End Try
    End Sub

    Private Sub RestoreLoginButton()
        Try
            btnLogin.Enabled = True
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            If selectedRole.ToLower() = "cashier" Then
                btnLogin.Text = "OPEN POS TERMINAL ➔"
            Else
                btnLogin.Text = "LOG IN TO DASHBOARD ➔"
            End If
            txtUsername.Focus()
        Catch
        End Try
    End Sub

    ' Lifts the lock the moment the countdown ends: known users
    ' are reset in the DB, unknown names are cleared from the
    ' session dictionary.
    Private Sub AutoRemoveLock()
        Try
            If coolUserId > 0 Then
                Using conn As MySqlConnection = DbHelper.GetConnection()
                    conn.Open()
                    Using cmd As New MySqlCommand("UPDATE users SET status='Active', login_attempts=0 WHERE id=@id", conn)
                        cmd.Parameters.AddWithValue("@id", coolUserId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            ElseIf Not String.IsNullOrWhiteSpace(coolUsername) Then
                unknownAttempts.Remove(coolUsername.ToLower())
            End If
        Catch ex As Exception
            Debug.WriteLine("AutoRemoveLock failed: " & ex.Message)
        Finally
            coolUserId = 0
            coolUsername = ""
        End Try
    End Sub

    Private Sub cooldownTimer_Tick(sender As Object, e As EventArgs) Handles cooldownTimer.Tick
        If IsCoolingDown() Then
            UpdateCooldownText()
        Else
            cooldownTimer.Stop()
            AutoRemoveLock()
            RestoreLoginButton()
        End If
    End Sub


    '=========================================================
    ' CASHIER TAB
    '=========================================================
    Private Sub btnCashierTab_Click(sender As Object, e As EventArgs) Handles btnCashierTab.Click

        selectedRole = "Cashier"

        'Colors
        btnCashierTab.BackColor = Color.FromArgb(140, 130, 115)
        btnAdminTab.BackColor = Color.FromArgb(253, 238, 178)

        'Labels
        lblUserHeader.Text = "CASHIER ID / USERNAME"
        lblPassHeader.Text = "PIN / PASSWORD"

        'Login button (leave the WAIT countdown alone mid-cooldown)
        If Not IsCoolingDown() Then btnLogin.Text = "OPEN POS TERMINAL ➔"

        'Clear fields
        txtUsername.Clear()
        txtPassword.Clear()

        txtUsername.Focus()

    End Sub


    '=========================================================
    ' ADMIN TAB
    '=========================================================
    Private Sub btnAdminTab_Click(sender As Object, e As EventArgs) Handles btnAdminTab.Click

        selectedRole = "Admin"

        'Colors
        btnAdminTab.BackColor = Color.FromArgb(140, 130, 115)
        btnCashierTab.BackColor = Color.FromArgb(253, 238, 178)

        'Labels
        lblUserHeader.Text = "ADMIN ID / USERNAME"
        lblPassHeader.Text = "ADMIN PASSWORD"

        'Login button (leave the WAIT countdown alone mid-cooldown)
        If Not IsCoolingDown() Then btnLogin.Text = "LOG IN TO DASHBOARD ➔"

        'Clear fields
        txtUsername.Clear()
        txtPassword.Clear()

        txtUsername.Focus()

    End Sub


    '=========================================================
    ' LOGIN BUTTON
    '=========================================================
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        '-----------------------------------------------------
        ' CHECK EMPTY FIELDS
        '-----------------------------------------------------
        If username = "" Then

            MessageBox.Show(
                "Please enter your username.",
                "Login Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtUsername.Focus()
            Return

        End If


        If password = "" Then

            MessageBox.Show(
                "Please enter your password.",
                "Login Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtPassword.Focus()
            Return

        End If


        '-----------------------------------------------------
        ' SESSION BLOCK: unknown name already burned 4 attempts
        '-----------------------------------------------------
        Dim sessionKey As String = username.ToLower()
        If unknownAttempts.ContainsKey(sessionKey) AndAlso unknownAttempts(sessionKey) <= 0 Then

            MessageBox.Show(
                "Login attempts are locked due to many login attempts." &
                vbCrLf &
                "Please wait 10 seconds and try again.",
                "Account Locked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtPassword.Clear()

            StartLoginCooldown(0, sessionKey)

            Return

        End If


        '-----------------------------------------------------
        ' CONNECT TO DATABASE
        '-----------------------------------------------------
        Try

            Using conn As MySqlConnection = DbHelper.GetConnection()

                conn.Open()


                '-------------------------------------------------
                ' FIND USER (id + fullname needed for Session)
                ' 4-attempt lockout: login_attempts counted per user.
                '-------------------------------------------------
                Dim query As String =
                    "SELECT id, fullname, username, password, role, status, login_attempts " &
                    "FROM users " &
                    "WHERE username = @username " &
                    "LIMIT 1"


                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@username", username)


                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        '-------------------------------------------------
                        ' USERNAME DOES NOT EXIST — anti-guessing path.
                        ' No DB row exists, so count down in the session
                        ' dictionary. Unknown names report "locked due to
                        ' many login attempts"; real accounts report
                        ' "this account is locked".
                        '-------------------------------------------------
                        If Not reader.Read() Then
                            reader.Close()

                            Dim key As String = username.ToLower()
                            Dim left As Integer = MaxAttempts - 1
                            If unknownAttempts.ContainsKey(key) Then
                                left = unknownAttempts(key) - 1
                            ElseIf unknownAttempts.Count >= MaxUnknownEntries Then
                                unknownAttempts.Clear()
                            End If
                            If left < 0 Then left = 0
                            unknownAttempts(key) = left

                            ' audit_logs.user_id FKs to users.id, so unknown names
                            ' cannot be logged there — trace locally instead.
                            Debug.WriteLine($"Unknown username '{username}' failed login ({MaxAttempts - left}/4)")

                            If left <= 0 Then
                                MessageBox.Show(
                                    "Invalid username or password." &
                                    vbCrLf &
                                    "Login attempts are locked due to many login attempts." &
                                    vbCrLf &
                                    "Please wait 10 seconds and try again.",
                                    "Account Locked",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                            Else
                                MessageBox.Show(
                                    "Invalid username or password." &
                                    vbCrLf &
                                    $"{left} attempt{If(left = 1, "", "s")} remaining.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                            End If

                            txtPassword.Clear()

                            If left <= 0 Then StartLoginCooldown(0, key)

                            Return

                        End If


                        '-------------------------------------------------
                        ' GET DATABASE VALUES
                        '-------------------------------------------------
                        Dim dbId As Integer = Convert.ToInt32(reader("id"))

                        Dim dbFullName As String =
                            reader("fullname").ToString()

                        Dim dbUsername As String =
                            reader("username").ToString()

                        Dim dbPassword As String =
                            reader("password").ToString()

                        Dim dbRole As String =
                            reader("role").ToString()

                        Dim dbStatus As String =
                            reader("status").ToString()

                        Dim dbAttempts As Integer = 0
                        Try
                            If reader("login_attempts") IsNot DBNull.Value Then
                                Integer.TryParse(reader("login_attempts").ToString(), dbAttempts)
                            End If
                        Catch
                            dbAttempts = 0
                        End Try

                        Dim dbUserIdForUpdate As Integer = dbId
                        reader.Close()


                        '-------------------------------------------------
                        ' CHECK ACCOUNT LOCKED (4 failed attempts)
                        '-------------------------------------------------
                        If dbStatus.ToLower() = "locked" OrElse dbAttempts >= 4 Then
                            If dbStatus.ToLower() <> "locked" Then
                                Try
                                    Using lockCmd As New MySqlCommand("UPDATE users SET status='Locked' WHERE id=@id", conn)
                                        lockCmd.Parameters.AddWithValue("@id", dbUserIdForUpdate)
                                        lockCmd.ExecuteNonQuery()
                                    End Using
                                Catch
                                End Try
                            End If

                            MessageBox.Show(
                                "This account is locked." &
                                vbCrLf &
                                "Please wait 10 seconds and try again.",
                                "Account Locked",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)

                            txtPassword.Clear()

                            StartLoginCooldown(dbUserIdForUpdate, dbUsername)

                            Return

                        End If


                        '-------------------------------------------------
                        ' CHECK PASSWORD (counts as 1 failed attempt)
                        '-------------------------------------------------
                        If password <> dbPassword Then

                            Dim newAttempts As Integer = dbAttempts + 1

                            Try
                                Using upd As New MySqlCommand("UPDATE users SET login_attempts=@n WHERE id=@id", conn)
                                    upd.Parameters.AddWithValue("@n", newAttempts)
                                    upd.Parameters.AddWithValue("@id", dbUserIdForUpdate)
                                    upd.ExecuteNonQuery()
                                End Using
                            Catch
                            End Try

                            Try
                                AuditLog.Log(dbUserIdForUpdate, "Login Failed", $"{dbUsername} failed login attempt {newAttempts}/4")
                            Catch
                            End Try

                            If newAttempts >= 4 Then
                                Try
                                    Using lockCmd As New MySqlCommand("UPDATE users SET status='Locked' WHERE id=@id", conn)
                                        lockCmd.Parameters.AddWithValue("@id", dbUserIdForUpdate)
                                        lockCmd.ExecuteNonQuery()
                                    End Using
                                Catch
                                End Try

                                MessageBox.Show(
                                    "Invalid username or password." &
                                    vbCrLf &
                                    "This account is locked." &
                                    vbCrLf &
                                    "Please wait 10 seconds and try again.",
                                    "Account Locked",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)

                                StartLoginCooldown(dbUserIdForUpdate, dbUsername)
                            Else
                                Dim left As Integer = 4 - newAttempts
                                MessageBox.Show(
                                    "Invalid username or password." &
                                    vbCrLf &
                                    $"{left} attempt{If(left = 1, "", "s")} remaining.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                            End If

                            txtPassword.Clear()
                            txtPassword.Focus()

                            Return

                        End If


                        '-------------------------------------------------
                        ' CHECK ACCOUNT STATUS
                        '-------------------------------------------------
                        If dbStatus.ToLower() <> "active" Then

                            MessageBox.Show(
                                "This account is currently inactive." &
                                vbCrLf &
                                "Please contact the administrator.",
                                "Account Inactive",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)

                            Return

                        End If

                        ' Password correct: reset the counter.
                        Try
                            Using resetCmd As New MySqlCommand("UPDATE users SET login_attempts=0 WHERE id=@id", conn)
                                resetCmd.Parameters.AddWithValue("@id", dbUserIdForUpdate)
                                resetCmd.ExecuteNonQuery()
                            End Using
                        Catch
                        End Try


                        '-------------------------------------------------
                        ' CHECK SELECTED TAB VS DATABASE ROLE
                        '-------------------------------------------------
                        If selectedRole.ToLower() = "cashier" Then

                            If dbRole.ToLower() <> "cashier" AndAlso
                               dbRole.ToLower() <> "staff" Then

                                MessageBox.Show(
                                    "This account is not registered as a Cashier/Staff account.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)

                                Return

                            End If


                            '---------------------------------------------
                            ' CASHIER → POS
                            '---------------------------------------------
                            MessageBox.Show(
                                "Login successful!" &
                                vbCrLf &
                                "Opening POS Terminal...",
                                "Cashier Access Granted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                            Session.SetUser(dbId, dbUsername, dbFullName, dbRole)
                            AuditLog.Log(dbId, "Login", $"{dbUsername} logged in as {dbRole} (POS)")
                            Try
                                unknownAttempts.Remove(dbUsername.ToLower())
                            Catch
                            End Try

                            Dim posForm As New frmPOS()

                            posForm.Show()

                            Me.Hide()


                        ElseIf selectedRole.ToLower() = "admin" Then

                            If dbRole.ToLower() <> "admin" Then

                                MessageBox.Show(
                                    "This account is not registered as an Administrator account.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)

                                Return

                            End If


                            '---------------------------------------------
                            ' ADMIN → DASHBOARD
                            '---------------------------------------------
                            MessageBox.Show(
                                "Login successful!" &
                                vbCrLf &
                                "Opening Admin Dashboard...",
                                "Admin Access Granted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                            Session.SetUser(dbId, dbUsername, dbFullName, dbRole)
                            AuditLog.Log(dbId, "Login", $"{dbUsername} logged in as {dbRole} (Dashboard)")
                            Try
                                unknownAttempts.Remove(dbUsername.ToLower())
                            Catch
                            End Try

                            Dim dashboard As New frmDashboard()

                            dashboard.Show()

                            Me.Hide()

                        End If

                    End Using

                End Using

            End Using


        Catch ex As MySqlException

            MessageBox.Show(
                "Database error:" &
                vbCrLf &
                vbCrLf &
                ex.Message,
                "MySQL Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)


        Catch ex As Exception

            MessageBox.Show(
                "An unexpected error occurred:" &
                vbCrLf &
                vbCrLf &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    '=========================================================
    ' FORGOT PASSWORD
    '=========================================================
    Private Sub lblForgotPassword_LinkClicked(
        sender As Object,
        e As LinkLabelLinkClickedEventArgs
    ) Handles lblForgotPassword.LinkClicked

        MessageBox.Show(
            "Please contact the System Administrator to reset your password.",
            "Reset Password",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    ' Header X returns to the front door instead of stranding a hidden MainForm.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Navigator.ReturnToSystemSelect(Me)
    End Sub
End Class