<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowUsers.aspx.cs" Inherits="Yoav.ShowUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:DataList ID="DataListUsers" runat="server" OnItemCommand="DataListUsers_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Birth-Date</th>
                    <th>DELETE</th>
                    <th>UPDATE</th>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table class="table">
                <tr>
                    <td><asp:Label ID="First" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FirstName" )%>'></asp:Label></td>
                    <td><asp:Label ID="Last" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LastName" )%>'></asp:Label></td>
                    <td><asp:Label ID="Username" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Username" )%>'></asp:Label></td>
                    <td><asp:Label ID="Email" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Email" )%>'></asp:Label></td>
                    <td><asp:Label ID="birth" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Birthdate" )%>'></asp:Label></td>
                    <td><asp:Button ID="delete1" runat="server" Text="delete" /></td>
                    <td>update</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table><tr><td><asp:Button ID="Show" runat="server" Text="show users" OnClick="Show_users" /></td></tr></table>
    <asp:Label ID="Delete_help" runat="server"></asp:Label>
    
</asp:Content>
