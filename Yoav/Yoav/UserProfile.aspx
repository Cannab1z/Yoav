<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Yoav.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
  <script type="text/javascript">
      $(function () {
          $("#images").sortable();
          $('#Save_ajax').click(function () {

              var orderArray = [], wrap = {};
              $("#images li").each(function (i) {
                  var imgObj = {
                      "id": $(this).data("id"),
                      "order": i + 1,
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
                      res;
                  },
                  error: function (res) {
                      res;
                  }
              });

          });
      });
  </script>
    <style>
        .disabled{
    pointer-events:none;
    opacity:0;
}
        .hey {
            padding-right:0;
            padding-left:0;
        }
        .pad {
            padding-bottom:10px;
            padding-top:10px;
        }
        .transparent {
            display: none;
        }
    </style>
    <h1><asp:Label ID="User_Name" runat="server" Text="">'s Profile</asp:Label></h1>
    <table>
        <tr><td>First Name: <asp:Label ID="First_Name" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Last Name: <asp:Label ID="Last_Name" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Button ID="Add_link" runat="server" Text="Add Video" OnClick="Add_Link" Visible="false" CssClass="btn btn-default"/><td>
        <td><asp:TextBox ID="YoutubeLink" runat="server" Visible="false"></asp:TextBox>
        <asp:RegularExpressionValidator ID="youtube_regex" runat="server" ControlToValidate="YoutubeLink" ErrorMessage="Unvalid youtube link." ValidationExpression="(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?"></asp:RegularExpressionValidator></td>
        <td><asp:Label ID="youtube_link_error" runat="server"></asp:Label></td>
        </tr>
        <tr><td><asp:Button ID="Add_playlist" runat="server" Text="Add Playlist" OnClick="Add_playlist_click" Visible="false" CssClass="btn btn-default"/><td>
    </table>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Currently viewing playlist number: "></asp:Label><asp:Label ID="Current" runat="server" Text="1"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Playlist name: "></asp:Label><asp:Label ID="PL_name" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Playlist likes: "></asp:Label><asp:Label ID="PL_likes" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Copy_playlist" runat="server" OnClick="Copy_PL" Visible="true" Text="Add This Playlist To Your Profile" CssClass="btn btn-default"/>
    <br />
    <br />
    <asp:Button ID="Delete_playlist" runat="server" OnClick="Delete_PL" Visible="false" Text="Delete This Playlist" CssClass="btn btn-danger"/>
    <asp:Button ID="Like" runat="server" OnClick="Like_PL" Visible="true" Text="Like This Playlst" CssClass="btn btn-success"/><asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />

    <asp:DataList ID="Playlist_lists" OnItemCommand="Playlist_ItemCommand" runat="server" RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Button ID="number" Text='<%#DataBinder.Eval(Container.DataItem,"number" )%>' runat="server" CommandName="Click" CssClass="btn btn-default" />
        </ItemTemplate>
    </asp:DataList>
    <br />
    <div class="row">
        <div class="col-md-2"><asp:Button ID="User_update" runat="server" Text="Update Profile" OnClick="Update_User" Visible="false" CssClass="btn btn-default"/></div>
        <div class="col-md-2"><asp:Button ID="Link_Edit" runat="server" Text="Edit Images" OnClick="Edit_Link" Visible="false" CssClass="btn btn-default"/></div>
        <div class="col-md-2"><asp:Button ID="Edit_Delete" runat="server" OnClick="Checkbox_Visible" Visible="false" Text="Select Items To Delete" CssClass="btn btn-default"/></div>
    </div>
    <br />
        <div class="row pad">
        <asp:Repeater ID="YoutubeData" runat="server">
            <ItemTemplate>
                    <div class="col-md-2">
                        <div class="embed-responsive embed-responsive-16by9">
                            <iframe  class="embed-responsive-item" src='<%#DataBinder.Eval(Container.DataItem,"link" )%>' allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                         </div>
                        <!--<asp:Label ID="count" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"count" )%>'></asp:Label>-->
                    </div>
                <%# (Container.ItemIndex + 1) % 6 == 0 ? "</div><div class='row pad'>" : string.Empty%>
            </ItemTemplate>
        </asp:Repeater>
            </div>
    <div class="row">
            <div id="images">
            <asp:Repeater ID="YoutubeThumbnail" Visible="false" runat="server">
            <ItemTemplate>
                    <div class="col-md-2 ">
                        <div class="jq">
                            <li data-id='<%# DataBinder.Eval(Container.DataItem, "link") %>' class="disabled mark"  ><ul data-id='<%#DataBinder.Eval(Container.DataItem,"count")%>'></ul></li>
                            <asp:CheckBox ID="CheckDelete" runat="server" Visible="false" />
                            <asp:Image ImageUrl='<%#DataBinder.Eval(Container.DataItem,"link")%>' runat="server" ID="img" CssClass="hey" Height="100px" Width="150px"/>
                            <asp:Label ID="img_number" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"count")%>'></asp:Label>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>
    <br />
    <asp:Button Text="Delete all selected items" OnClick="Button_Delete" Visible="false" ID="delete_btn"  runat="server" CssClass="btn btn-default" />
    <input type="button" value="Save Edit" id="Save_ajax" onClick="window.location.href=window.location.href" class="btn btn-default" />
</asp:Content>
