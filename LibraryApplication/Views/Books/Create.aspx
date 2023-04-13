<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Create.aspx.vb" Inherits="Views_Books_Create" Title="Library - Create Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container text-center" runat="server">
        <hr />
        <h1>Library - Create Book</h1>
        <hr />
        <div class="form-group">
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="text" ID="txtTitle" name="title" placeholder="title" MaxLength="255" />
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="text" ID="txtDescription" name="description" placeholder="description" MaxLength="255" />
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="text" ID="txtGender" name="gender" placeholder="gender" MaxLength="255" />
            <asp:TextBox runat="server" required="required" class="form-control mb-3" type="date" ID="dpReleaseDate" name="releaseDate" placeholder="release date" MaxLength="255" />

            <asp:Button ID="btnCreateBook" runat="server" class="btnCreate btn btn-success" Text="create" />
        </div>
    </section>

</asp:Content>
