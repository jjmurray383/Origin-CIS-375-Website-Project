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

            // Assure user is not already logged in
            if (User.Identity.IsAuthenticated == true)
                Response.Redirect("RegisterError.aspx");

            if (!IsPostBack)
            {
                int year = System.DateTime.Now.Year;
                year += 10; // Add for current students who don't graduate this year but in the next few coming years.
                DropDownList GradYear = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("GradYearDropdown");
                DropDownList EmployerStartYear = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("EmployerStartDateDDYear");
                DropDownList EmployerEndYear = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("EmployerEndDateYear");
                for (int i = 1900; i <= year; i++)
                {
                    ListItem yearItem = new ListItem(i.ToString(), i.ToString(), true);
                    GradYear.Items.Add(yearItem);
                    EmployerStartYear.Items.Add(yearItem);
                    EmployerEndYear.Items.Add(yearItem);
                }
                GradYear.DataBind();
                EmployerStartYear.DataBind();
                EmployerEndYear.DataBind();
            }
        }


        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {

            bool addSuccess = false;

        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            #region Database string arrays;
            string[] StudentDatabaseColumns = new string[] { "Fname", "Minit", "Lname", "Email", "Password", "PhoneNum" };
            string[] StudentAddressDatabaseColumns = new string[] { "Street", "State", "City", "ZipCode", "Email" };
            string[] EducationDatabaseColumns = new string[] { "SchoolName", "Major", "Degree", "GPA", "Minor", "GraduationDate", "Email" };
            string[] EmploymentDatabaseColumns = new string[] { "EmployerName", "EmployeeTitle", "Schedule", "ContactInformation", "Email" };
            string[] EmploymentHistoryDatabaseColumns = new string[] { "StartDate", "EndDate", "EmployerName", "EmployeeTitle", "Email" };
            #endregion Database string arrays;

            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //string continueUrl = "Success.aspx";
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/Account/Success.aspx";
            }
            //Response.Redirect(continueUrl);

            #region Verify Student email is unique;
            // First verify that this user is unique; do this by finding the email and checking against DB
            TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
            SqlConnection DBConn = new SqlConnection(connectionString);
            SqlCommand DBCmd = new SqlCommand();
            SqlCommand sqlComm = new SqlCommand();
            SqlDataReader myReader = null;

            try
            {
                DBConn.Open();
                // Add SQL statement to insert into database
                DBCmd = new SqlCommand(
                "SELECT Email FROM STUDENT " +
                    "WHERE Email = @Email;", DBConn);

                // Add database parameters
                // DBCmd.Parameters.Add("@UID", System.Data.SqlDbType.Int).Value = newUserId;

                // Add database parameters
                DBCmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                myReader = DBCmd.ExecuteReader();
                /*
                 * Run query here. If email found in database, user is making duplicate. Stop.
                 */
                if (myReader.Read())
                {
                    Response.Redirect("RegisterError.aspx");
                }
                else
                {
                    myReader.Close();
                    DBConn.Close();

#endregion Verify Student email is unique;

            #region Adding Student entity;

                    TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstNameBox");
                    TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastNameBox");
                    TextBox UsernameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
                    TextBox PasswordBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password");
                    TextBox MiddleInitialBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("MiddleInitialBox");
                    TextBox LastNameBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastNameBox");
                    TextBox PhoneNumBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("PhoneNumBox");

                    string insertQuery = "INSERT INTO STUDENT (";
                    for (int item = 0; item < StudentDatabaseColumns.Length; item++)
                    {
                        if (StudentDatabaseColumns[item] != "")
                        {
                            if (item == StudentDatabaseColumns.Length - 1)
                                insertQuery += StudentDatabaseColumns[item];
                            else
                                insertQuery += StudentDatabaseColumns[item] + ",";
                        }
                    }

                    insertQuery += ") VALUES (";
                    for (int item = 0; item < StudentDatabaseColumns.Length; item++)
                    {
                        if (StudentDatabaseColumns[item] != "")
                        {
                            if (item == StudentDatabaseColumns.Length - 1)
                                insertQuery += "@" + StudentDatabaseColumns[item];
                            else
                                insertQuery += "@" + StudentDatabaseColumns[item] + ",";
                        }
                    }
                    insertQuery += ");";
                    sqlComm = new SqlCommand(insertQuery, DBConn);


                    sqlComm.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = FirstNameTextBox.Text;
                    sqlComm.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;

                    if (MiddleInitialBox.Text != "")
                        sqlComm.Parameters.Add("@Minit", System.Data.SqlDbType.Char).Value = MiddleInitialBox.Text;
                    sqlComm.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = LastNameBox.Text;
                    sqlComm.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = PasswordBox.Text;
                    if (PhoneNumBox != null)
                        sqlComm.Parameters.Add("@PhoneNum", System.Data.SqlDbType.VarChar).Value = PhoneNumBox.Text;
                    DBConn.Open();
                    sqlComm.ExecuteNonQuery();
                }
#endregion Adding Student entity;

            #region Adding Student_Address entity;
                //Start of Gathering Student Address Values
                TextBox StreetBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("StreetBox");
                TextBox CityBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("CityBox");
                DropDownList StateDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("StateDropdown");
                TextBox ZIPBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ZIPBox");

                string insertQueryAddress = "INSERT INTO STUDENT_ADDRESS (";
                for (int item = 0; item < StudentAddressDatabaseColumns.Length; item++)
                {
                    if (StudentAddressDatabaseColumns[item] != "")
                    {
                        if (item == StudentAddressDatabaseColumns.Length - 1)
                            insertQueryAddress += StudentAddressDatabaseColumns[item];
                        else
                            insertQueryAddress += StudentAddressDatabaseColumns[item] + ",";
                    }
                }

                insertQueryAddress += ") VALUES (";
                for (int item = 0; item < StudentAddressDatabaseColumns.Length; item++)
                {
                    if (StudentAddressDatabaseColumns[item] != "")
                    {
                        if (item == StudentAddressDatabaseColumns.Length - 1)
                            insertQueryAddress += "@" + StudentAddressDatabaseColumns[item];
                        else
                            insertQueryAddress += "@" + StudentAddressDatabaseColumns[item] + ",";
                    }
                }
                insertQueryAddress += ");";
                if (insertQueryAddress != "INSERT INTO STUDENT_ADDRESS () VALUES ();")
                {
                    sqlComm = new SqlCommand(insertQueryAddress, DBConn);

                    if (StreetBox.Text != null)
                        sqlComm.Parameters.Add("@Street", System.Data.SqlDbType.VarChar).Value = StreetBox.Text;
                    if (StateDropdown.Text != null)
                        sqlComm.Parameters.Add("@State", System.Data.SqlDbType.VarChar).Value = StateDropdown.Text;
                    if (CityBox.Text != null)
                        sqlComm.Parameters.Add("@City", System.Data.SqlDbType.VarChar).Value = CityBox.Text;
                    if (ZIPBox.Text != null)
                        sqlComm.Parameters.Add("@ZipCode", System.Data.SqlDbType.Char).Value = ZIPBox.Text;
                    sqlComm.ExecuteNonQuery();
                }
                //Finished with adding Student_Address to database
#endregion Adding Student_Address entity;

            #region Adding Education entity;
                //Starting with adding Education to database
                TextBox UniversityTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UniversityTextBox");
                DropDownList DegreeDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("DegreeDropdown");
                DropDownList MajorDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("MajorDropdown");
                DropDownList MinorDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("MinorDropdown");
                TextBox GPABox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("GPABox");
                DropDownList GraduationMonth = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("GraduationMonth");
                DropDownList GradYearDropdown = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("GradYearDropdown");

                string insertQueryEducation = "INSERT INTO EDUCATION (";
                for (int item = 0; item < EducationDatabaseColumns.Length; item++)
                {
                    if (EducationDatabaseColumns[item] != "")
                    {
                        if (item == EducationDatabaseColumns.Length - 1)
                            insertQueryEducation += EducationDatabaseColumns[item];
                        else
                            insertQueryEducation += EducationDatabaseColumns[item] + ",";
                    }
                }

                insertQueryAddress += ") VALUES (";
                for (int item = 0; item < EducationDatabaseColumns.Length; item++)
                {
                    if (EducationDatabaseColumns[item] != "")
                    {
                        if (item == EducationDatabaseColumns.Length - 1)
                            insertQueryEducation += "@" + EducationDatabaseColumns[item];
                        else
                            insertQueryEducation += "@" + EducationDatabaseColumns[item] + ",";
                    }
                }
                insertQueryEducation += ");";
                if (insertQueryEducation != "INSERT INTO EDUCATION () VALUES ();")
                {
                    sqlComm = new SqlCommand(insertQueryEducation, DBConn);
                    if (UniversityTextBox.Text != null)
                        sqlComm.Parameters.Add("@School", System.Data.SqlDbType.VarChar).Value = UniversityTextBox.Text;
                    if (DegreeDropdown.Text != null)
                        sqlComm.Parameters.Add("@Degree", System.Data.SqlDbType.VarChar).Value = DegreeDropdown.Text;
                    if (MajorDropdown.Text != null)
                        sqlComm.Parameters.Add("@Major", System.Data.SqlDbType.VarChar).Value = MajorDropdown.Text;
                    if (MinorDropdown.Text != null)
                        sqlComm.Parameters.Add("@Minor", System.Data.SqlDbType.VarChar).Value = MinorDropdown.Text;
                    // Graduation date
                    DateTime dt;
                    String currentText, currentText2;
                    currentText = GradYearDropdown.SelectedValue;
                    currentText2 = GraduationMonth.SelectedValue;
                    if ((currentText != null) && (currentText2 != null) &&
                        (currentText != "--") && (currentText2 != "--") )
                    {
                        dt = new DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), 0);
                        sqlComm.Parameters.Add("@GradDate", System.Data.SqlDbType.Date).Value = dt.ToString();
                    }
                    if (GPABox.Text != null)
                        try
                        {
                            sqlComm.Parameters.Add("@GPA", System.Data.SqlDbType.Float).Value = Convert.ToDouble(GPABox.Text);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString());
                            // Do nothing
                        }

                    sqlComm.ExecuteNonQuery();
                }
                //Finished with adding Student_Address to database

#endregion Adding Education entity;

            #region Adding Employment entity;
                //Starting with adding Employment to database
                TextBox EmployerBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerBox");
                TextBox EmployeeTitleBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployeeTitleBox");
                TextBox ScheduleBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ScheduleBox");
                TextBox EmployerContactInfoBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerContactInfoBox");

                string insertQueryEmployment = "INSERT INTO EMPLOYMENT (";
                for (int item = 0; item < EmploymentDatabaseColumns.Length; item++)
                {
                    if (EmploymentDatabaseColumns[item] != "")
                    {
                        if (item == EmploymentDatabaseColumns.Length - 1)
                            insertQueryEmployment += EmploymentDatabaseColumns[item];
                        else
                            insertQueryEmployment += EmploymentDatabaseColumns[item] + ",";
                    }
                }

                insertQueryEmployment += ") VALUES (";
                for (int item = 0; item < EmploymentDatabaseColumns.Length; item++)
                {
                    if (EmploymentDatabaseColumns[item] != "")
                    {
                        if (item == EmploymentDatabaseColumns.Length - 1)
                            insertQueryEmployment += "@" + EmploymentDatabaseColumns[item];
                        else
                            insertQueryEmployment += "@" + EmploymentDatabaseColumns[item] + ",";
                    }
                }
                insertQueryEmployment += ");";
                if (insertQueryEmployment != "INSERT INTO EMPLOYMENT () VALUES ();")
                {
                    sqlComm = new SqlCommand(insertQueryEmployment, DBConn);
                    if (EmployerBox.Text != null)
                        sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar).Value = EmployerBox.Text;
                    if (EmployeeTitleBox.Text != null)
                        sqlComm.Parameters.Add("@EmpTitle", System.Data.SqlDbType.VarChar).Value = EmployeeTitleBox.Text;
                    if (ScheduleBox.Text != null)
                        sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = ScheduleBox.Text;
                    if (EmployerContactInfoBox.Text != null)
                        sqlComm.Parameters.Add("@EmpCtctInf", System.Data.SqlDbType.VarChar).Value = EmployerContactInfoBox.Text;

                    sqlComm.ExecuteNonQuery();
                }
                //Finished Adding to Employment
#endregion Adding Employment entity;


                #region Adding Employment_History entity;
                //Starting with adding Employment to database
                DropDownList EmployerStartDateDDDay = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerStartDateDDDay");
                DropDownList EmployerStartDateDDMonth = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerStartDateDDMonth");
                DropDownList EmployerStartDateDDYear = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerStartDateDDYear");
                DropDownList EmployerEndDateDay = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEndDateDay");
                DropDownList EmployerEndDateMonth = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEndDateMonth");
                DropDownList EmployerEndDateYear = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerEndDateYear");
                TextBox EmployerHistoryBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerHistoryBox");
                TextBox EmployerHistoryTitleBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerHistoryTitleBox");
                TextBox EmployerHistoryEmailBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("EmployerHistoryEmailBox");

                string insertQueryEmploymentHistory = "INSERT INTO EMPLOYMENT (";
                for (int item = 0; item < EmploymentHistoryDatabaseColumns.Length; item++)
                {
                    if (EmploymentHistoryDatabaseColumns[item] != "")
                    {
                        if (item == EmploymentHistoryDatabaseColumns.Length - 1)
                            insertQueryEmploymentHistory += EmploymentHistoryDatabaseColumns[item];
                        else
                            insertQueryEmploymentHistory += EmploymentHistoryDatabaseColumns[item] + ",";
                    }
                }

                insertQueryEmploymentHistory += ") VALUES (";
                for (int item = 0; item < EmploymentDatabaseColumns.Length; item++)
                {
                    if (EmploymentDatabaseColumns[item] != "")
                    {
                        if (item == EmploymentDatabaseColumns.Length - 1)
                            insertQueryEmployment += "@" + EmploymentDatabaseColumns[item];
                        else
                            insertQueryEmployment += "@" + EmploymentDatabaseColumns[item] + ",";
                    }
                }
                insertQueryEmployment += ");";
                if (insertQueryEmployment != "INSERT INTO EMPLOYMENT () VALUES ();")
                {
                    sqlComm = new SqlCommand(insertQueryEmployment, DBConn);
                    if (EmployerBox.Text != null)
                        sqlComm.Parameters.Add("@Employer", System.Data.SqlDbType.VarChar).Value = EmployerBox.Text;
                    if (EmployeeTitleBox.Text != null)
                        sqlComm.Parameters.Add("@EmpTitle", System.Data.SqlDbType.VarChar).Value = EmployeeTitleBox.Text;
                    if (ScheduleBox.Text != null)
                        sqlComm.Parameters.Add("@Sched", System.Data.SqlDbType.VarChar).Value = ScheduleBox.Text;
                    if (EmployerContactInfoBox.Text != null)
                        sqlComm.Parameters.Add("@EmpCtctInf", System.Data.SqlDbType.VarChar).Value = EmployerContactInfoBox.Text;
                    // Employer start dates.
                    DateTime dtt;
                    string currentText3, currentTextEmpl, currentTextEmpl2;
                    if (((currentTextEmpl = EmployerStartDateDDDay.SelectedValue) != "--") && ((currentTextEmpl2 = EmployerStartDateDDMonth.SelectedValue) != "--")
                        && ((currentText3 = EmployerStartDateDDDay.SelectedValue) != "--"))
                    {
                        dtt = new DateTime(Convert.ToInt32(currentTextEmpl), Convert.ToInt32(currentTextEmpl2), Convert.ToInt32(currentText3));
                        sqlComm.Parameters.Add("@EmpStrtDt", System.Data.SqlDbType.Date).Value = dtt;
                    }
                    // Employer end date
                    DateTime dttt;
                    if (((currentTextEmpl = EmployerEndDateYear.SelectedValue) != "--") && ((currentTextEmpl2 = EmployerEndDateMonth.SelectedValue) != "--")
                        && ((currentText3 = EmployerEndDateDay.SelectedValue) != "--"))
                    {
                        dttt = new DateTime(Convert.ToInt32(currentTextEmpl), Convert.ToInt32(currentTextEmpl2), Convert.ToInt32(currentText3));
                        sqlComm.Parameters.Add("@EmpEndDt", System.Data.SqlDbType.Date).Value = dttt;
                    }
                    if (EmployerHistoryBox.Text != null)
                        sqlComm.Parameters.Add("@EmpHist", System.Data.SqlDbType.VarChar).Value = EmployerHistoryBox.Text;
                    if (EmployerHistoryTitleBox.Text != null)
                        sqlComm.Parameters.Add("@EmpHistTitle", System.Data.SqlDbType.VarChar).Value = EmployerHistoryTitleBox.Text;
                    if (EmployerHistoryEmailBox.Text != null)
                        sqlComm.Parameters.Add("@EmpHistEmail", System.Data.SqlDbType.VarChar).Value = EmployerHistoryEmailBox.Text;
                    sqlComm.ExecuteNonQuery();
                }
                #endregion Adding Employment_History entity;
                
                Roles.AddUserToRole(EmailTextBox.Text, "users");

                // Set cookie (mmm, cookies...)
                FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

                // Close database connection and dispose database objects
                DBCmd.Dispose();
                DBConn.Close();
                DBConn = null;

                Response.Redirect(continueUrl);

            }
            catch (Exception exp)
            {
                Response.Write(exp);
            }
        }
    }
}
