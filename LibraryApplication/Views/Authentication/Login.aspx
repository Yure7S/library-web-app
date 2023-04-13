<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Views_Authentication_Login" Title="Library - Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container">
        <div class="login-page">
            <div class="form">
                <p class="fw-bold">Login</p>
                <asp:Label ID="lblSuccess" runat="server" CssClass="mb-3" Font-Bold="True" ForeColor="Green" />
                <hr />
                <asp:TextBox runat="server" required="required" type="text" ID="txtUsername" name="username" placeholder="username" MaxLength="50" />
                <asp:TextBox runat="server" required="required" type="text" ID="txtPassword" name="password" placeholder="password" MaxLength="50" />

                <asp:Label ID="lblInvalid" runat="server" CssClass="mb-3" Font-Bold="True" ForeColor="Red" />
                <br />

                <asp:Button ID="btnLogin" runat="server" CssClass="btnLogin mb-3" Text="login" BackColor="#76b852" />
                <p class="message">No have account? <a href="<%: GetRouteUrl("RegisterRoute", Nothing) %>">Register here</a></p>
            </div>
        </div>
    </section>

</asp:Content>
