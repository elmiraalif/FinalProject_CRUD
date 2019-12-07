using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace n01318198_CRUD_ElmiraAlif
{
    public class PAGEDB
    {
        private static string Database { get { return "cms"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3307"; } }
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }

        //ConnectionSTring : Connecting to the database
       protected static string ConnectionString
        {
            get
            {
                return "database = " + Database +
                 "; server = " + Server +
                 "; port = " + Port +
                 "; user = " + User +
                 "; password = " + Password;
            }
        }
        //getting a result set of pages: List_Query
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            try
            {
                //getting a message
                Debug.WriteLine("Connection initialized");
                //openning the db connection
                Connect.Open();
                //a query for the connection
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //get the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Each ROW
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //Each COLUMN 
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));
                    }
                    ResultSet.Add(Row);
                }
                //Closing the result set
                resultset.Close();
            }
            //If there's something wrong, do : 
            catch (Exception e)
            {
                Debug.WriteLine("There is something wrong!");
                Debug.WriteLine(e.ToString());
            }//end of catch

            Connect.Close();
            Debug.WriteLine("Database Connection terminated!");

            return ResultSet;
        }//end of resultset
    }
}