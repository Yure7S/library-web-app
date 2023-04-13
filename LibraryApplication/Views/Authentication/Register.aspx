<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Views_Authentication_Register" Title="Library - Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container">
        <div class="login-page">
            <div class="form">
                <p>Library CRUD</p>
                <hr />
                <asp:TextBox runat="server" required="required" type="text" ID="txtFullName" name="text" placeholder="full name" MaxLength="50" />

                <asp:TextBox runat="server" required="required" type="text" ID="txtUsername" name="username" placeholder="username" MaxLength="50" />

                <asp:TextBox runat="server" required="required" type="email" ID="txtEmail" name="email" placeholder="e-mail" MaxLength="50" />

                <asp:TextBox runat="server" required="required" type="password" ID="txtPassword" name="password" placeholder="password" MaxLength="50" />

                <asp:Label runat="server" ID="lblErrorMessage" CssClass="mb-3" Font-Bold="True" ForeColor="Red" />

                <asp:Button ID="btnRegister" runat="server" class="btnRegister" Text="register" BackColor="#76b852" />
                <p class="message">Already registered? <a href="<%: GetRouteUrl("LoginRoute", Nothing) %>">Login now</a></p>D
            </div>
        </div>
    </section>

</asp:Content>
