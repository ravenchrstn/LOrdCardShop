using LOrdCardShop.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View
{
	public partial class LoginRegister : System.Web.UI.MasterPage
	{
		AuthController ac = new AuthController();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack && ac.Authenticated()) ac.RedirectHomeAccordingToUserRole(ac.getUser());
        }
	}
}