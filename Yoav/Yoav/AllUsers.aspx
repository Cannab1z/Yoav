<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllUsers.aspx.cs" Inherits="AllUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>������ iFly</title>
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
        <asp:Label ID="Lpcard" runat="server" Text="������ iFly" Font-Bold="True"></asp:Label><br />
        <asp:Literal ID="Lintro" runat="server">
         ����� ������ ����� ���� �������� ����� ������� ������ �� �������� ����, ����� ������ �� �������� ������ ����� ��� �����.
         </asp:Literal></td></tr>
    <tr><td>
        
        <table>
        <tr>
        <td width="100" style="background-color:#003C79; height: 18px;"><asp:Label ID="table1" runat="server" Text="�� �����" ForeColor="White"></asp:Label></td>
        <td width="100" style="background-color:gainsboro; height: 18px;"><asp:Label ID="Label2" runat="server" Text="�� ����"></asp:Label></td>
        <td width="100" style="background-color:#003C79; height: 18px;"><asp:Label ID="Label3" runat="server" Text="�� �����" ForeColor="White"></asp:Label></td>
        <td width="100" style="background-color:gainsboro; height: 18px;"><asp:Label ID="Label4" runat="server" Text="���� ������"></asp:Label></td>
        <td width="100" style="background-color:#003C79; height: 18px;"><asp:Label ID="Label5" runat="server" Text="�����" ForeColor="White"></asp:Label></td>
        <td width="70" style="background-color:gainsboro; height: 18px;"><asp:Label ID="Label6" runat="server" Text="����� �����"></asp:Label></td>
        <td width="70" style="background-color:#003C79; height: 18px;"><asp:Label ID="Label1" runat="server" Text="����� �����" ForeColor="White"></asp:Label></td>
        </tr>
            
        
        <asp:Repeater ID="Repeaterofusers" runat="server">
        <ItemTemplate>
        <tr>
        <td width="100"><a href="MyOrders.aspx?THEUSER=<%#DataBinder.Eval(Container.DataItem, "Unickname")%>" style="color:#3c3a3a; font-size:1.1em; "><%#DataBinder.Eval(Container.DataItem, "Unickname")%></a></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Ufirstname")%></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Ulastname")%></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Uaddress")%></td>
        <td width="100"><%#DataBinder.Eval(Container.DataItem, "Upassword")%></td>
        <td width="70"><a href="UpdateUser.aspx?EDITUSER=<%#DataBinder.Eval(Container.DataItem, "Unickname")%>"><img src="img/edit.jpg" border="0"/></a></td>
        <td width="70"><a href="CanceltheUser.aspx?DELUSER=<%#DataBinder.Eval(Container.DataItem, "Unickname")%>"><img src="img/delete.jpg" border="0"/></a></td>
        </tr>     
        </ItemTemplate>
        
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
