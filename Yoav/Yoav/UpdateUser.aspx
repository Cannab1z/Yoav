<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="Yoav.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div class="jumbotron-nobackground" >
            <h1><asp:Label ID="Header" runat="server" Text=""></asp:Label></h1>
        </div>
    </center>
    
    <table class="form-horizontal">

        <tr class="form-group">
            <td class="col-md-6 control-label"><label><asp:Label ID="User_Name" runat="server" Text="Username"></asp:Label></label></td>
            <td class="col-md-6"><asp:TextBox ID="Username" runat="server" Text="" Enabled ="False"></asp:TextBox></td>
        </tr>
        <tr class="form-group">
            <td class="col-md-6 control-label"><label><asp:Label ID="Password_label" runat="server" Text="Password"></asp:Label></label></td>
            <td class="col-md-6"><asp:TextBox ID="User_pass" TextMode="Password" runat="server" ></asp:TextBox></td>
        </tr>
        <tr class="form-group">
            <td class="col-md-6 control-label"><label><asp:Label ID="Repeat_Password_label" runat="server" Text="Repeat Password"></asp:Label></label></td>
            <td class="col-md-6"><asp:TextBox ID="repeat_user_pass" TextMode="Password" runat="server" ></asp:TextBox></td>
        </tr>
        <tr class="form-group">
            <td class="col-md-6 control-label"><label><asp:Label ID="Email_label" runat="server" Text="Email"></asp:Label></label></td>
            <td class="col-md-6"><asp:TextBox ID="Email" runat="server" TextMode="Email" ></asp:TextBox></td>
        </tr>
        <tr class="form-group">
            <td class="col-md-6"></td>
            <td class="col-md-6"><asp:Button ID="Update_user" runat="server" Text="Update" OnClick="Update_Click" CssClass="btn btn-default"/></td>

        </tr>
        
    </table>
    <asp:Label ID="error_label" runat="server"></asp:Label>
</asp:Content>
