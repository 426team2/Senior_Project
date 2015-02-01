<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Time_Entry.aspx.cs" Inherits="Time_Entry" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- HEADERS --%>
    <h2>Step 2. Enter Time</h2>
    <p class="lead">Complete all fields to save</p>
    <p>&nbsp;</p>


    <%-- EMPLOYEE DROP DOWN LIST --%>
    <p class="lead">Employee&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="EmployeeDDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="EmployeeDDList_SelectedIndexChanged">
            <asp:ListItem> </asp:ListItem>
            <asp:ListItem>Bryan Ruff</asp:ListItem>
            <asp:ListItem>Paul Simmons</asp:ListItem>
        </asp:DropDownList>
    </p>

    <div><%-- ADD SOME EXTRA SPACE BETWEEN EMPLOYEE AND DATE BOX --%></div>

    <%-- CALANDER STUFF --%>
    <script type="text/javascript">

        function displayCalendar() {
            var datePicker = document.getElementById('datePicker');
            datePicker.style.display = 'block';
        }

    </script>  
       
    <%-- STYLE FOR CALANDER --%>
    <style type="text/css">
        #datePicker
        {
            display:none;
            position:absolute;
            border:solid 2px black;
            background-color:white;
        }
    </style>

    <div class="content">

    <%-- CALANDER SELECTION DISPLAY --%>
    <asp:Label
        id="lblEventDate"
        Text="Date"
        class="lead"
        AssociatedControlID="txtEventDate"
        Runat="server" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

    <%-- CALANDER TEXT BOX --%>
    <asp:TextBox
        id="txtEventDate"
        Runat="server" />
    &nbsp;&nbsp;&nbsp;

    <%-- CALANDER IMAGE DISPLAY --%>
    <img runat="server" src="App_GlobalResources/datepicker_512" onclick="displayCalendar()" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <%-- CALANDER SELECTION HANDLER --%>
    <div id="datePicker">
    <asp:Calendar
        id="calEventDate"
        OnSelectionChanged="calEventDate_SelectionChanged"
        Runat="server" /> 
    </div>    

    <%-- CUSTOMER DROP DOWN LIST --%>
    <p class="lead">   
       Customer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:DropDownList ID="CustomerDDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CustomerDDList_SelectedIndexChanged">
           <asp:ListItem> </asp:ListItem>
           <asp:ListItem>Alvin Lee</asp:ListItem>
           <asp:ListItem>Brad Hall</asp:ListItem>
       </asp:DropDownList>
    </p>

    <%-- SERVICE DROP DOWN LIST --%>
    <p class="lead">Service Item&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ServItemDDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ServItemDDList_SelectedIndexChanged">
            <asp:ListItem Text=" " Value=" "></asp:ListItem>
            <asp:ListItem Text="Research" Value="$50.00"></asp:ListItem>
            <asp:ListItem Text="Deposition" Value="$100.00"></asp:ListItem>
        </asp:DropDownList>
    </p>

    <%-- RATE BOX --%>
    <p class="lead">Rate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server"> </asp:Label>
    </p>

    <%-- TIME BOX --%>
    <p class="lead">Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TimeData" runat="server" OnTextChanged="TimeData_TextChanged" TextMode="Number"></asp:TextBox>
    </p>

    <%-- DESCRIPTION BOX --%>
    <p class="lead">Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="DescriptionData" runat="server" BorderStyle="Solid" Height="145px" Width="750px" BorderWidth="5px" EnableTheming="True" TextMode="MultiLine"></asp:TextBox>
    </p>
    
    <%-- CLEAR/SAVE BUTTON --%>
    <p class="lead" dir="ltr">
        <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SaveButton" runat="server" BackColor="#339933" ForeColor="White" OnClick="SaveButton_Click" Text="Save" />
    </p>

    <%-- HEADER FOR TIME ACTIVITY TABLE --%>
    <p class="lead" dir="ltr">
        Time Activities
    </p>

    <%-- TIME ACTIVITY TABLE --%>
    <p class="lead">
        <asp:Table ID="Table1" runat="server" BorderStyle="Solid" CellPadding="1" CellSpacing="1" CssClass="table">
            <asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Solid">Employee</asp:TableCell>
                <asp:TableCell runat="server" BorderStyle="Solid">Customer</asp:TableCell>
                <asp:TableCell runat="server" BorderStyle="Solid">Service Item</asp:TableCell>
                <asp:TableCell runat="server" BorderStyle="Solid">Date</asp:TableCell>
                <asp:TableCell runat="server" BorderStyle="Solid">Hours</asp:TableCell>
                <asp:TableCell runat="server" BorderStyle="Solid">Amount</asp:TableCell>
                <asp:TableCell runat="server" BorderStyle="Solid">QBO ID</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>

    <%-- A FEW EXTRA SPACES --%>
    <p class="lead">&nbsp;</p>
    <p class="lead">&nbsp;</p>
    </div>

<%-- END OF CONTENT --%>
</asp:Content>
