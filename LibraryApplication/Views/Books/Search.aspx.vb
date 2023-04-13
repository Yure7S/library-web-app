Imports System.Data
Imports System.Diagnostics

Partial Class Views_Books_Search
    Inherits Page

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Dim myUri As Uri = HttpContext.Current.Request.Url
            Dim searchParameter As String = HttpUtility.ParseQueryString(myUri.Query).Get("search")
            lblSearch.Text = searchParameter
        End If
    End Sub

    Protected Function SearchResult(ByVal parameter As String) As DataRowCollection
        Dim book As New Book()
        Dim datatable As DataTable
        datatable = book.Search(title:=parameter)
        Return datatable.Rows
    End Function

End Class
