<script Language="VB" RunAt="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(System.Web.Routing.RouteTable.Routes)
    End Sub

    Private Sub RegisterRoutes(ByVal routes As System.Web.Routing.RouteCollection)
        ' Authentication Routes
        routes.MapPageRoute("LoginRoute", "Users/Login/", "~/Views/Authentication/Login.aspx")
        routes.MapPageRoute("RegisterRoute", "Users/Register/", "~/Views/Authentication/Register.aspx")

        ' Books Routes
        routes.MapPageRoute("HomeRoute", "Books/", "~/Views/Books/Home.aspx")
        routes.MapPageRoute("DetailBookRoute", "Books/{bookId}/", "~/Views/Books/Details.aspx")
        routes.MapPageRoute("CreateBookRoute", "Books/Create/", "~/Views/Books/Create.aspx")
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

</script>
