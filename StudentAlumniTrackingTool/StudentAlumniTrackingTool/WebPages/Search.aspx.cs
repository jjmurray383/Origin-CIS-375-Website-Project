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
               
            }
        }

        protected void OnSearchClick(object sender, EventArgs e)
        {

        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            // Gather all fields - user may have them all entered

            TextBox LastNameBox = this.LastNameBox;
            DropDownList MajorDropdown = this.MajorDropdown;
            DropDownList GraduationMonth = this.GraduationMonth;
            DropDownList GradYearDropdown = this.GradYearDropdown;
            TextBox EmployerBox = this.EmployerBox;
            DateTime dt;
            bool Successful = false;
            // Query the DB
            SqlCommand sqlComm = new SqlCommand();

            int emptyCount = 0;
            int identifier = 0;
            try
            {
                // Start SQL command here for parameterization 
                sqlComm = new SqlCommand(
                    "SELECT STUDENT.Fname, STUDENT.Lname, EDUCATION.SchoolName FROM STUDENT, EDUCATION ");

                string currentText;
                if (!((currentText = EmployerBox.Text).Equals("")))
                {
                    sqlComm.CommandText += ", EMPLOYMENT WHERE(EmployerName LIKE @EmployerName AND EMPLOYMENT.Email = STUDENT.Email";
                    sqlComm.Parameters.Add("@EmployerName", System.Data.SqlDbType.VarChar).Value = "%" + currentText + "%";
                    Session["EmployerName"] = "%" + currentText + "%";
                    identifier++;
                }
                else emptyCount++;

                if (!((currentText = LastNameBox.Text).Equals("")))
                {
                    if(emptyCount==1)
                        sqlComm.CommandText += "WHERE(STUDENT.Lname LIKE @Lname";
                    else
                        sqlComm.CommandText += " AND Lname LIKE @Lname";
                    sqlComm.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = "%" + currentText + "%";
                    sqlComm.Parameters["@Lname"].Value = currentText;
                    Session["Lname"] = "%" + currentText + "%";
                    identifier = identifier + 2;
                }
                else emptyCount++;
                if (!((currentText = MajorDropdown.Text).Equals("")))
                {
                    if (emptyCount == 2)
                        sqlComm.CommandText += "WHERE(Major LIKE @Major";
                    else
                        sqlComm.CommandText += " AND Major LIKE @Major";
                    sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar).Value = "%" + currentText + "%";
                    Session["Major"] = "%" + currentText + "%";
                    identifier = identifier + 4;
                }
                else emptyCount++;

                /* Graduation dropdowns */
                
                String currentText2;
                if (!((currentText = GradYearDropdown.SelectedValue).Equals("")) && !((currentText2 = GraduationMonth.SelectedValue).Equals("")))
                {
                    if (emptyCount == 3)
                        sqlComm.CommandText += "WHERE(GraduationDate LIKE @GraduationDate";
                    else
                        sqlComm.CommandText += " AND GraduationDate LIKE @GraduationDate";
                    dt = DateTime.Parse(currentText + "/" + currentText2);
                    sqlComm.Parameters.Add("@GraduationDate", System.Data.SqlDbType.Date).Value = "%" + dt.ToShortDateString() + "%";
                    Session["GraduationDate"] = "%" + dt.ToShortDateString() + "%";
                    identifier = identifier + 8;
                }
                else
                {
                    emptyCount++;
                }
                /* 
                 * Make sure we have a query we can actually run; in other words, that the user put in SOME 
                 * sort of data so that we don't run empty searches.
                 */


                if (emptyCount >= 4)
                {
                    EntryError.Text = "You did not specify any criteria. You cannot run an empty search.";
                    EntryError.Visible = true;
                }
                else
                {
                    sqlComm.CommandText += " AND STUDENT.Email = EDUCATION.Email);";
                    string sqlQuery = sqlComm.CommandText;
                    // Generate search query here as a session variable - will be passed to results page
                    Session["SearchQuery"] = sqlQuery;
                    Session["Identifier"] = identifier;
                    Successful = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                // Close DB connection and queries
                sqlComm.Dispose();
            }
            if(Successful)
                Response.Redirect("SearchResults.aspx");
        }
        
    }
}