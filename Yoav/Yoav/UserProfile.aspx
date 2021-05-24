<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Yoav.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label ID="User_Name" runat="server" Text="">'s Profile</asp:Label></h1>
    <table>
        <tr><td>First Name: <asp:Label ID="First_Name" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Last Name: <asp:Label ID="Last_Name" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Button ID="Add_link" runat="server" Text="Add Video" OnClick="Add_Link" Visible="false" CssClass="btn btn-default"/><td>
        <td><asp:TextBox ID="YoutubeLink" runat="server" Visible="false" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="youtube_regex" runat="server" ControlToValidate="YoutubeLink" ErrorMessage="Unvalid youtube link." ValidationExpression="(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?"></asp:RegularExpressionValidator></td></tr>
        <tr><td><asp:Button ID="User_update" runat="server" Text="Update User" OnClick="Update_User" Visible="false" CssClass="btn btn-default"/></td></tr>

        <asp:Repeater ID="YoutubeData" runat="server">
            <ItemTemplate>
                <object width="480" height="385"><param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "Link") %>'></param>
                <param name="allowFullScreen" value="true"></param>
                <param name="allowscriptaccess" value="always"></param>
                <embed src='<%#DataBinder.Eval(Container.DataItem, "Link") %>' type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="480" height="385">
                </embed>
                </object>
            <br />    
            </ItemTemplate>
    </asp:Repeater>

    </table>
    
    
</asp:Content>
