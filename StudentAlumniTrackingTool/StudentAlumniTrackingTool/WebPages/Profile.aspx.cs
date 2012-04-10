using System;
using System.Collections.Generic;
using System.Configuration;
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
            string queryStr = Request.QueryString.ToString();
            SqlConnection sqlCon = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();

            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

            // Parse query string
            queryStr = Page.Request.QueryString["name"].ToString();

            // Assure user is themselves or is admin for edit purposes
            bool canEdit;
            if (User.Identity.Name.Equals(queryStr) || User.Identity.Name.Equals("admin") || User.Identity.Equals("admin2"))
                canEdit = true;
            else
                canEdit = false;

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
            sqlComm.BeginExecuteReader();

            // Return results will go here
            bool readOnly = !canEdit;

            // Populate with values
            FirstNameBox.Text = ""; // Some stuff to go here, can't leave it as just ""
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

            // Read only?
            FirstNameBox.ReadOnly = readOnly;
            MiddleInitialBox.ReadOnly = readOnly;
            LastNameBox.ReadOnly = readOnly;
            PhoneNumBox.ReadOnly = readOnly;
            StreetBox.ReadOnly = readOnly;
            CityBox.ReadOnly = readOnly;
            StateDropdown.Enabled = canEdit;
            ZIPBox.ReadOnly = readOnly;
            UniversityTextBox.ReadOnly = readOnly;
            DegreeDropdown.Enabled = canEdit;
            MajorDropdown.Enabled = canEdit;
            MinorDropdown.Enabled = canEdit;
            GPABox.ReadOnly = readOnly;
            GraduationMonth.Enabled = canEdit;
            GradYearDropdown.Enabled = canEdit;
            UniversityEmailBox.ReadOnly = readOnly;
            EmployerBox.ReadOnly = readOnly;
            EmployeeTitleBox.ReadOnly = readOnly;
            ScheduleBox.ReadOnly = readOnly;
            EmployerContactInfoBox.ReadOnly = readOnly;
            EmployerEmailBox.ReadOnly = readOnly;
            EmployerStartDateDDDay.Enabled = canEdit;
            EmployerStartDateDDMonth.Enabled = canEdit;
            EmployerStartDateDDYear.Enabled = canEdit;
            EmployerEndDateDay.Enabled = canEdit;
            EmployerEndDateMonth.Enabled = canEdit;
            EmployerEndDateYear.Enabled = canEdit;
            EmployerHistoryBox.ReadOnly = readOnly;
            EmployerHistoryTitleBox.ReadOnly = readOnly;

            // Finally, is edit button at bottom visible?
            EditUserButton.Enabled = canEdit;
            EditUserButton.Visible = canEdit;
        }

        protected void EditProfile(object sender, EventArgs e)
        {

            #region Database string arrays;
            string[] StudentDatabaseColumns = new string[] { "Fname", "Minit", "Lname", "Email", "Password", "PhoneNum" };
            string[] StudentAddressDatabaseColumns = new string[] { "Street", "State", "City", "ZipCode", "Email" };
            string[] EducationDatabaseColumns = new string[] { "SchoolName", "Major", "Degree", "GPA", "Minor", "GraduationDate", "Email" };
            string[] EmploymentDatabaseColumns = new string[] { "EmployerName", "EmployeeTitle", "Schedule", "ContactInformation", "Email" };
            string[] EmploymentHistoryDatabaseColumns = new string[] { "StartDate", "EndDate", "EmployerName", "EmployeeTitle", "Email" };
            #endregion Database string arrays;

            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string continueUrl = "~/Account/Success.aspx";
            //Response.Redirect(continueUrl);

            #region Verify Student email is unique;
            // First verify that this user is unique; do this by finding the email and checking against DB
            //TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
            SqlConnection DBConn = new SqlConnection(connectionString);
            SqlCommand DBCmd = new SqlCommand();
            SqlCommand sqlComm = new SqlCommand();
            SqlDataReader myReader = null;

            try
            {

                #region Editing Student entity;

                if (FirstNameBox.Text != "" && LastNameBox.Text != "")
                {
                    string insertQuery = "INSERT INTO STUDENT (";
                    for (int item = 0; item < StudentDatabaseColumns.Length; item++)
                    {

                        if (item == StudentDatabaseColumns.Length - 1)
                            insertQuery += StudentDatabaseColumns[item];
                        else
                            insertQuery += StudentDatabaseColumns[item] + ",";

                    }

                    insertQuery += ") VALUES (";
                    for (int item = 0; item < StudentDatabaseColumns.Length; item++)
                    {
                        if (item == StudentDatabaseColumns.Length - 1)
                            insertQuery += "@" + StudentDatabaseColumns[item];
                        else
                            insertQuery += "@" + StudentDatabaseColumns[item] + ",";
                    }
                    insertQuery += ");";
                    sqlComm = new SqlCommand(insertQuery, DBConn);


                    sqlComm.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = FirstNameBox.Text;
                    //sqlComm.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;

                    if (MiddleInitialBox.Text != "")
                        sqlComm.Parameters.Add("@Minit", System.Data.SqlDbType.Char).Value = MiddleInitialBox.Text;
                    sqlComm.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = LastNameBox.Text;
                    if (PhoneNumBox != null)
                        sqlComm.Parameters.Add("@PhoneNum", System.Data.SqlDbType.VarChar).Value = PhoneNumBox.Text;
                    DBConn.Open();
                    sqlComm.ExecuteNonQuery();
                }

                #endregion Editing Student entity;

                #region Editing Student_Address entity;
                //Start of Gathering Student Address Values

                if (StreetBox.Text != "" && CityBox.Text != "" && StateDropdown.SelectedValue != "--" && ZIPBox.Text != "")
                {
                    string insertQueryAddress = "INSERT INTO STUDENT_ADDRESS (";
                    for (int item = 0; item < StudentAddressDatabaseColumns.Length; item++)
                    {

                        if (item == StudentAddressDatabaseColumns.Length - 1)
                            insertQueryAddress += StudentAddressDatabaseColumns[item];
                        else
                            insertQueryAddress += StudentAddressDatabaseColumns[item] + ",";
                    }

                    insertQueryAddress += ") VALUES (";
                    for (int item = 0; item < StudentAddressDatabaseColumns.Length; item++)
                    {

                        if (item == StudentAddressDatabaseColumns.Length - 1)
                            insertQueryAddress += "@" + StudentAddressDatabaseColumns[item];
                        else
                            insertQueryAddress += "@" + StudentAddressDatabaseColumns[item] + ",";

                    }
                    insertQueryAddress += ");";
                    if (insertQueryAddress != "INSERT INTO STUDENT_ADDRESS () VALUES ();")
                    {
                        sqlComm = new SqlCommand(insertQueryAddress, DBConn);
                        //sqlComm.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
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
                }
                //Finished with adding Student_Address to database
                #endregion Editing Student_Address entity;

                #region Editing Education entity;
                //Starting with adding Education to database

                if (UniversityTextBox.Text != "" && DegreeDropdown.SelectedValue != "--" && MajorDropdown.SelectedValue != "--" &&
                                GPABox.Text != "" && GraduationMonth.SelectedValue != "--" && GradYearDropdown.SelectedValue != "--")
                {

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

                    insertQueryEducation += ") VALUES (";
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
                        //sqlComm.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                        if (UniversityTextBox.Text != null)
                            sqlComm.Parameters.Add("@SchoolName", System.Data.SqlDbType.VarChar).Value = UniversityTextBox.Text;
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
                            (currentText != "--") && (currentText2 != "--"))
                        {
                            //DateTime(Convert.ToInt32(currentText), Convert.ToInt32(currentText2), 0);
                            dt = new DateTime();
                            dt = DateTime.Parse(currentText + "/" + currentText2);
                            sqlComm.Parameters.Add("@GraduationDate", System.Data.SqlDbType.Date).Value = dt.ToShortDateString();
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
                }
                //Finished with adding Student_Address to database

                #endregion Editing Education entity;

                #region Editing Employment entity;
                //Starting with adding Employment to database

                if (EmployerBox.Text != "" && EmployeeTitleBox.Text != "" && ScheduleBox.Text != "" && EmployerContactInfoBox.Text != "")
                {
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
                        //sqlComm.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                        if (EmployerBox.Text != null)
                            sqlComm.Parameters.Add("@EmployerName", System.Data.SqlDbType.VarChar).Value = EmployerBox.Text;
                        if (EmployeeTitleBox.Text != null)
                            sqlComm.Parameters.Add("@EmployeeTitle", System.Data.SqlDbType.VarChar).Value = EmployeeTitleBox.Text;
                        if (ScheduleBox.Text != null)
                            sqlComm.Parameters.Add("@Schedule", System.Data.SqlDbType.VarChar).Value = ScheduleBox.Text;
                        if (EmployerContactInfoBox.Text != null)
                            sqlComm.Parameters.Add("@ContactInformation", System.Data.SqlDbType.VarChar).Value = EmployerContactInfoBox.Text;

                        sqlComm.ExecuteNonQuery();
                    }
                }
                //Finished Editing to Employment
                #endregion Editing Employment entity;


                #region Editing Employment_History entity;
                //Starting with adding Employment to database

                if (EmployerHistoryBox.Text != "" && EmployerHistoryTitleBox.Text != "" && ScheduleBox.Text != "" && EmployerContactInfoBox.Text != "")
                {
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
                                insertQueryEmploymentHistory += "@" + EmploymentDatabaseColumns[item];
                            else
                                insertQueryEmploymentHistory += "@" + EmploymentDatabaseColumns[item] + ",";
                        }
                    }
                    insertQueryEmploymentHistory += ");";
                    if (insertQueryEmploymentHistory != "INSERT INTO EMPLOYMENT () VALUES ();")
                    {
                        sqlComm = new SqlCommand(insertQueryEmploymentHistory, DBConn);
                        //sqlComm.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = EmailTextBox.Text;
                        if (EmployerBox.Text != null)
                            sqlComm.Parameters.Add("@EmployerName", System.Data.SqlDbType.VarChar).Value = EmployerBox.Text;
                        if (EmployeeTitleBox.Text != null)
                            sqlComm.Parameters.Add("@EmpLoyeeTitle", System.Data.SqlDbType.VarChar).Value = EmployeeTitleBox.Text;
                        // Employer start dates.
                        DateTime dtt;
                        string currentText3, currentTextEmpl, currentTextEmpl2;
                        if (((currentTextEmpl = EmployerStartDateDDDay.SelectedValue) != "--") && ((currentTextEmpl2 = EmployerStartDateDDMonth.SelectedValue) != "--")
                            && ((currentText3 = EmployerStartDateDDYear.SelectedValue) != "--"))
                        {
                            dtt = DateTime.Parse(currentTextEmpl + "/" + currentTextEmpl2 + "/" + EmployerStartDateDDYear);
                            sqlComm.Parameters.Add("@StartDate", System.Data.SqlDbType.Date).Value = dtt.ToShortDateString();
                        }
                        // Employer end date
                        DateTime dttt;
                        if (((currentTextEmpl = EmployerEndDateYear.SelectedValue) != "--") && ((currentTextEmpl2 = EmployerEndDateMonth.SelectedValue) != "--")
                            && ((currentText3 = EmployerEndDateDay.SelectedValue) != "--"))
                        {
                            dttt = DateTime.Parse(currentTextEmpl + "/" + currentTextEmpl2 + "/" + EmployerStartDateDDYear);
                            sqlComm.Parameters.Add("@EndDate", System.Data.SqlDbType.Date).Value = dttt.ToShortDateString();
                        }
                        sqlComm.ExecuteNonQuery();
                    }
                }
                #endregion Editing Employment_History entity;


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

#region Old Code;
/* Query the DB
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
} */

#endregion Old Code