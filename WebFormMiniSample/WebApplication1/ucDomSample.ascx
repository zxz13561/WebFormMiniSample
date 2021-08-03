<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDomSample.ascx.cs" Inherits="WebApplication1.ucDomSample" %>
<asp:PlaceHolder runat="server" ID="PlaceHolder">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </asp:PlaceHolder>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/img01.png" />
</asp:PlaceHolder>


