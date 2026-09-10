Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class frmLogin

    '=========================================================
    ' DATABASE CONNECTION
    '=========================================================
    Private connectionString As String =
        "Server=localhost;Database=school_canteen_db;Uid=root;Pwd=;"

    '=========================================================
    ' SELECTED LOGIN ROLE
    '=========================================================
    Private selectedRole As String = "Cashier"


    '=========================================================
    ' FORM LOAD
    '=========================================================
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        'Login button
        btnLogin.Text = "OPEN POS TERMINAL ➔"

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

        'Login button
        btnLogin.Text = "LOG IN TO DASHBOARD ➔"

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
        ' CONNECT TO DATABASE
        '-----------------------------------------------------
        Try

            Using conn As New MySqlConnection(connectionString)

                conn.Open()


                '-------------------------------------------------
                ' FIND USER
                '-------------------------------------------------
                Dim query As String =
                    "SELECT username, password, role, status " &
                    "FROM users " &
                    "WHERE username = @username " &
                    "LIMIT 1"


                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@username", username)


                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        '-------------------------------------------------
                        ' USERNAME DOES NOT EXIST
                        '-------------------------------------------------
                        If Not reader.Read() Then

                            MessageBox.Show(
                                "Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

                            txtPassword.Clear()
                            txtPassword.Focus()

                            Return

                        End If


                        '-------------------------------------------------
                        ' GET DATABASE VALUES
                        '-------------------------------------------------
                        Dim dbPassword As String =
                            reader("password").ToString()

                        Dim dbRole As String =
                            reader("role").ToString()

                        Dim dbStatus As String =
                            reader("status").ToString()


                        '-------------------------------------------------
                        ' CHECK PASSWORD
                        '-------------------------------------------------
                        If password <> dbPassword Then

                            MessageBox.Show(
                                "Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class