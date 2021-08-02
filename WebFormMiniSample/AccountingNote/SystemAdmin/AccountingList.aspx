<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


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
                    <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="False" Width="353px" OnRowDataBound="gvAccountList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
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
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

                    <uc1:ucPager runat="server" ID="ucPager" PageSize="10" CurrentPage="1" Url="AccountingList.aspx" />

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
