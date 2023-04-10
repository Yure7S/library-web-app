<%@ Page Language="VB" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="_Default" Title="Library - Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container-fluid text-center" runat="server">

        <hr />
        <h1>Library - CRUD</h1>
        <hr />
        <form id="form1" runat="server">
            <asp:Button ID="btnCreateBook" runat="server" class="btnCreateBook btn btn-success" Text="create book" />
            <asp:Button ID="btnEditBook" runat="server" class="btnCreateBook btn btn-warning" Text="edit book" />
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
                                    <asp:LinkButton ID="lnkExcluirPessoa" runat="server" class="btn btn-social-icon bg-red" CommandName="EXCLUIR" ToolTip="ExcluirPessoa">
                                        <i id="iExcluirPessoa" runat="server" class="fa fa-trash"></i>
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
