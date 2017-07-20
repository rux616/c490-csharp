<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="cView_P4_DanCassidy.Add" %>

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
                    <td class="auto-style3">ADD ITEM</td>
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
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Visible="False" OnClick="btnAdd_Click" />
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
            <asp:MultiView ID="mViewBasic" runat="server">
                <asp:View ID="viewBasic" runat="server">
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
            <asp:MultiView ID="mViewSpecific" runat="server">
                <asp:View ID="viewBusiness" runat="server">
                    <table style="width: auto;">
                        <caption style="border-style: solid; border-width: 1px">
                            Business-Specific Information</caption>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lblLicenseNumber" runat="server" Text="License Number:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLicenseNumber" runat="server" Width="300px"></asp:TextBox>
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
                <asp:View ID="viewPark" runat="server">
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
