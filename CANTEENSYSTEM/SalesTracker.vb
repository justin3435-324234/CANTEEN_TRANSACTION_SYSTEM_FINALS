Imports MySql.Data.MySqlClient

Module SalesTracker

    Private _totalSales As Decimal = 0
    Private _itemsSold As Integer = 0
    Private _sales As New List(Of Decimal)
    Private _transactionItems As New List(Of Integer)

    ' Employee storage for salary deduction
    Public Class Employee
        Public Property EmpNo As String
        Public Property Username As String
        Public Property FullName As String
        Public Property Position As String
        Public Property SDRemaining As Decimal
        Public Property Status As String
        Public Property DeductionStatus As String
        Public Property PeriodStart As String
        Public Property PeriodEnd As String
        Public Property CreatedAt As DateTime

        Public Sub New(empNo As String, fullName As String, position As String, sdRemaining As Decimal, status As String, deductionStatus As String)
            Me.EmpNo = empNo
            Me.FullName = fullName
            Me.Position = position
            Me.SDRemaining = sdRemaining
            Me.Status = status
            Me.DeductionStatus = deductionStatus
        End Sub

        Public Sub New(empNo As String, username As String, fullName As String, position As String, sdRemaining As Decimal, status As String, deductionStatus As String, periodStart As String, periodEnd As String)
            Me.EmpNo = empNo
            Me.Username = username
            Me.FullName = fullName
            Me.Position = position
            Me.SDRemaining = sdRemaining
            Me.Status = status
            Me.DeductionStatus = deductionStatus
            Me.PeriodStart = periodStart
            Me.PeriodEnd = periodEnd
        End Sub
    End Class

    Private _employees As New List(Of Employee)

    Private Const ConnectionString As String = "Server=localhost;Database=school_canteen_db;Uid=root;Pwd=;"

    Public ReadOnly Property TotalSales As Decimal
        Get
            Return _totalSales
        End Get
    End Property

    Public ReadOnly Property ItemsSold As Integer
        Get
            Return _itemsSold
        End Get
    End Property

    Public ReadOnly Property SaleAmounts As List(Of Decimal)
        Get
            Return _sales
        End Get
    End Property

    Public ReadOnly Property TransactionItems As List(Of Integer)
        Get
            Return _transactionItems
        End Get
    End Property

    Public ReadOnly Property Employees As List(Of Employee)
        Get
            Return _employees
        End Get
    End Property

    Private Sub EnsureEmployeeSchema()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                ' Add username column if missing (MySQL 10.4 supports IF NOT EXISTS)
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE employees ADD COLUMN IF NOT EXISTS username varchar(50) NOT NULL DEFAULT ''", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE employees ADD COLUMN IF NOT EXISTS period_start date DEFAULT NULL", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE employees ADD COLUMN IF NOT EXISTS period_end date DEFAULT NULL", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
            End Using
        Catch
        End Try
    End Sub

    ' Add new employee to persistent storage
    Public Sub AddEmployee(empNo As String, username As String, fullName As String, position As String, sdRemaining As Decimal, status As String, deductionStatus As String)
        EnsureEmployeeSchema()
        Try
            System.IO.File.AppendAllText("C:\Users\Justin\Desktop\CANTEEN_TRANSACTION_MANAGEMENT_SYSTEM\debug_signup.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} AddEmployee empNo='{empNo}' usernameParam='{username}' fullName='{fullName}'" & vbCrLf)
        Catch
        End Try
        System.Diagnostics.Debug.WriteLine($"AddEmployee empNo={empNo}, username={username}, fullName={fullName}")

        ' Check if employee already exists (by EmpNo)
        Dim existing = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        Dim periodStartVal As String = DateTime.Now.ToString("yyyy-MM-dd")
        If existing IsNot Nothing Then
            ' Update existing
            existing.Username = username
            existing.FullName = fullName
            existing.Position = position
            existing.SDRemaining = sdRemaining
            existing.Status = status
            existing.DeductionStatus = deductionStatus
            If String.IsNullOrWhiteSpace(existing.PeriodStart) Then existing.PeriodStart = periodStartVal
        Else
            Dim newEmp As New Employee(empNo, username, fullName, position, sdRemaining, status, deductionStatus, periodStartVal, "")
            newEmp.CreatedAt = DateTime.Now
            _employees.Add(newEmp)
        End If

        ' Save to database
        SaveEmployeeToDatabase(empNo, username, fullName, position, sdRemaining, status, deductionStatus)
    End Sub

    ' Save employee to MySQL database
    Private Sub SaveEmployeeToDatabase(empNo As String, username As String, fullName As String, position As String, sdRemaining As Decimal, status As String, deductionStatus As String)
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                ' Check if employee exists - try new column first, fallback to old
                Dim count As Integer = 0
                Try
                    Using chk As New MySqlCommand("SELECT COUNT(*) FROM employees WHERE employee_number=@empNo", conn)
                        chk.Parameters.AddWithValue("@empNo", empNo)
                        count = Convert.ToInt32(chk.ExecuteScalar())
                    End Using
                Catch
                    Try
                        Using chk2 As New MySqlCommand("SELECT COUNT(*) FROM employees WHERE EmpNo=@empNo", conn)
                            chk2.Parameters.AddWithValue("@empNo", empNo)
                            count = Convert.ToInt32(chk2.ExecuteScalar())
                        End Using
                    Catch ex2 As Exception
                        Throw ex2
                    End Try
                End Try

                If count > 0 Then
                    ' Update existing employee
                    Try
                        Dim updateQuery As String = "UPDATE employees SET username=@username, full_name=@fullName, position=@position, sd_remaining=@sdRemaining, status=@status, deduction_status=@deductionStatus, period_start=@periodStart WHERE employee_number=@empNo"
                        Using cmd2 As New MySqlCommand(updateQuery, conn)
                            cmd2.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                            cmd2.Parameters.AddWithValue("@fullName", fullName)
                            cmd2.Parameters.AddWithValue("@position", position)
                            cmd2.Parameters.AddWithValue("@sdRemaining", sdRemaining)
                            cmd2.Parameters.AddWithValue("@status", status)
                            cmd2.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                            cmd2.Parameters.AddWithValue("@periodStart", DateTime.Now.ToString("yyyy-MM-dd"))
                            cmd2.Parameters.AddWithValue("@empNo", empNo)
                            cmd2.ExecuteNonQuery()
                        End Using
                    Catch
                        Dim qOld As String = "UPDATE employees SET username=@username, FullName=@fullName, Position=@position, SDRemaining=@sdRemaining, Status=@status, DeductionStatus=@deductionStatus WHERE EmpNo=@empNo"
                        Using cmdOld As New MySqlCommand(qOld, conn)
                            cmdOld.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                            cmdOld.Parameters.AddWithValue("@fullName", fullName)
                            cmdOld.Parameters.AddWithValue("@position", position)
                            cmdOld.Parameters.AddWithValue("@sdRemaining", sdRemaining)
                            cmdOld.Parameters.AddWithValue("@status", status)
                            cmdOld.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                            cmdOld.Parameters.AddWithValue("@empNo", empNo)
                            cmdOld.ExecuteNonQuery()
                        End Using
                    End Try
                Else
                    ' Insert new employee - use full schema with auto dates
                    Try
                        Dim insertQuery As String = "INSERT INTO employees (employee_number, username, full_name, position, employee_type, status, created_at, pin, sd_limit, sd_remaining, sd_status, deduction_status, period_start, period_end) VALUES (@empNo, @username, @fullName, @position, 'Employee', @status, NOW(), '1234', 2500.00, @sdRemaining, 'Available', @deductionStatus, @periodStart, NULL)"
                        Using cmd2 As New MySqlCommand(insertQuery, conn)
                            cmd2.Parameters.AddWithValue("@empNo", empNo)
                            cmd2.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                            cmd2.Parameters.AddWithValue("@fullName", fullName)
                            cmd2.Parameters.AddWithValue("@position", position)
                            cmd2.Parameters.AddWithValue("@sdRemaining", sdRemaining)
                            cmd2.Parameters.AddWithValue("@status", status)
                            cmd2.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                            cmd2.Parameters.AddWithValue("@periodStart", DateTime.Now.ToString("yyyy-MM-dd"))
                            cmd2.ExecuteNonQuery()
                        End Using
                    Catch
                        Dim qOld2 As String = "INSERT INTO employees (employee_number, username, full_name, position, employee_type, status, created_at, pin, sd_remaining, deduction_status) VALUES (@empNo, @username, @fullName, @position, 'Employee', @status, NOW(), '1234', @sdRemaining, @deductionStatus)"
                        Try
                            Using cmdOld As New MySqlCommand(qOld2, conn)
                                cmdOld.Parameters.AddWithValue("@empNo", empNo)
                                cmdOld.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                                cmdOld.Parameters.AddWithValue("@fullName", fullName)
                                cmdOld.Parameters.AddWithValue("@position", position)
                                cmdOld.Parameters.AddWithValue("@sdRemaining", sdRemaining)
                                cmdOld.Parameters.AddWithValue("@status", status)
                                cmdOld.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                                cmdOld.ExecuteNonQuery()
                            End Using
                        Catch
                            Dim qFallback As String = "INSERT INTO employees (EmpNo, username, FullName, Position, SDRemaining, Status, DeductionStatus) VALUES (@empNo, @username, @fullName, @position, @sdRemaining, @status, @deductionStatus)"
                            Using cmdF As New MySqlCommand(qFallback, conn)
                                cmdF.Parameters.AddWithValue("@empNo", empNo)
                                cmdF.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                                cmdF.Parameters.AddWithValue("@fullName", fullName)
                                cmdF.Parameters.AddWithValue("@position", position)
                                cmdF.Parameters.AddWithValue("@sdRemaining", sdRemaining)
                                cmdF.Parameters.AddWithValue("@status", status)
                                cmdF.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                                cmdF.ExecuteNonQuery()
                            End Using
                        End Try
                    End Try
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to save employee to database: " & ex.Message & vbCrLf & "Please run Database/school_canteen_db.sql to update schema.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load employees from MySQL database
    Public Sub LoadEmployeesFromDatabase()
        _employees.Clear()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim query As String = "SELECT employee_number, username, full_name, position, sd_remaining, status, deduction_status, period_start, period_end, created_at FROM employees"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim empNoVal As String = reader("employee_number").ToString()
                            Dim usernameVal As String = If(reader("username") Is DBNull.Value, "", reader("username").ToString())
                            Dim fullNameVal As String = If(reader("full_name") Is DBNull.Value, "", reader("full_name").ToString())
                            Dim posVal As String = If(reader("position") Is DBNull.Value, "", reader("position").ToString())
                            Dim sdRem As Decimal = 2500
                            If Not IsDBNull(reader("sd_remaining")) Then Decimal.TryParse(reader("sd_remaining").ToString(), sdRem)
                            Dim statusVal As String = If(reader("status") Is DBNull.Value, "Available", reader("status").ToString())
                            Dim dedStatusVal As String = If(reader("deduction_status") Is DBNull.Value, "PENDING", reader("deduction_status").ToString())
                            Dim pStart As String = If(reader("period_start") Is DBNull.Value, "", Convert.ToDateTime(reader("period_start")).ToString("yyyy-MM-dd"))
                            If reader("period_start") Is DBNull.Value Then pStart = ""
                            Dim pEnd As String = If(reader("period_end") Is DBNull.Value, "", Convert.ToDateTime(reader("period_end")).ToString("yyyy-MM-dd"))
                            If reader("period_end") Is DBNull.Value Then pEnd = ""
                            Dim createdAtVal As DateTime = DateTime.Now
                            If Not IsDBNull(reader("created_at")) Then DateTime.TryParse(reader("created_at").ToString(), createdAtVal)

                            Dim emp As New Employee(empNoVal, usernameVal, fullNameVal, posVal, sdRem, statusVal, dedStatusVal, pStart, pEnd)
                            emp.CreatedAt = createdAtVal
                            _employees.Add(emp)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Fallback to old column names if new schema not yet applied
            Try
                _employees.Clear()
                Using conn2 As New MySqlConnection(ConnectionString)
                    conn2.Open()
                    Dim q2 As String = "SELECT * FROM employees"
                    Using cmd2 As New MySqlCommand(q2, conn2)
                        Using r2 As MySqlDataReader = cmd2.ExecuteReader()
                            While r2.Read()
                                Dim empNo2 As String = r2(0).ToString()
                                Dim emp As New Employee(empNo2, empNo2, "", 2500, "Available", "PENDING")
                                _employees.Add(emp)
                            End While
                        End Using
                    End Using
                End Using
            Catch ex2 As Exception
                MessageBox.Show("Failed to load employees from database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Public Sub DeleteEmployee(empNo As String)
        Dim existing = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        If existing IsNot Nothing Then _employees.Remove(existing)

        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New MySqlCommand("DELETE FROM employees WHERE employee_number=@empNo", conn)
                        cmd.Parameters.AddWithValue("@empNo", empNo)
                        If cmd.ExecuteNonQuery() = 0 Then
                            Using cmd2 As New MySqlCommand("DELETE FROM employees WHERE EmpNo=@empNo", conn)
                                cmd2.Parameters.AddWithValue("@empNo", empNo)
                                cmd2.ExecuteNonQuery()
                            End Using
                        End If
                    End Using
                Catch
                    Using cmd2 As New MySqlCommand("DELETE FROM employees WHERE EmpNo=@empNo", conn)
                        cmd2.Parameters.AddWithValue("@empNo", empNo)
                        cmd2.ExecuteNonQuery()
                    End Using
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to delete employee from database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub UpdateEmployee(empNo As String, fullName As String, position As String)
        Dim existing = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        If existing IsNot Nothing Then
            existing.FullName = fullName
            existing.Position = position
            Try
                Using conn As New MySqlConnection(ConnectionString)
                    conn.Open()
                    Try
                        Using cmd As New MySqlCommand("UPDATE employees SET full_name=@fullName, position=@pos WHERE employee_number=@empNo", conn)
                            cmd.Parameters.AddWithValue("@fullName", fullName)
                            cmd.Parameters.AddWithValue("@pos", position)
                            cmd.Parameters.AddWithValue("@empNo", empNo)
                            If cmd.ExecuteNonQuery() = 0 Then
                                Using cmd2 As New MySqlCommand("UPDATE employees SET FullName=@fullName, Position=@pos WHERE EmpNo=@empNo", conn)
                                    cmd2.Parameters.AddWithValue("@fullName", fullName)
                                    cmd2.Parameters.AddWithValue("@pos", position)
                                    cmd2.Parameters.AddWithValue("@empNo", empNo)
                                    cmd2.ExecuteNonQuery()
                                End Using
                            End If
                        End Using
                    Catch
                        Using cmd2 As New MySqlCommand("UPDATE employees SET FullName=@fullName, Position=@pos WHERE EmpNo=@empNo", conn)
                            cmd2.Parameters.AddWithValue("@fullName", fullName)
                            cmd2.Parameters.AddWithValue("@pos", position)
                            cmd2.Parameters.AddWithValue("@empNo", empNo)
                            cmd2.ExecuteNonQuery()
                        End Using
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to update employee: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Public Sub UpdateSDRemaining(empNo As String, newRemaining As Decimal)
        Dim emp = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        If emp IsNot Nothing Then emp.SDRemaining = newRemaining
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New MySqlCommand("UPDATE employees SET sd_remaining=@rem WHERE employee_number=@empNo", conn)
                        cmd.Parameters.AddWithValue("@rem", newRemaining)
                        cmd.Parameters.AddWithValue("@empNo", empNo)
                        If cmd.ExecuteNonQuery() = 0 Then
                            Using cmd2 As New MySqlCommand("UPDATE employees SET SDRemaining=@rem WHERE EmpNo=@empNo", conn)
                                cmd2.Parameters.AddWithValue("@rem", newRemaining)
                                cmd2.Parameters.AddWithValue("@empNo", empNo)
                                cmd2.ExecuteNonQuery()
                            End Using
                        End If
                    End Using
                Catch
                    Using cmd2 As New MySqlCommand("UPDATE employees SET SDRemaining=@rem WHERE EmpNo=@empNo", conn)
                        cmd2.Parameters.AddWithValue("@rem", newRemaining)
                        cmd2.Parameters.AddWithValue("@empNo", empNo)
                        cmd2.ExecuteNonQuery()
                    End Using
                End Try
            End Using
        Catch ex As Exception
            Debug.WriteLine("UpdateSDRemaining failed: " & ex.Message)
        End Try
    End Sub

    ' Record sale to persistent storage
    Public Sub RecordSale(total As Decimal, items As Integer)
        _totalSales += total
        _itemsSold += items
        _sales.Add(total)
        _transactionItems.Add(items)

        ' Record sale to database
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim query As String = "INSERT INTO sales (total_amount, items_count, sale_date) VALUES (@total, @items, NOW())"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@total", total)
                    cmd.Parameters.AddWithValue("@items", items)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log error but don't crash - sale was already recorded in memory
            Debug.WriteLine("Failed to record sale to database: " & ex.Message)
        End Try
    End Sub

End Module