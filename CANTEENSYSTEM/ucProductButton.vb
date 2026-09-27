Public Class ucProductButton

    Public Event CardClicked As EventHandler

    Private _boundItem As ProductCatalog.ProductItem

    Public ReadOnly Property BoundItem As ProductCatalog.ProductItem
        Get
            Return _boundItem
        End Get
    End Property

    Public Property ProductId As Integer = 0
    Public Property ItemName As String = ""
    Public Property Price As Decimal = 0
    Public Property Stock As Integer = 0

    Public ReadOnly Property IsOutOfStock As Boolean
        Get
            Return Stock <= 0
        End Get
    End Property

    ''' <summary>Design-time only preview text for the card (settable in the
    ''' Properties window). Bind() overwrites it at runtime.</summary>
    Public Property PreviewText As String
        Get
            Return btnCard.Text
        End Get
        Set(value As String)
            btnCard.Text = value
        End Set
    End Property

    ''' <summary>Design-time only enabled-state preview (forwards to the
    ''' inner card button). Bind() overwrites it at runtime.</summary>
    Public Property PreviewEnabled As Boolean
        Get
            Return btnCard.Enabled
        End Get
        Set(value As Boolean)
            btnCard.Enabled = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>Bind a catalog item to this card (Designer template + runtime use).</summary>
    Public Sub Bind(item As ProductCatalog.ProductItem)
        _boundItem = item
        If item Is Nothing Then Exit Sub
        ProductId = item.ProductId
        ItemName = item.ProductName
        Price = item.Price
        Stock = item.Stock
        Me.Name = "dynProd_" & item.ProductId
        Me.Tag = item
        If item.IsOutOfStock Then
            btnCard.Text = item.ProductName & vbCrLf & "₱" & item.Price.ToString("N2") & vbCrLf & "(OUT OF STOCK)"
            btnCard.Enabled = False
        Else
            btnCard.Text = item.ProductName & vbCrLf & "₱" & item.Price.ToString("N2")
            btnCard.Enabled = True
        End If
    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        RaiseEvent CardClicked(Me, EventArgs.Empty)
    End Sub

End Class
