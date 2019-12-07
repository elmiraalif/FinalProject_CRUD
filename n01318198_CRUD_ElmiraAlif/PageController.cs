using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;

namespace n01318198_CRUD_ElmiraAlif
{
    public class PageController : PAGEDB
    {

        //Adding pages method
        public void AddPage (Http_Page new_page)
        {
            string query = "INSERT INTO pages(PAGETITLE, PAGEDATE, PAGEBODY) VALUES('{0}','{1}','{2}')";
            query = String.Format(query, new_page.GetPage_Title(), new_page.GetPage_Date().ToString("yyyy-MM-dd"), new_page.GetPage_Body());

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Something went Wrong!");
                Debug.WriteLine(e.ToString());
            }
            Connect.Close();
        }//end of add page method

        //Find page method
        public Http_Page FindPage(int id)
        {
            //ConnectionString
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //creating a page to return sth
            Http_Page result_page = new Http_Page();
            try
            {
                //get the id of the pages
                string query = "SELECT * FROM pages WHERE PAGEID = " + id;
                //get the message that connection has been started
                Debug.WriteLine("Connection Innitialized!");
                //opening the connection
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //getting the result set 
                MySqlDataReader resultset = cmd.ExecuteReader();
                //creating a list of the pages
                List<Http_Page> pages = new List<Http_Page>();

                while (resultset.Read())
                {
                    Http_Page currentpage = new Http_Page();
                    //Each column
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        //get the key value pairs of the result set
                        string key = resultset.GetName(i);
                        if (resultset.IsDBNull(i)) continue;
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        //going to each column one by one to check the key and the value
                        switch (key)
                        {
                            case "PAGETITLE":
                                currentpage.SetPage_Title(value);
                                break;
                            case "PAGEBODY":
                                currentpage.SetPage_Body(value);
                                break;
                            case "PAGEDATE":
                                //Reference: from Christine's code in Http5101-School_System Project
                                //converting a student to a date
                                currentpage.SetPage_Date(DateTime.ParseExact(value, "M/d/yyyy hh:mm:ss tt", new CultureInfo("en-US")));
                                break;
                        }
                        //adding the current page to the list of pages
                        pages.Add(currentpage);
                    }
                    result_page = pages[0];
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Something went wrong!");
                Debug.WriteLine(e.ToString());
            }
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");
            return result_page;
        }//end of find page method

        //update page method
        public void UpdatePage(int page_id, Http_Page new_page)
        {
            string query = "UPDATE pages SET PAGETITLE = '{0}',PAGEDATE = '{1}', PAGEBODY = '{2}' WHERE PAGEID='{3}'";
            query = String.Format(query, new_page.GetPage_Title(), new_page.GetPage_Date().ToString("yyyy-MM-dd"), new_page.GetPage_Body(), page_id);
            //connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);

            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch(Exception e)
            {
                Debug.WriteLine("Something went Wrong!");
                Debug.WriteLine(e.ToString());
            }
            Connect.Close();
        }

        //Deleting the page
        public void DeletePage(int page_id)
        {
            string query = "DELETE FROM pages WHERE PAGEID= {0}";
            query = String.Format(query, page_id);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Debug.WriteLine("Something went wrong!");
                Debug.WriteLine(e.ToString());
            }
            Connect.Close();
        }

    }
}