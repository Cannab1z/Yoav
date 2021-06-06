<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Yoav.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
  <script type="text/javascript">
      $(function () {
          $("#images").sortable({
              placeholder: "vacant",
              update: function (e, ui) {
                  
                  var orderArray = [], wrap = {};
                  $("#images li").each(function (i) {
                      var imgObj = {
                          "id": $(this).attr("id"),
                          "order": i + 1
                      };
                      orderArray.push(imgObj);
                  });
                  wrap.d = orderArray;
                  $.ajax({
                      url: "UserProfile.aspx/UpdateImagesOrder",
                      type: "POST",
                      dataType: "json",
                      data: JSON.stringify(wrap),
                      contentType: "application/json; charset=utf-8",
                      success: function (res) {
                          alert('success!!');
                      },
                      error: function (res) {
                          alert(res.responseText);
                      }
                  });

              }
          });
      });
  </script>
    <h1><asp:Label ID="User_Name" runat="server" Text="">'s Profile</asp:Label></h1>
    <table>
        <tr><td>First Name: <asp:Label ID="First_Name" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Last Name: <asp:Label ID="Last_Name" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Button ID="Add_link" runat="server" Text="Add Video" OnClick="Add_Link" Visible="false" CssClass="btn btn-default"/><td>
        <td><asp:TextBox ID="YoutubeLink" runat="server" Visible="false"></asp:TextBox>
        <asp:RegularExpressionValidator ID="youtube_regex" runat="server" ControlToValidate="YoutubeLink" ErrorMessage="Unvalid youtube link." ValidationExpression="(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?"></asp:RegularExpressionValidator></td>
        <td><asp:Label ID="youtube_link_error" runat="server"></asp:Label></td>
        </tr>
        <tr><td><asp:Button ID="User_update" runat="server" Text="Update User" OnClick="Update_User" Visible="false" CssClass="btn btn-default"/></td></tr>
        <tr><td><asp:Button ID="Link_Edit" runat="server" Text="Edit" OnClick="Edit_Link" Visible="false" CssClass="btn btn-default"/></td></tr>
        <tr><td><asp:Button ID="Edit_Delete" runat="server" OnClick="Checkbox_Visible" Text="select items to delete" CssClass="btn btn-default"/></td></tr>
        </table>
        <div class="row">
        <asp:Repeater ID="YoutubeData" runat="server">
            <ItemTemplate>
                    <div class="col-md-2">
                        <div class="embed-responsive embed-responsive-16by9">
                            <iframe  class="embed-responsive-item" src='<%#DataBinder.Eval(Container.DataItem,"link" )%>' allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                         </div>
                        <!--<asp:Label ID="count" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"count" )%>'></asp:Label>-->
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            <ul id="images">
            <asp:Repeater ID="YoutubeThumbnail" Visible="false" runat="server">
            <ItemTemplate>
                    <div class="col-md-2 ">
                        <li id="<%# DataBinder.Eval(Container.DataItem, "link") %>"  ></li>
                        <asp:CheckBox ID="CheckDelete" runat="server" Visible="false" />
                        <asp:Image ImageUrl='<%#DataBinder.Eval(Container.DataItem,"link")%>' runat="server" ID="img"/>
                        <asp:Label ID="img_number" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"count")%>'></asp:Label>

                    </div>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
    </div>
    <br />
    <asp:Button Text="Delete all selected items" OnClick="Button_Delete" Visible="false" ID="delete_btn"  runat="server" />
    <asp:Label ID="hey" runat="server"></asp:Label>
    
</asp:Content>
