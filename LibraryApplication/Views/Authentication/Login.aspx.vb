Imports System.Data
Imports System.Web.Helpers


Partial Class Views_Authentication_Login
    Inherits Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSuccess.Text = Session("Success")
    End Sub

#Region "Login Functions"
    Public Function Login() As Boolean
        Dim dataTable As DataTable
        Dim dataRow As DataRow
        Dim user As New User
        Dim success As Boolean = False

        dataTable = user.Search(username:=txtUsername.Text.ToString())

        If dataTable.Rows.Count > 0 Then
            dataRow = dataTable.Rows(0)

            Dim verifyPassword As Boolean = Crypto.VerifyHashedPassword(dataRow("Password").ToString(), txtPassword.Text.ToString())

            If verifyPassword = True Then
                FormsAuthentication.RedirectFromLoginPage(dataRow("username").ToString(), False)
                Session("Success") = "Login realizado com sucesso."
                success = True
                Return success
            End If
        End If

        Return success
    End Function

#End Region

#Region "Login Events"

    Protected Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Login() = True Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        Else
            lblInvalid.Text = "Invalid Username/Password."
        End If
    End Sub

#End Region

End Class
