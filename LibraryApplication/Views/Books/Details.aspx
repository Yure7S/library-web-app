<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Views_Books_Details" Title="Library - Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <br />
        <h1>Book Details - "<%: lblTitle.Text %>"</h1>
        <hr />
    </div>
    <section class="container" runat="server">
        <div class="mb-3">
            <br />
            <label class="form-label">Created By:</label>
            <asp:Label runat="server" ID="lblUsername" />
            <br />
            <label class="form-label">Title:</label>
            <asp:Label runat="server" ID="lblTitle" />
            <br />
            <label class="form-label">Description:</label>
            <asp:Label runat="server" ID="lblDescription" />
            <br />
            <label class="form-label">Gender:</label>
            <asp:Label runat="server" ID="lblGender" />
            <br />
        </div>

        <% If VerifyAuthenticatedUserIsBookCreator() Then %>

        <asp:LinkButton ID="btnEditBook" runat="server" CssClass="btn btn-primary" Text="Edit Book" />

        <% End If %>
    </section>

</asp:Content>
