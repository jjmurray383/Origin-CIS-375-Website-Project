using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace StudentAlumniTrackingTool.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string FindEmail = this.LoginUser.UserName;
            SqlConnection DBConn = new SqlConnection(connectionString);
            SqlCommand DBCmd = new SqlCommand();
            SqlDataReader myReader = null;

            if (FindEmail == "admin")
            {
                if (this.LoginUser.Password == "12345678")
                {
                    User.IsInRole("admins");
                    //success
                }
                else
                ;
                //fail
            }

            try
            {
                DBConn.Open();
                // Add SQL statement to insert into database
                DBCmd = new SqlCommand(
                "SELECT Password FROM STUDENT " +
                    "WHERE Email = @Email;", DBConn);

                DBCmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = FindEmail;
                myReader = DBCmd.ExecuteReader();
                if(myReader.Read())
                {
                    if (this.LoginUser.Password == myReader[0].ToString())
                    {
                        //WHERE DO I GO ONCE I SUCCESSFULLY LOG IN???
                        FormsAuthentication.SetAuthCookie(FindEmail, false /* createPersistentCookie */);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        //INCORRECT PASSWORD BRO
                    }
                }
                else
                {
                    //GENERAL FAILED TO DO ANYTHING
                }
                DBConn.Close();

            }
            catch (Exception exp)
            {
                Response.Write(exp);
            }
            
        }
    }
}
