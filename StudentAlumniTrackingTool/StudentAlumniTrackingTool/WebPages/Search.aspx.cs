using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace StudentAlumniTrackingTool.WebPages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int year = System.DateTime.Now.Year;
                year += 10; // Add for current students who don't graduate this year but in the next few coming years.
                /* DropDownList GradYear = (DropDownList)Page.FindControl("GradYearDropdown");
                DropDownList EmployerStartYear = (DropDownList)Page.FindControl("EmployerStartDateDDYear");
                DropDownList EmployerEndYear = (DropDownList)Page.FindControl("EmployerEndDateYear");
                */

                for (int i = 1900; i <= year; i++)
                {
                    ListItem yearItem = new ListItem(i.ToString(), i.ToString(), true);
                    GradYearDropdown.Items.Add(yearItem);
                }
            }
        }

        protected void OnSearchClick(object sender, EventArgs e)
        {
            // Gather all fields - user may have them all entered
            /* LastNameBox;
            TextBox LastNameBox = (TextBox)FindControl("LastNameBox");
            DropDownList MajorDropdown = (DropDownList)FindControl("MajorDropdown");
            DropDownList GraduationMonth = (DropDownList)FindControl("GraduationMonth");
            DropDownList GradYearDropdown = (DropDownList)FindControl("GradYearDropdown");
            TextBox EmployerBox = (TextBox)FindControl("EmployerBox"); */

            // Query the DB
            SqlCommand sqlComm = new SqlCommand();

            int emptyCount = 0;
            try
            {
                // Start SQL command here for parameterization 
                sqlComm = new SqlCommand(
                    "");

                string currentText;
                if (!((currentText = LastNameBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@LName", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = MajorDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                /* Graduation dropdowns */
                DateTime dt;
                String currentText2;
                if (!((currentText = GradYearDropdown.SelectedValue).Equals("")) && !((currentText2 = GraduationMonth.SelectedValue).Equals("")))
                {
                    dt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), 0);
                    sqlComm.Parameters.Add("@GradDate", System.Data.SqlDbType.Date).Value = dt;
                }
                else 
                    emptyCount += 3;
                
                if (!((currentText = EmployerBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                /* 
                 * Make sure we have a query we can actually run; in other words, that the user put in SOME 
                 * sort of data so that we don't run empty searches.
                 */

                
                if (emptyCount >= 30)
                {
                    EntryError.Text = "You did not specify any criteria. You cannot run an empty search.";
                    EntryError.Visible = true;
                } else {
                    string sqlQuery = sqlComm.ToString();
                    // Generate search query here as a session variable - will be passed to results page
                    Session["SearchQuery"] = sqlQuery;
                    Response.Redirect(SearchButton.PostBackUrl);
                }

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                // Close DB connection and queries
                sqlComm.Dispose();
            }
        } 
    }
}