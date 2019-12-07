using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n01318198_CRUD_ElmiraAlif
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //When the Publish button is clicked:
        protected void Add_Page(object sender, EventArgs e)
        {
            //make a connection 
            PageController db = new PageController();
            //Create a new page
            Http_Page new_page = new Http_Page();
            //setting the data of the new page
            new_page.SetPage_Title(page_title.Text);
            new_page.SetPage_Date(DateTime.Now);
            new_page.SetPage_Body(page_body.Text);


            //Adding the new page to our database
            db.AddPage(new_page);
            //go back to the list of pages (manage pages)
            Response.Redirect("ListPages.aspx");

        }




    }
}