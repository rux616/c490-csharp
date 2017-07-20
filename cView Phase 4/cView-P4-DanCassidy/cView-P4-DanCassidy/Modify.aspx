<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="cView_P4_DanCassidy.Modify" %>

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
                    <td class="auto-style3">MODIFY ITEM</td>
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
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="ddlItemType_SelectedIndexChanged" Visible="False" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSaveChanges" runat="server" OnClick="btnSaveChanges_Click" Text="Save Changes" Visible="False" />
                        <asp:Button ID="btnModify" runat="server" Text="Modify" Visible="False" OnClick="btnModify_Click" />
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
            <asp:MultiView ID="mViewDisplay" runat="server">
                <asp:View ID="viewBusinessChoice" runat="server"> 
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
                <asp:View ID="viewParkChoice" runat="server">
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
                <asp:View ID="viewPublicFacilityChoice" runat="server">
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

        <div>
            <asp:MultiView ID="mViewModifyBasic" runat="server">
                <asp:View ID="viewModifyBasic" runat="server">
                    <table style="width: auto;">
                        <caption style="border-style: solid; border-width: 1px">
                            Basic Information</caption>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblType" runat="server" Text="Type:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtType" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblStreetAddress" runat="server" Text="Street Address:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStreetAddress" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblZip" runat="server" Text="ZIP Code:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtZip" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLatitude" runat="server" Text="Latitude:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLatitude" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLongitude" runat="server" Text="Longitude:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLongitude" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
            <asp:MultiView ID="mViewModifySpecific" runat="server">
                <asp:View ID="viewModifyBusiness" runat="server">
                    <table style="width: auto;">
                        <caption style="border-style: solid; border-width: 1px">
                            Business-Specific Information</caption>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLicenseNumber" runat="server" Text="License Number:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLicenseNumber" runat="server" Width="300px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLicenseIssueDate" runat="server" Text="License Issue Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLicenseIssueDate" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLicenseExpirDate" runat="server" Text="License Expiration Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLicenseExpirDate" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLicenseStatus" runat="server" Text="License Status:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLicenseStatus" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblCouncilDistrict" runat="server" Text="Council District:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCouncilDistrict" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="viewModifyPark" runat="server">
                    <table id="tblPark" style="width: auto;">
                        <caption style="border-style: solid; border-width: 1px">
                            Park-Specific Information</caption>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblFeatureBaseball" runat="server" Text="Number of Baseball Diamonds:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeatureBaseball" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblFeatureBasketball" runat="server" Text="Number of Basketball Courts:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeatureBasketball" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblFeatureGolf" runat="server" Text="Number of Golf Courses:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeatureGolf" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblFeatureLargeMPField" runat="server" Text="Number of Large Multipurpose Fields:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeatureLargeMPField" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblFeatureTennis" runat="server" Text="Number of Tennis Courts:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeatureTennis" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblFeatureVolleyball" runat="server" Text="Number of Volleyball Courts:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeatureVolleyball" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </div>

    </form>
</body>
</html>
