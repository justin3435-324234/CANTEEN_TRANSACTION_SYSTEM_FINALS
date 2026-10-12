Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmEmployeeLogin
    Inherits Form

    Public Property EmployeeNumber As String = ""
    Public Property EmployeeUsername As String = ""
    Public Property EmployeeName As String = ""
    Public Property EmployeePosition As String = ""
    Public Property EmployeeStatus As String = ""
    Public Property EmployeeDeductionStatus As String = ""
    Public Property IsValidLogin As Boolean = False

    ' Anti-guessing: session-level fail counter for UNKNOWN employee
    ' usernames (no DB row exists to count against). Capped so random-name
    ' spraying cannot grow memory.
    Private unknownAttempts As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
    Private Const MaxUnknownEntries As Integer = 500
    Private Const MaxAttempts As Integer = 4

    ' Lock cooldown: after an account locks, the LOGIN button stays
    ' disabled for 10 seconds, then the lock is REMOVED automatically
    ' (status back to Active, attempts reset). No admin action needed.
    Private Const LockCooldownSeconds As Integer = 10
    Private cooldownEndsAt As DateTime = DateTime.MinValue
    Private WithEvents cooldownTimer As New Timer()
    Private coolEmpNo As String = ""
    Private coolUsername As String = ""

    ' PHASE 0: connection string lives in DbHelper (App.config).

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPin As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPin As Label
    Friend WithEvents btnCancel As Button

    Public Sub New()
        InitializeComponent()
        cooldownTimer.Interval = 250
    End Sub

    Private Function IsCoolingDown() As Boolean
        Return DateTime.Now < cooldownEndsAt
    End Function

    Private Sub StartLoginCooldown(Optional empNo As String = "", Optional username As String = "")
        coolEmpNo = If(empNo, "")
        coolUsername = If(username, "")
        cooldownEndsAt = DateTime.Now.AddSeconds(LockCooldownSeconds)
        Try
            btnLogin.Enabled = False
            txtUsername.Enabled = False
            txtPin.Enabled = False
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
            txtPin.Enabled = True
            btnLogin.Text = "LOGIN"
            txtUsername.Focus()
        Catch
        End Try
    End Sub

    ' Lifts the lock the moment the countdown ends: known employees
    ' are reset in the DB, unknown names are cleared from the session.
    Private Sub AutoRemoveLock()
        Try
            If Not String.IsNullOrWhiteSpace(coolEmpNo) Then
                Using conn As MySqlConnection = DbHelper.GetConnection()
                    conn.Open()
                    Try
                        Using cmd As New MySqlCommand("UPDATE employees SET status='Active', login_attempts=0 WHERE employee_number=@e", conn)
                            cmd.Parameters.AddWithValue("@e", coolEmpNo)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch
                        Using cmd2 As New MySqlCommand("UPDATE employees SET status='Active' WHERE employee_number=@e", conn)
                            cmd2.Parameters.AddWithValue("@e", coolEmpNo)
                            cmd2.ExecuteNonQuery()
                        End Using
                    End Try
                End Using
            ElseIf Not String.IsNullOrWhiteSpace(coolUsername) Then
                unknownAttempts.Remove(coolUsername.ToLower())
            End If
        Catch ex As Exception
            Debug.WriteLine("AutoRemoveLock failed: " & ex.Message)
        Finally
            coolEmpNo = ""
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

    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPin = New System.Windows.Forms.Label()
        Me.txtPin = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(58, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(215, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "EMPLOYEE LOGIN"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.White
        Me.lblSubtitle.Location = New System.Drawing.Point(60, 64)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(336, 20)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Enter your username and PIN for salary deduction"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.White
        Me.lblUsername.Location = New System.Drawing.Point(60, 100)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(94, 23)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtUsername.Location = New System.Drawing.Point(60, 125)
        Me.txtUsername.MaxLength = 50
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(280, 32)
        Me.txtUsername.TabIndex = 3
        '
        'lblPin
        '
        Me.lblPin.AutoSize = True
        Me.lblPin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPin.ForeColor = System.Drawing.Color.White
        Me.lblPin.Location = New System.Drawing.Point(60, 165)
        Me.lblPin.Name = "lblPin"
        Me.lblPin.Size = New System.Drawing.Size(106, 23)
        Me.lblPin.TabIndex = 5
        Me.lblPin.Text = "4-Digit PIN:"
        '
        'txtPin
        '
        Me.txtPin.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPin.Location = New System.Drawing.Point(60, 190)
        Me.txtPin.MaxLength = 4
        Me.txtPin.Name = "txtPin"
        Me.txtPin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPin.Size = New System.Drawing.Size(280, 32)
        Me.txtPin.TabIndex = 6
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Location = New System.Drawing.Point(60, 245)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(130, 40)
        Me.btnLogin.TabIndex = 7
        Me.btnLogin.Text = "LOGIN"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(210, 245)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(130, 40)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmEmployeeLogin
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(418, 332)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPin)
        Me.Controls.Add(Me.txtPin)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnCancel)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmployeeLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Login - Salary Deduction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub txtPin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPin.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usernameInput As String = txtUsername.Text.Trim()
        Dim pin As String = txtPin.Text.Trim()

        If String.IsNullOrWhiteSpace(usernameInput) Then
            MessageBox.Show("Please enter your Username.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        End If

        ' Validate PIN
        If String.IsNullOrWhiteSpace(pin) OrElse pin.Length <> 4 OrElse Not IsNumeric(pin) Then
            MessageBox.Show("Please enter a valid 4-digit PIN.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPin.Focus()
            Exit Sub
        End If

        ' Session block: unknown name already burned 4 attempts.
        Dim sessionKey As String = usernameInput.ToLower()
        If unknownAttempts.ContainsKey(sessionKey) AndAlso unknownAttempts(sessionKey) <= 0 Then
            MessageBox.Show("Login attempts are locked due to many login attempts." & vbCrLf & "Please wait 10 seconds and try again.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPin.Clear()
            StartLoginCooldown("", sessionKey)
            Exit Sub
        End If

        ' 4-attempt lockout: counter is per employee username.
        Dim knownEmpNo As String = ""
        Dim knownAttempts As Integer = 0
        Dim knownLocked As Boolean = False
        Try
            Using preConn As MySqlConnection = DbHelper.GetConnection()
                preConn.Open()
                Try
                    Using pre As New MySqlCommand("SELECT employee_number, status, login_attempts FROM employees WHERE username=@u LIMIT 1", preConn)
                        pre.Parameters.AddWithValue("@u", usernameInput)
                        Using pr As MySqlDataReader = pre.ExecuteReader()
                            If pr.Read() Then
                                knownEmpNo = pr("employee_number").ToString()
                                Dim st As String = If(pr("status") Is DBNull.Value, "Active", pr("status").ToString())
                                Try
                                    If pr("login_attempts") IsNot DBNull.Value Then Integer.TryParse(pr("login_attempts").ToString(), knownAttempts)
                                Catch
                                End Try
                                If st.Equals("Locked", StringComparison.OrdinalIgnoreCase) OrElse knownAttempts >= 4 Then knownLocked = True
                            End If
                        End Using
                    End Using
                Catch
                    ' login_attempts column may not exist yet (pre-migration): retry without it.
                    Try
                        Using pre2 As New MySqlCommand("SELECT employee_number, status FROM employees WHERE username=@u LIMIT 1", preConn)
                            pre2.Parameters.AddWithValue("@u", usernameInput)
                            Using pr2 As MySqlDataReader = pre2.ExecuteReader()
                                If pr2.Read() Then
                                    knownEmpNo = pr2("employee_number").ToString()
                                    Dim st2 As String = If(pr2("status") Is DBNull.Value, "Active", pr2("status").ToString())
                                    If st2.Equals("Locked", StringComparison.OrdinalIgnoreCase) Then knownLocked = True
                                End If
                            End Using
                        End Using
                    Catch
                    End Try
                End Try
            End Using
        Catch
        End Try

        If knownLocked Then
            Try
                Using lockConn As MySqlConnection = DbHelper.GetConnection()
                    lockConn.Open()
                    Using lockCmd As New MySqlCommand("UPDATE employees SET status='Locked' WHERE username=@u", lockConn)
                        lockCmd.Parameters.AddWithValue("@u", usernameInput)
                        lockCmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch
            End Try
            MessageBox.Show("This employee account is locked." & vbCrLf & "Please wait 10 seconds and try again.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPin.Clear()
            StartLoginCooldown(knownEmpNo, usernameInput)
            Exit Sub
        End If

        ' Verify against employees.sql / database (employees table)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Dim query As String = "SELECT employee_number, username, full_name, position, status, deduction_status FROM employees WHERE username=@username AND pin=@pin LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", usernameInput)
                    cmd.Parameters.AddWithValue("@pin", pin)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            EmployeeNumber = reader("employee_number").ToString()
                            EmployeeUsername = reader("username").ToString()
                            EmployeeName = reader("full_name").ToString()
                            EmployeePosition = If(reader("position") Is DBNull.Value, "", reader("position").ToString())
                            EmployeeStatus = If(reader("status") Is DBNull.Value, "Available", reader("status").ToString())
                            EmployeeDeductionStatus = If(reader("deduction_status") Is DBNull.Value, "PENDING", reader("deduction_status").ToString().Trim().ToUpper())
                            If RejectInactiveAccount() Then Exit Sub
                            ResetEmployeeAttempts(EmployeeNumber)
                            Try
                                unknownAttempts.Remove(usernameInput.ToLower())
                            Catch
                            End Try
                            IsValidLogin = True
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                            Exit Sub
                        End If
                    End Using
                End Using

                ' Fallback: try case-insensitive username with old column names
                Dim fallbackQuery As String = "SELECT EmpNo, username, FullName, Position, Status, DeductionStatus FROM employees WHERE username=@username AND pin=@pin LIMIT 1"
                Try
                    Using cmd2 As New MySqlCommand(fallbackQuery, conn)
                        cmd2.Parameters.AddWithValue("@username", usernameInput)
                        cmd2.Parameters.AddWithValue("@pin", pin)
                        Using r2 As MySqlDataReader = cmd2.ExecuteReader()
                            If r2.Read() Then
                                EmployeeNumber = r2("EmpNo").ToString()
                                EmployeeUsername = r2("username").ToString()
                                EmployeeName = r2("FullName").ToString()
                                EmployeePosition = If(r2("Position") Is DBNull.Value, "", r2("Position").ToString())
                                EmployeeStatus = If(r2("Status") Is DBNull.Value, "Available", r2("Status").ToString())
                                EmployeeDeductionStatus = If(r2("DeductionStatus") Is DBNull.Value, "PENDING", r2("DeductionStatus").ToString().Trim().ToUpper())
                                If RejectInactiveAccount() Then Exit Sub
                                ResetEmployeeAttempts(EmployeeNumber)
                                Try
                                    unknownAttempts.Remove(usernameInput.ToLower())
                                Catch
                                End Try
                                IsValidLogin = True
                                Me.DialogResult = DialogResult.OK
                                Me.Close()
                                Exit Sub
                            End If
                        End Using
                    End Using
                Catch
                End Try
            End Using
        Catch ex As Exception
            ' DB error - fallback to in-memory SalesTracker check by username
            For Each emp As SalesTracker.Employee In SalesTracker.Employees
                If emp.Username.Equals(usernameInput, StringComparison.OrdinalIgnoreCase) Then
                    ' Note: PIN not stored in memory, allow login if username matches as fallback
                    EmployeeNumber = emp.EmpNo
                    EmployeeUsername = emp.Username
                    EmployeeName = emp.FullName
                    EmployeePosition = emp.Position
                    EmployeeStatus = emp.Status
                    EmployeeDeductionStatus = emp.DeductionStatus
                    If RejectInactiveAccount() Then Exit Sub
                    IsValidLogin = True
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Exit Sub
                End If
            Next
            MessageBox.Show("Database connection failed: " & ex.Message & vbCrLf & "Please check your MySQL server.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' NOTE: no in-memory username-only bypass here — the DB already answered
        ' and the PIN was wrong. Allowing login by username alone would defeat
        ' the 4-attempt lockout. (DB-unreachable fallback above is the only bypass.)

        ' Not found: wrong PIN for a known username counts as 1 failed attempt.
        If Not String.IsNullOrWhiteSpace(knownEmpNo) Then
            Dim newAttempts As Integer = knownAttempts + 1
            Try
                Using uConn As MySqlConnection = DbHelper.GetConnection()
                    uConn.Open()
                    Using upd As New MySqlCommand("UPDATE employees SET login_attempts=@n WHERE employee_number=@e", uConn)
                        upd.Parameters.AddWithValue("@n", newAttempts)
                        upd.Parameters.AddWithValue("@e", knownEmpNo)
                        upd.ExecuteNonQuery()
                    End Using
                    If newAttempts >= 4 Then
                        Using lockCmd As New MySqlCommand("UPDATE employees SET status='Locked' WHERE employee_number=@e", uConn)
                            lockCmd.Parameters.AddWithValue("@e", knownEmpNo)
                            lockCmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            Catch
            End Try
            If newAttempts >= 4 Then
                MessageBox.Show("Invalid Username or PIN." & vbCrLf & "This employee account is locked." & vbCrLf & "Please wait 10 seconds and try again.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error)
                StartLoginCooldown(knownEmpNo, usernameInput)
            Else
                Dim left As Integer = 4 - newAttempts
                MessageBox.Show($"Invalid Username or PIN." & vbCrLf & $"{left} attempt{If(left = 1, "", "s")} remaining.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ' Unknown username: count down in the session dictionary.
            ' Unknown names report "locked due to many login attempts";
            ' real accounts report "this account is locked".
            Dim key As String = usernameInput.ToLower()
            Dim left As Integer = MaxAttempts - 1
            If unknownAttempts.ContainsKey(key) Then
                left = unknownAttempts(key) - 1
            ElseIf unknownAttempts.Count >= MaxUnknownEntries Then
                unknownAttempts.Clear()
            End If
            If left < 0 Then left = 0
            unknownAttempts(key) = left
            Debug.WriteLine($"Unknown employee '{usernameInput}' failed login ({MaxAttempts - left}/4)")

            If left <= 0 Then
                MessageBox.Show("Invalid Username or PIN." & vbCrLf & "Login attempts are locked due to many login attempts." & vbCrLf & "Please wait 10 seconds and try again.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error)
                StartLoginCooldown("", key)
            Else
                MessageBox.Show($"Invalid Username or PIN." & vbCrLf & $"{left} attempt{If(left = 1, "", "s")} remaining.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        txtPin.Clear()
        txtPin.Focus()
        txtUsername.SelectAll()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Deactivated/locked accounts cannot use salary deduction. Returns True when
    ' the login was refused (dialog already closed cancelled); callers exit.
    Private Function RejectInactiveAccount() As Boolean
        If String.Equals(EmployeeStatus, "Locked", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("This employee account is locked." & vbCrLf & "Please head to the cashier / administrator to unlock it.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            IsValidLogin = False
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return True
        End If
        If Not String.Equals(EmployeeStatus, "Inactive", StringComparison.OrdinalIgnoreCase) Then Return False
        MessageBox.Show("This employee account is deactivated." & vbCrLf & "Salary deduction is not allowed.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        IsValidLogin = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
        Return True
    End Function

    Private Sub ResetEmployeeAttempts(empNo As String)
        If String.IsNullOrWhiteSpace(empNo) Then Exit Sub
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE employees SET login_attempts=0 WHERE employee_number=@e", conn)
                    cmd.Parameters.AddWithValue("@e", empNo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Pre-migration DBs lack the column: success still counts.
        End Try
    End Sub

    Private Function NormalizeEmployeeNumber(input As String) As String
        If String.IsNullOrWhiteSpace(input) Then Return ""

        Dim upperInput As String = input.Trim().ToUpper()

        ' If already in TCH-XXX format
        If upperInput.StartsWith("TCH-") Then
            Dim suffix As String = upperInput.Substring(4)
            If suffix.Length = 3 AndAlso IsNumeric(suffix) Then
                Return "TCH-" & suffix
            End If
            Return ""
        End If

        ' If just 3 digits
        If upperInput.Length = 3 AndAlso IsNumeric(upperInput) Then
            Return "TCH-" & upperInput
        End If

        Return ""
    End Function
End Class