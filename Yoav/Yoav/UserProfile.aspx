﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Yoav.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
        <tr><td><asp:Button ID="fdgdfg" runat="server" Text="hey" Visible="true" CssClass="btn btn-default"/></td></tr>
        </table>
        <div class="row">
        <asp:Repeater ID="YoutubeData" runat="server">
            <ItemTemplate>
                    <div class="col-md-2">
                        <div class="embed-responsive embed-responsive-16by9">
                            <iframe  class="embed-responsive-item" src='<%#DataBinder.Eval(Container.DataItem,"link" )%>' allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                         </div>
                        <asp:Label ID="count" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"count" )%>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            <asp:Repeater ID="YoutubeThumbnail" Visible="false" runat="server">
            <ItemTemplate>
                    <div class="col-md-2">
                        <asp:CheckBox ID="checkDel" runat="server"/>
                        <asp:Image ImageUrl='<%#DataBinder.Eval(Container.DataItem,"link")%>' runat="server" />
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            <asp:Button Text="delete" OnClick="Delete_Link" runat="server" />
    </div>
    <asp:Label ID="hey" runat="server"></asp:Label>
    
</asp:Content>
