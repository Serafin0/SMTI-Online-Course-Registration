using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMTI_Online_Course_Registration.BLL;
using SMTI_Online_Course_Registration.DAL;

namespace SMTI_Online_Course_Registration.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve the user input for user code and password
            string userCode = txtUserCode.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate if the user code and password fields are not empty
            if (string.IsNullOrEmpty(userCode) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both User Code and Password.";
                return;
            }

            // Validate user credentials using the User BLL
            bool isValidUser = SMTI_Online_Course_Registration.BLL.User.ValidateUser(userCode, password);

            if (isValidUser)
            {
                // Assuming we store the logged-in user's details in a session variable
                Session["userCode"] = userCode;

                // Redirect to the main student dashboard or course list after successful login
                Response.Redirect("~/GUI/RegisterCourses.aspx");
            }
            else
            {
                // Display error message if user credentials are incorrect
                lblMessage.Text = "Invalid User Code or Password.";
                txtUserCode.Text = "";
                txtPassword.Text = "";
                txtUserCode.Focus();
            }
        }

    }
}