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
</asp:Content>
