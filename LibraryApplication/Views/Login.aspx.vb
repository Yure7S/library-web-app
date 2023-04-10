Imports System.Data
Imports System.Diagnostics
Imports System.Web.Helpers


Partial Class _Default
    Inherits System.Web.UI.Page

#Region "Login Functions"
    Public Function Login() As Boolean
        Dim connection As New Connection
        Dim dataTable As DataTable
        Dim dataRow As DataRow
        Dim SQL As New StringBuilder

        Dim success As Boolean = False

        SQL.Append(" SELECT *")
        SQL.Append(" FROM Users")
        SQL.Append(" WHERE Username = '" & txtUsername.Text.ToString() & "'")

        dataTable = connection.OpenDataTable(SQL.ToString())

        If dataTable.Rows.Count > 0 Then
            dataRow = dataTable.Rows(0)

            Dim verifyPassword As Boolean = Crypto.VerifyHashedPassword(dataRow("Password").ToString(), txtPassword.Text.ToString())

            If verifyPassword = True Then
                FormsAuthentication.RedirectFromLoginPage(dataRow("username").ToString(), False)
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
            Response.Redirect("~/Views/Books/Home.aspx")
        Else
            lblInvalid.Text = "Invalid Username/Password."
        End If
    End Sub

#End Region

End Class
