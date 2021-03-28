<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertUser.aspx.cs" Inherits="InsertUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
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
            <td><asp:TextBox ID="Username" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Password_label" runat="server" Text="Password"></asp:Label></td>
            <td><asp:TextBox ID="Passowrd" TextMode="Password" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Date" runat="server" Text="Age"></asp:Label></td>
            <td><asp:Calendar ID="Age" runat="server"></asp:Calendar></td>
        </tr>
         <tr>
            <td><asp:Button ID="AddUser" runat="server" Text="הרשמה" OnClick="AddUser_Click" /></td>
             <td><input type="reset" /></td>
        </tr>
    </table>
    </div>  
        
    </form>
</body>
</html>
