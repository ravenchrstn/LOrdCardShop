using LOrdCardShop.Controller;
using LOrdCardShop.Factory;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View
{
	public partial class Register : System.Web.UI.Page
	{
        UserController uc = new UserController();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                RadioButtonGender.SelectedValue = "Male";
                RadioButtonRole.SelectedValue = "Customer";
            }
		}

        protected void Validate(string username, string email, string password, DateTime DOB, string gender, string confirmation_password, string role)
        {
            errorUsername.Text = uc.ValidateUsername(username);
            errorEmail.Text = uc.ValidateEmail(email);
            errorPassword.Text = uc.ValidatePassword(password);
            errorDOB.Text = uc.ValidateDOB(DOB);
            errorGender.Text = uc.ValidateGender(gender);
            errorConfirmation.Text = uc.ValidateConfirmationPassword(confirmation_password, password);
            errorRole.Text = uc.ValidateRole(role);
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string username = usernameInput.Text;
            string email = emailInput.Text;
            string password = passwordInput.Text;
            DateTime DOB = calendarInput.VisibleDate;
            string gender = RadioButtonGender.SelectedValue;
            string confirmation_password = confirmationPasswordInput.Text;
            string role = RadioButtonRole.SelectedValue;

            Validate(username, email, password, DOB, gender, confirmation_password, role);
            System.Diagnostics.Debug.WriteLine("dobnya adalah " + DOB);
            if (!errorRole.Text.Equals("") || !errorUsername.Text.Equals("") || !errorPassword.Text.Equals("") || !errorDOB.Text.Equals("") || !errorConfirmation.Text.Equals("") || !errorRole.Text.Equals("")) return;

            uc.CreateUser(username, email, password, gender, confirmation_password, role);
            Response.Redirect("~/View/Login.aspx");
        }
	}
}