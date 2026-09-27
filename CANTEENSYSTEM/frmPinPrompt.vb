Public Class frmPinPrompt

    Public Sub New(prompt As String, title As String)
        InitializeComponent()
        lblPrompt.Text = prompt
        Me.Text = title
    End Sub

    ''' <summary>Masked PIN if OK was pressed, else empty string.</summary>
    Public ReadOnly Property PinIfOK As String
        Get
            If Me.DialogResult = DialogResult.OK Then Return txtPin.Text.Trim()
            Return ""
        End Get
    End Property

    Public ReadOnly Property PinText As String
        Get
            Return txtPin.Text.Trim()
        End Get
    End Property

End Class
