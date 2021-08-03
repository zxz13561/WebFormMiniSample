<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Src="~/ucTest.ascx" TagPrefix="uc1" TagName="ucTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="Page btn" />
    <uc1:ucTest runat="server" id="ucTest" />
</asp:Content>
