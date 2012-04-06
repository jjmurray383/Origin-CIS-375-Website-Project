using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
                for (int i = 1900; i <= year; i++)
                {
                    GradYearDropdown.Items.Add(i.ToString);
                    EmployerStartDateDDYear.Items.Add(i.ToString);
                    EmployerEndDateYear.Items.Add(i.ToString);
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

            // First verify that this user is unique
            TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");

            // Test if this is a unique DB entry
            Console.WriteLine(EmailTextBox.Text);
            SqlConnection dbConn = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();

            // Retrieve all the values from the registration form to insert into database
            TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
            TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
            TextBox UsernameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
            /*TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");

            MySqlConnection DBConn = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand DBCmd = new MySqlCommand();

            try
            {
                // Add Insert statement to insert into database
                DBCmd = new MySqlCommand(
                    "INSERT INTO userprofile(UID, Email, Fname, Lname)" +
                    "VALUES (@UID, @Email, @Fname, @Lname)", DBConn);

                // Add database parameters
                DBCmd.Parameters.Add("@UID", MySqlDbType.Int32).Value = newUserId;
                DBCmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = EmailTextBox.Text;
                DBCmd.Parameters.Add("@Fname", MySqlDbType.VarChar).Value = FirstNameTextBox.Text;
                DBCmd.Parameters.Add("@Lname", MySqlDbType.VarChar).Value = LastNameTextBox.Text;
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

            Response.Redirect(continueUrl); */

        }
    }
}
