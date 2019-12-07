<%@ Page Title="" Language="C#" MasterPageFile="~/LAYOUT.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="n01318198_CRUD_ElmiraAlif.ListPages" %>
<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">

    <div class="_table" runat="server">
            <h1>Manage Pages</h1>
           <div id="new_page" runat="server">
               <asp:Button runat="server" Text="Create a New Page" class="button" OnClick="NewPage_Click" />
           </div> 
            <div class="list-item">
                <div class="col3">Page Title</div>
                <div class="col3">Date Modified</div>
                <div class="col3last">Action</div>
            </div>
        <div id="pages_result" runat="server"></div>
    </div>
</asp:Content>
