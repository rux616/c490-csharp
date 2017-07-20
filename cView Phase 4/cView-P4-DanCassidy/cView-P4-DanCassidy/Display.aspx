<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="cView_P4_DanCassidy.Display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: auto; border-spacing: 0px; border-collapse: collapse;">
                <tr>
                    <td class="auto-style3">DISPLAY</td>
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
            <table style="width: auto;">
                <tr>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                            <asp:ListItem>Item Type</asp:ListItem>
                            <asp:ListItem>Business</asp:ListItem>
                            <asp:ListItem>Park</asp:ListItem>
                            <asp:ListItem>Public Facility</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <asp:SqlDataSource ID="sqlBusiness" runat="server" ConnectionString="<%$ ConnectionStrings:djcassidConnectionString %>" SelectCommand="SELECT * FROM [Business]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlPark" runat="server" ConnectionString="<%$ ConnectionStrings:djcassidConnectionString %>" SelectCommand="SELECT * FROM [Park]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlPublicFacility" runat="server" ConnectionString="<%$ ConnectionStrings:djcassidConnectionString %>" SelectCommand="SELECT * FROM [PublicFacility]"></asp:SqlDataSource>
        </div>

        <div>
            <asp:MultiView ID="mViewData" runat="server">
                <asp:View ID="viewBusiness" runat="server">
                    <asp:GridView ID="gViewBusiness" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="LicenseNumber" DataSourceID="sqlBusiness" ForeColor="#333333" GridLines="None" AllowSorting="True" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="LicenseNumber" HeaderText="License Number" ReadOnly="True" SortExpression="LicenseNumber" />
                            <asp:BoundField DataField="Name" HeaderText="Business Name" SortExpression="Name" />
                            <asp:BoundField DataField="Type" HeaderText="Business Type" SortExpression="Type" />
                            <asp:BoundField DataField="StreetAddress" HeaderText="Street Address" SortExpression="StreetAddress" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                            <asp:BoundField DataField="Zip" HeaderText="ZIP Code" SortExpression="Zip" />
                            <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                            <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone Number" SortExpression="Phone" />
                            <asp:BoundField DataField="LicenseIssueDate" HeaderText="License Issue Date" SortExpression="LicenseIssueDate" DataFormatString="{0:d}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LicenseExpirDate" HeaderText="License Expiration Date" SortExpression="LicenseExpirDate" DataFormatString="{0:d}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LicenseStatus" HeaderText="License Status" SortExpression="LicenseStatus">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CouncilDistrict" HeaderText="Council District" SortExpression="CouncilDistrict" />
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
                    <asp:GridView ID="gViewPark" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Name" DataSourceID="sqlPark" ForeColor="#333333" GridLines="None" AllowSorting="True" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Park Name" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="Type" HeaderText="Park Type" SortExpression="Type" />
                            <asp:BoundField DataField="StreetAddress" HeaderText="Street Address" SortExpression="StreetAddress" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                            <asp:BoundField DataField="Zip" HeaderText="ZIP Code" SortExpression="Zip" />
                            <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                            <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone Number" SortExpression="Phone" />
                            <asp:BoundField DataField="FeatureBaseball" HeaderText="Number of Baseball Diamonds" SortExpression="FeatureBaseball">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeatureBasketball" HeaderText="Number of Basketball Courts" SortExpression="FeatureBasketball">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeatureGolf" HeaderText="Number of Golf Courses" SortExpression="FeatureGolf">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeatureLargeMPField" HeaderText="Number of Large Multipurpose Fields" SortExpression="FeatureLargeMPField">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeatureTennis" HeaderText="Number of Tennis Courts" SortExpression="FeatureTennis">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeatureVolleyball" HeaderText="Number of Volleyball Courts" SortExpression="FeatureVolleyball">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
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
                    <asp:GridView ID="gViewPublicFacility" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Name" DataSourceID="sqlPublicFacility" ForeColor="#333333" GridLines="None" AllowSorting="True" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                            <asp:BoundField DataField="StreetAddress" HeaderText="StreetAddress" SortExpression="StreetAddress" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                            <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                            <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                            <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
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
