using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01318198_CRUD_ElmiraAlif
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageController controller = new PageController();
                PageContent(controller);
            }
        }
        protected void Update_Page(object sender, EventArgs e)
        {
            PageController controller = new PageController();
            Http_Page new_page = new Http_Page();
            bool valid = true;
            string page_id = Request.QueryString["page_id"];
            if (String.IsNullOrEmpty(page_id)) valid = false;
            if (valid)
            {
                //setting the page data
                new_page.SetPage_Title(page_title.Text);
                new_page.SetPage_Date(DateTime.Now);
                new_page.SetPage_Body(page_body.Text);
            }
            //then add to the database
            try
            {
                controller.UpdatePage(Int32.Parse(page_id), new_page);
                Response.Redirect("ListPages.aspx");

            }
            catch
            {
                valid = false;

            }
        }//end of update page
        protected void PageContent(PageController controller)
        {
            bool valid = true;
            string page_id = Request.QueryString["page_id"];
            if (String.IsNullOrEmpty(page_id)) valid = false;
            if (valid)
            {
                Http_Page page_record = controller.FindPage(Int32.Parse(page_id));
                page_title.Text = page_record.GetPage_Title();
                page_body.Text = page_record.GetPage_Body();
            }
        }//end of page content

    }
}