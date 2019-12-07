using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01318198_CRUD_ElmiraAlif
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //if the user clicks YES
        protected void Delete_Page(object sender, EventArgs e)
        {
            string page_id = Request.QueryString["page_id"];
            PageController controller = new PageController();
            controller.DeletePage(Int32.Parse(page_id));
            Response.Redirect("ListPages.aspx");


        }
        //if the user clicks NO
        protected void Back_To_List(object sender, EventArgs e)
        {
            Response.Redirect("ListPages.aspx");
        }
    }
}