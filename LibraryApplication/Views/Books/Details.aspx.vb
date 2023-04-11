Imports System.Diagnostics

Partial Class Views_Books_Details
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Dim myUri As Uri = HttpContext.Current.Request.Url
            Dim bookId As Integer = HttpUtility.ParseQueryString(myUri.Query).Get("bookId")
            BookDetails(bookId)
        End If
    End Sub

    Private Sub BookDetails(ByVal id As Integer)
        Dim book As New Book(id)
        Dim user As New User(book.UserId)

        lblUsername.Text = user.FullName
        lblTitle.Text = book.Title
        lblDescription.Text = book.Description
        lblGender.Text = book.Gender
    End Sub

End Class
