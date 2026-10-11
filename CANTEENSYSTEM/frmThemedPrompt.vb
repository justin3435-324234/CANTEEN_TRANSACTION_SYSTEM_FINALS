''' <summary>Themed replacement for VB InputBox(): navy/gold dialog with the
''' same prompt/title/default semantics. Returns Nothing on Cancel,
''' otherwise the entered text (untrimmed — callers trim as before).</summary>
Public Class frmThemedPrompt

    Public Sub New(prompt As String, title As String, defaultValue As String)
        InitializeComponent()
        lblPrompt.Text = prompt
        Me.Text = title
        txtValue.Text = If(defaultValue, "")
        txtValue.SelectionStart = txtValue.Text.Length
    End Sub

    Public Shared Function Ask(prompt As String, title As String, Optional defaultValue As String = "") As String
        Using d As New frmThemedPrompt(prompt, title, defaultValue)
            If d.ShowDialog() = DialogResult.OK Then Return d.txtValue.Text
            Return Nothing
        End Using
    End Function

End Class
