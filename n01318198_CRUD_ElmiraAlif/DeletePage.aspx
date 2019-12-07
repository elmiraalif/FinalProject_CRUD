<%@ Page Title="" Language="C#" MasterPageFile="~/LAYOUT.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="n01318198_CRUD_ElmiraAlif.DeletePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">

<p>Are you sure you want to remove this page?</p>
<ASP:Button OnClick="Delete_Page" Text="YES" CssClass="button" runat="server"/>   
<ASP:Button OnClick="Back_To_List" Text="NO" CssClass="button-cancel" runat="server"/>   

</asp:Content>
