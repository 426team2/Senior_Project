using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Configuration;

public partial class Time_Entry : Page
{
    // initialize variables
    public string employeeSelected;
    public string customerSelected;
    public string serviceItemSelected;
    public string rateForServItem;
    public string timeDataEntered;

    // page load handler
    protected void Page_Load(object sender, EventArgs e)
    {
        // stub
    }

    // calander selection change handler
    protected void calEventDate_SelectionChanged(object sender, EventArgs e)
    {
        // set text in the date textbox to selected date
        txtEventDate.Text = calEventDate.SelectedDate.ToString("d");

        // DEBUG OUTPUT
        Debug.WriteLine(txtEventDate.Text);
    }

    // employee selection change handler
    protected void EmployeeDDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // set a variable for the employee selected
        employeeSelected = EmployeeDDList.SelectedItem.Text;

        // DEBUG OUTPUT
        Debug.WriteLine(employeeSelected);

    }

    // customer selection change handler
    protected void CustomerDDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // set a variable for the customer selected
        customerSelected = CustomerDDList.SelectedItem.Text;

        // DEBUG OUTPUT
        Debug.WriteLine(customerSelected);
    }

    // service item change handler
    protected void ServItemDDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // set service item selection and corresponding rate to a variable 
        serviceItemSelected = ServItemDDList.SelectedItem.Text;
        rateForServItem = ServItemDDList.SelectedItem.Value;

        // DEBUG OUTPUT
        Debug.WriteLine(serviceItemSelected);
        Debug.WriteLine(rateForServItem);

        // change the rate that is displayed so it is valid for the service item selected
        Label2.Text = ServItemDDList.SelectedItem.Value;

        // check if the webpage re rendered the time data, if not the force webpage to validate its data
        if (!IsPostBack)
            {
            Validate();
            }
    }

    // time data change handler
    protected void TimeData_TextChanged(object sender, EventArgs e)
    {
        // set the time data to a variable 
        timeDataEntered = TimeData.Text;

        // DEBUG OUTPUT
        Debug.WriteLine(timeDataEntered);
    }

    // clear butten action handler
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        // clear all the above field
        // clear the employee drop down box
        EmployeeDDList.ClearSelection();
        EmployeeDDList.SelectedIndex = 0;

        // clear the date
        txtEventDate.Text = " ";

        // clear the customer drop down box
        CustomerDDList.ClearSelection();
        CustomerDDList.SelectedIndex = 0;

        // clear the service item and rate associated with it
        ServItemDDList.ClearSelection();
        ServItemDDList.SelectedIndex = 0;

        // change the rate that is displayed so it is valid for the service item selected
        Label2.Text = ServItemDDList.SelectedItem.Value;

        // check if the webpage re rendered the time data, if not the force webpage to validate its data
        if (!IsPostBack)
        {
            Validate();
        }

        // clear the time 
        TimeData.Text = "";

        // clear the description
        DescriptionData.Text = "";
    }

    // save button action handler
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        // initialize variables
        string query = "";
        int rowsAffected = 0;
        bool flag = false;

        // test variables for insert test
        int id = 7;
        string efirsttemp = "test8";
        string elasttemp = "testlast8";
        int eidtemp = 16;
        string cfirsttemp = "test9";
        string clasttemp = "testlast9";
        int cidtemp = 17;
        bool testInsert = true;
        bool testSelect = false;

        // create an object to interact with the database
        Connector dbConn = new Connector ();


        if (testSelect)
        {
            // generate query string to test select functionality
            query = "SELECT * FROM Table_test WHERE EQID='58'";

            // call the DataSelect function to test select functionality
            rowsAffected = dbConn.DataSelect(query);

            // write out rows affected to screen
            Debug.WriteLine(rowsAffected);
        }

        if (testInsert)
        {
            // call DataInsert to insert the new data to the database
            flag = dbConn.DataInsert(id,efirsttemp,elasttemp,eidtemp,cfirsttemp,clasttemp,cidtemp);

            // test flag to see if insert worked or not and report to debug console
            if (flag)
            {
                // it worked
                Debug.WriteLine("time activity of ID " + id + " inserted");
            }

            else
            {
                // it did not work
                Debug.WriteLine("insert does not work");
            }
        }
    }
}