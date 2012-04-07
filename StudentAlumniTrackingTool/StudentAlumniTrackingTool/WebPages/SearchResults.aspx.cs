using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace StudentAlumniTrackingTool.WebPages
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = 0;
            string queryString = Request.ServerVariables["SearchQuery"];
            if (queryString == null)
            {
                NoResultsPanel.Visible = true;
                ResultsPanel.Visible = false;
            }
            else
            {
                
                ResultsPanel.Visible = true;
                SqlDataSource1.ConnectionString = null; 
            }
        }

        protected void ResultsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}