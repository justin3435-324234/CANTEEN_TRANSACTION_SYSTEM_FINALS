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
        Public Property Status As String
        Public Property DeductionStatus As String
        Public Property PeriodStart As String
        Public Property PeriodEnd As String
        Public Property CreatedAt As DateTime

        Public Sub New(empNo As String, fullName As String, position As String, status As String, deductionStatus As String)
            Me.EmpNo = empNo
            Me.FullName = fullName
            Me.Position = position
            Me.Status = status
            Me.DeductionStatus = deductionStatus
        End Sub

        Public Sub New(empNo As String, username As String, fullName As String, position As String, status As String, deductionStatus As String, periodStart As String, periodEnd As String)
            Me.EmpNo = empNo
            Me.Username = username
            Me.FullName = fullName
            Me.Position = position
            Me.Status = status
            Me.DeductionStatus = deductionStatus
            Me.PeriodStart = periodStart
            Me.PeriodEnd = periodEnd
        End Sub
    End Class

    Private _employees As New List(Of Employee)

    ' PHASE 0: canonical connection lives in DbHelper (App.config <connectionStrings name="CanteenDb">).
    ' Kept as a property so any leftover references still compile during migration.

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
            Using conn As MySqlConnection = DbHelper.GetConnection()
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
    Public Sub AddEmployee(empNo As String, username As String, fullName As String, position As String, status As String, deductionStatus As String)
        ' Canonical casing: employees.deduction_status is ALWAYS ALL-CAPS in this system.
        deductionStatus = If(String.IsNullOrWhiteSpace(deductionStatus), "PENDING", deductionStatus.Trim().ToUpper())
        If String.Equals(status, "Available", StringComparison.OrdinalIgnoreCase) Then status = "Active"
        If String.IsNullOrWhiteSpace(status) Then status = "Active"
        EnsureEmployeeSchema()

        ' Check if employee already exists (by EmpNo)
        Dim existing = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        Dim periodStartVal As String = DateTime.Now.ToString("yyyy-MM-dd")
        If existing IsNot Nothing Then
            ' Update existing
            existing.Username = username
            existing.FullName = fullName
            existing.Position = position
            existing.Status = status
            existing.DeductionStatus = deductionStatus
            If String.IsNullOrWhiteSpace(existing.PeriodStart) Then existing.PeriodStart = periodStartVal
        Else
            Dim newEmp As New Employee(empNo, username, fullName, position, status, deductionStatus, periodStartVal, "")
            newEmp.CreatedAt = DateTime.Now
            _employees.Add(newEmp)
        End If

        ' Save to database
        SaveEmployeeToDatabase(empNo, username, fullName, position, status, deductionStatus)
        Try
            Dim auditUid As Integer = 0
            Try
                auditUid = Session.CurrentUserId
            Catch
            End Try
            AuditLog.Log(auditUid, "Add Employee", $"{empNo} - {fullName} ({position})")
        Catch
        End Try
    End Sub

    ' Save employee to MySQL database
    Private Sub SaveEmployeeToDatabase(empNo As String, username As String, fullName As String, position As String, status As String, deductionStatus As String)
        deductionStatus = If(String.IsNullOrWhiteSpace(deductionStatus), "PENDING", deductionStatus.Trim().ToUpper())
        ' Defensive: legacy callers pass "Available"; schema enum is Active/Inactive.
        If String.Equals(status, "Available", StringComparison.OrdinalIgnoreCase) Then status = "Active"
        If String.IsNullOrWhiteSpace(status) Then status = "Active"
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
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
                        Dim updateQuery As String = "UPDATE employees SET username=@username, full_name=@fullName, position=@position, status=@status, deduction_status=@deductionStatus, period_start=@periodStart WHERE employee_number=@empNo"
                        Using cmd2 As New MySqlCommand(updateQuery, conn)
                            cmd2.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                            cmd2.Parameters.AddWithValue("@fullName", fullName)
                            cmd2.Parameters.AddWithValue("@position", position)
                            cmd2.Parameters.AddWithValue("@status", status)
                            cmd2.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                            cmd2.Parameters.AddWithValue("@periodStart", DateTime.Now.ToString("yyyy-MM-dd"))
                            cmd2.Parameters.AddWithValue("@empNo", empNo)
                            cmd2.ExecuteNonQuery()
                        End Using
                    Catch
                        Dim qOld As String = "UPDATE employees SET username=@username, FullName=@fullName, Position=@position, Status=@status, DeductionStatus=@deductionStatus WHERE EmpNo=@empNo"
                        Using cmdOld As New MySqlCommand(qOld, conn)
                            cmdOld.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                            cmdOld.Parameters.AddWithValue("@fullName", fullName)
                            cmdOld.Parameters.AddWithValue("@position", position)
                            cmdOld.Parameters.AddWithValue("@status", status)
                            cmdOld.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                            cmdOld.Parameters.AddWithValue("@empNo", empNo)
                            cmdOld.ExecuteNonQuery()
                        End Using
                    End Try
                Else
                    ' Insert new employee - canonical Phase 0 schema (single attempt; all columns verified).
                    ' Legacy fallbacks kept below in case an old database file is used.
                    Try
                        Dim insertQuery As String = "INSERT INTO employees (employee_number, username, full_name, position, employee_type, status, created_at, pin, deduction_status, period_start, period_end) VALUES (@empNo, @username, @fullName, @position, @empType, @status, NOW(), '1234', @deductionStatus, @periodStart, NULL)"
                        Using cmd2 As New MySqlCommand(insertQuery, conn)
                            cmd2.Parameters.AddWithValue("@empNo", empNo)
                            cmd2.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                            cmd2.Parameters.AddWithValue("@fullName", fullName)
                            cmd2.Parameters.AddWithValue("@position", position)
                            cmd2.Parameters.AddWithValue("@empType", If(position.ToLower().Contains("teacher"), "Teacher", "Employee"))
                            cmd2.Parameters.AddWithValue("@status", status)
                            cmd2.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                            cmd2.Parameters.AddWithValue("@periodStart", DateTime.Now.ToString("yyyy-MM-dd"))
                            cmd2.ExecuteNonQuery()
                        End Using
                    Catch
                        Dim qOld2 As String = "INSERT INTO employees (employee_number, username, full_name, position, employee_type, status, created_at, pin, deduction_status) VALUES (@empNo, @username, @fullName, @position, 'Employee', @status, NOW(), '1234', @deductionStatus)"
                        Try
                            Using cmdOld As New MySqlCommand(qOld2, conn)
                                cmdOld.Parameters.AddWithValue("@empNo", empNo)
                                cmdOld.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                                cmdOld.Parameters.AddWithValue("@fullName", fullName)
                                cmdOld.Parameters.AddWithValue("@position", position)
                                cmdOld.Parameters.AddWithValue("@status", status)
                                cmdOld.Parameters.AddWithValue("@deductionStatus", deductionStatus)
                                cmdOld.ExecuteNonQuery()
                            End Using
                        Catch
                            Dim qFallback As String = "INSERT INTO employees (EmpNo, username, FullName, Position, Status, DeductionStatus) VALUES (@empNo, @username, @fullName, @position, @status, @deductionStatus)"
                            Using cmdF As New MySqlCommand(qFallback, conn)
                                cmdF.Parameters.AddWithValue("@empNo", empNo)
                                cmdF.Parameters.AddWithValue("@username", If(String.IsNullOrWhiteSpace(username), empNo, username))
                                cmdF.Parameters.AddWithValue("@fullName", fullName)
                                cmdF.Parameters.AddWithValue("@position", position)
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
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()

                Dim query As String = "SELECT employee_number, username, full_name, position, status, deduction_status, period_start, period_end, created_at FROM employees"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim empNoVal As String = reader("employee_number").ToString()
                            Dim usernameVal As String = If(reader("username") Is DBNull.Value, "", reader("username").ToString())
                            Dim fullNameVal As String = If(reader("full_name") Is DBNull.Value, "", reader("full_name").ToString())
                            Dim posVal As String = If(reader("position") Is DBNull.Value, "", reader("position").ToString())
                            Dim statusVal As String = If(reader("status") Is DBNull.Value, "Available", reader("status").ToString())
                            Dim dedStatusVal As String = If(reader("deduction_status") Is DBNull.Value, "PENDING", reader("deduction_status").ToString().Trim().ToUpper())
                            Dim pStart As String = If(reader("period_start") Is DBNull.Value, "", Convert.ToDateTime(reader("period_start")).ToString("yyyy-MM-dd"))
                            If reader("period_start") Is DBNull.Value Then pStart = ""
                            Dim pEnd As String = If(reader("period_end") Is DBNull.Value, "", Convert.ToDateTime(reader("period_end")).ToString("yyyy-MM-dd"))
                            If reader("period_end") Is DBNull.Value Then pEnd = ""
                            Dim createdAtVal As DateTime = DateTime.Now
                            If Not IsDBNull(reader("created_at")) Then DateTime.TryParse(reader("created_at").ToString(), createdAtVal)

                            Dim emp As New Employee(empNoVal, usernameVal, fullNameVal, posVal, statusVal, dedStatusVal, pStart, pEnd)
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
                Using conn2 As MySqlConnection = DbHelper.GetConnection()
                    conn2.Open()
                    Dim q2 As String = "SELECT * FROM employees"
                    Using cmd2 As New MySqlCommand(q2, conn2)
                        Using r2 As MySqlDataReader = cmd2.ExecuteReader()
                            While r2.Read()
                                Dim empNo2 As String = r2(0).ToString()
                                Dim emp As New Employee(empNo2, empNo2, "", "Available", "PENDING")
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

    ' Returns True when the employee was actually removed. False means the
    ' delete was refused (payroll history exists — FK would reject it) or a
    ' DB error occurred. Callers own all user messages; this stays UI-quiet
    ' on the refused path so payroll records can never be orphaned or lost.
    ' Deactivated staff go through DeleteEmployeeCascade instead (explicit).
    Public Function DeleteEmployee(empNo As String) As Boolean
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using guard As New MySqlCommand("SELECT COUNT(*) FROM salary_deductions WHERE employee_number=@e", conn)
                    guard.Parameters.AddWithValue("@e", empNo)
                    If Convert.ToInt32(guard.ExecuteScalar()) > 0 Then Return False
                End Using
                ' Kiosk orders carry employee_number with no FK — deleting here would
                ' orphan pending rows and cause the same FK failure at POS completion.
                Using kguard As New MySqlCommand("SELECT COUNT(*) FROM kiosk_orders WHERE employee_number=@e AND status IN ('Pending','Processing')", conn)
                    kguard.Parameters.AddWithValue("@e", empNo)
                    If Convert.ToInt32(kguard.ExecuteScalar()) > 0 Then Return False
                End Using
                Try
                    Using cmd As New MySqlCommand("DELETE FROM employees WHERE employee_number=@empNo", conn)
                        cmd.Parameters.AddWithValue("@empNo", empNo)
                        If cmd.ExecuteNonQuery() = 0 Then
                            Using cmd2 As New MySqlCommand("DELETE FROM employees WHERE EmpNo=@empNo", conn)
                                cmd2.Parameters.AddWithValue("@empNo", empNo)
                                If cmd2.ExecuteNonQuery() = 0 Then Return False
                            End Using
                        End If
                    End Using
                Catch
                    Using cmd2 As New MySqlCommand("DELETE FROM employees WHERE EmpNo=@empNo", conn)
                        cmd2.Parameters.AddWithValue("@empNo", empNo)
                        If cmd2.ExecuteNonQuery() = 0 Then Return False
                    End Using
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to delete employee from database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Dim existing = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        If existing IsNot Nothing Then _employees.Remove(existing)
        Try
            Dim auditUid As Integer = 0
            Try
                auditUid = Session.CurrentUserId
            Catch
            End Try
            AuditLog.Log(auditUid, "Delete Employee", $"{empNo} removed")
        Catch
        End Try
        Return True
    End Function

    ' Cascade delete for DEACTIVATED staff only: removes their salary_deduction
    ' rows first (FK-safe order), then the employee, all in ONE transaction.
    ' Payroll history for that employee is PERMANENTLY lost — callers must
    ' confirm explicitly (typed employee number) before calling.
    ' Returns rows deleted (<0 on DB error).
    Public Function DeleteEmployeeCascade(empNo As String) As Integer
        Dim rowsDeleted As Integer = -1
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Using delRows As New MySqlCommand("DELETE FROM salary_deductions WHERE employee_number=@e", conn, tx)
                            delRows.Parameters.AddWithValue("@e", empNo)
                            rowsDeleted = delRows.ExecuteNonQuery()
                        End Using
                        Using delEmp As New MySqlCommand("DELETE FROM employees WHERE employee_number=@e", conn, tx)
                            delEmp.Parameters.AddWithValue("@e", empNo)
                            If delEmp.ExecuteNonQuery() = 0 Then
                                tx.Rollback()
                                Return -1
                            End If
                        End Using
                        tx.Commit()
                    Catch
                        Try
                            tx.Rollback()
                        Catch
                        End Try
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to delete employee: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

        Dim stillThere = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        If stillThere IsNot Nothing Then _employees.Remove(stillThere)
        Try
            Dim auditUid As Integer = 0
            Try
                auditUid = Session.CurrentUserId
            Catch
            End Try
            AuditLog.Log(auditUid, "Delete Employee (Cascade)", $"{empNo} removed with {rowsDeleted} deduction row(s)")
        Catch
        End Try
        Return rowsDeleted
    End Function

    Public Sub UpdateEmployee(empNo As String, fullName As String, position As String)
        Dim existing = _employees.FirstOrDefault(Function(e) e.EmpNo = empNo)
        If existing IsNot Nothing Then
            existing.FullName = fullName
            existing.Position = position
            Try
                Using conn As MySqlConnection = DbHelper.GetConnection()
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

    ' In-memory sale counters for the dashboard session.
    ' PHASE 3: database persistence moved to TransactionService.Checkout
    ' (atomic header + details + stock + movements). Calling that AND this
    ' would double-record, so this stays memory-only by design.
    Public Sub RecordSale(total As Decimal, items As Integer)
        _totalSales += total
        _itemsSold += items
        _sales.Add(total)
        _transactionItems.Add(items)
    End Sub

End Module