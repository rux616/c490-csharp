<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="cView_P4_DanCassidy.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 250px;
        }

        .auto-style4 {
            width: 300px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: auto; border-spacing: 0px; border-collapse: collapse;">
                <tr>
                    <td class="auto-style3">DELETE ITEM</td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Main.aspx">Main</a></td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Add.aspx">Add Item</a></td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Modify.aspx">Modify Item</a></td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Delete.aspx">Delete Item</a></td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Display.aspx">Display</a></td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Search.aspx">Search</a></td>
                    <td style="border-left-style: solid; border-width: 1px; padding-right: 5px; padding-left: 5px; border-right-style: solid;"><a href="Statistics.aspx">Statistics</a></td>
                </tr>
            </table>
        </div>

        <div>
            <hr />
        </div>
        <div>
            <table style="width: auto; height: auto;">
                <tr>
                    <td class="auto-style3">

                        <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                            <asp:ListItem>Item Type</asp:ListItem>
                            <asp:ListItem>Business</asp:ListItem>
                            <asp:ListItem>Park</asp:ListItem>
                            <asp:ListItem>Public Facility</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" OnClick="btnDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: auto;">
                        <asp:Label ID="lblError" runat="server" Style="word-wrap: break-word;" ForeColor="Red" Text="Error" Visible="False" Width="550px"></asp:Label>
                        <asp:Label ID="lblResult" runat="server" Style="word-wrap: break-word;" Text="Result" Visible="False" Width="550px"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
        <div>

            <asp:SqlDataSource ID="sqlBusiness" runat="server" ConnectionString="<%$ ConnectionStrings:djcassidConnectionString %>" SelectCommand="SELECT [LicenseNumber], [Name], [StreetAddress] FROM [Business]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlPark" runat="server" ConnectionString="<%$ ConnectionStrings:djcassidConnectionString %>" SelectCommand="SELECT [Name], [StreetAddress] FROM [Park]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlPublicFacility" runat="server" ConnectionString="<%$ ConnectionStrings:djcassidConnectionString %>" SelectCommand="SELECT [Name], [StreetAddress] FROM [PublicFacility]"></asp:SqlDataSource>

        </div>
        <div>
            <asp:MultiView ID="mViewData" runat="server">
                <asp:View ID="viewBusiness" runat="server"> 
                    <asp:GridView ID="gViewBusiness" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="LicenseNumber" DataSourceID="sqlBusiness" ForeColor="#333333" GridLines="None" Width="550px" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="LicenseNumber" HeaderText="License Number" ReadOnly="True" SortExpression="LicenseNumber" />
                            <asp:BoundField DataField="Name" HeaderText="Business Name" SortExpression="Name" />
                            <asp:BoundField DataField="StreetAddress" HeaderText="Street Address" SortExpression="StreetAddress" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </asp:View>
                <asp:View ID="viewPark" runat="server">
                    <asp:GridView ID="gViewPark" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Name" DataSourceID="sqlPark" ForeColor="#333333" GridLines="None" Width="550px" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Name" HeaderText="Park Name" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="StreetAddress" HeaderText="Street Address" SortExpression="StreetAddress" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </asp:View>
                <asp:View ID="viewPublicFacility" runat="server">
                    <asp:GridView ID="gViewPublicFacility" runat="server" AllowSorting="True" CellPadding="4" DataSourceID="sqlPublicFacility" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Name" Width="550px" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Name" HeaderText="Public Facility Name" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="StreetAddress" HeaderText="Street Address" SortExpression="StreetAddress" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
