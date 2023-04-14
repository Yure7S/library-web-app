<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Master/MasterPage.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Views_Books_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="container text-center" runat="server">
        <hr />
        <h1>Library - Edit Book</h1>
        <hr />
        <div class="form-group">
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="text" ID="txtTitle" name="title" placeholder="title" MaxLength="255" />
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="text" ID="txtDescription" name="description" placeholder="description" MaxLength="255" />
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="text" ID="txtGender" name="gender" placeholder="gender" MaxLength="255" />

            <asp:Button ID="btnEditBook" runat="server" class="btnCreate btn btn-success" Text="create" />
        </div>
    </section>

</asp:Content>

