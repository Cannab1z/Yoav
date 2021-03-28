<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleAllUsers.aspx.cs" Inherits="AllUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>משתמשי iFly</title>
</head>
<body style="font-size: 0.8em; color: black; font-family: Arial; direction: rtl;">
    <form id="form1" runat="server">
    <div>
    
        <center>
        <table align="center" style="border-right: gainsboro 1px solid; border-top: gainsboro 1px solid; margin: 1px; border-left: gainsboro 1px solid; border-bottom: gainsboro 1px solid">
    <tr>
    <td colspan="3">
    <a href="login.aspx"><img src="img/ifly2.jpg" border="0"></a>
    </td>
    </tr>
    <tr>
     <td>
     
    <table width="100%">
    <tr><td style="text-align: right;">
        <asp:Label ID="Lpcard" runat="server" Text="משתמשי iFly" Font-Bold="True"></asp:Label><br />
        <asp:Literal ID="Lintro" runat="server">
         מתוקף הרשאתך כמנהל באתר באפשרותך לצפות בהזמנות שביצעו כל המשתמשים באתר, עריכת פרטיהם של המשתמשים ומחיקת משתמש לפי הצורך.
         </asp:Literal></td></tr>
    <tr><td>
        
        <table border=1>
        <tr>
 <td width="100" style="background-color:#003C79; height: 18px;">
 <asp:Label ID="Label3" runat="server" Text="שם פרטי" ForeColor="White">
 </asp:Label></td>
        <td width="100" style="background-color:gainsboro; height: 18px;"><asp:Label ID="Label4" runat="server" Text="שם משפחה"></asp:Label></td>
        <td width="100" style="background-color:#003C79; height: 18px;"><asp:Label ID="Label5" runat="server" Text="איזור מגורים" ForeColor="White"></asp:Label></td>
        <td width="70" style="background-color:gainsboro; height: 18px;"><asp:Label ID="Label6" runat="server" Text="סיסמא"></asp:Label></td>
          </tr>
            <asp:Repeater ID="Repeater1" runat="server">
            
            </asp:Repeater>
        
        <asp:Repeater ID="Repeaterofusers" runat="server">
        <ItemTemplate>
        <tr>
         <td width="100"><%#DataBinder.Eval(Container.DataItem, "Ulastname")%></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Ufirstname")%></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Uaddress")%></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Upassword")%></td>
         </tr>     
        </ItemTemplate>
        <AlternatingItemTemplate>
         <tr>
         <td width="100"  style="background-color:powderblue;"><%#DataBinder.Eval(Container.DataItem, "Ulastname")%></td>
        <td width="100" style="background-color:powderblue;"><%#DataBinder.Eval(Container.DataItem, "Ufirstname")%></td>
        <td width="100" style="background-color:powderblue;"><%#DataBinder.Eval(Container.DataItem, "Uaddress")%></td>
        <td width="100" style="background-color:powderblue;"><%#DataBinder.Eval(Container.DataItem, "Upassword")%></td>
         </tr>     
        
        </AlternatingItemTemplate>
        
        
        </asp:Repeater>
        
        
        </table>
        
        </td>
        </tr>
    </table>
     
     
     </td>
     </tr>
     </table>
     </center>
    
    </div>
    </form>
</body>
</html>
