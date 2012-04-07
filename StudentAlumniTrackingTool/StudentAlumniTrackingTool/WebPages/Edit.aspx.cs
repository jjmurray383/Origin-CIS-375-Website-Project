using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace StudentAlumniTrackingTool.WebPages
{
    public partial class Edit : System.Web.UI.Page
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

            try
            {
                sqlComm = new SqlCommand(
                    "");
                string currentText;
                if (!((currentText = FirstNameBox.Text).Equals(""))) {
                    sqlComm.Parameters.Add("@FName", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = MiddleInitialBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@MI", System.Data.SqlDbType.Char).Value = currentText;
                }
                if (!((currentText = LastNameBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@LName", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = PhoneNumBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@PNum", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = StreetBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Street", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = StateDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@State", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = ZIPBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@ZIP", System.Data.SqlDbType.Char).Value = currentText;
                }
                if (!((currentText = UniversityBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@School", System.Data.SqlDbType.VarChar).Value = currentText;
                }

                if (!((currentText = DegreeDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Degree", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = MajorDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar).Value = currentText;
                }

                if (!((currentText = MinorDropdown.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Minor", System.Data.SqlDbType.VarChar).Value = currentText;
                }

                /* Graduation dropdowns */

                /* GPA somewhere in here */

                if (!((currentText = UniversityEmailBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Uemail", System.Data.SqlDbType.VarChar).Value = currentText;
                }

                if (!((currentText = EmployerBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = EmployeeTitleBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpTitle", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = ScheduleBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = EmployerContactInfoBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = currentText;
                }

                if (!((currentText = EmployerEmailBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                /* Employer start and end dates */

                if (!((currentText = EmployerHistoryBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpHist", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = EmployerHistoryTitleBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpHistTitle", System.Data.SqlDbType.VarChar).Value = currentText;
                }
                if (!((currentText = EmployerHistoryEmailBox.Text).Equals("")))
                {
                    sqlComm.Parameters.Add("@EmpHistEmail", System.Data.SqlDbType.VarChar).Value = currentText;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        } 
    }
}