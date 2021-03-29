<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Yoav.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <table>
        <tr>
            <td><asp:Label ID="User_Name" runat="server" Text="Username"></asp:Label></td>
            <td><asp:TextBox ID="Username" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Password_label" runat="server" Text="Password"></asp:Label></td>
            <td><asp:TextBox ID="user_pass" TextMode="Password" runat="server" ></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Button ID="CheckLogin" runat="server" Text="Login" OnClick="Check_login" /></td>
             <td><input type="reset" /></td>
        </tr>
        
    </table>
    <asp:Label ID="label_error" runat="server"></asp:Label>
    </div>  
</asp:Content>
