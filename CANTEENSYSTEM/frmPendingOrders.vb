Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class frmPendingOrders

    ' Draggable borderless window (header-drag like a title bar).
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function WindowFromPoint(pt As Drawing.Point) As IntPtr
    End Function
    ' NOTE: native WM_VSCROLL was tried and proven to do nothing on this grid
    ' (verified off-screen: messages dispatched, position never moved).

    Private Const WM_MOUSEWHEEL As Integer = &H20A
    Private wheelFilter As PendingGridWheelFilter

    ' Focus-independent wheel scrolling: WinForms only routes the wheel to
    ' the FOCUSED control, and focus here gets lost to repaints/activation.
    ' This filter catches the wheel over the grid regardless of focus.
    Private Class PendingGridWheelFilter
        Implements IMessageFilter
        Private ReadOnly owner As frmPendingOrders

        Public Sub New(form As frmPendingOrders)
            owner = form
        End Sub

        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            If m.Msg <> WM_MOUSEWHEEL Then Return False
            Try
                If owner Is Nothing OrElse owner.IsDisposed Then Return False
                Dim grid As DataGridView = owner.dgvPendingOrders
                If grid Is Nothing OrElse grid.IsDisposed OrElse Not grid.Visible Then Return False
                Dim h As IntPtr = WindowFromPoint(Control.MousePosition)
                Dim c As Control = Control.FromHandle(h)
                While c IsNot Nothing
                    If c Is grid Then
                        Dim delta As Integer = CInt(m.WParam.ToInt64() >> 16)
                        owner.ScrollPendingGrid(If(delta > 0, -1, 1))
                        Return True
                    End If
                    c = c.Parent
                End While
            Catch
            End Try
            Return False
        End Function
    End Class

    ' PHASE 4: live view over kiosk_orders. Refresh = re-query,
    ' Cancel = status flip, Process = push lines into frmPOS (payment
    ' there completes the order atomically via TransactionService).
    ' (Designer-visible: btnProcessOrder/btnScrollUp/btnScrollDown/
    '  btnPendingClose all live in frmPendingOrders.Designer.vb)

    ' The Designer docks Panel1 BEFORE the grid, so the bottom button panel
    ' OVERLAPS the grid's lower rows: the grid thinks all rows fit (no
    ' scrollbar, nothing to scroll) while Panel1 covers them on screen.
    ' Explicit geometry (no Dock guessing): grid fills exactly the space
    ' between header and bottom panel, so overflow becomes real and every
    ' scroll path (bar, wheel, ▲▼) works on actual hidden rows.
    Private Sub FixPendingGridLayout()
        Try
            If dgvPendingOrders Is Nothing OrElse pnlPendingHeader Is Nothing OrElse Panel1 Is Nothing Then Exit Sub
            dgvPendingOrders.Dock = DockStyle.None
            Dim top As Integer = pnlPendingHeader.Bottom
            Dim bottom As Integer = Panel1.Top
            dgvPendingOrders.Location = New Point(0, top)
            dgvPendingOrders.Size = New Size(Me.ClientSize.Width, Math.Max(100, bottom - top))
            dgvPendingOrders.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Catch ex As Exception
            Debug.WriteLine("FixPendingGridLayout failed: " & ex.Message)
        End Try
    End Sub

    Private Sub frmPendingOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        ' Opened centered (it used to appear wherever Windows felt like it,
        ' which could hide the bottom buttons off-screen).
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.CenterToScreen()
        EnsurePendingHeaderButtons()
        StyleRefreshButton()
        FixPendingGridLayout()
        ' Mouse-wheel scrolling works only when the grid has focus: grab it
        ' on hover so the wheel just works, no click needed first.
        If dgvPendingOrders IsNot Nothing Then
            dgvPendingOrders.ScrollBars = ScrollBars.Both
            AddHandler dgvPendingOrders.MouseEnter, AddressOf PendingGrid_MouseEnter
        End If
        If wheelFilter Is Nothing Then
            wheelFilter = New PendingGridWheelFilter(Me)
            Application.AddMessageFilter(wheelFilter)
        End If
        ' Header-drag to move the borderless window.
        If pnlPendingHeader IsNot Nothing Then
            AddHandler pnlPendingHeader.MouseDown, AddressOf PendingHeader_MouseDown
        End If
        For Each lbl As Control In pnlPendingHeader.Controls.OfType(Of Label)()
            AddHandler lbl.MouseDown, AddressOf PendingHeader_MouseDown
        Next
        ' Designer-visible: btnProcessOrder already in Panel1.
        RefreshOrders()
    End Sub

    ' Designer-visible buttons: just ensure z-order (Panel1/header overlap).
    Private Sub EnsurePendingHeaderButtons()
        Try
            If btnScrollUp IsNot Nothing Then btnScrollUp.BringToFront()
            If btnScrollDown IsNot Nothing Then btnScrollDown.BringToFront()
            If btnPendingClose IsNot Nothing Then btnPendingClose.BringToFront()
            If btnProcessOrder IsNot Nothing Then btnProcessOrder.BringToFront()
        Catch ex As Exception
            Debug.WriteLine("EnsurePendingHeaderButtons failed: " & ex.Message)
        End Try
    End Sub

    ' Kept as no-op shims so older calls still compile if referenced.
    Private Sub AddScrollButtons()
        EnsurePendingHeaderButtons()
    End Sub

    Private Sub btnScrollUp_Click(sender As Object, e As EventArgs) Handles btnScrollUp.Click
        ScrollLog("UP clicked")
        ScrollPendingGrid(-1)
    End Sub

    Private Sub btnScrollDown_Click(sender As Object, e As EventArgs) Handles btnScrollDown.Click
        ScrollLog("DOWN clicked")
        ScrollPendingGrid(1)
    End Sub

    ' Diagnostic trail (TEMP folder) so a dead click can be diagnosed
    ' from the actual runtime state instead of guessed at.
    Private Sub ScrollLog(msg As String)
        Try
            Dim detail As String = ""
            Try
                If dgvPendingOrders IsNot Nothing Then
                    detail = $" rows={dgvPendingOrders.Rows.Count} first={dgvPendingOrders.FirstDisplayedScrollingRowIndex} displayed={dgvPendingOrders.DisplayedRowCount(False)}"
                Else
                    detail = " grid=Nothing"
                End If
            Catch ex As Exception
                detail = " state-err=" & ex.GetType().Name & ":" & ex.Message
            End Try
            System.IO.File.AppendAllText(
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "pending_scroll.log"),
                $"{DateTime.Now:HH:mm:ss.fff} {msg}{detail}" & vbCrLf)
        Catch
        End Try
    End Sub

    ' Borderless window needs a way out (POS reopens it via F6).
    ' (Designer-visible: btnPendingClose lives in the designer.)
    Private Sub AddCloseButton()
        EnsurePendingHeaderButtons()
    End Sub

    Private Sub btnPendingClose_Click(sender As Object, e As EventArgs) Handles btnPendingClose.Click
        Me.Close()
    End Sub

    ' The designer REFRESH button restyled unmissable-yellow + navy text.
    Private Sub StyleRefreshButton()
        Try
            If Button1 Is Nothing Then Exit Sub
            Button1.BackColor = Color.FromArgb(245, 194, 27)
            Button1.ForeColor = Color.FromArgb(0, 0, 64)
            Button1.FlatStyle = FlatStyle.Flat
            Button1.FlatAppearance.BorderSize = 0
            Button1.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Button1.Cursor = Cursors.Hand
        Catch ex As Exception
            Debug.WriteLine("StyleRefreshButton failed: " & ex.Message)
        End Try
    End Sub

    Private Sub PendingGrid_MouseEnter(sender As Object, e As EventArgs)
        Try
            If dgvPendingOrders IsNot Nothing AndAlso dgvPendingOrders.CanFocus Then
                dgvPendingOrders.Focus()
            End If
        Catch
        End Try
    End Sub

    Private Sub frmPendingOrders_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            If wheelFilter IsNot Nothing Then
                Application.RemoveMessageFilter(wheelFilter)
                wheelFilter = Nothing
            End If
        Catch
        End Try
    End Sub

    ' Clamped grid scroll: notches>0 scrolls down. Single place for all
    ' wheel/button paths. Primary: FirstDisplayedScrollingRowIndex (proven to
    ' work on displayed grids). Fallback: anchoring CurrentCell, which the
    ' grid MUST display — so one of the two always moves.
    Public Sub ScrollPendingGrid(notches As Integer)
        Try
            If dgvPendingOrders Is Nothing Then
                ScrollLog("scroll: grid Nothing")
                Exit Sub
            End If
            If dgvPendingOrders.Rows.Count = 0 Then
                ScrollLog("scroll: 0 rows")
                Exit Sub
            End If
            Dim before As Integer = SafeFirstRow()
            Dim visibleCount As Integer = 1
            Try
                visibleCount = Math.Max(1, dgvPendingOrders.DisplayedRowCount(False))
            Catch
            End Try
            Dim maxFirst As Integer = Math.Max(0, dgvPendingOrders.Rows.Count - visibleCount)
            Dim target As Integer = before + notches * 3
            If target < 0 Then target = 0
            If target > maxFirst Then target = maxFirst
            dgvPendingOrders.FirstDisplayedScrollingRowIndex = target
            Dim used As String = "property"
            If SafeFirstRow() <> target AndAlso target >= 0 AndAlso target < dgvPendingOrders.Rows.Count Then
                Dim colIdx As Integer = -1
                For Each c As DataGridViewColumn In dgvPendingOrders.Columns
                    If c.Visible Then
                        colIdx = c.Index
                        Exit For
                    End If
                Next
                If colIdx >= 0 Then
                    dgvPendingOrders.CurrentCell = dgvPendingOrders.Rows(target).Cells(colIdx)
                    used = "currentcell"
                End If
            End If
            ScrollLog($"scroll notches={notches} before={before} target={target} after={SafeFirstRow()} via={used}")
        Catch ex As Exception
            ScrollLog("scroll EX: " & ex.GetType().Name & ": " & ex.Message)
        End Try
    End Sub

    Private Function SafeFirstRow() As Integer
        Try
            Return dgvPendingOrders.FirstDisplayedScrollingRowIndex
        Catch
            Return -1
        End Try
    End Function

    Private Sub PendingHeader_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub

    Public Sub RefreshOrders()
        If dgvPendingOrders Is Nothing Then Exit Sub
        Try
            dgvPendingOrders.Rows.Clear()
            Dim sql As String =
                "SELECT ko.kiosk_order_id, ko.order_number, ko.order_type, ko.total_amount, " &
                "ko.payment_method, ko.status, ko.order_date, ko.employee_number, " &
                "COUNT(kod.kiosk_order_detail_id) AS line_count, " &
                "SUBSTRING(GROUP_CONCAT(CONCAT(p.product_name, ' x', kod.quantity) SEPARATOR ', '), 1, 60) AS items " &
                "FROM kiosk_orders ko LEFT JOIN kiosk_order_details kod ON kod.kiosk_order_id = ko.kiosk_order_id " &
                "LEFT JOIN products p ON p.product_id = kod.product_id " &
                "WHERE ko.status IN ('Pending','Processing') " &
                "GROUP BY ko.kiosk_order_id ORDER BY ko.order_date"
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim idx As Integer = dgvPendingOrders.Rows.Add(
                                rdr("order_number").ToString(),
                                rdr("order_type").ToString(),
                                If(rdr("items") Is DBNull.Value, "", rdr("items").ToString()),
                                "₱" & Convert.ToDecimal(rdr("total_amount")).ToString("N2"),
                                rdr("payment_method").ToString(),
                                rdr("status").ToString(),
                                "PROCESS →")
                            dgvPendingOrders.Rows(idx).Tag = Convert.ToInt32(rdr("kiosk_order_id"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load pending orders: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshOrders()
    End Sub

    Private Function SelectedKioskOrderId() As Integer
        If dgvPendingOrders Is Nothing Then Return 0
        Dim row As DataGridViewRow = Nothing
        If dgvPendingOrders.SelectedRows.Count > 0 Then row = dgvPendingOrders.SelectedRows(0)
        If row Is Nothing AndAlso dgvPendingOrders.CurrentRow IsNot Nothing Then row = dgvPendingOrders.CurrentRow
        If row Is Nothing OrElse row.Tag Is Nothing Then Return 0
        Dim id As Integer = 0
        Integer.TryParse(row.Tag.ToString(), id)
        Return id
    End Function

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        Dim kid As Integer = SelectedKioskOrderId()
        If kid <= 0 Then
            MessageBox.Show("Please select an order first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Cancel this kiosk order? It will not be served.", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub
        Try
            Dim uid As Integer = 1
            Try
                If Session.CurrentUserId > 0 Then uid = Session.CurrentUserId
            Catch
            End Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE kiosk_orders SET status='Cancelled' WHERE kiosk_order_id=@kid AND status IN ('Pending','Processing')", conn)
                    cmd.Parameters.AddWithValue("@kid", kid)
                    If cmd.ExecuteNonQuery() = 0 Then
                        MessageBox.Show("Order is no longer pending.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RefreshOrders()
                        Exit Sub
                    End If
                End Using
                Using aud As New MySqlCommand("INSERT INTO audit_logs (user_id, action, description) VALUES (@uid, 'Cancel Kiosk Order', @d)", conn)
                    aud.Parameters.AddWithValue("@uid", uid)
                    aud.Parameters.AddWithValue("@d", $"kiosk order #{kid} cancelled")
                    aud.ExecuteNonQuery()
                End Using
            End Using
            RefreshOrders()
            MessageBox.Show("Order cancelled.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to cancel order: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProcessOrder_Click(sender As Object, e As EventArgs) Handles btnProcessOrder.Click
        ProcessSelectedOrder()
    End Sub

    Private Sub dgvPendingOrders_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendingOrders.CellDoubleClick
        If e.RowIndex >= 0 Then ProcessSelectedOrder()
    End Sub

    Private Sub ProcessSelectedOrder()
        Dim kid As Integer = SelectedKioskOrderId()
        If kid <= 0 Then
            MessageBox.Show("Please select an order first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Dim orderNo As String = ""
            Dim payMethod As String = "Cash"
            Dim empNo As String = ""
            Dim lines As New List(Of TransactionService.CartLine)
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using head As New MySqlCommand("SELECT order_number, payment_method, employee_number, status FROM kiosk_orders WHERE kiosk_order_id=@kid", conn)
                    head.Parameters.AddWithValue("@kid", kid)
                    Using rdr As MySqlDataReader = head.ExecuteReader()
                        If Not rdr.Read() Then
                            MessageBox.Show("Order not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            RefreshOrders()
                            Exit Sub
                        End If
                        Dim st As String = rdr("status").ToString()
                        If st <> "Pending" AndAlso st <> "Processing" Then
                            MessageBox.Show($"Order is already {st}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            RefreshOrders()
                            Exit Sub
                        End If
                        orderNo = rdr("order_number").ToString()
                        payMethod = rdr("payment_method").ToString()
                        If rdr("employee_number") IsNot DBNull.Value Then empNo = rdr("employee_number").ToString()
                    End Using
                End Using
                Using det As New MySqlCommand("SELECT kod.product_id, p.product_name, kod.quantity, kod.unit_price FROM kiosk_order_details kod JOIN products p ON p.product_id = kod.product_id WHERE kod.kiosk_order_id=@kid", conn)
                    det.Parameters.AddWithValue("@kid", kid)
                    Using rdr As MySqlDataReader = det.ExecuteReader()
                        While rdr.Read()
                            Dim cl As New TransactionService.CartLine With {
                                .ProductId = Convert.ToInt32(rdr("product_id")),
                                .ProductName = rdr("product_name").ToString(),
                                .Quantity = Convert.ToInt32(rdr("quantity")),
                                .UnitPrice = Convert.ToDecimal(rdr("unit_price"))
                            }
                            lines.Add(cl)
                        End While
                    End Using
                End Using
                If lines.Count = 0 Then
                    MessageBox.Show("Order has no items.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Using mark As New MySqlCommand("UPDATE kiosk_orders SET status='Processing' WHERE kiosk_order_id=@kid AND status='Pending'", conn)
                    mark.Parameters.AddWithValue("@kid", kid)
                    mark.ExecuteNonQuery() ' already Processing stays Processing
                End Using
            End Using

            Dim pos As frmPOS = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is frmPOS Then
                    pos = CType(f, frmPOS)
                    Exit For
                End If
            Next
            If pos Is Nothing Then pos = New frmPOS()
            pos.LoadKioskOrder(kid, orderNo, lines, payMethod, empNo)
            pos.Show()
            pos.BringToFront()
            RefreshOrders()
        Catch ex As Exception
            MessageBox.Show("Failed to process order: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
