using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace StudentAlumniTrackingTool.WebPages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.ClientQueryString == null)
                Response.Redirect("Error.aspx");
            // Get user info from SQL
            // Query the DB
            string connectionString = "";
            string queryStr;
            SqlConnection sqlCon = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();


            // Assure user is themselves or is admin
            string clientQuerystr = Page.ClientQueryString;
            if (User.Identity.Name.Equals(Page.ClientQueryString) || User.Identity.Name.Equals("admin"))
                Console.Write(Page.ClientQueryString);
            else
                Response.Redirect("Error.aspx");

            // Popuate fields with data
            TextBox FirstNameBox = (TextBox)FindControl("FirstNameBox");
            TextBox MiddleInitialBox = (TextBox)FindControl("MiddleInitialBox");
            TextBox LastNameBox = (TextBox)FindControl("LastNameBox");
            TextBox PhoneNumBox = (TextBox)FindControl("PhoneNumBox");
            TextBox StreetBox = (TextBox)FindControl("StreetBox");
            TextBox CityBox = (TextBox)FindControl("CityBox");
            DropDownList StateDropdown = (DropDownList)FindControl("StateDropdown");
            TextBox ZIPBox = (TextBox)FindControl("ZIPBox");
            TextBox UniversityTextBox = (TextBox)FindControl("UniversityTextBox");
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

            // Begin building the SQL query to populated the Edit boxes
            sqlComm.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@MI", System.Data.SqlDbType.Char);
            sqlComm.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@PNum", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@Street", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@State", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@ZIP", System.Data.SqlDbType.Char);
            sqlComm.Parameters.Add("@School", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@Degree", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@Minor", System.Data.SqlDbType.VarChar);
            // Graduation date
           
            sqlComm.Parameters.Add("@GradDate", System.Data.SqlDbType.Date);
            sqlComm.Parameters.Add("@GPA", System.Data.SqlDbType.Float);
            sqlComm.Parameters.Add("@UEmail", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@EmpTitle", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@EmpCtctInf", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@EmpEmail", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@EmpStrtDt", System.Data.SqlDbType.Date);
            sqlComm.Parameters.Add("@EmpEndDt", System.Data.SqlDbType.Date);
            sqlComm.Parameters.Add("@EmpHist", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@EmpHistTitle", System.Data.SqlDbType.VarChar);
            sqlComm.Parameters.Add("@EmpHistEmail", System.Data.SqlDbType.VarChar);

            // SQL query here

            // Return results will go here
            FirstNameBox.Text = "";
            MiddleInitialBox.Text = "";
            LastNameBox.Text = "";
            PhoneNumBox.Text = "";
            StreetBox.Text = "";
            CityBox.Text = "";
            StateDropdown.Text = "";
            ZIPBox.Text = "";
            UniversityTextBox.Text = "";
             DegreeDropdown.Text = ""; 
             MajorDropdown.Text = ""; 
             MinorDropdown.Text = ""; 
             GPABox.Text = ""; 
             GraduationMonth.Text = ""; 
             GradYearDropdown.Text = "";
             UniversityEmailBox.Text = "";
             EmployerBox.Text = "";
             EmployeeTitleBox.Text = ""; 
             ScheduleBox.Text = ""; 
             EmployerContactInfoBox.Text = "";
             EmployerEmailBox.Text = "";
             EmployerStartDateDDDay.Text = "";
             EmployerStartDateDDMonth.Text = "";
             EmployerStartDateDDYear.Text = "";
             EmployerEndDateDay.Text = ""; 
             EmployerEndDateMonth.Text = "";
             EmployerEndDateYear.Text = "";
             EmployerHistoryBox.Text = "";
             EmployerHistoryTitleBox.Text = "";
             EmployerHistoryEmailBox.Text = ""; 

        }

        protected void EditProfile(object sender, EventArgs e)
        {
            // Get the profile's associated email
            string email = "";

            // If current user is not the user on the profile page
            if (User.Identity.Name == email)
                Response.Redirect("Error.aspx");
            // Gather all fields - user may have them all entered
            TextBox FirstNameBox = (TextBox) FindControl("FirstNameBox");
            TextBox MiddleInitialBox = (TextBox)FindControl("MiddleInitialBox");
            TextBox LastNameBox = (TextBox)FindControl("LastNameBox");
            TextBox PhoneNumBox = (TextBox)FindControl("PhoneNumBox");
            TextBox StreetBox = (TextBox)FindControl("StreetBox");
            TextBox CityBox = (TextBox)FindControl("CityBox");
            DropDownList StateDropdown = (DropDownList)FindControl("StateDropdown");
            TextBox ZIPBox = (TextBox)FindControl("ZIPBox");
            TextBox UniversityTextBox = (TextBox)FindControl("UniversityTextBox");
            DropDownList DegreeDropdown = (DropDownList)FindControl("DegreeDropdown");
            DropDownList MajorDropdown = (DropDownList)FindControl("MajorDropdown");
            DropDownList MinorDropdown = (DropDownList)FindControl("MinorDropdown");
            TextBox GPABox = (TextBox) FindControl("GPABox");
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
            SqlCommand sqlComm = new SqlCommand();

            int emptyCount = 0;
            try
            {
                // Add SQL statement to update into database
                sqlComm = new SqlCommand(
                    "");


                // Add database parameters
                sqlComm.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = FirstNameBox.Text;
                sqlComm.Parameters.Add("@MI", System.Data.SqlDbType.Char).Value = MiddleInitialBox.Text;
                sqlComm.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = LastNameBox.Text;
                sqlComm.Parameters.Add("@PNum", System.Data.SqlDbType.VarChar).Value = PhoneNumBox.Text;
                sqlComm.Parameters.Add("@Street", System.Data.SqlDbType.VarChar).Value = StreetBox.Text;
                sqlComm.Parameters.Add("@State", System.Data.SqlDbType.VarChar).Value = StateDropdown.Text;
                sqlComm.Parameters.Add("@ZIP", System.Data.SqlDbType.Char).Value = ZIPBox.Text;
                sqlComm.Parameters.Add("@School", System.Data.SqlDbType.VarChar).Value = UniversityTextBox.Text;
                sqlComm.Parameters.Add("@Degree", System.Data.SqlDbType.VarChar).Value = DegreeDropdown.Text;
                sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar).Value = MajorDropdown.Text;
                sqlComm.Parameters.Add("@Minor", System.Data.SqlDbType.VarChar).Value = MinorDropdown.Text;
                // Graduation date
                DateTime dt;
                String currentText, currentText2;
                if (!((currentText = GradYearDropdown.Text).Equals("")) && !((currentText2 = GraduationMonth.Text).Equals("")))
                {
                    dt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), 0);
                    sqlComm.Parameters.Add("@GradDate", System.Data.SqlDbType.Date).Value = dt;
                }
                sqlComm.Parameters.Add("@GPA", System.Data.SqlDbType.Float).Value = Convert.ToDouble(GPABox.Text);
                sqlComm.Parameters.Add("@UEmail", System.Data.SqlDbType.VarChar).Value = UniversityEmailBox.Text;
                sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar).Value = EmployerBox.Text;
                sqlComm.Parameters.Add("@EmpTitle", System.Data.SqlDbType.VarChar).Value = EmployeeTitleBox.Text;
                sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = ScheduleBox.Text;
                sqlComm.Parameters.Add("@EmpCtctInf", System.Data.SqlDbType.VarChar).Value = EmployerContactInfoBox.Text;
                sqlComm.Parameters.Add("@EmpEmail", System.Data.SqlDbType.VarChar).Value = EmployerEmailBox.Text;
                // Employer start dates.
                DateTime dtt;
                string currentText3;
                if (!((currentText = EmployerStartDateDDDay.Text).Equals("")) && !((currentText2 = EmployerStartDateDDMonth.Text).Equals(""))
                    && ((currentText3 = EmployerStartDateDDDay.Text).Equals("")) )
                {
                    dtt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), Convert.ToInt32(currentText3));
                    sqlComm.Parameters.Add("@EmpStrtDt", System.Data.SqlDbType.Date).Value = dtt;
                }
                // Employer end date
                 DateTime dttt;
                if (!((currentText = EmployerEndDateYear.Text).Equals("")) && !((currentText2 = EmployerEndDateMonth.Text).Equals(""))
                    && ((currentText3 = EmployerEndDateDay.Text).Equals("")) )
                {
                    dttt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), Convert.ToInt32(currentText3));
                    sqlComm.Parameters.Add("@EmpEndDt", System.Data.SqlDbType.Date).Value = dttt;
                }
                sqlComm.Parameters.Add("@EmpHist", System.Data.SqlDbType.VarChar).Value = EmployerHistoryBox.Text;
                sqlComm.Parameters.Add("@EmpHistTitle", System.Data.SqlDbType.VarChar).Value = EmployerHistoryTitleBox.Text;
                sqlComm.Parameters.Add("@EmpHistEmail", System.Data.SqlDbType.VarChar).Value = EmployerHistoryEmailBox.Text;

                string sqlQuery = sqlComm.ToString();
                // Generate search query here as a session variable - will be passed to results page
                Session["EditQuery"] = sqlQuery;

                // Finally, if script is built, execute the non query.
                sqlComm.ExecuteNonQuery();

                // Close database connection and dispose database objects
                sqlComm.Dispose();

                // Redirect to success page
                Response.Redirect(EditUserButton.PostBackUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        } 
    }
}