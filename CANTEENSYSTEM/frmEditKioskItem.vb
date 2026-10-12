Public Class frmEditKioskItem

    Private qty As Integer = 1
    Private unitPrice As Decimal = 0
    Private maxQty As Integer = 99

    ''' <summary>Chosen quantity (Nothing = cancel, 0 = remove, N = new qty).</summary>
    Public Property ResultQty As Integer?

    Public Sub New(itemName As String, price As Decimal, curQty As Integer, maxStock As Integer)
        InitializeComponent()
        unitPrice = price
        qty = Math.Max(1, curQty)
        maxQty = Math.Max(1, maxStock)
        lblName.Text = itemName
        lblUnit.Text = "₱" & unitPrice.ToString("N2") & " each"
        RefreshQty()
    End Sub

    Private Sub RefreshQty()
        lblQty.Text = qty.ToString()
        lblSub.Text = "₱" & (qty * unitPrice).ToString("N2")
        btnMinus.Enabled = (qty > 1)
        btnPlus.Enabled = (qty < maxQty)
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        If qty > 1 Then qty -= 1
        RefreshQty()
    End Sub

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        If qty < maxQty Then qty += 1
        RefreshQty()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ResultQty = qty
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        ResultQty = 0
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ResultQty = Nothing
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
