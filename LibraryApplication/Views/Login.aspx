<%@ Page Language="VB" MasterPageFile="Master/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="_Default" Title="Library - Login"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container">
        <div class="login-page">
            <div class="form">
                <form id="form1" runat="server" class="login-form">
                    <p>Library CRUD</p>
                    <hr />
                    <asp:TextBox runat="server" required="required" type="text" ID="txtUsername" name="username" placeholder="username" MaxLength="50" />
                    <asp:TextBox runat="server" required="required" type="text" ID="txtPassword" name="password" placeholder="password" MaxLength="50" />

                    <asp:Label ID="lblInvalid" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>

                    <asp:Button ID="btnLogin" runat="server" class="btnLogin" Text="login" BackColor="#76b852" />
                    <p class="message">No have account? <a href="Register.aspx">Register here</a></p>
                </form>
            </div>
        </div>
    </section>

</asp:Content>
