''' <summary>Themed category picker: navy/gold dropdown replacing the
''' type-a-number-or-name prompt. Returns the chosen category name,
''' or Nothing on Cancel.</summary>
Public Class frmCategoryPicker

    Public Sub New(title As String, categories As List(Of String))
        InitializeComponent()
        Me.Text = title
        If categories IsNot Nothing Then
            For Each c As String In categories
                cboCategory.Items.Add(c)
            Next
            If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0
        End If
    End Sub

    Public Shared Function Pick(title As String, categories As List(Of String)) As String
        If categories Is Nothing OrElse categories.Count = 0 Then Return Nothing
        Using d As New frmCategoryPicker(title, categories)
            If d.ShowDialog() = DialogResult.OK AndAlso d.cboCategory.SelectedItem IsNot Nothing Then
                Return d.cboCategory.SelectedItem.ToString()
            End If
            Return Nothing
        End Using
    End Function

End Class
