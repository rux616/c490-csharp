<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="cView_P4_DanCassidy.Menu" %>

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
                    <td class="auto-style3">MAIN</td>
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

            You can use the menu to navigate to each page, or use the buttons below to randomize the tables or reset them to their last randomized state, respectively.</div>
        <div>
            <br />
            <asp:Button ID="btnRandomize" runat="server" OnClick="btnRandomize_Click" Text="Randomize" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
            <asp:Label ID="lblResult" runat="server" Text="Result" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
