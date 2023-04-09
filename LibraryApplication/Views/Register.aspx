<%@ Page Language="VB" MasterPageFile="Master/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container">
        <div class="login-page">
            <div class="form">
                <form id="form1" runat="server" class="login-form">
                    <p>Library CRUD</p>
                    <hr />
                    <asp:TextBox runat="server" required="required" type="text" id="txtUsername" name="username" placeholder="username" maxlength="50"/>
                    <asp:TextBox runat="server" required="required" type="email" id="txtEmail" name="email" placeholder="e-mail" maxlength="50"/>
                    <asp:TextBox runat="server" required="required" type="password" id="txtPassword" name="password" placeholder="password" maxlength="50"/>
                    <asp:Button ID="btnRegister" runat="server" class="btnRegister" Text="register" />
                    <p class="message">Already registered? <a href="Register.aspx">Login now</a></p>
                </form>
            </div>
        </div>
    </section>

</asp:Content>

