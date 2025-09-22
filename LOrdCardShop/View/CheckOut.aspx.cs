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
	public partial class CheckOut : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        CartController ctc = new CartController();
        CardController cdc = new CardController();
        TransactionDetailController tdc = new TransactionDetailController();
        TransactionHeaderController thc = new TransactionHeaderController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ac.CustomerAuthentication("~/View/Home/Home_Admin.aspx");
                CartLoad();
            }
        }

        protected void CartLoad()
        {
            int user_id = ac.getUser().UserID;
            checkOutRepeater.DataSource = ctc.GetCartsByUserID(user_id);
            checkOutRepeater.DataBind();
        }

        protected string GetCardName(string card_id)
        {
            return cdc.GetCardByID(int.Parse(card_id)).CardName;
        }

        protected string GetCardDescription(string card_id)
        {
            return cdc.GetCardByID(int.Parse(card_id)).CardDesc;
        }

        protected decimal GetCardPrice(string card_id)
        {
            return cdc.GetCardByID(int.Parse(card_id)).CardPrice;
        }

        protected string GetCardUrl(string card_id)
        {
            return cdc.GetCardUrl(cdc.GetCardByID(int.Parse(card_id)).CardName);
        }

        protected string GetQuantity(string quantity)
        {
            return ctc.GetQuantity(quantity);
        }

        protected void checkOutRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                int user_id = ac.getUser().UserID;
                Label totalPriceLabel = (Label)e.Item.FindControl("totalPrice");
                totalPriceLabel.Text = "Total Price: " + ctc.GetTotalPrice(user_id).ToString();
            }
        }

        protected void checkOutButton_Click(object sender, EventArgs e)
        {
            int user_id = ac.getUser().UserID;
            List<Cart> carts = ctc.GetCartsByUserID(user_id);
            foreach (Cart cart in carts)
            {
                TransactionHeader transactionHeader = thc.InsertTransactionHeaderByCart(cart);
                tdc.InsertTransactionDetailByCartAndTransactionHeader(cart, transactionHeader);

                ctc.DeleteCart(cart);
            }
            Response.Redirect("~/View/CartView.aspx");
        }
    }
}