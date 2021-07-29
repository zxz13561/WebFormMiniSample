<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

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
                    <asp:Button Text="Add Accounting" ID="btnCreate" runat="server" OnClick="btnCreate_Click"/>
                    <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="false" Width="353px" OnRowDataBound="gvAccountList_RowDataBound" >
                        <Columns>
                            <asp:BoundField HeaderText="標題" DataField="Caption" />
                            <asp:BoundField HeaderText="金額" DataField="Amount" />
                            <asp:TemplateField HeaderText="In/Out">
                                <ItemTemplate>
                                    <asp:Label ID="lblActType" runat="server" />
                                    <asp:Literal ID="ltActType" runat="server" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%#Eval("ID")%>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:PlaceHolder runat="server" ID="plcNoData" Visible="true">
                        <p style="font-family : Arial;color : red;">
                            No data in your Accounting Note.
                        </p>
                    </asp:PlaceHolder>
                 </td>
            </tr>
        </table>
    </form>
</body>
</html>
