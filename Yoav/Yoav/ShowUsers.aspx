<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowUsers.aspx.cs" Inherits="Yoav.ShowUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataListUsers" runat="server" OnItemCommand="DataListUsers_ItemCommand" CssClass="table-hover table-responsive table">
        <HeaderTemplate>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Password</th>
                    <th>Birth-Date</th>
                    <th>DELETE</th>
                    <th>UPDATE</th>
        </HeaderTemplate>
        <ItemTemplate>
                    <td><asp:Label ID="First" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FirstName" )%>'></asp:Label></td>
                    <td><asp:Label ID="Last" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LastName" )%>'></asp:Label></td>
                    <td><asp:Label ID="Username" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Username" )%>'></asp:Label></td>
                    <td><asp:Label ID="Email" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Email" )%>'></asp:Label></td>
                    <td><asp:Label ID="user_pass" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"user_Password" )%>'></asp:Label></td>
                    <td><asp:Label ID="birth" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Birthdate" )%>'></asp:Label></td>
                    <td><asp:Button ID="delete1" CommandName="Delete_command" runat="server" Text="delete" CssClass="btn btn-primary"/></td>
                    <td><asp:Button ID="update1" CommandName="Update_command" runat="server" Text="update" CssClass="btn btn-primary" /></td>
        </ItemTemplate>
    </asp:DataList>
    <table><tr><td><asp:Button ID="Show" runat="server" Text="show users" OnClick="Show_users" CssClass="btn btn-primary"/></td></tr></table>
    <asp:Label ID="Label_help" runat="server"></asp:Label>
    
</asp:Content>
