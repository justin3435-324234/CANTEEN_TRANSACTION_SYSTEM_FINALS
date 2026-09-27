Imports MySql.Data.MySqlClient

' ============================================================
' PHASE 5 — SalaryService: payroll-side salary deduction logic.
' Reads employees + salary_deductions aggregates (no deduction
' LIMIT anywhere per spec). Writes: mark Pending rows Deducted,
' cancel Pending rows. UI-free; frmDashboard renders the grid.
' ============================================================
Public Module SalaryService

    Public Class EmployeeDeductionSummary
        Public Property EmpNo As String
        Public Property Username As String
        Public Property FullName As String
        Public Property Position As String
        Public Property Status As String
        Public Property DeductionStatus As String
        Public Property PeriodStart As String
        Public Property PeriodEnd As String
        Public Property PendingTotal As Decimal
        Public Property PendingCount As Integer
        Public Property DeductedTotal As Decimal
        Public Property SettledTotal As Decimal
    End Class

    Public Function GetSummaries() As List(Of EmployeeDeductionSummary)
        Dim list As New List(Of EmployeeDeductionSummary)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Dim sql As String =
                    "SELECT e.employee_number, e.username, e.full_name, e.position, e.status, " &
                    "e.deduction_status, e.period_start, e.period_end, " &
                    "COALESCE(SUM(CASE WHEN sd.deduction_status='Pending' THEN sd.deduction_amount ELSE 0 END), 0) AS pending_total, " &
                    "SUM(CASE WHEN sd.deduction_status='Pending' THEN 1 ELSE 0 END) AS pending_count, " &
                    "COALESCE(SUM(CASE WHEN sd.deduction_status='Deducted' THEN sd.deduction_amount ELSE 0 END), 0) AS deducted_total, " &
                    "COALESCE(SUM(CASE WHEN sd.deduction_status='Settled' THEN sd.deduction_amount ELSE 0 END), 0) AS settled_total " &
                    "FROM employees e LEFT JOIN salary_deductions sd ON sd.employee_number = e.employee_number " &
                    "GROUP BY e.employee_number ORDER BY e.employee_number"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim s As New EmployeeDeductionSummary With {
                                .EmpNo = rdr("employee_number").ToString(),
                                .Username = If(rdr("username") Is DBNull.Value, "", rdr("username").ToString()),
                                .FullName = If(rdr("full_name") Is DBNull.Value, "", rdr("full_name").ToString()),
                                .Position = If(rdr("position") Is DBNull.Value, "", rdr("position").ToString()),
                                .Status = If(rdr("status") Is DBNull.Value, "", rdr("status").ToString()),
                                .DeductionStatus = If(rdr("deduction_status") Is DBNull.Value, "PENDING", rdr("deduction_status").ToString().Trim().ToUpper()),
                                .PeriodStart = If(rdr("period_start") Is DBNull.Value, "", Convert.ToDateTime(rdr("period_start")).ToString("yyyy-MM-dd")),
                                .PeriodEnd = If(rdr("period_end") Is DBNull.Value, "", Convert.ToDateTime(rdr("period_end")).ToString("yyyy-MM-dd")),
                                .PendingTotal = Convert.ToDecimal(rdr("pending_total")),
                                .PendingCount = Convert.ToInt32(rdr("pending_count")),
                                .DeductedTotal = Convert.ToDecimal(rdr("deducted_total")),
                                .SettledTotal = Convert.ToDecimal(rdr("settled_total"))
                            }
                            list.Add(s)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("SalaryService.GetSummaries failed: " & ex.Message)
        End Try
        Return list
    End Function

    Private Function ServiceUserId() As Integer
        Try
            If Session.CurrentUserId > 0 Then Return Session.CurrentUserId
        Catch
        End Try
        Return 1
    End Function

    Private Sub WriteAudit(action As String, description As String)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, @action, @d)", conn)
                    cmd.Parameters.AddWithValue("@uid", ServiceUserId())
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@d", If(description, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("SalaryService.WriteAudit failed: " & ex.Message)
        End Try
    End Sub

    ' Employee-level status flag (the grid's PENDING/COMPLETE combo).
    ' Persisted so it survives reloads; does NOT touch deduction rows.
    ' COMPLETE also stamps period_end=today; back to PENDING clears the date.
    Public Function SetEmployeeStatus(empNo As String, status As String) As Boolean
        Dim norm As String = If(String.IsNullOrWhiteSpace(status), "PENDING", status.Trim().ToUpper())
        If norm <> "PENDING" AndAlso norm <> "COMPLETE" Then Return False
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE employees SET deduction_status=@s, period_end=CASE WHEN @s='COMPLETE' THEN CURDATE() ELSE NULL END WHERE employee_number=@e", conn)
                    cmd.Parameters.AddWithValue("@s", norm)
                    cmd.Parameters.AddWithValue("@e", empNo)
                    If cmd.ExecuteNonQuery() = 0 Then Return False
                End Using
            End Using
            WriteAudit("Employee Status", $"{empNo} deduction status → {norm}")
            Return True
        Catch ex As Exception
            Debug.WriteLine("SalaryService.SetEmployeeStatus failed: " & ex.Message)
            Return False
        End Try
    End Function

    ' Payroll confirms cash collection: all Pending rows for the employee become Deducted.
    Public Function MarkDeducted(empNo As String) As Integer
        Dim affected As Integer = 0
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE salary_deductions SET deduction_status='Deducted' WHERE employee_number=@e AND deduction_status='Pending'", conn)
                    cmd.Parameters.AddWithValue("@e", empNo)
                    affected = cmd.ExecuteNonQuery()
                End Using
            End Using
            If affected > 0 Then WriteAudit("Salary Deducted", $"{empNo}: {affected} pending deduction(s) marked Deducted")
        Catch ex As Exception
            Debug.WriteLine("SalaryService.MarkDeducted failed: " & ex.Message)
        End Try
        Return affected
    End Function

    ' Period close (COMPLETE toggle): settle every open row for the employee
    ' (Pending + Deducted -> Settled) and close the employee flag with
    ' period_end=today, all in ONE transaction. Settled rows keep full history
    ' (reports list them) but drop out of the Pending/Deducted peso columns,
    ' so both read 0.00 after a close. Returns rows settled, -1 on error.
    Public Function SettlePeriod(empNo As String) As Integer
        Dim settled As Integer = 0
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Using flipCmd As New MySqlCommand("UPDATE salary_deductions SET deduction_status='Settled' WHERE employee_number=@e AND deduction_status IN ('Pending','Deducted')", conn, tx)
                            flipCmd.Parameters.AddWithValue("@e", empNo)
                            settled = flipCmd.ExecuteNonQuery()
                        End Using
                        Using empCmd As New MySqlCommand("UPDATE employees SET deduction_status='COMPLETE', period_end=CURDATE() WHERE employee_number=@e", conn, tx)
                            empCmd.Parameters.AddWithValue("@e", empNo)
                            If empCmd.ExecuteNonQuery() = 0 Then
                                tx.Rollback()
                                Return -1
                            End If
                        End Using
                        Using audCmd As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, 'Period Settled', @d)", conn, tx)
                            audCmd.Parameters.AddWithValue("@uid", ServiceUserId())
                            audCmd.Parameters.AddWithValue("@d", $"{empNo} period COMPLETE: {settled} row(s) settled, period_end stamped")
                            audCmd.ExecuteNonQuery()
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
            Debug.WriteLine("SalaryService.SettlePeriod failed: " & ex.Message)
            Return -1
        End Try
        Return settled
    End Function

    ' Active/Inactive flag (salary DEACTIVATE button). Inactive employees are
    ' blocked at salary login; payroll history is never touched.
    Public Function SetActiveStatus(empNo As String, active As Boolean) As Boolean
        Dim s As String = If(active, "Active", "Inactive")
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE employees SET status=@s WHERE employee_number=@e", conn)
                    cmd.Parameters.AddWithValue("@s", s)
                    cmd.Parameters.AddWithValue("@e", empNo)
                    If cmd.ExecuteNonQuery() = 0 Then Return False
                End Using
            End Using
            WriteAudit(If(active, "Reactivate Employee", "Deactivate Employee"), $"{empNo} → {s}")
            Return True
        Catch ex As Exception
            Debug.WriteLine("SalaryService.SetActiveStatus failed: " & ex.Message)
            Return False
        End Try
    End Function

    ' Void pending rows that will never be collected (e.g. voided sale adjustments).
    Public Function CancelPending(empNo As String) As Integer
        Dim affected As Integer = 0
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE salary_deductions SET deduction_status='Cancelled' WHERE employee_number=@e AND deduction_status='Pending'", conn)
                    cmd.Parameters.AddWithValue("@e", empNo)
                    affected = cmd.ExecuteNonQuery()
                End Using
            End Using
            If affected > 0 Then WriteAudit("Cancel Deduction", $"{empNo}: {affected} pending deduction(s) cancelled")
        Catch ex As Exception
            Debug.WriteLine("SalaryService.CancelPending failed: " & ex.Message)
        End Try
        Return affected
    End Function

End Module
