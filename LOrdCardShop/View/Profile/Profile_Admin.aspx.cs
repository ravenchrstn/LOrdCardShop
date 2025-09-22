using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.Profile
{
	public partial class Profile_Admin : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ac.AdminAuthentication("~/View/Profile/Profile_Customer.aspx");

                User user = ac.getUser();
                usernameInput.Text = user.UserName;
                emailInput.Text = user.UserEmail;
                RadioButtonGender.SelectedValue = user.UserGender;
            }
            
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string username = usernameInput.Text;
            string email = emailInput.Text;
            string gender = RadioButtonGender.SelectedValue;

            errorUsername.Text = uc.ValidateUsername(username);
            errorEmail.Text = uc.ValidateEmail(email);
            errorGender.Text = uc.ValidateGender(gender);

            User user = ac.getUser();
            if (username.Equals(user.UserName)) errorUsername.Text = "";
            if (email.Equals(user.UserEmail)) errorEmail.Text = "";

            if (!errorUsername.Text.Equals("") || !errorEmail.Text.Equals("") || !errorGender.Text.Equals("")) return;

            uc.UpdateUser(user, username, email, gender);
            Response.Redirect("~/View/Home/Home_Admin.aspx");
        }
    }
}