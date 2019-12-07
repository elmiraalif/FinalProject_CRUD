<%@ Page Title="" Language="C#" MasterPageFile="~/LAYOUT.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="n01318198_CRUD_ElmiraAlif.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
        <h2>New Page</h2>
    <div class="formrow">
        <div class="page-title">
            <label>Page Title:</label>
            <asp:TextBox runat="server" ID="page_title" CssClass="input-style"></asp:TextBox>
        </div>
        <div class="add-button">
            <asp:Button runat="server" Text="UPDATE" class="button" OnClick="Update_Page" />
        </div> 
    </div>

    <div class="formrow">
        <asp:TextBox ID="page_body" TextMode="multiline" Columns="35" Rows="27" runat="server" />
    </div>
</asp:Content>
