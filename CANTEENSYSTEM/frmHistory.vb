Imports MySql.Data.MySqlClient

Public Class frmHistory

    ' PHASE 7: read-only stock movement log over stock_movements.
    Private Const HISTORY_PLACEHOLDER As String = "🔍 Search product..."
    Private historyLoaded As Boolean = False

    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        dtpFrom.Value = DateTime.Today.AddDays(-30)
        dtpTo.Value = DateTime.Today
        AddHistoryRefresh()
        historyLoaded = True
        LoadHistory()
    End Sub

    ' ↻ sits right of Clear Filters; reloads with current filter values.
    ' (Designer-visible: btnHistoryRefresh lives in frmHistory.Designer.vb)
    Private Sub AddHistoryRefresh()
        Try
            If btnClearFilters Is Nothing OrElse btnHistoryRefresh Is Nothing Then Exit Sub
            btnHistoryRefresh.Size = New Size(100, btnClearFilters.Height)
            btnHistoryRefresh.Location = New Point(btnClearFilters.Right + 8, btnClearFilters.Top)
        Catch ex As Exception
            Debug.WriteLine("AddHistoryRefresh failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnHistoryRefresh_Click(sender As Object, e As EventArgs) Handles btnHistoryRefresh.Click
        LoadHistory()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Function HistorySearchText() As String
        If txtSearchHistory Is Nothing Then Return ""
        Dim t As String = txtSearchHistory.Text.Trim()
        If t = HISTORY_PLACEHOLDER OrElse t.StartsWith("🔍") Then Return ""
        Return t
    End Function

    Private Function HistoryTypeFilter() As String
        If cboMovementType Is Nothing OrElse cboMovementType.SelectedItem Is Nothing Then Return ""
        Dim sel As String = cboMovementType.SelectedItem.ToString()
        If sel = "All" Then Return ""
        Return sel
    End Function

    Public Sub LoadHistory()
        If dgvInventoryHistory Is Nothing Then Exit Sub
        Try
            dgvInventoryHistory.Rows.Clear()
            Dim q As String = HistorySearchText()
            Dim typ As String = HistoryTypeFilter()
            Dim fromD As Date = If(dtpFrom IsNot Nothing, dtpFrom.Value.Date, DateTime.Today.AddDays(-30))
            Dim toD As Date = If(dtpTo IsNot Nothing, dtpTo.Value.Date.AddDays(1), DateTime.Today.AddDays(1))
            Dim sql As String =
                "SELECT sm.movement_id, sm.movement_date, p.product_name, sm.movement_type, sm.quantity, u.username, sm.remarks " &
                "FROM stock_movements sm JOIN products p ON p.product_id = sm.product_id " &
                "JOIN users u ON u.id = sm.user_id " &
                "WHERE (@q = '' OR p.product_name LIKE CONCAT('%', @q, '%')) " &
                "AND (@typ = '' OR sm.movement_type = @typ) " &
                "AND sm.movement_date >= @fromD AND sm.movement_date < @toD " &
                "ORDER BY sm.movement_date DESC, sm.movement_id DESC LIMIT 500"
            Dim totalQtyIn As Integer = 0
            Dim totalQtyOut As Integer = 0
            Dim rows As Integer = 0
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@q", q)
                    cmd.Parameters.AddWithValue("@typ", typ)
                    cmd.Parameters.AddWithValue("@fromD", fromD)
                    cmd.Parameters.AddWithValue("@toD", toD)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            dgvInventoryHistory.Rows.Add(
                                Convert.ToInt32(rdr("movement_id")),
                                Convert.ToDateTime(rdr("movement_date")).ToString("yyyy-MM-dd HH:mm"),
                                rdr("product_name").ToString(),
                                rdr("movement_type").ToString(),
                                Convert.ToInt32(rdr("quantity")),
                                rdr("username").ToString(),
                                If(rdr("remarks") Is DBNull.Value, "", rdr("remarks").ToString()))
                            rows += 1
                            Dim mt As String = rdr("movement_type").ToString()
                            Dim qty As Integer = Convert.ToInt32(rdr("quantity"))
                            If mt = "Stock In" Then
                                totalQtyIn += qty
                            Else
                                totalQtyOut += qty
                            End If
                        End While
                    End Using
                End Using
            End Using
            If lblTotalMovementsValue IsNot Nothing Then lblTotalMovementsValue.Text = rows.ToString()
            If lblStockInValue IsNot Nothing Then lblStockInValue.Text = "+" & totalQtyIn.ToString()
            If lblStockOutValue IsNot Nothing Then lblStockOutValue.Text = "-" & totalQtyOut.ToString()
        Catch ex As Exception
            MessageBox.Show("Failed to load history: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchHistory_GotFocus(sender As Object, e As EventArgs) Handles txtSearchHistory.GotFocus
        If txtSearchHistory.Text = HISTORY_PLACEHOLDER Then
            txtSearchHistory.Text = ""
        End If
    End Sub

    Private Sub txtSearchHistory_LostFocus(sender As Object, e As EventArgs) Handles txtSearchHistory.LostFocus
        If String.IsNullOrWhiteSpace(txtSearchHistory.Text) Then
            txtSearchHistory.Text = HISTORY_PLACEHOLDER
        End If
    End Sub

    Private Sub txtSearchHistory_TextChanged(sender As Object, e As EventArgs) Handles txtSearchHistory.TextChanged
        If historyLoaded AndAlso txtSearchHistory.Focused Then LoadHistory()
    End Sub

    Private Sub cboMovementType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMovementType.SelectedIndexChanged
        If historyLoaded Then LoadHistory()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        If historyLoaded Then LoadHistory()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        If historyLoaded Then LoadHistory()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        txtSearchHistory.Text = HISTORY_PLACEHOLDER
        If cboMovementType.Items.Count > 0 Then cboMovementType.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddDays(-30)
        dtpTo.Value = DateTime.Today
        LoadHistory()
    End Sub

End Class
