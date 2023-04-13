<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Master/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Views_Books_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="text-center">
        <hr />
        <h1>Library - Search "<asp:Label ID="lblSearch" runat="server" />"</h1>
        <hr />
    </div>

    <section class="container" runat="server">
            <div>

                <%
                    Dim myUri As Uri = HttpContext.Current.Request.Url
                    Dim searchParameter As String = HttpUtility.ParseQueryString(myUri.Query).Get("search")

                    For Each item As System.Data.DataRow In SearchResult(searchParameter)
                        Dim detailUrl As String = GetRouteUrl("DetailBookRoute", New With {.bookId = item("Id")})
                        Dim bookTitle As New StringBuilder
                %>
                <h3>
                    <a href="<%: detailUrl %>">
                        <%: item("title") %>
                    </a>
                </h3>
                <%
                    Next
                %>

            </div>
    </section>

</asp:Content>

