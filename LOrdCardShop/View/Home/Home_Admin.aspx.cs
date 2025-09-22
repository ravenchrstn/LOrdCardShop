using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.Home
{
	public partial class Home_Admin : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ac.AdminAuthentication("~/View/Home/Home_Customer.aspx");
                User user_cookie = ac.GetUserCookie();
                User user_session = ac.GetUserSession();

                if (user_session == null && user_cookie == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }

                User user = null;
                if (user_session != null)
                {
                    user = ac.GetUserSession();
                }
                else if (user_cookie != null)
                {
                    user = ac.GetUserCookie();
                    if (user_session == null) ac.SetUserSession(user);
                }

                if (user.UserRole.Equals("Customer")) Response.Redirect("~/View/Home/Home_Customer.aspx");

                greetingLabel.Text = "Hello, " + user.UserName;
            }
        }
	}
}