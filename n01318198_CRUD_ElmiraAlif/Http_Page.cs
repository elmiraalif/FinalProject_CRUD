using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01318198_CRUD_ElmiraAlif
{
    public class Http_Page
    {
       //We create this class as a blueprint of our pages
        private string Page_Title;
        private DateTime Page_Date;
        private string Page_Body;

        //Getting the values
        public string GetPage_Title()
        {
            return Page_Title;
        }

        public DateTime GetPage_Date()
        {
            return Page_Date;
        }

        public string GetPage_Body()
        {
            return Page_Body;
        }
        //Setting the values
        public void SetPage_Title(string value)
        {
            Page_Title = value;
        }
        public void SetPage_Body(string value)
        {
            Page_Body = value;
        }
        public void SetPage_Date(DateTime value)
        {
            Page_Date = value;
        }
    }
}