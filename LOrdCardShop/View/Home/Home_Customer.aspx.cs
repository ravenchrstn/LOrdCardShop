using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.Home
{
	public partial class Home_Customer : System.Web.UI.Page
	{
		AuthController ac = new AuthController();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                ac.CustomerAuthentication("~/View/Home/Home_Admin.aspx");

                User user = ac.getUser();
                greetingLabel.Text = "Hello, " + user.UserName;
            }
        }
	}
}