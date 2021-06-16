<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Yoav.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background:transparent !important">
        <h1>YoutubePlaylists</h1>
        <p>Welcome to the website that create your youtube playlists and gives the users their creativity freedom</p>
         <div class="form-group navbar-form navbar-left">
        <asp:TextBox runat="server" TextMode="Search" placeholder="Search for Profiles" CssClass="form-control" ID="Search"></asp:TextBox>
        <asp:LinkButton CssClass="btn btn-primary" Text="Search"  runat="server" ID="Search_btn" OnClick="Search_click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span></asp:LinkButton>
        </div>
    </div>

    <div class="row">
    <asp:DataList ID="DataListLikes" runat="server" CssClass="table-hover table-responsive table" RepeatDirection="Horizontal" OnItemCommand="DataListLikes_ItemCommand">
        <ItemTemplate>
               <div class="panel panel-info">
                   <div class="panel-body">
                       <h3><asp:Label ID="User" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Username" )%>'></asp:Label></h3>
                   </div>
                    <div class="panel-footer">
                        <p>Playlist's Name: <asp:Label ID="PL_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Playlist_name" )%>'></asp:Label></p>
                        <p>Playlist Number: <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Playlist_number" )%>'></asp:Label></p>
                        <p>Playlist Likes: <asp:Label ID="PL_likes" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Likes" )%>'></asp:Label></p>
                        <p><asp:LinkButton runat="server" ID="profile" CommandName="Profile" Text="Go to Profile" CssClass="btn btn-info"></asp:LinkButton></p>
                    </div>
              </div>
        </ItemTemplate>
    </asp:DataList>
        </div>
</asp:Content>
