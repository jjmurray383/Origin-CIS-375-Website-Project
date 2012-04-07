using System;
using System.Collections.Generic;
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

        protected void AddMember(object sender, EventArgs e)
        {

        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);

            // First verify that this user is unique; do this by finding the email and checking against DB
            TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
            string connectionString = "";
            SqlConnection DBConn = new SqlConnection(connectionString);
            SqlCommand DBCmd = new SqlCommand();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                // Add SQL statement to insert into database
                DBCmd = new SqlCommand(
                    "INSERT INTO userprofile(UID, Email, Fname, Lname)" +
                    "VALUES (@UID, @Email, @Fname, @Lname)", DBConn);

                // Add database parameters
                // DBCmd.Parameters.Add("@UID", System.Data.SqlDbType.Int).Value = newUserId;
                DBCmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                DBCmd.ExecuteNonQuery();
            }

            catch (Exception exp)
            {
                Response.Write(exp);
            }

            // Retrieve all the values from the registration form to insert into database
            TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
            TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
            TextBox UsernameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");

            

            try
            {
                // Add SQL statement to insert into database
                DBCmd = new SqlCommand(
                    "INSERT ");

                // Add database parameters
                // DBCmd.Parameters.Add("@UID", System.Data.SqlDbType.Int).Value = newUserId;
                DBCmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                DBCmd.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = FirstNameTextBox.Text;
                DBCmd.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = LastNameTextBox.Text;
                DBCmd.ExecuteNonQuery();
            }

            catch (Exception exp)
            {
                Response.Write(exp);
            }

            // Close database connection and dispose database objects
            DBCmd.Dispose();
            DBConn.Close();
            DBConn = null;

            Response.Redirect(continueUrl);

        }
    }
}
