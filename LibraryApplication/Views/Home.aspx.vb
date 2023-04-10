
Partial Class _Default
    Inherits System.Web.UI.Page

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

#End Region


End Class
