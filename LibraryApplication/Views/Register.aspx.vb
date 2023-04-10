
Imports System.Activities.Statements

Partial Class _Default
    Inherits Page

#Region "Register Functions"

    Private Function VerifyRegister() As Boolean
        Dim objUser As New User
        Dim exists As Boolean = False

        With objUser.Search(username:=txtUsername.Text)
            If .Rows.Count > 0 Then
                MsgBox("Username already registered.")
                exists = True
            End If
        End With

        With objUser.Search(email:=txtEmail.Text)
            If .Rows.Count > 0 Then
                MsgBox("E-mail already registered.")
                exists = True
            End If
        End With

        objUser = Nothing

        Return exists
    End Function

    Private Sub CleanFields()
        txtUsername.Text = ""
        txtEmail.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Function Save() As Boolean
        Dim objUser As New User(ViewState("Id"))
        Dim created As Boolean = False

        With objUser
            If VerifyRegister() = True Then
                Return False
            End If

            .Username = txtUsername.Text
            .Email = txtEmail.Text
            .Password = txtPassword.Text
            .Save()
        End With

        objUser = Nothing
        Return True
    End Function
#End Region

#Region "Register Events"
    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegister.Click
        If Save() = True Then
            CleanFields()
            Response.Redirect("~/Views/Login.aspx")
        Else
            Response.Redirect("~/Views/Register.aspx")
        End If
    End Sub
#End Region

End Class
