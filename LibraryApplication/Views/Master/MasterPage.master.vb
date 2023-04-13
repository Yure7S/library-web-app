Imports System.Data

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub GetSearchParameter()
        Dim book As New Book()
        Dim dataTable As DataTable

        dataTable = book.Search(title:=txtSearch.Text)

        If dataTable.Rows.Count > 0 Then
            Response.Redirect(GetRouteUrl("SearchBookRoute", Nothing) & "?search=" & txtSearch.Text)
        Else
            Session("Success") = "Livro não encontrado."
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        End If
    End Sub

    Protected Sub btnSearchBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchBook.Click
        GetSearchParameter()
    End Sub

End Class

