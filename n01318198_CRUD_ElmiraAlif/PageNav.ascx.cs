using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01318198_CRUD_ElmiraAlif
{
    public partial class PageNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();
            ListPages(db);
        }
        protected void ListPages(PAGEDB db)
        {
            string query = "SELECT PAGETITLE FROM pages";
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                page_nav.InnerHtml += "<div class=\"page-nav\">" + row["PAGETITLE"] + "</div>";

            }

        }

    }
}