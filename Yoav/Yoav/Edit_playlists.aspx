<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_playlists.aspx.cs" Inherits="Yoav.Edit_playlists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataListPlaylists" runat="server" OnItemCommand="DataListPlaylists_ItemCommand" CssClass="table-hover table-responsive table">
        <HeaderTemplate>
                    <th>Number</th>
                    <th>Name</th>
                    <th>Likes</th>
                    <th>Update</th>
        </HeaderTemplate>
        <ItemTemplate>
                    <td><asp:Label ID="Number" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Playlist_number" )%>'></asp:Label></td>
                    <td><asp:TextBox ID="Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Playlist_name" )%>' ></asp:TextBox></td>
                    <td><asp:Label ID="Likes" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Likes" )%>'></asp:Label></td>
                    <td><asp:Button ID="update1" CommandName="Update_command" runat="server" Text="update" CssClass="btn btn-primary" /></td>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
