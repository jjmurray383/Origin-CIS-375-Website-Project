using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAlumniTrackingTool.WebPages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Find user email from URL/query string and insert it into profile heading
            String email;
            email = Request.QueryString.ToString();
            Label label = (Label) Page.FindControl("TitleName");
            label.Text = email;
        }
    }
}