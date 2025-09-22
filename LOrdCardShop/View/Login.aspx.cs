using LOrdCardShop.Controller;
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
	public partial class Login : System.Web.UI.Page
	{
		AuthController ac = new AuthController();
		UserController uc = new UserController();
		protected void Page_Load(object sender, EventArgs e)
		{
            
		}

		protected void submitButton_Click(object sender, EventArgs e)
		{
			string username = usernameInput.Text;
			string password = passwordInput.Text;
			bool remember_me = rememberMeCheckbox.Checked;

			User user = uc.GetUserByUsername(username);
            Authenticate(user, password, remember_me);
        }

		protected void Authenticate(User user, string password, bool remember_me)
		{
            if (user == null)
            {
                errorLogin.Text = "User not found";
                return;
            }

            if (user.UserPassword.Equals(password))
            {
                ac.SetUserSession(user);
                if (remember_me) ac.SetUserCookie(user.UserID);
                ac.RedirectHomeAccordingToUserRole(user);
                return;
            }
            errorLogin.Text = "Incorrect Password";
        }
    }
}