using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.ChangePassword
{
	public partial class ChangePassword_Customer : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        UserController uc = new UserController();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack) ac.CustomerAuthentication("~/View/ChangePassword/ChangePassword_Admin.aspx");
        }

        protected void ValidationAndShowingErrorText(User user, string old_password, string new_password, string confirmation_password)
        {
            errorOldPassword.Text = uc.IsPasswordSame(user, old_password);
            errorNewPassword.Text = uc.ValidatePassword(new_password);
            errorConfirmationPassword.Text = uc.IsPasswordSame(new_password, confirmation_password);
        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            User user = ac.getUser();

            string old_password = oldPasswordInput.Text;
            string new_password = newPassowordInput.Text;
            string confirmation_password = confirmationPasswordInput.Text;

            ValidationAndShowingErrorText(user, old_password, new_password, confirmation_password);

            if (!errorOldPassword.Text.Equals("") || !errorNewPassword.Text.Equals("") || !errorConfirmationPassword.Text.Equals("")) return;

            uc.UpdateUserPassword(user, new_password);
            Response.Redirect("~/View/Profile/Profile_Customer.aspx");
        }
    }
}