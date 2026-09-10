Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text.RegularExpressions

Public Class frmEmployeeSignUp
    Inherits Form

    Public Property EmployeeNumber As String = ""
    Public Property FullName As String = ""
    Public Property Position As String = ""
    Public Property EmployeeType As String = ""
    Public Property Username As String = ""
    Public Property PIN As String = ""

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPIN As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents cmbPosition As ComboBox
    Friend WithEvents cmbEmployeeType As ComboBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblEmpType As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblPIN As Label

    Public Sub New()
        InitializeComponent()
        EmployeeNumber = GenerateEmployeeNumber()
    End Sub

    Private Function GenerateEmployeeNumber() As String
        Dim nextNumber As Integer = 1
        For Each emp As SalesTracker.Employee In SalesTracker.Employees
            If emp.EmpNo IsNot Nothing AndAlso emp.EmpNo.StartsWith("EMP-") Then
                Dim numPart As Integer = 0
                If Integer.TryParse(emp.EmpNo.Replace("EMP-", ""), numPart) AndAlso numPart >= nextNumber Then
                    nextNumber = numPart + 1
                End If
            End If
        Next
        ' Also check database for max EMP- number to avoid duplicates when memory is empty
        Try
            Using conn As New MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Database=school_canteen_db;Uid=root;Pwd=;")
                conn.Open()
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT employee_number FROM employees WHERE employee_number LIKE 'EMP-%'", conn)
                    Using rdr As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim empNoDb As String = rdr(0).ToString()
                            If empNoDb.StartsWith("EMP-") Then
                                Dim n As Integer = 0
                                If Integer.TryParse(empNoDb.Replace("EMP-", ""), n) AndAlso n >= nextNumber Then
                                    nextNumber = n + 1
                                End If
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch
        End Try
        Return "EMP-" & nextNumber.ToString("D3")
    End Function

    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPIN = New System.Windows.Forms.Label()
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblEmpType = New System.Windows.Forms.Label()
        Me.cmbEmployeeType = New System.Windows.Forms.ComboBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.cmbPosition = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(44, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(376, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "NEW EMPLOYEE REGISTRATION"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.White
        Me.lblSubtitle.Location = New System.Drawing.Point(50, 55)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(297, 20)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Enter employee details for salary deduction"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.White
        Me.lblUsername.Location = New System.Drawing.Point(50, 100)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(94, 23)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtUsername.Location = New System.Drawing.Point(50, 125)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(320, 32)
        Me.txtUsername.TabIndex = 3
        '
        'lblPIN
        '
        Me.lblPIN.AutoSize = True
        Me.lblPIN.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPIN.ForeColor = System.Drawing.Color.White
        Me.lblPIN.Location = New System.Drawing.Point(50, 170)
        Me.lblPIN.Name = "lblPIN"
        Me.lblPIN.Size = New System.Drawing.Size(43, 23)
        Me.lblPIN.TabIndex = 4
        Me.lblPIN.Text = "PIN:"
        '
        'txtPIN
        '
        Me.txtPIN.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPIN.Location = New System.Drawing.Point(50, 195)
        Me.txtPIN.MaxLength = 4
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Size = New System.Drawing.Size(120, 32)
        Me.txtPIN.TabIndex = 5
        Me.txtPIN.UseSystemPasswordChar = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(50, 240)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(96, 23)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Full Name:"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtName.Location = New System.Drawing.Point(50, 265)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(320, 32)
        Me.txtName.TabIndex = 7
        '
        'lblEmpType
        '
        Me.lblEmpType.AutoSize = True
        Me.lblEmpType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmpType.ForeColor = System.Drawing.Color.White
        Me.lblEmpType.Location = New System.Drawing.Point(50, 310)
        Me.lblEmpType.Name = "lblEmpType"
        Me.lblEmpType.Size = New System.Drawing.Size(136, 23)
        Me.lblEmpType.TabIndex = 8
        Me.lblEmpType.Text = "Employee Type:"
        '
        'cmbEmployeeType
        '
        Me.cmbEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmployeeType.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbEmployeeType.Items.AddRange(New Object() {"Teacher", "Staff", "Admin", "Security", "Maintenance", "Canteen Staff", "Librarian", "Nurse", "Guidance Counselor", "IT Personnel"})
        Me.cmbEmployeeType.Location = New System.Drawing.Point(50, 335)
        Me.cmbEmployeeType.Name = "cmbEmployeeType"
        Me.cmbEmployeeType.Size = New System.Drawing.Size(320, 33)
        Me.cmbEmployeeType.TabIndex = 9
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosition.ForeColor = System.Drawing.Color.White
        Me.lblPosition.Location = New System.Drawing.Point(50, 380)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(78, 23)
        Me.lblPosition.TabIndex = 10
        Me.lblPosition.Text = "Position:"
        '
        'cmbPosition
        '
        Me.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPosition.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbPosition.Items.AddRange(New Object() {"Teacher", "Staff", "Admin", "Security", "Maintenance", "Canteen Staff", "Librarian", "Nurse", "Guidance Counselor", "IT Personnel"})
        Me.cmbPosition.Location = New System.Drawing.Point(50, 405)
        Me.cmbPosition.Name = "cmbPosition"
        Me.cmbPosition.Size = New System.Drawing.Size(320, 33)
        Me.cmbPosition.TabIndex = 11
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(50, 460)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(140, 40)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "REGISTER"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(210, 460)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 40)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmEmployeeSignUp
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(448, 530)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPIN)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblEmpType)
        Me.Controls.Add(Me.cmbEmployeeType)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.cmbPosition)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmployeeSignUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Sign Up - Salary Deduction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim pin As String = txtPIN.Text.Trim()
        Dim errors As New List(Of String)

        ' Collect all validation errors
        If String.IsNullOrWhiteSpace(username) Then
            errors.Add("• Username is required")
        End If

        If pin.Length <> 4 Then
            errors.Add("• PIN must be exactly 4 digits")
        ElseIf Not Integer.TryParse(pin, Nothing) Then
            errors.Add("• PIN must be numeric")
        End If

        If String.IsNullOrWhiteSpace(txtName.Text.Trim()) Then
            errors.Add("• Full Name is required")
        End If

        If cmbEmployeeType.SelectedItem Is Nothing Then
            errors.Add("• Employee Type is required")
        End If

        If cmbPosition.SelectedItem Is Nothing Then
            errors.Add("• Position is required")
        End If

        ' Show all errors at once
        If errors.Count > 0 Then
            MessageBox.Show("Please input the required fields" & vbCrLf & vbCrLf & String.Join(vbCrLf, errors),
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Focus first invalid field
            If String.IsNullOrWhiteSpace(username) Then
                txtUsername.Focus()
            ElseIf pin.Length <> 4 OrElse Not Integer.TryParse(pin, Nothing) Then
                txtPIN.Focus()
            ElseIf String.IsNullOrWhiteSpace(txtName.Text.Trim()) Then
                txtName.Focus()
            Else
                cmbEmployeeType.Focus()
            End If
            Exit Sub
        End If

        ' Set properties - keep typed username, EmployeeNumber stays as auto EMP-001
        Me.Username = username
        Me.PIN = pin
        Me.FullName = txtName.Text.Trim()
        Me.EmployeeType = cmbEmployeeType.SelectedItem.ToString()
        Me.Position = cmbPosition.SelectedItem.ToString()
        Try
            System.IO.File.AppendAllText("C:\Users\Justin\Desktop\CANTEEN_TRANSACTION_MANAGEMENT_SYSTEM\debug_signup.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} SIGNUP txtUsername='{txtUsername.Text}' usernameVar='{username}' UsernameProp='{Me.Username}' EmpNo='{Me.EmployeeNumber}' FullName='{Me.FullName}'" & vbCrLf)
        Catch
        End Try

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEmployeeSignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class