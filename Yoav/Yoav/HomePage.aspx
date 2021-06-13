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
          <div class="col-md-8">
            <div class="thumbnail">
              <asp:Image ImageUrl="~/homepage_img.png" runat="server" ID="Image1" />
              <div class="caption">
                <h3>IdanKid's Profile</h3>
                <p>Here is one example of rearranging the videos to make one big image</p>
                <p><asp:LinkButton runat="server" ID="idankid" OnClick="Profile_click" Text="Go to Idankid's Profile" CssClass="btn btn-default"></asp:LinkButton></p>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
