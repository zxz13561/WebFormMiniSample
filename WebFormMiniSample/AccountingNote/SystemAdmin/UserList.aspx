﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnCreate" Text="text" runat="server" />
    <asp:GridView runat="server" ID="GridView1"></asp:GridView>
    <uc1:ucPager runat="server" id="ucPager" />
</asp:Content>
