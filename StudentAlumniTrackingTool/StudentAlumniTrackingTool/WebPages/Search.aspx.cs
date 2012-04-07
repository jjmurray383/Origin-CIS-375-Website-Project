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

        }

        protected void OnSearchClick(object sender, EventArgs e)
        {
            // Gather all fields - user may have them all entered
            TextBox FirstNameBox = (TextBox) FindControl("FirstNameBox");
            TextBox MiddleInitialBox = (TextBox)FindControl("MiddleInitialBox");
            TextBox LastNameBox = (TextBox)FindControl("LastNameBox");
            TextBox PhoneNumBox = (TextBox)FindControl("PhoneNumBox");
            TextBox StreetBox = (TextBox)FindControl("StreetBox");
            TextBox CityBox = (TextBox)FindControl("CityBox");
            DropDownList StateDropdown = (DropDownList)FindControl("StateDropdown");
            TextBox ZIPBox = (TextBox)FindControl("ZIPBox");
            TextBox UniversityBox = (TextBox)FindControl("UniversityBox");
            DropDownList DegreeDropdown = (DropDownList)FindControl("DegreeDropdown");
            DropDownList MajorDropdown = (DropDownList)FindControl("MajorDropdown");
            DropDownList MinorDropdown = (DropDownList)FindControl("MinorDropdown");
            TextBox GPABox = (TextBox)FindControl("GPABox");
            DropDownList GraduationMonth = (DropDownList)FindControl("GraduationMonth");
            DropDownList GradYearDropdown = (DropDownList)FindControl("GradYearDropdown");
            TextBox UniversityEmailBox = (TextBox)FindControl("UniversityEmailBox");
            TextBox EmployerBox = (TextBox)FindControl("EmployerBox");
            TextBox EmployeeTitleBox = (TextBox)FindControl("EmployeeTitleBox");
            TextBox ScheduleBox = (TextBox)FindControl("ScheduleBox");
            TextBox EmployerContactInfoBox = (TextBox)FindControl("EmployerContactInfoBox");
            TextBox EmployerEmailBox = (TextBox)FindControl("EmployerEmailBox");
            DropDownList EmployerStartDateDDDay = (DropDownList)FindControl("EmployerStartDateDDDay");
            DropDownList EmployerStartDateDDMonth = (DropDownList)FindControl("EmployerStartDateDDMonth");
            DropDownList EmployerStartDateDDYear = (DropDownList)FindControl("EmployerStartDateDDYear");
            DropDownList EmployerEndDateDay = (DropDownList)FindControl("EmployerEndDateDay");
            DropDownList EmployerEndDateMonth = (DropDownList)FindControl("EmployerEndDateMonth");
            DropDownList EmployerEndDateYear = (DropDownList)FindControl("EmployerEndDateYear");
            TextBox EmployerHistoryBox = (TextBox)FindControl("EmployerHistoryBox");
            TextBox EmployerHistoryTitleBox = (TextBox)FindControl("EmployerHistoryTitleBox");
            TextBox EmployerHistoryEmailBox = (TextBox)FindControl("EmployerHistoryEmailBox");

            // Query the DB
            SqlConnection dbConn = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();

            int emptyCount = 0;
            try
            {
                sqlComm = new SqlCommand(
                    "");
                string currentText;
                if (!((currentText = FirstNameBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@FName", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = MiddleInitialBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@MI", System.Data.SqlDbType.Char).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = LastNameBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@LName", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = PhoneNumBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@PNum", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = StreetBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Street", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = StateDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@State", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = ZIPBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@ZIP", System.Data.SqlDbType.Char).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = UniversityBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@School", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                if (!((currentText = DegreeDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Degree", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = MajorDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                if (!((currentText = MinorDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Minor", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                /* Graduation dropdowns */
                DateTime dt;
                String currentText2;
                if (!((currentText = GradYearDropdown.Text).Equals("")) && !((currentText2 = GraduationMonth.Text).Equals("")))
                {
                    dt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), 0);
                    sqlComm.Parameters.Add("@GradDate", System.Data.SqlDbType.Date).Value = dt;
                }
                else 
                    emptyCount += 3;
                
                if (!((currentText = GPABox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@GPA", System.Data.SqlDbType.Float).Value = Convert.ToDouble(currentText);
                }
                else emptyCount++;

                if (!((currentText = UniversityEmailBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Uemail", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                if (!((currentText = EmployerBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = EmployeeTitleBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpTitle", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = ScheduleBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = EmployerContactInfoBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                if (!((currentText = EmployerEmailBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                /* Employer start and end dates */
                DateTime dtt;
                string currentText3;
                if (!((currentText = EmployerStartDateDDDay.Text).Equals("")) && !((currentText2 = EmployerStartDateDDMonth.Text).Equals(""))
                    && ((currentText3 = EmployerStartDateDDDay.Text).Equals("")) )
                {
                    dtt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), Convert.ToInt32(currentText3));
                    sqlComm.Parameters.Add("@EmpStrtDt", System.Data.SqlDbType.Date).Value = dtt;
                }
                else
                    emptyCount += 3;

                 DateTime dttt;
                if (!((currentText = EmployerEndDateYear.Text).Equals("")) && !((currentText2 = EmployerEndDateMonth.Text).Equals(""))
                    && ((currentText3 = EmployerEndDateDay.Text).Equals("")) )
                {
                    dttt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), Convert.ToInt32(currentText3));
                    sqlComm.Parameters.Add("@EmpEndDt", System.Data.SqlDbType.Date).Value = dttt;
                }
                else
                    emptyCount += 3;
                if (!((currentText = EmployerHistoryBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpHist", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = EmployerHistoryTitleBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpHistTitle", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;
                if (!((currentText = EmployerHistoryEmailBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpHistEmail", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                else emptyCount++;

                /* 
                 * Make sure we have a query we can actually run; in other words, that the user put in SOME 
                 * sort of data so that we don't run empty searches.
                 */
                if (emptyCount >= 30)
                {
                    EntryError.Text = "You did not specify any criteria. You cannot run an empty search";
                    EntryError.Visible = true;
                } else {
                    // Generate search query here as a session variable
                    string sqlQuery = "SELECT ";
                    Session["SearchQuery"] = sqlQuery;
                }

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                // Close DB connection and queries
                dbConn.Close();
                sqlComm.Dispose();
            }
        } 
    }
}