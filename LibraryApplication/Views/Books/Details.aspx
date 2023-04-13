<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Views_Books_Details" Title="Library - Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <hr />
        <h1>Library - Book Details</h1>
        <hr />
    </div>
    <section class="container" runat="server">
        <div>
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
    </section>

</asp:Content>
