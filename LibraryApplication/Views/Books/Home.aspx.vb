Imports System.Data
Imports System.Diagnostics

Partial Class _Default
    Inherits Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            LoadGrid()
        End If
    End Sub

#Region "Home Commands"

    Private Sub Logout()
        Try
            FormsAuthentication.SignOut()
            MsgBox("Logout realizado com sucesso.")
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

#End Region

#Region "Home Events"

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogout.Click
        If User.Identity.IsAuthenticated Then
            Logout()
            Response.Redirect("~/Views/Login.aspx")
        End If
    End Sub

    Protected Sub btnCreateBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateBook.Click
        If User.Identity.IsAuthenticated Then
            Response.Redirect("~/Views/Books/Create.aspx")
        End If
    End Sub

    Protected Sub btnEditBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditBook.Click
        If User.Identity.IsAuthenticated Then
            Response.Redirect("~/Views/Books/Edit.aspx")
        End If
    End Sub

#End Region

#Region "Listing Functions"

    Private Sub LoadGrid()
        Dim objBooks As New Book()

        Dim objUser As New User()
        Dim username = User.Identity.Name
        Dim dataTable As DataTable = objUser.Search(username:=username.ToString())
        Dim userId = dataTable.Rows(0)("Id")

        grdBooks.DataSource = objBooks.Search(userId:=userId)
        grdBooks.DataBind()
    End Sub

#End Region

#Region "Listing Events"

#End Region

End Class
