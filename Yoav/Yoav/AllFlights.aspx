<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllFlights.aspx.cs" Inherits="AllFlights" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>לוח טיסות מלא</title>
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
        <asp:Label ID="Lheader" runat="server" Text="לוח טיסות iFly" Font-Bold="True"></asp:Label></td></tr>
    <tr><td>
        
        <table align="center">
        <tr>
        <td width="100" style="background-color:#003C79;"><asp:Label ID="table1" runat="server" Text="מספר טיסה" ForeColor="White"></asp:Label></td>
        <td width="100" style="background-color:gainsboro;"><asp:Label ID="Label2" runat="server" Text="מוצא"></asp:Label></td>
        <td width="100" style="background-color:#003C79;"><asp:Label ID="Label3" runat="server" Text="יעד" ForeColor="White"></asp:Label></td>
        <td width="100" style="background-color:gainsboro;"><asp:Label ID="Label4" runat="server" Text="תאריך המראה"></asp:Label></td>
        <td width="100" style="background-color:#003C79;"><asp:Label ID="Label5" runat="server" Text="שעת המראה" ForeColor="White"></asp:Label></td>
        <td width="150" style="background-color:gainsboro;"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
        </tr>
        
        </table>
        
        
        <asp:DataList ID="DataListProd" runat="server" CellSpacing="1" DataKeyField="Rnumoffl"
            RepeatColumns="1" Style="background-color: gainsboro" align="center" 
            onitemcommand="DataListProd_ItemCommand">
            <ItemTemplate>
                <table align="center">
                <tr>
                <td width="100"><asp:Label ID="LNumoffl" runat="server" Font-Bold="true" Font-Underline="false" ForeColor="#414247" Text=""><%#DataBinder.Eval(Container.DataItem,"Rnumoffl" )%></asp:Label></td>
                <td width="100"><asp:Label ID="Llocation2" runat="server" Font-Bold="true" Font-Size="1.2em" Text=""><%#DataBinder.Eval(Container.DataItem,"Rlocation" )%></asp:Label></td>
                <td width="100"><asp:Label ID="Ldestenation2" runat="server" Font-Bold="true" Font-Size="1.2em" Text=""><%#DataBinder.Eval(Container.DataItem,"Rdestenation")%></asp:Label></td>
                <td width="100"><asp:Label ID="moreinfo" runat="server" Font-Bold="true" Font-Underline="false" ForeColor="#414247" Text=""><%#DataBinder.Eval(Container.DataItem,"Rdate")%></asp:Label></td>
                <td width="100"><asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Underline="false" ForeColor="#414247" Text=""><%#DataBinder.Eval(Container.DataItem,"Rtime")%></asp:Label>
                <td width="150"><a href='theproduct.aspx?Myflight=<%#DataBinder.Eval(Container.DataItem,"Rnumoffl")%>'>
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Underline="false" ForeColor="#414247" Text="פרטים נוספים כאן"></asp:Label></a>
                </td>
                <td>
                <asp:Button ID="AddtoBasket" runat="server" Text="הוספה לסל" />
                </td>
                    </tr>
                    
                </table>
            </ItemTemplate>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#322C24" />
            <SelectedItemStyle BackColor="#738A9C" ForeColor="#322C24" />
            <AlternatingItemStyle BackColor="#F7F7F7" ForeColor="#322C24" />
            <ItemStyle BackColor="#E7E7FF" ForeColor="#322C24" />
            <HeaderStyle BackColor="#4A3C8C" ForeColor="#322C24" />
        </asp:DataList></td>
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
