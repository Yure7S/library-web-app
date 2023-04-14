
Imports System.Data
Imports System.Diagnostics

Partial Class Views_Books_Edit
    Inherits System.Web.UI.Page

    Private myUri As String = HttpContext.Current.Request.Url.AbsoluteUri
    Private Property Book As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not VerifyAuthenticatedUserIsBookCreator() Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        Else

            Book = myUri.Substring(myUri.IndexOf("/") + 29)
        End If
    End Sub

    Protected Function VerifyAuthenticatedUserIsBookCreator() As Boolean
        Dim currentUser As New User(Session("UserId"))
        Dim currentBook As New Book(Book)

        If currentUser.Id = currentBook.UserId Then
            Return True
        End If

        Return False
    End Function

#Region "Edit Function"
    Private Function EditBook(ByVal bookId As Integer) As Boolean
        Dim objBook As New Book(bookId)

        Try
            With objBook
                .Title = txtTitle.Text
                .Description = txtDescription.Text
                .Gender = txtGender.Text
                .Save()
            End With
            Session("Success") = "Livro editado com sucesso."
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function
#End Region

#Region "Edit Events"
    Protected Sub btnEditBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditBook.Click
        If EditBook(Book) Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        End If
    End Sub
#End Region

End Class
