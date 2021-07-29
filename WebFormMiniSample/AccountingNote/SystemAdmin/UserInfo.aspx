﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a>
                    <br />
                    <a href="AccountingList.aspx">使用者管理</a>
                </td>
                <td>
                    <table border="0">
                        <tr>
                            <th style="text-align : right">
                                帳號
                            </th>
                            <td>
                                <asp:Literal ID="ltlAcc" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align : right">
                                姓名
                            </th>
                                <td>
                                <asp:Literal ID="ltlName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align : right">
                                E-mail
                            </th>
                                <td>
                                <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnLogout" Text="登出" runat="server" OnClick="btnLogout_Click"/>
                 </td>
            </tr>
        </table>
    </form>
</body>
</html>
