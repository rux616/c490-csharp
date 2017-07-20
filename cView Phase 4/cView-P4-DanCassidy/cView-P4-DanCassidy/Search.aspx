<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="cView_P4_DanCassidy.Search" %>

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
                    <td class="auto-style3">SEARCH</td>
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
            <table style="width:auto; height: auto;">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                            <asp:ListItem>Item Type</asp:ListItem>
                            <asp:ListItem>Business</asp:ListItem>
                            <asp:ListItem>Park</asp:ListItem>
                            <asp:ListItem>Public Facility</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlBusiness" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBusiness_SelectedIndexChanged" Visible="False">
                            <asp:ListItem>Business Fields</asp:ListItem>
                            <asp:ListItem>Name</asp:ListItem>
                            <asp:ListItem>Type</asp:ListItem>
                            <asp:ListItem>Street Address</asp:ListItem>
                            <asp:ListItem>City</asp:ListItem>
                            <asp:ListItem>State</asp:ListItem>
                            <asp:ListItem>ZIP Code</asp:ListItem>
                            <asp:ListItem>Latitude</asp:ListItem>
                            <asp:ListItem>Longitude</asp:ListItem>
                            <asp:ListItem>Phone Number</asp:ListItem>
                            <asp:ListItem>License Number</asp:ListItem>
                            <asp:ListItem>License Issue Date</asp:ListItem>
                            <asp:ListItem>License Expiration Date</asp:ListItem>
                            <asp:ListItem>License Status</asp:ListItem>
                            <asp:ListItem>Council District</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlPark" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPark_SelectedIndexChanged" Visible="False">
                            <asp:ListItem>Park Fields</asp:ListItem>
                            <asp:ListItem>Name</asp:ListItem>
                            <asp:ListItem>Type</asp:ListItem>
                            <asp:ListItem>Street Address</asp:ListItem>
                            <asp:ListItem>City</asp:ListItem>
                            <asp:ListItem>State</asp:ListItem>
                            <asp:ListItem>ZIP Code</asp:ListItem>
                            <asp:ListItem>Latitude</asp:ListItem>
                            <asp:ListItem>Longitude</asp:ListItem>
                            <asp:ListItem>Phone Number</asp:ListItem>
                            <asp:ListItem># of Baseball Diamonds</asp:ListItem>
                            <asp:ListItem># of Basketball Courts</asp:ListItem>
                            <asp:ListItem># of Golf Courses</asp:ListItem>
                            <asp:ListItem># of Large Multipurpose Fields</asp:ListItem>
                            <asp:ListItem># of Tennis Courts</asp:ListItem>
                            <asp:ListItem># of Volleyball Courts</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlPublicFacility" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPublicFacility_SelectedIndexChanged" Visible="False">
                            <asp:ListItem>Public Facility Fields</asp:ListItem>
                            <asp:ListItem>Name</asp:ListItem>
                            <asp:ListItem>Type</asp:ListItem>
                            <asp:ListItem>Street Address</asp:ListItem>
                            <asp:ListItem>City</asp:ListItem>
                            <asp:ListItem>State</asp:ListItem>
                            <asp:ListItem>ZIP Code</asp:ListItem>
                            <asp:ListItem>Latitude</asp:ListItem>
                            <asp:ListItem>Longitude</asp:ListItem>
                            <asp:ListItem>Phone Number</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlComparatorsStrings" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlComparatorsStrings_SelectedIndexChanged" Visible="False">
                            <asp:ListItem>Available Comparisons</asp:ListItem>
                            <asp:ListItem>Contains</asp:ListItem>
                            <asp:ListItem>Does Not Contain</asp:ListItem>
                            <asp:ListItem>Is Equal To</asp:ListItem>
                            <asp:ListItem>Is Not Equal To</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlComparatorsNotStrings" runat="server" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="ddlComparatorsNotStrings_SelectedIndexChanged">
                            <asp:ListItem>Available Comparisons</asp:ListItem>
                            <asp:ListItem>Contains</asp:ListItem>
                            <asp:ListItem>Does Not Contain</asp:ListItem>
                            <asp:ListItem>Is Equal To</asp:ListItem>
                            <asp:ListItem>Is Not Equal To</asp:ListItem>
                            <asp:ListItem>Is Greater Than</asp:ListItem>
                            <asp:ListItem>Is Less Than</asp:ListItem>
                            <asp:ListItem>Is Greater Than or Equal To</asp:ListItem>
                            <asp:ListItem>Is Less Than or Equal To</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="height: auto">
                        <asp:TextBox ID="txtSearch" runat="server" Visible="False" Width="525px"></asp:TextBox>
                    </td>
                    <td style="height: auto">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Visible="False" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="height: auto">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
                        <asp:Label ID="lblResult" runat="server" Text="Result" Visible="False"></asp:Label>
                    </td>
                    <td style="height: auto">&nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="cView_P4_DanCassidy.CViewDataEntities" EntityTypeName="" TableName="Businesses" Where="Name == @Name &amp;&amp; Type != @Type &amp;&amp; StreetAddress &gt; @StreetAddress &amp;&amp; City &gt;= @City &amp;&amp; State &lt; @State &amp;&amp; Zip &lt;= @Zip &amp;&amp; Latitude == @Latitude &amp;&amp; LicenseIssueDate == @LicenseIssueDate">
                <WhereParameters>
                    <asp:ControlParameter ControlID="txtSearch" Name="Name" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSearch" Name="Type" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSearch" Name="StreetAddress" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSearch" Name="City" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSearch" Name="State" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSearch" Name="Zip" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSearch" Name="Latitude" PropertyName="Text" Type="Decimal" />
                    <asp:ControlParameter ControlID="txtSearch" Name="LicenseIssueDate" PropertyName="Text" Type="DateTime" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <div>

            <asp:MultiView ID="mViewSearchResults" runat="server">
                <asp:View ID="viewBusinessResults" runat="server">
                    <asp:GridView ID="gViewBusinessResults" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" DataSourceID="LinqDataSource1">
                        <AlternatingRowStyle BackColor="White" />
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
                <asp:View ID="viewParkResults" runat="server">
                    <asp:GridView ID="gViewParkResults" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Name" ForeColor="#333333" GridLines="None">
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
                            <asp:BoundField DataField="FeatureBaseball" HeaderText="Number of Baseball Diamonds" SortExpression="FeatureBaseball" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                            <asp:BoundField DataField="FeatureBasketball" HeaderText="Number of Basketball Courts" SortExpression="FeatureBasketball" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                            <asp:BoundField DataField="FeatureGolf" HeaderText="Number of Golf Courses" SortExpression="FeatureGolf" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                            <asp:BoundField DataField="FeatureLargeMPField" HeaderText="Number of Large Multipurpose Fields" SortExpression="FeatureLargeMPField" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                            <asp:BoundField DataField="FeatureTennis" HeaderText="Number of Tennis Courts" SortExpression="FeatureTennis" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                            <asp:BoundField DataField="FeatureVolleyball" HeaderText="Number of Volleyball Courts" SortExpression="FeatureVolleyball" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
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
                <asp:View ID="viewPublicFacilityResults" runat="server">
                    <asp:GridView ID="gViewPublicFacilityResults" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Name" ForeColor="#333333" GridLines="None">
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
