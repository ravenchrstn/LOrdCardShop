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

namespace LOrdCardShop.View.CardView
{
	public partial class OrderCard : System.Web.UI.Page
	{
		AuthController ac = new AuthController();
		CardController cdc = new CardController();
		CartController ctc = new CartController();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                ac.CustomerAuthentication("~/View/Home/Home_Admin.aspx");
                string search = Request.QueryString["search"];
				LoadCards(search);
            }
        }

		protected void LoadCards(string search)
		{
            if (string.IsNullOrEmpty(search))
            {
                cardRepeater.DataSource = cdc.GetCards();
                cardRepeater.DataBind();
				return;
            }
            cardRepeater.DataSource = cdc.GetSpecificNameCards(search);
            cardRepeater.DataBind();

        }

		protected string GetCardUrl(string card_name)
		{
			return cdc.GetCardUrl(card_name);
		}

        protected void cart_detail_Command(object sender, CommandEventArgs e)
        {
            int card_id = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Detail")) Response.Redirect("~/View/CardView/CardDetail.aspx?CardID=" + card_id);
            else if (e.CommandName.Equals("Cart"))
			{
                int user_id = ac.getUser().UserID;
				Cart cart = ctc.GetCartByUserIDAndCardID(user_id, card_id);
				if (cart != null)
				{
					ctc.IncreaseQuantity(cart.CartID);
					return;
				}
				ctc.CreateCart(card_id, user_id);
			}
        }
    }
}