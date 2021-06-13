<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchUsers.aspx.cs" Inherits="Yoav.SearchUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:DataList ID="DataListUsers" runat="server" CssClass="table-hover table-responsive table">
        <HeaderTemplate>
                    <th>Username</th>
                    <th>First Name</th>
                    <th>Last Name</th>
        </HeaderTemplate>
        <ItemTemplate>
                    <td><asp:LinkButton ID="hey" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Username" )%>' CssClass="btn btn-primary" OnClick="Send_Profile"></asp:LinkButton></td>
                    <td><asp:Label ID="First" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FirstName" )%>'></asp:Label></td>
                    <td><asp:Label ID="Last" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LastName" )%>'></asp:Label></td>
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="error_btn" runat="server"></asp:Label>
</asp:Content>
