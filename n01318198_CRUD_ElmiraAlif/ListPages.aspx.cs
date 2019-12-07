using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n01318198_CRUD_ElmiraAlif
{
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //resetting the pages_result element
            pages_result.InnerHtml = "";
            string query = "SELECT * FROM pages";

            var db = new PAGEDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                //making the same format of the the class "_table":
                pages_result.InnerHtml += "<div class=\"list-item\">";
                //adding the new page and get a new id
                string page_id = row["PAGEID"];
                //get the new title 
                string page_title = row["PAGETITLE"];
                //display the title
                pages_result.InnerHtml += "<div class=\"col3\"><a href=\"UpdatePage.aspx?page_id=" + page_id + "\">" + page_title+ "</a></div>";

                string page_date = row["PAGEDATE"];
                pages_result.InnerHtml += "<div class=\"col3 \">" + page_date + "</div>";

                string page_body = row["PAGEBODY"];

                //adding the delete button to the column
                pages_result.InnerHtml += " <div class=\"col3last\"><a href=\"DeletePage.aspx?page_id=" + page_id + "\">DELETE</a></div>";
                //closing the div tag of list items
                pages_result.InnerHtml += "</div>";
            }
         }//end of page load
        protected void NewPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPage.aspx");
        }
    }
}