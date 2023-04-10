<%@ Page Language="VB" MasterPageFile="Master/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="_Default" Title="Library - Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container-fluid text-center" runat="server">
        <div class="card">
            <hr />
            <form id="form1" runat="server">
                <asp:Button ID="btnLogout" runat="server" class="btnLogout btn btn-primary" Text="logout" />
            </form>
        </div>
    </section>

</asp:Content>
