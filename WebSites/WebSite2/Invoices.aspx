<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Invoices.aspx.cs" Inherits="Invoices" %>

<%-- Step 3 Header--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Step 3: Generate Invoices</h2>
    <p class="lead">Total Pending: 0</p>
    <p></p>

    <%-- Table for Pending Invoices --%>
    <asp:Table ID="Table1" runat="server" CellPadding="1" CellSpacing="1" CssClass="table">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="Solid">Customer</asp:TableCell>
            <asp:TableCell runat="server" BorderStyle="Solid">Date Range</asp:TableCell>
            <asp:TableCell runat="server" BorderStyle="Solid">Total</asp:TableCell>
            <asp:TableCell runat="server" BorderStyle="Solid">Actions</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <%-- Table for Total Invoices --%>
    <p class="lead">Total Invoices: 0</p>
    <p></p>
    <asp:Table ID="Table2" runat="server" CellPadding="1" CellSpacing="1" CssClass="table">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="Solid">Customer</asp:TableCell>
            <asp:TableCell runat="server" BorderStyle="Solid">Date Range</asp:TableCell>
            <asp:TableCell runat="server" BorderStyle="Solid">Total</asp:TableCell>
            <asp:TableCell runat="server" BorderStyle="Solid">Actions</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
