<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Views_Books_Home" Title="Library - Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container-fluid text-center" runat="server">
        <br />

        <div class="alert alert-success container-sm small w-25 p-3">
            <asp:Label ID="lblSuccess" runat="server" CssClass="mb-3" Font-Bold="True" ForeColor="Green" />
        </div>

        <asp:Button ID="btnCreateBook" runat="server" class="btnCreateBook btn btn-success" Text="create book" />
        <asp:Button ID="btnLogout" runat="server" class="btnLogout btn btn-danger text-end" Text="logout" />

        <hr />
        <br />

        <div class="container">

            <asp:Label id="lblBooks" runat="server"/>

            <asp:GridView ID="grdBooks" runat="server" CssClass="table table-bordered" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="Id">
                <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                <Columns>
                    <asp:BoundField runat="server" DataField="Title" SortExpression="Title" HeaderText="Title" />
                    <asp:BoundField runat="server" DataField="Gender" SortExpression="Gender" HeaderText="Gender" />
                    <asp:BoundField runat="server" DataField="Description" SortExpression="Description" HeaderText="Description" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <div class="btn-group">
                                <asp:LinkButton ID="lnkDeleteBook" runat="server" class="btn btn-social-icon bg-red" CommandName="DeleteBook" ToolTip="DeleteBook">
                                        <p class="btn btn-danger">Delete</p>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkDetailBook" runat="server" class="btn btn-social-icon bg-red" CommandName="DetailBook" ToolTip="DetailBook">
                                        <p class="btn btn-primary">Details</p>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </section>

</asp:Content>
