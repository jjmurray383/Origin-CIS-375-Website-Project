using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace StudentAlumniTrackingTool.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

            if (!IsPostBack)
            {
                int year = System.DateTime.Now.Year;
                year += 10; // Add for current students who don't graduate this year but in the next few coming years.
                DropDownList GradYear = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("GradYearDropdown");
                DropDownList EmployerStartYear = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("EmployerStartDateDDYear");
                DropDownList EmployerEndYear = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("EmployerEndDateYear");
                for (int i = 1900; i <= year; i++)
                {
                    ListItem yearItem = new ListItem(i.ToString());
                    GradYear.Items.Add(yearItem);
                    EmployerStartYear.Items.Add(yearItem);
                    EmployerEndYear.Items.Add(yearItem);
                }
            }
        }


        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
           
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            //Response.Redirect(continueUrl);


            // First verify that this user is unique; do this by finding the email and checking against DB
            TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
            SqlConnection DBConn = new SqlConnection(connectionString);
            SqlCommand DBCmd = new SqlCommand();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                DBConn.Open();
                // Add SQL statement to insert into database
                DBCmd = new SqlCommand(
                "INSERT INTO STUDENT(Email, Fname, Lname)" +
                    "VALUES (@UID, @Email, @Fname, @Lname)", DBConn);

                // Add database parameters
                // DBCmd.Parameters.Add("@UID", System.Data.SqlDbType.Int).Value = newUserId;

                // Add database parameters
                DBCmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                /*
                 * Run query here. If email found in database, user is making duplicate. Stop.
                 */
                DBCmd.ExecuteNonQuery();
                /* if (found == true) {
                    Response.Redirect("RegisterError.aspx");
                 } */

            }

            catch (Exception exp)
            {
                Response.Write(exp);
            }
            // Gather all fields - user may have them all entered
            TextBox PasswordBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password");
            TextBox MiddleInitialBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("MiddleInitialBox");
            TextBox LastNameBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastNameBox");
            TextBox PhoneNumBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("PhoneNumBox");
            TextBox StreetBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("StreetBox");
            TextBox CityBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("CityBox");
            DropDownList StateDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("StateDropdown");
            TextBox ZIPBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ZIPBox");
            TextBox UniversityTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UniversityTextBox");
            DropDownList DegreeDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("DegreeDropdown");
            DropDownList MajorDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("MajorDropdown");
            DropDownList MinorDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("MinorDropdown");
            TextBox GPABox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("GPABox");
            DropDownList GraduationMonth = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("GraduationMonth");
            DropDownList GradYearDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("GradYearDropdown");
            TextBox UniversityEmailBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UniversityEmailBox");
            TextBox EmployerBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerBox");
            TextBox EmployeeTitleBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployeeTitleBox");
            TextBox ScheduleBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ScheduleBox");
            TextBox EmployerContactInfoBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerContactInfoBox");
            TextBox EmployerEmailBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEmailBox");
            DropDownList EmployerStartDateDDDay = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerStartDateDDDay");
            DropDownList EmployerStartDateDDMonth = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerStartDateDDMonth");
            DropDownList EmployerStartDateDDYear = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerStartDateDDYear");
            DropDownList EmployerEndDateDay = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEndDateDay");
            DropDownList EmployerEndDateMonth = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEndDateMonth");
            DropDownList EmployerEndDateYear = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEndDateYear");
            TextBox EmployerHistoryBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerHistoryBox");
            TextBox EmployerHistoryTitleBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerHistoryTitleBox");
            TextBox EmployerHistoryEmailBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerHistoryEmailBox");

            // Retrieve all the values from the registration form to insert into database
            TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
            TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
            TextBox UsernameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");

            sqlComm.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = FirstNameTextBox.Text;
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
                && ((currentText3 = EmployerStartDateDDDay.Text).Equals("")))
            {
                dtt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), Convert.ToInt32(currentText3));
                sqlComm.Parameters.Add("@EmpStrtDt", System.Data.SqlDbType.Date).Value = dtt;
            }
            // Employer end date
            DateTime dttt;
            if (!((currentText = EmployerEndDateYear.Text).Equals("")) && !((currentText2 = EmployerEndDateMonth.Text).Equals(""))
                && ((currentText3 = EmployerEndDateDay.Text).Equals("")))
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


            // Close database connection and dispose database objects
            DBCmd.Dispose();
            DBConn.Close();
            DBConn = null;

            Response.Redirect(continueUrl);

        }
    }
}
