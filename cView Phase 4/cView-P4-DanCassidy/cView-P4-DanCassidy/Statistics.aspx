<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="cView_P4_DanCassidy.Statistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 250px;
        }

        .auto-style5 {
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: auto; border-spacing: 0px; border-collapse: collapse;">
                <tr>
                    <td class="auto-style3">STATISTICS</td>
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
            
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
            
        </div>
        <div>
            <table style="width: auto; border-collapse: collapse;">
                <tr>
                    <td class="auto-style3" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">Total # of Parks:</td>
                    <td class="auto-style5" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">
                        <asp:Label ID="lblStatistics1" runat="server" Text="Statistics 1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">Total # of Parks by Park Types:</td>
                    <td class="auto-style5" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">
                        <asp:Label ID="lblStatistics2" runat="server" Text="Statistics 2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">Total # of Businesses:</td>
                    <td class="auto-style5" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">
                        <asp:Label ID="lblStatistics3" runat="server" Text="Statistics 3"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">Total # of license renewals for each Business:</td>
                    <td class="auto-style5" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">
                        <asp:Label ID="lblStatistics4" runat="server" Text="Statistics 4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">Total # of Facilities that have substring &quot;Fire&quot;:</td>
                    <td class="auto-style5" style="padding: 5px; border-style: solid; border-width: 1px; border-collapse: collapse">
                        <asp:Label ID="lblStatistics5" runat="server" Text="Statistics 5"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
