using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop
{
	public partial class CustomerMaster : System.Web.UI.MasterPage
	{

        AuthController ac = new AuthController();
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void logout_Click(object sender, EventArgs e)
        {
            ac.AbandonSession();
            ac.RemoveAllCookies();
            Response.Redirect("~/View/Login.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string card_name = searchBox.Text;
            Response.Redirect("~/View/CardView/OrderCard.aspx?search=" + card_name);
        }
    }
}