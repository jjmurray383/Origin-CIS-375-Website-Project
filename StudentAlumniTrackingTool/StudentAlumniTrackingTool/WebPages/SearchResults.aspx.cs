using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentAlumniTrackingTool.WebPages
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader theReader = (SqlDataReader)Session["Reader"];

                ResultsGridView.DataSource = theReader;
                ResultsGridView.DataBind();
                ResultsPanel.Visible = true;
            }
            catch (Exception except)
            {
                Console.WriteLine(except);
                Session["ErrorOccured"] = except.ToString();
                Response.Redirect("Error.aspx");
            }

        }

        protected void ResultsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}