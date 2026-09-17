' ============================================================
' Navigator: single place for front-door navigation.
' frmSystemSelect is the MainForm and must never be closed
' during a session — every return path re-shows it.
' ============================================================
Public Module Navigator

    Public Sub ReturnToSystemSelect(caller As Form)
        Try
            Dim selectForm As frmSystemSelect = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is frmSystemSelect Then
                    selectForm = CType(f, frmSystemSelect)
                    Exit For
                End If
            Next
            If selectForm Is Nothing Then selectForm = New frmSystemSelect()
            selectForm.Show()
            selectForm.BringToFront()
        Catch ex As Exception
            Debug.WriteLine("Navigator.ReturnToSystemSelect failed: " & ex.Message)
        Finally
            Try
                If caller IsNot Nothing Then caller.Close()
            Catch
            End Try
        End Try
    End Sub

End Module
