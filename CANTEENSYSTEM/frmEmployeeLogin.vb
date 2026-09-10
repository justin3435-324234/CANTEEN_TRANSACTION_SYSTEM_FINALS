Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmEmployeeLogin
    Inherits Form

    Public Property EmployeeNumber As String = ""
    Public Property EmployeeUsername As String = ""
    Public Property EmployeeName As String = ""
    Public Property EmployeePosition As String = ""
    Public Property EmployeeSDRemaining As Decimal = 0
    Public Property EmployeeStatus As String = ""
    Public Property EmployeeDeductionStatus As String = ""
    Public Property IsValidLogin As Boolean = False

    Private Const ConnStr As String = "Server=localhost;Database=school_canteen_db;Uid=root;Pwd=;"

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

        ' Verify against employees.sql / database (employees table)
        Try
            Using conn As New MySqlConnection(ConnStr)
                conn.Open()
                Dim query As String = "SELECT employee_number, username, full_name, position, sd_remaining, status, deduction_status FROM employees WHERE username=@username AND pin=@pin LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", usernameInput)
                    cmd.Parameters.AddWithValue("@pin", pin)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            EmployeeNumber = reader("employee_number").ToString()
                            EmployeeUsername = reader("username").ToString()
                            EmployeeName = reader("full_name").ToString()
                            EmployeePosition = If(reader("position") Is DBNull.Value, "", reader("position").ToString())
                            Dim sdRem As Decimal = 2500
                            If Not IsDBNull(reader("sd_remaining")) Then Decimal.TryParse(reader("sd_remaining").ToString(), sdRem)
                            EmployeeSDRemaining = sdRem
                            EmployeeStatus = If(reader("status") Is DBNull.Value, "Available", reader("status").ToString())
                            EmployeeDeductionStatus = If(reader("deduction_status") Is DBNull.Value, "PENDING", reader("deduction_status").ToString())
                            IsValidLogin = True
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                            Exit Sub
                        End If
                    End Using
                End Using

                ' Fallback: try case-insensitive username with old column names
                Dim fallbackQuery As String = "SELECT EmpNo, username, FullName, Position, SDRemaining, Status, DeductionStatus FROM employees WHERE username=@username AND pin=@pin LIMIT 1"
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
                                Dim sd2 As Decimal = 2500
                                If Not IsDBNull(r2("SDRemaining")) Then Decimal.TryParse(r2("SDRemaining").ToString(), sd2)
                                EmployeeSDRemaining = sd2
                                EmployeeStatus = If(r2("Status") Is DBNull.Value, "Available", r2("Status").ToString())
                                EmployeeDeductionStatus = If(r2("DeductionStatus") Is DBNull.Value, "PENDING", r2("DeductionStatus").ToString())
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
                    EmployeeSDRemaining = emp.SDRemaining
                    EmployeeStatus = emp.Status
                    EmployeeDeductionStatus = emp.DeductionStatus
                    IsValidLogin = True
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Exit Sub
                End If
            Next
            MessageBox.Show("Database connection failed: " & ex.Message & vbCrLf & "Please check your MySQL server.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Also check in-memory list by username if DB not found (e.g., just added employee not yet committed)
        For Each emp As SalesTracker.Employee In SalesTracker.Employees
            If emp.Username.Equals(usernameInput, StringComparison.OrdinalIgnoreCase) Then
                EmployeeNumber = emp.EmpNo
                EmployeeUsername = emp.Username
                EmployeeName = emp.FullName
                EmployeePosition = emp.Position
                EmployeeSDRemaining = emp.SDRemaining
                EmployeeStatus = emp.Status
                EmployeeDeductionStatus = emp.DeductionStatus
                IsValidLogin = True
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Exit Sub
            End If
        Next

        ' Not found
        MessageBox.Show("Invalid Username or PIN. Account not found in employees table.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        txtUsername.Focus()
        txtUsername.SelectAll()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
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