<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Yoav.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <table>
        <tr>
            <td><asp:Label ID="First_Name" runat="server" Text="First Name"></asp:Label></td>
            <td><asp:TextBox ID="FirstName" runat="server" ></asp:TextBox></td>  
        </tr>
        <tr>
            <td><asp:Label ID="Last_Name" runat="server" Text="Last Name"></asp:Label></td>
            <td><asp:TextBox ID="LastName" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="User_Name" runat="server" Text="Username"></asp:Label></td>
            <td><asp:TextBox ID="Username" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="Username_regex" runat="server" ControlToValidate="Username" ErrorMessage="Username must be 3-16 characters, containing only english letters and numbers." ValidationExpression="^[a-zA-Z0-9]{3,16}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Email_label" runat="server" Text="Email"></asp:Label></td>
            <td><asp:TextBox ID="Email" runat="server" TextMode="Email" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Password_label" runat="server" Text="Password"></asp:Label></td>
            <td><asp:TextBox ID="Passowrd" TextMode="Password" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Date" runat="server" Text="Birth Date"></asp:Label></td>
            <td><asp:TextBox ID="datepicker" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Button ID="AddUser" runat="server" Text="Register" OnClick="AddUser_Click" /></td>
             <td><input type="reset" /></td>
        </tr>
    </table>
    </div>  
</asp:Content>
