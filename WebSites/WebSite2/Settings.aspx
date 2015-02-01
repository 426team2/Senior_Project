<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Display Step 1 and Quickbook's Connect Button --%>
    <div class="col-left">

        <%-- Initialize OAuth Protocols --%>
        <script type="text/javascript" src="https://js.appcenter.intuit.com/Content/IA/intuit.ipp.anywhere.js"></script>
        <script type="text/javascript">
            intuit.ipp.anywhere.setup({
                menuProxy: '<%=  Request.Url.GetLeftPart(UriPartial.Authority) + "/" + ConfigurationManager.AppSettings["menuProxy"].ToString()  %>',
                grantUrl: '<%=  Request.Url.GetLeftPart(UriPartial.Authority) + "/" + ConfigurationManager.AppSettings["grantUrl"].ToString()  %>'
            });
        </script>

        <%-- Step 1 on page --%>
        <h1>Step 1: Set up your app</h1>

        <%-- Step 1a on page --%>
        <p class="lead">a. Connect To QuickBooks Online</p>

        <%-- Logic for button; display if not connected, else do not display --%>
        <p class="text">Your app is not connected to QuickBooks Online.</p>
        <%-- Connect to QuickBooks button --%>
        <p><ipp:connectToIntuit></ipp:connectToIntuit></p>

        <%-- Step 1b on page --%>
        <p class="lead">b. Sync your app data with QuickBooks Online</p>
        <p class="text">The following entities will be synced to QuickBooks Online.  Once you have synced the entities, you can click the "View in QB" link to view the entity in QB</p>
    </div>

    <%-- Sync Table --%>
    <table  border ="1">
    <tr>
        <th colspan ="1" ><b>Entity Type</b></th>
        <th colspan ="1" ><b>Action</b></th>
    </tr>

    <%-- Employees Sync --%>
    <tr>
        <td>Employees</td>
        <td><asp:Button ID="Button1" runat="server"  Text="Sync" OnClick="Button1_Click" /></td>
    </tr>

    <%-- Customers Sync --%>
    <tr>
        <td>Customers</td>
        <td><asp:Button ID="Button2" runat="server"  Text="Sync" OnClick="Button2_Click" /></td>
    </tr>

    <%-- Service Items Sync --%>
    <tr>
        <td>Service Items</td>
        <td><asp:Button ID="Button3" runat="server"  Text="Sync" OnClick="Button3_Click" /></td>
    </tr>
    </table>

    <%-- Employees, Customers, Service Items Title --%>
    <div class="col-left">
        <p class="lead"></p> 
        <p class="lead">Employees, Customers, Service Items</p> 
    </div> 
    
    <%-- Create 3 Equal Columns for each table --%>
    <div class="row">
        <div class="col-md-4">
 
            <%-- Employee Table --%>
            <p class="lead">Employees <asp:Button ID="Employee_View" runat="server" Text="View in QuickBooks"/></p>
            <asp:Table ID="Table1" runat="server" CellPadding="-1" CssClass="table" BorderStyle="Solid"  BorderWidth="1">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">First Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">Last Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">QBO ID</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Bryan</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Ruff</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">58</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Paul</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Simmons</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">59</asp:TableCell>
                </asp:TableRow>
            </asp:Table>

        </div>

        <%-- Customer Table --%>
        <div class="col-md-4">
            <p class="lead">Customers <asp:Button ID="Customer_View" runat="server" Text="View in QuickBooks"/></p>
            <asp:Table ID="Table2" runat="server" CellPadding="-1" CssClass="table" BorderStyle="Solid"  BorderWidth="1">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">First Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">Last Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">QBO ID</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Alvin</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Lee</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">60</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Brad</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Hall</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">61</asp:TableCell>
                </asp:TableRow>
            </asp:Table>

        </div>

        <%-- Service Item Table --%>
        <div class="col-md-4">
            <p class="lead">Service Items <asp:Button ID="Service_View" runat="server" Text="View in QuickBooks"/></p>
            <asp:Table ID="Table3" runat="server" CellPadding="-1" CssClass="table" BorderStyle="Solid"  BorderWidth="1">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">Rate</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1" Font-Bold="True">QBO ID</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Research</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">$50.00 / Hour</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">19</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">Deposition</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">$100.00 / Hour</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" BorderWidth="1">20</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>
