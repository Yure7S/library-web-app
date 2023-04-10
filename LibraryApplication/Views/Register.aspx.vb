Partial Class _Default
    Inherits Page

#Region "Register Functions"

    Private Function VerifyRegister() As Boolean
        Dim objUser As New User
        Dim exists As Boolean = False

        If txtPassword.Text.Length < 8 Then
            lblErrorMessage.Text = "Sua senha precisa conter mais de 8 caracteres."
        End If

        With objUser.Search(username:=txtUsername.Text)
            If .Rows.Count > 0 Then
                lblErrorMessage.Text = "Username already registered."
                exists = True
            End If
        End With

        With objUser.Search(email:=txtEmail.Text)
            If .Rows.Count > 0 Then
                lblErrorMessage.Text = "E-mail already registered."
                exists = True
            End If
        End With

        objUser = Nothing

        Return exists
    End Function

    Private Sub CleanFields()
        txtUsername.Text = ""
        txtFullName.Text = ""
        txtEmail.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Function Save() As Boolean
        Dim objUser As New User(ViewState("Id"))
        Dim created As Boolean = True

        With objUser
            If VerifyRegister() = True Then
                Return False
            End If

            .Username = txtUsername.Text
            .FullName = txtFullName.Text
            .Email = txtEmail.Text
            .Password = txtPassword.Text
            .Save()
        End With

        objUser = Nothing
        Session("Success") = "Usuário cadastrado com sucesso."

        Return True
    End Function
#End Region

#Region "Register Events"

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegister.Click
        If Save() = True Then
            CleanFields()
            Response.Redirect("~/Views/Login.aspx")
        End If
    End Sub

#End Region

End Class
