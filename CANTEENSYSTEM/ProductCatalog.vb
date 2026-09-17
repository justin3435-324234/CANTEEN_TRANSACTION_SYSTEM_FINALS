Imports MySql.Data.MySqlClient

' ============================================================
' PHASE 2 — ProductCatalog: single source of truth for the
' sellable menu. Both frmPOS and frmKiosk generate their product
' buttons from GetActiveProducts(), so anything added/edited/
' deactivated in Inventory appears (or disappears) automatically.
' Only products with status='Active' are returned; stock level
' travels with each item so forms can disable out-of-stock ones.
' ============================================================
Public Module ProductCatalog

    Public Class ProductItem
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property CategoryId As Integer
        Public Property CategoryName As String
        Public Property Price As Decimal
        Public Property Stock As Integer

        Public ReadOnly Property IsOutOfStock As Boolean
            Get
                Return Stock <= 0
            End Get
        End Property
    End Class

    Public Function GetActiveProducts() As List(Of ProductItem)
        Dim items As New List(Of ProductItem)
        Try
            Using conn As MySqlConnection = DbHelper.GetConnection()
                conn.Open()
                Dim sql As String =
                    "SELECT p.product_id, p.product_name, p.category_id, c.category_name, p.price, p.stock_quantity " &
                    "FROM products p JOIN categories c ON c.category_id = p.category_id " &
                    "WHERE p.status = 'Active' ORDER BY p.product_name"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr As MySqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim it As New ProductItem With {
                                .ProductId = Convert.ToInt32(rdr("product_id")),
                                .ProductName = rdr("product_name").ToString(),
                                .CategoryId = Convert.ToInt32(rdr("category_id")),
                                .CategoryName = rdr("category_name").ToString(),
                                .Price = Convert.ToDecimal(rdr("price")),
                                .Stock = Convert.ToInt32(rdr("stock_quantity"))
                            }
                            items.Add(it)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("ProductCatalog.GetActiveProducts failed: " & ex.Message)
        End Try
        Return items
    End Function

    ' Category-key match: sidebar buttons use short keys ("MEALS") while
    ' DB names are full ("Ulam / Meals"). Contains-match both directions.
    Public Function MatchesCategory(categoryName As String, filterKey As String) As Boolean
        If String.IsNullOrWhiteSpace(filterKey) OrElse filterKey.Trim().ToUpper() = "ALL" Then Return True
        If String.IsNullOrWhiteSpace(categoryName) Then Return False
        Dim cat As String = categoryName.Trim().ToUpper()
        Dim key As String = filterKey.Trim().ToUpper()
        Return cat.Contains(key) OrElse key.Contains(cat)
    End Function

End Module
