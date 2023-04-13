Imports System.Data
Imports System.Runtime.InteropServices

Partial Class Views_Books_Create
    Inherits Page

#Region "Create Book Functions"

    Private Sub CleanFields()
        txtTitle.Text = ""
        txtDescription.Text = ""
        txtGender.Text = ""
    End Sub

    Public Function CreateBook() As Boolean
        Dim objBook As New Book(ViewState("Id"))
        Dim created As Boolean = True

        Dim objUser As New User()
        Dim username = User.Identity.Name
        Dim dataTable As DataTable = objUser.Search(username:=username.ToString())

        If dataTable.Rows.Count > 0 Then
            Dim dataRow As DataRow = dataTable.Rows(0)
            With objBook
                .UserId = dataRow("Id")
                .Title = txtTitle.Text
                .Description = txtDescription.Text
                .Gender = txtGender.Text
                .Save()
            End With
            Session("Success") = "Livro criado com sucesso."
        End If

        objBook = Nothing
        Return True
    End Function

#End Region

#Region "Create Book Events"

    Protected Sub btnCreateBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateBook.Click
        If CreateBook() = True Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        Else
            CleanFields()
        End If
    End Sub

#End Region

End Class
