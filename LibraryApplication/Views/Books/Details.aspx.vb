Partial Class Views_Books_Details
    Inherits System.Web.UI.Page

    Private myUri As String = HttpContext.Current.Request.Url.AbsoluteUri
    Private book As Integer = myUri.Substring(myUri.IndexOf("/") + 24)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            BookDetails(book)
        End If
    End Sub

    Protected Function VerifyAuthenticatedUserIsBookCreator() As Boolean
        Dim currentUser As New User(Session("UserId"))
        Dim currentBook As New Book(book)

        If currentUser.Id = currentBook.UserId Then
            Return True
        End If

        Return False
    End Function

#Region "Details Functions"
    Private Sub BookDetails(ByVal id As Integer)
        Dim book As New Book(id)
        Dim user As New User(book.UserId)

        lblUsername.Text = user.FullName
        lblTitle.Text = book.Title
        lblDescription.Text = book.Description
        lblGender.Text = book.Gender
    End Sub
#End Region

#Region "Details Events"
    Protected Sub btnEditBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditBook.Click
        If VerifyAuthenticatedUserIsBookCreator() Then
            Response.Redirect(GetRouteUrl("EditBookRoute", New With {.bookId = book}))
        End If
    End Sub
#End Region

End Class
