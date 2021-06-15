<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="new_playlist.aspx.cs" Inherits="Yoav.new_playlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Hello, <asp:Label Text="" runat="server" ID="name" />. fill the form to create a new playlist</h1>
    <br />
    <table>
        <tr>
            <td><asp:Label ID="PL_name" runat="server" Text="Playlist name: "></asp:Label></td>
            <td><asp:TextBox ID="PL_text" runat="server" ></asp:TextBox></td>  
        </tr>
        <tr>
            <td><asp:Button ID="AddPL" runat="server" Text="Add" OnClick="AddPL_Click" CssClass="btn btn-default" /></td>
             <td><input type="reset" class="btn btn-default" /></td>
        </tr>
     </table>

</asp:Content>
