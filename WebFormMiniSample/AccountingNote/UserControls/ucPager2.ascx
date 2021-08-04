<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPager2.ascx.cs" Inherits="AccountingNote.UserControls.ucPager2" %>

<div>
    <a href="#" id="aLinkFirst" runat="server">First</a>
    <a href="#" id="aLink1" runat="server">1</a>
    <a href="#" id="aLink2" runat="server">2</a>
    <asp:Literal runat="server" ID="ltlCurrentPage"></asp:Literal>
    <a href="#" id="aLink4" runat="server">4</a>
    <a href="#" id="aLink5" runat="server">5</a>
    <a href="#" id="aLinkLast" runat="server">Last</a>
    <asp:Literal Text="" ID="ltPager" runat="server" />
</div>
