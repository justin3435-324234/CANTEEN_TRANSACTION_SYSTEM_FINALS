Imports MySql.Data.MySqlClient

' ============================================================
' PHASE 3 — TransactionService: atomic POS checkout writer.
' One MySqlTransaction covers: transactions header (+ number),
' transaction_details, stock deduction (guarded), stock_movements,
' salary_deductions (salary path), audit_logs. Any failure rolls
' back everything so half-written sales are impossible.
' Reused by Phase 4 (pending kiosk orders) — keep UI-free.
' ============================================================
Public Module TransactionService

    Public Class CartLine
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property Quantity As Integer
        Public Property UnitPrice As Decimal
        Public ReadOnly Property Subtotal As Decimal
            Get
                Return Quantity * UnitPrice
            End Get
        End Property
    End Class

    Public Class CheckoutResult
        Public Property Success As Boolean
        Public Property Message As String
        Public Property TransactionId As Integer
        Public Property TransactionNumber As String
    End Class

    Public Function IsSalaryPayment(paymentMethod As String) As Boolean
        If String.IsNullOrWhiteSpace(paymentMethod) Then Return False
        Dim pm As String = paymentMethod.ToLower()
        Return pm.Contains("salary") OrElse pm.Contains("deduction")
    End Function

    Private Function CheckoutUserId() As Integer
        Try
            If Session.CurrentUserId > 0 Then Return Session.CurrentUserId
        Catch
        End Try
        Return 1 ' seed admin row; Session is set on login
    End Function

    ' Friendly pre-check against live stock (re-enforced inside Checkout).
    Public Function ValidateStock(lines As List(Of CartLine)) As CheckoutResult
        Dim res As New CheckoutResult With {.Success = True}
        If lines Is Nothing OrElse lines.Count = 0 Then
            res.Success = False
            res.Message = "Cart is empty."
            Return res
        End If
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                For Each ln In lines
                    If ln.ProductId <= 0 Then
                        res.Success = False
                        res.Message = $"Could not identify '{ln.ProductName}' in inventory. Please re-add it from the menu."
                        Return res
                    End If
                    If ln.Quantity <= 0 Then
                        res.Success = False
                        res.Message = $"Invalid quantity for '{ln.ProductName}'."
                        Return res
                    End If
                    Using cmd As New MySqlCommand("SELECT stock_quantity FROM products WHERE product_id=@id AND status='Active'", conn)
                        cmd.Parameters.AddWithValue("@id", ln.ProductId)
                        Dim obj As Object = cmd.ExecuteScalar()
                        If obj Is Nothing OrElse obj Is DBNull.Value Then
                            res.Success = False
                            res.Message = $"'{ln.ProductName}' is no longer available."
                            Return res
                        End If
                        If Convert.ToInt32(obj) < ln.Quantity Then
                            res.Success = False
                            res.Message = $"Insufficient stock for '{ln.ProductName}' (available: {obj}, needed: {ln.Quantity})."
                            Return res
                        End If
                    End Using
                Next
            End Using
        Catch ex As Exception
            res.Success = False
            res.Message = "Stock check failed: " & ex.Message
        End Try
        Return res
    End Function

    Public Class KioskOrderResult
        Public Property Success As Boolean
        Public Property Message As String
        Public Property KioskOrderId As Integer
        Public Property OrderNumber As String
    End Class

    ' PHASE 4: persist a kiosk order as Pending (paid later at POS).
    ' Order numbers look like K-20260915-001 and are UNIQUE-checked.
    Public Function SaveKioskOrder(lines As List(Of CartLine), orderType As String, paymentMethod As String, employeeNumber As String) As KioskOrderResult
        Dim res As New KioskOrderResult With {.Success = False}
        If lines Is Nothing OrElse lines.Count = 0 Then
            res.Message = "Order is empty."
            Return res
        End If
        Dim total As Decimal = 0
        For Each ln In lines
            If ln.ProductId <= 0 OrElse ln.Quantity <= 0 Then
                res.Message = $"Could not identify '{ln.ProductName}' in inventory."
                Return res
            End If
            total += ln.Subtotal
        Next
        Dim uid As Integer = CheckoutUserId()
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim orderNo As String = GenerateOrderNumber(conn, tx)
                        Dim kid As Integer
                        Using cmd As New MySqlCommand("INSERT INTO kiosk_orders (order_number, total_amount, status, order_type, payment_method, employee_number) VALUES (@no, @total, 'Pending', @otype, @pm, @emp)", conn, tx)
                            cmd.Parameters.AddWithValue("@no", orderNo)
                            cmd.Parameters.AddWithValue("@total", total)
                            cmd.Parameters.AddWithValue("@otype", If(String.IsNullOrWhiteSpace(orderType), "DineIn", orderType))
                            cmd.Parameters.AddWithValue("@pm", If(String.IsNullOrWhiteSpace(paymentMethod), "Cash", paymentMethod))
                            cmd.Parameters.AddWithValue("@emp", If(String.IsNullOrWhiteSpace(employeeNumber), CType(DBNull.Value, Object), employeeNumber))
                            cmd.ExecuteNonQuery()
                            kid = CInt(cmd.LastInsertedId)
                        End Using
                        For Each ln In lines
                            Using det As New MySqlCommand("INSERT INTO kiosk_order_details (kiosk_order_id, product_id, quantity, unit_price, subtotal) VALUES (@kid, @pid, @qty, @price, @sub)", conn, tx)
                                det.Parameters.AddWithValue("@kid", kid)
                                det.Parameters.AddWithValue("@pid", ln.ProductId)
                                det.Parameters.AddWithValue("@qty", ln.Quantity)
                                det.Parameters.AddWithValue("@price", ln.UnitPrice)
                                det.Parameters.AddWithValue("@sub", ln.Subtotal)
                                det.ExecuteNonQuery()
                            End Using
                        Next
                        Using aud As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, 'Kiosk Order', @d)", conn, tx)
                            aud.Parameters.AddWithValue("@uid", uid)
                            aud.Parameters.AddWithValue("@d", $"{orderNo} {orderType} ₱{total:N2} ({lines.Count} line(s))")
                            aud.ExecuteNonQuery()
                        End Using
                        tx.Commit()
                        res.Success = True
                        res.KioskOrderId = kid
                        res.OrderNumber = orderNo
                    Catch ex As Exception
                        Try
                            tx.Rollback()
                        Catch
                        End Try
                        res.Message = ex.Message
                    End Try
                End Using
            End Using
        Catch ex As Exception
            res.Message = ex.Message
        End Try
        Return res
    End Function

    Private Function GenerateOrderNumber(conn As MySqlConnection, tx As MySqlTransaction) As String
        Dim dayPart As String = DateTime.Now.ToString("yyyyMMdd")
        Dim seq As Integer = 0
        Using cnt As New MySqlCommand("SELECT COUNT(*) FROM kiosk_orders WHERE order_number LIKE CONCAT('K-', @day, '-%')", conn, tx)
            cnt.Parameters.AddWithValue("@day", dayPart)
            seq = Convert.ToInt32(cnt.ExecuteScalar()) + 1
        End Using
        For attempt As Integer = 1 To 20
            Dim candidate As String = $"K-{dayPart}-{seq.ToString("D3")}"
            Using chk As New MySqlCommand("SELECT COUNT(*) FROM kiosk_orders WHERE order_number=@no", conn, tx)
                chk.Parameters.AddWithValue("@no", candidate)
                If Convert.ToInt32(chk.ExecuteScalar()) = 0 Then Return candidate
            End Using
            seq += 1
        Next
        ' Fallback: timestamp makes collision practically impossible.
        Return $"K-{dayPart}-{DateTime.Now.ToString("HHmmss")}"
    End Function

    Public Function Checkout(lines As List(Of CartLine), paymentMethod As String, cashReceived As Decimal, changeAmount As Decimal, employeeNumber As String, Optional kioskOrderId As Integer = 0) As CheckoutResult
        Dim res As New CheckoutResult With {.Success = False}
        If lines Is Nothing OrElse lines.Count = 0 Then
            res.Message = "Cart is empty."
            Return res
        End If
        Dim total As Decimal = 0
        For Each ln In lines
            total += ln.Subtotal
        Next
        Dim uid As Integer = CheckoutUserId()
        Dim isSalary As Boolean = IsSalaryPayment(paymentMethod)

        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Salary guard: salary_deductions.employee_number FKs to
                        ' employees.employee_number, so fail fast with a friendly
                        ' message instead of a raw MySQL 1452 FK error. Empty is
                        ' rejected (never silently skip the deduction row), missing
                        ' or Inactive employees are blocked before any write.
                        If isSalary Then
                            If String.IsNullOrWhiteSpace(employeeNumber) Then
                                Throw New Exception("Salary Deduction needs an employee login (nothing was saved). Cancel and retry with an employee, or use Cash.")
                            End If
                            Using chk As New MySqlCommand("SELECT status FROM employees WHERE employee_number=@e LIMIT 1", conn, tx)
                                chk.Parameters.AddWithValue("@e", employeeNumber)
                                Dim st As Object = chk.ExecuteScalar()
                                If st Is Nothing OrElse st Is DBNull.Value Then
                                    Throw New Exception($"Employee '{employeeNumber}' was not found (nothing was saved). Re-register / re-login and retry.")
                                End If
                                If String.Equals(st.ToString(), "Inactive", StringComparison.OrdinalIgnoreCase) Then
                                    Throw New Exception($"Employee '{employeeNumber}' is Inactive — salary deduction blocked (nothing was saved).")
                                End If
                            End Using
                        End If
                        ' 1. Header (number stamped below from the real auto-id).
                        Dim tid As Integer
                        Using cmd As New MySqlCommand("INSERT INTO transactions (transaction_date, user_id, total_amount, cash_received, change_amount, payment_method, status, employee_number) VALUES (NOW(), @uid, @total, @cash, @chg, @pm, 'Completed', @emp)", conn, tx)
                            cmd.Parameters.AddWithValue("@uid", uid)
                            cmd.Parameters.AddWithValue("@total", total)
                            cmd.Parameters.AddWithValue("@cash", cashReceived)
                            cmd.Parameters.AddWithValue("@chg", changeAmount)
                            cmd.Parameters.AddWithValue("@pm", If(String.IsNullOrWhiteSpace(paymentMethod), "Cash", paymentMethod))
                            cmd.Parameters.AddWithValue("@emp", If(String.IsNullOrWhiteSpace(employeeNumber), CType(DBNull.Value, Object), employeeNumber))
                            cmd.ExecuteNonQuery()
                            tid = CInt(cmd.LastInsertedId)
                        End Using
                        Dim trn As String = "TRN-" & DateTime.Now.ToString("yyyyMMdd-") & tid.ToString("D4")
                        Using upd As New MySqlCommand("UPDATE transactions SET transaction_number=@trn, kiosk_order_id=@kid WHERE transaction_id=@id", conn, tx)
                            upd.Parameters.AddWithValue("@trn", trn)
                            upd.Parameters.AddWithValue("@kid", If(kioskOrderId > 0, CType(kioskOrderId, Object), DBNull.Value))
                            upd.Parameters.AddWithValue("@id", tid)
                            upd.ExecuteNonQuery()
                        End Using

                        ' 2. Details + guarded stock deduction + movements.
                        For Each ln In lines
                            Using det As New MySqlCommand("INSERT INTO transaction_details (transaction_id, product_id, quantity, price, subtotal) VALUES (@tid, @pid, @qty, @price, @sub)", conn, tx)
                                det.Parameters.AddWithValue("@tid", tid)
                                det.Parameters.AddWithValue("@pid", ln.ProductId)
                                det.Parameters.AddWithValue("@qty", ln.Quantity)
                                det.Parameters.AddWithValue("@price", ln.UnitPrice)
                                det.Parameters.AddWithValue("@sub", ln.Subtotal)
                                det.ExecuteNonQuery()
                            End Using
                            Using stk As New MySqlCommand("UPDATE products SET stock_quantity = stock_quantity - @qty WHERE product_id=@pid AND stock_quantity >= @qty", conn, tx)
                                stk.Parameters.AddWithValue("@qty", ln.Quantity)
                                stk.Parameters.AddWithValue("@pid", ln.ProductId)
                                If stk.ExecuteNonQuery() = 0 Then
                                    Throw New Exception($"Insufficient stock for '{ln.ProductName}' (sale rolled back, nothing was saved).")
                                End If
                            End Using
                            Using mov As New MySqlCommand("INSERT INTO stock_movements (product_id, user_id, movement_type, quantity, remarks) VALUES (@pid, @uid, 'Sale', @qty, @rem)", conn, tx)
                                mov.Parameters.AddWithValue("@pid", ln.ProductId)
                                mov.Parameters.AddWithValue("@uid", uid)
                                mov.Parameters.AddWithValue("@qty", ln.Quantity)
                                mov.Parameters.AddWithValue("@rem", trn)
                                mov.ExecuteNonQuery()
                            End Using
                        Next

                        ' 3. Salary deduction row (no-limit rule: any amount allowed).
                        ' employeeNumber is guaranteed non-empty + existing by the guard above.
                        If isSalary Then
                            Using ded As New MySqlCommand("INSERT INTO salary_deductions (employee_number, transaction_id, deduction_amount, deduction_status, remarks) VALUES (@emp, @tid, @amt, 'Pending', @rem)", conn, tx)
                                ded.Parameters.AddWithValue("@emp", employeeNumber)
                                ded.Parameters.AddWithValue("@tid", tid)
                                ded.Parameters.AddWithValue("@amt", total)
                                ded.Parameters.AddWithValue("@rem", trn)
                                ded.ExecuteNonQuery()
                            End Using
                        End If

                        ' 4. PHASE 4: complete the kiosk order atomically with the sale.
                        ' If the order was cancelled meanwhile, the whole sale rolls back.
                        If kioskOrderId > 0 Then
                            Using kok As New MySqlCommand("UPDATE kiosk_orders SET status='Completed' WHERE kiosk_order_id=@kid AND status IN ('Pending','Processing')", conn, tx)
                                kok.Parameters.AddWithValue("@kid", kioskOrderId)
                                If kok.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("This kiosk order is no longer pending (it may have been cancelled). Sale rolled back, nothing was saved.")
                                End If
                            End Using
                        End If

                        ' 5. Audit trail.
                        Using aud As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, 'POS Sale', @d)", conn, tx)
                            aud.Parameters.AddWithValue("@uid", uid)
                            Dim kref As String = If(kioskOrderId > 0, $" kiosk=#{kioskOrderId}", "")
                            aud.Parameters.AddWithValue("@d", $"{trn} {paymentMethod} ₱{total:N2} ({lines.Count} line(s)){kref}")
                            aud.ExecuteNonQuery()
                        End Using

                        tx.Commit()
                        res.Success = True
                        res.TransactionId = tid
                        res.TransactionNumber = trn
                    Catch ex As Exception
                        Try
                            tx.Rollback()
                        Catch
                        End Try
                        ' Map the raw FK error to something a cashier can act on.
                        Dim msg As String = ex.Message
                        If msg.Contains("fk_deduction_employee") OrElse msg.Contains("foreign key constraint fails") Then
                            msg = $"Employee '{employeeNumber}' was not found, so the salary charge was blocked and rolled back (nothing was saved). Re-register / re-login the employee and retry."
                        End If
                        res.Message = msg
                    End Try
                End Using
            End Using
        Catch ex As Exception
            res.Message = ex.Message
        End Try
        Return res
    End Function

End Module
