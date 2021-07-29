<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingDetail" %>

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
                    <!--這裡放主要內容-->
                    <table>
                        <tr>
                            <td style="text-align:right">
                                Type : 
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlActType" runat="server">
                                    <asp:ListItem Value="0">支出</asp:ListItem>
                                    <asp:ListItem Value="1">收入</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">
                                Amount : 
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">
                                Caption:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right;">
                                Dese:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"/>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete"/>
                    <br />
                    <asp:Literal Text="" ID="ltlMsg" runat="server" />
                 </td>
            </tr>
        </table>
    </form>
</body>
</html>
