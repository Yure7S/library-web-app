Imports System.Data
Imports System.Diagnostics

Partial Class _Default
    Inherits Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            LoadGrid()
        End If
        lblSuccess.Text = Session("Success")
    End Sub

#Region "Home Commands"

    Private Sub Logout()
        Try
            FormsAuthentication.SignOut()
            Session("Success") = "Logout realizado com sucesso."
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub SearchByName()
        Dim book As New Book()
        Dim dataTable As DataTable

        dataTable = book.Search(title:=txtSearch.Text)

        If dataTable.Rows.Count > 0 Then
            Debug.WriteLine(dataTable.Rows.Count)
        Else
            Debug.WriteLine("nada")
        End If
    End Sub
#End Region

#Region "Home Events"

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogout.Click
        If User.Identity.IsAuthenticated Then
            Logout()
            Response.Redirect(GetRouteUrl("LoginRoute", Nothing))
        End If
    End Sub

    Protected Sub btnCreateBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateBook.Click
        If User.Identity.IsAuthenticated Then
            Response.Redirect(GetRouteUrl("CreateBookRoute", Nothing))
        End If
    End Sub

    Protected Sub btnSearchBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchBook.Click
        If User.Identity.IsAuthenticated Then
            SearchByName()
        End If
    End Sub

#End Region

#Region "Listing Functions"

    Private Sub LoadGrid()
        Dim books As New Book()

        Dim objUser As New User()
        Dim username = User.Identity.Name
        Dim dataTable As DataTable = objUser.Search(username:=username.ToString())
        Dim userId = dataTable.Rows(0)("Id")

        grdBooks.DataSource = books.Search(userId:=userId)
        grdBooks.DataBind()
    End Sub

    Private Sub DeleteBook(ByVal bookId As Integer)
        Dim book As New Book

        If book.Delete(bookId) > 0 Then
            Session("Success") = "Livro deletado com sucesso"
        End If

        LoadGrid()
    End Sub

#End Region

#Region "Listing Events"

    Protected Sub grdBooks_RowCommand(ByVal source As Object, ByVal e As GridViewCommandEventArgs) Handles grdBooks.RowCommand
        Dim book As Integer = grdBooks.DataKeys(e.CommandArgument).Item(0)

        If e.CommandName = "" Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        ElseIf e.CommandName = "DeleteBook" Then
            DeleteBook(book)
        ElseIf e.CommandName = "DetailBook" Then
            Response.Redirect(GetRouteUrl("DetailBookRoute", New With {.bookId = book}))
        End If
    End Sub

    Protected Sub grdBooks_RowDataBound(ByVal source As Object, e As GridViewRowEventArgs) Handles grdBooks.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow
                Dim lnkDeleteBook As New LinkButton
                Dim lnkDetailBook As New LinkButton

                lnkDeleteBook = DirectCast(e.Row.Cells(3).FindControl("lnkDeleteBook"), LinkButton)
                lnkDeleteBook.CommandArgument = e.Row.RowIndex

                lnkDetailBook = DirectCast(e.Row.Cells(3).FindControl("lnkDetailBook"), LinkButton)
                lnkDetailBook.CommandArgument = e.Row.RowIndex

                lnkDeleteBook = Nothing
                lnkDetailBook = Nothing
        End Select
    End Sub

#End Region

End Class