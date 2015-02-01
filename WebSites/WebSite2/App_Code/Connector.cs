using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Class used to make connection between database and web app for time activities
/// Connection is made through the configuration manager, actual connection information ( sql connection 
/// string used ) can be found in the Web.config file.
/// Select, Insert, Update, and Delete functions are also included in this class.
/// </summary>
public class Connector
{
	public Connector()
	{
        // we do not need to do anything in the constructor for this class
	}

    public SqlConnection createDBConnection()
    {
        // create a connection string for the database
        ConnectionStringSettings settings;
        // pull the connection string from the web.config file
        settings = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnection"];
        // create a variable to store the retrieved string into
        string connectionString = settings.ConnectionString;

        // create a connection object
        SqlConnection DatabaseConnection;
        DatabaseConnection = new SqlConnection();
        // initialize the connection objects connection string to the above created string
        DatabaseConnection.ConnectionString = connectionString;

        // return the initialized database connection object
        return DatabaseConnection;
    }

    public int DataSelect(string query)
    {
        // initialize variables
        int rows = 0;

        // create a connection string for the database
        //ConnectionStringSettings settings;
        //settings = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnection"];
        //string connectionString = settings.ConnectionString;

        // create a connection object
        //SqlConnection Connection1;
        //Connection1 = new SqlConnection();
        //Connection1.ConnectionString = connectionString;

        // create db connection object
        SqlConnection Connection1;
        Connection1 = createDBConnection();

        // use try block to fail gracefully
        try
        {
            // open a connection to the database
            Connection1.Open();
            Debug.WriteLine("connection opened to select");

            // create an sqlcommand object with the query and database connection
            SqlCommand command = new SqlCommand(query, Connection1);

            // create a sql reader object with the sql command object
            SqlDataReader reader = command.ExecuteReader();

            // only read if there is valid information to be read
            if (reader.HasRows)
            {
                // initialize variable to iterate over reader results
                int i = 1;

                // while the reader has rows
                while (reader.Read())
                {
                    // since there are 7 elements in each row of the table, bet we do not wanbt the first (i=0)
                    while (i < 7)
                    { 
                        // output the information from the reader
                        Debug.WriteLine(reader[i]);
                        // increment i
                        i += 1;
                    }
                }
            }

            // close the connection to the database
            Connection1.Close();
            Debug.WriteLine("connection closed");

            // return the number of rows affected
            return rows;
        }

        // catch the error to make it a learning experience instead of failure
        catch (SqlException err)
        {
            // initialize variables
            string errorMessages = "";

            // create a readable error message from the sql exception(s)
            for (int i = 0; i < err.Errors.Count; i++)
            {
                errorMessages = "Index #" + i + "\n" +
                    "Message: " + err.Errors[i].Message + "\n" +
                    "LineNumber: " + err.Errors[i].LineNumber + "\n" +
                    "Source: " + err.Errors[i].Source + "\n" +
                    "Procedure: " + err.Errors[i].Procedure + "\n";
            }
            // write the error message out to the debug console
            Debug.WriteLine(errorMessages);

            // close the connection to the database
            Connection1.Close();
        }
        // return the number of rows affected
        return rows;
    }

    // insert command handler
    public bool DataInsert(int id, string efirst, string elast, int eid, string cfirst, string clast, int cid)
    {
        // initialize variables
        bool flag = false;
        int rowsAffected = 0;

        // create a connection string for the database
        //ConnectionStringSettings settings;
        //settings = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnection"];
        //string connectionString = settings.ConnectionString;

        // create a connection object
        //SqlConnection Connection1;
        //Connection1 = new SqlConnection();
        //Connection1.ConnectionString = connectionString;

        // create db connection object
        SqlConnection Connection1;
        Connection1 = createDBConnection();

        // open a connection to the table
        Connection1.Open();
        System.Diagnostics.Debug.WriteLine("connection opened to insert");

        // create a command object for the query
        using (SqlCommand command = new SqlCommand(
        "INSERT INTO Table_test VALUES(@Id,@EFirst,@ELast,@EQID,@CFirst,@CLast,@CQID)", Connection1))
        {
            // create a parameterized query
            command.Parameters.Add(new SqlParameter("Id", id));
            command.Parameters.Add(new SqlParameter("EFirst", efirst));
            command.Parameters.Add(new SqlParameter("ELast", elast));
            command.Parameters.Add(new SqlParameter("EQID", eid));
            command.Parameters.Add(new SqlParameter("CFirst", cfirst));
            command.Parameters.Add(new SqlParameter("CLast", clast));
            command.Parameters.Add(new SqlParameter("CQID", cid));
            // use try block to fail gracefully
            try
            {
                // execute the query
                rowsAffected = command.ExecuteNonQuery();
                Debug.WriteLine(rowsAffected);

                // close the connection to the database
                Connection1.Close();
                Debug.WriteLine("connection closed");

                // set flag to true to signify data was inserted
                flag = true;
            }
            
            // catch the error to make it a learning experience instead of failure
            catch (SqlException err)
            {
                // initialize variables
                string errorMessage = "";

                // create a readable error message from the sql exception(s)
                for (int i = 0; i < err.Errors.Count; i++)
                {
                    errorMessage = "Index #" + i + "\n" +
                        "Message: " + err.Errors[i].Message + "\n" +
                        "LineNumber: " + err.Errors[i].LineNumber + "\n" +
                        "Source: " + err.Errors[i].Source + "\n" +
                        "Procedure: " + err.Errors[i].Procedure + "\n";
                }
                // write the error message out to the debug console
                Debug.WriteLine(errorMessage);

                // close the connection to the database still and return 0
                Connection1.Close();

                // set flag to false to signify information was not inserted
                flag = false;
            }
        }
        // return the number of rows affected
        return flag;
    }

    // update class
    public int DataUpdate(string query)
    {
        // initialize variables

        // create sql query

        // execute sql query

        // return success or failure
        // stub
        return 0;
    }

    // delete class
    public int DataDelete(string query)
    {
        // recieve ID for activity in question

        // generate query to remove time activity from database

        // execute query

        // return success or failure


        // stub
        return 0;
    }

}