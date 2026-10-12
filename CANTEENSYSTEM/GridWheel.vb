Imports System.Runtime.InteropServices

' ============================================================
' GridWheel: focus-independent mouse-wheel scrolling for grids.
' Vertical wheel scrolls rows; Shift+wheel (or a horizontal-wheel
' message) scrolls columns. Only acts when the cursor is over the
' registered grid; everything else passes through untouched.
' Each grid instance gets one filter; unregister on FormClosed.
' ============================================================
Public Module GridWheel

    Private Const WM_MOUSEWHEEL As Integer = &H20A
    Private Const WM_MOUSEHWHEEL As Integer = &H20E

    <DllImport("user32.dll")>
    Private Function WindowFromPointHandle(pt As Drawing.Point) As IntPtr
    End Function

    Public Class WheelFilter
        Implements IMessageFilter
        Private ReadOnly grid As DataGridView
        Private ReadOnly tag As String

        Public Sub New(target As DataGridView, name As String)
            grid = target
            tag = name
        End Sub

        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            If m.Msg <> WM_MOUSEWHEEL AndAlso m.Msg <> WM_MOUSEHWHEEL Then Return False
            Try
                If grid Is Nothing OrElse grid.IsDisposed OrElse Not grid.Visible Then Return False
                Dim h As IntPtr = WindowFromPointHandle(Control.MousePosition)
                Dim c As Control = Control.FromHandle(h)
                While c IsNot Nothing
                    If c Is grid Then
                        If m.Msg = WM_MOUSEHWHEEL Then
                            Dim dh As Integer = CInt(m.WParam.ToInt64())
                            ScrollHorizontal(grid, tag, If(dh > 0, 1, -1))
                        ElseIf (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                            Dim ds As Integer = CInt(m.WParam.ToInt64() >> 16)
                            ScrollHorizontal(grid, tag, If(ds > 0, -1, 1))
                        ElseIf GridNeedsHorizontal(grid) AndAlso Not GridNeedsVertical(grid) Then
                            ' No vertical overflow (plain wheel would do nothing
                            ' visible): roll columns instead. Wheel up = left.
                            Dim dvh As Integer = CInt(m.WParam.ToInt64() >> 16)
                            ScrollHorizontal(grid, tag, If(dvh > 0, -1, 1))
                        Else
                            Dim dv As Integer = CInt(m.WParam.ToInt64() >> 16)
                            ScrollVertical(grid, tag, If(dv > 0, -1, 1))
                        End If
                        Return True
                    End If
                    c = c.Parent
                End While
            Catch
            End Try
            Return False
        End Function
    End Class

    Public Function GridNeedsVertical(grid As DataGridView) As Boolean
        Try
            If grid Is Nothing OrElse grid.Rows.Count = 0 Then Return False
            Dim shown As Integer = 0
            Try
                shown = Math.Max(1, grid.DisplayedRowCount(False))
            Catch
                shown = 1
            End Try
            Return grid.Rows.Count > shown
        Catch
            Return False
        End Try
    End Function

    Public Function GridNeedsHorizontal(grid As DataGridView) As Boolean
        Try
            If grid Is Nothing Then Return False
            Dim total As Integer = 0
            For Each col As DataGridViewColumn In grid.Columns
                If col.Visible Then total += col.Width
            Next
            Return total > grid.ClientSize.Width
        Catch
            Return False
        End Try
    End Function

    Public Sub ScrollVertical(grid As DataGridView, tag As String, notches As Integer)
        Try
            If grid Is Nothing OrElse grid.Rows.Count = 0 Then Exit Sub
            Dim before As Integer = SafeFirstRow(grid)
            Dim visibleCount As Integer = 1
            Try
                visibleCount = Math.Max(1, grid.DisplayedRowCount(False))
            Catch
            End Try
            Dim maxFirst As Integer = Math.Max(0, grid.Rows.Count - visibleCount)
            Dim target As Integer = before + notches * 3
            If target < 0 Then target = 0
            If target > maxFirst Then target = maxFirst
            grid.FirstDisplayedScrollingRowIndex = target
            Dim used As String = "property"
            If SafeFirstRow(grid) <> target AndAlso target >= 0 AndAlso target < grid.Rows.Count Then
                If AnchorRow(grid, target) Then used = "currentcell"
            End If
            WheelLog(tag, $"v notches={notches} before={before} target={target} after={SafeFirstRow(grid)} via={used}")
        Catch ex As Exception
            WheelLog(tag, "v EX: " & ex.GetType().Name & ": " & ex.Message)
        End Try
    End Sub

    Public Sub ScrollHorizontal(grid As DataGridView, tag As String, notches As Integer)
        Try
            If grid Is Nothing OrElse grid.Columns.Count = 0 Then Exit Sub
            Dim visCols As New List(Of Integer)
            For Each c As DataGridViewColumn In grid.Columns
                If c.Visible Then visCols.Add(c.Index)
            Next
            If visCols.Count = 0 Then Exit Sub
            Dim cur As Integer = 0
            Try
                cur = grid.FirstDisplayedScrollingColumnIndex
            Catch
                cur = 0
            End Try
            Dim pos As Integer = Math.Max(0, visCols.IndexOf(cur))
            Dim npos As Integer = pos + notches
            If npos < 0 Then npos = 0
            If npos > visCols.Count - 1 Then npos = visCols.Count - 1
            Dim targetCol As Integer = visCols(npos)
            grid.FirstDisplayedScrollingColumnIndex = targetCol
            Dim used As String = "property"
            Dim afterCol As Integer = -1
            Try
                afterCol = grid.FirstDisplayedScrollingColumnIndex
            Catch
            End Try
            If afterCol <> targetCol Then
                Dim rowIdx As Integer = 0
                Try
                    If grid.CurrentCell IsNot Nothing Then rowIdx = grid.CurrentCell.RowIndex
                Catch
                End Try
                If rowIdx >= 0 AndAlso rowIdx < grid.Rows.Count AndAlso Not grid.Rows(rowIdx).IsNewRow Then
                    grid.CurrentCell = grid.Rows(rowIdx).Cells(targetCol)
                    used = "currentcell"
                    Try
                        afterCol = grid.FirstDisplayedScrollingColumnIndex
                    Catch
                    End Try
                End If
            End If
            WheelLog(tag, $"h notches={notches} before={cur} target={targetCol} after={afterCol} via={used}")
        Catch ex As Exception
            WheelLog(tag, "h EX: " & ex.GetType().Name & ": " & ex.Message)
        End Try
    End Sub

    Private Function SafeFirstRow(grid As DataGridView) As Integer
        Try
            Return grid.FirstDisplayedScrollingRowIndex
        Catch
            Return -1
        End Try
    End Function

    Private Function AnchorRow(grid As DataGridView, target As Integer) As Boolean
        Try
            Dim colIdx As Integer = -1
            For Each c As DataGridViewColumn In grid.Columns
                If c.Visible Then
                    colIdx = c.Index
                    Exit For
                End If
            Next
            If colIdx < 0 Then Return False
            grid.CurrentCell = grid.Rows(target).Cells(colIdx)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub WheelLog(tag As String, msg As String)
        Try
            System.IO.File.AppendAllText(
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "gridwheel.log"),
                $"{DateTime.Now:HH:mm:ss.fff} [{tag}] {msg}" & vbCrLf)
        Catch
        End Try
    End Sub

End Module
