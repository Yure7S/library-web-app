<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="_Default" Title="Library - Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container-fluid text-center" runat="server">

        <hr />
        <h1>Library - CRUD</h1>
        <form id="form1" runat="server">

            <div class="container">
                <asp:TextBox runat="server" required="required" type="text" ID="txtSearch" name="search" CssClass="form-control mr-sm-2" placeholder="search" MaxLength="50" />
                <asp:Button ID="btnSearchBook" runat="server" class="btn btn-outline-success my-2 my-sm-0" Text="search book" />
            </div>
            <br />

            <asp:Label ID="lblSuccess" runat="server" CssClass="mb-3" Font-Bold="True" ForeColor="Green" />

            <hr />

            <asp:Button ID="btnCreateBook" runat="server" class="btnCreateBook btn btn-success" Text="create book" />
            <asp:Button ID="btnLogout" runat="server" class="btnLogout btn btn-danger" Text="logout" />

            <br />
            <hr />
            <br />

            <div class="container">
                <asp:GridView ID="grdBooks" runat="server" CssClass="table table-bordered" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="Id">
                    <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                    <Columns>
                        <asp:BoundField runat="server" DataField="Title" SortExpression="Title" HeaderText="Title" />
                        <asp:BoundField runat="server" DataField="Gender" SortExpression="Gender" HeaderText="Gender" />
                        <asp:BoundField runat="server" DataField="Description" SortExpression="Description" HeaderText="Description" />
                        <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
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
        </form>

    </section>

</asp:Content>
