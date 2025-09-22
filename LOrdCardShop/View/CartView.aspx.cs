using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View
{
	public partial class CartView : System.Web.UI.Page
	{

        AuthController ac = new AuthController();
        CartController ctc = new CartController();
        CardController cdc = new CardController();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                ac.CustomerAuthentication("~/View/Home/Home_Admin.aspx");
                CartLoad();
                disablingButtonsIfCartEmpy();
            }
		}

        protected void disablingButtonsIfCartEmpy()
        {
            int footerIndex = cartRepeater.Controls.Count - 1;
            RepeaterItem footerItem = (RepeaterItem) cartRepeater.Controls[footerIndex];

            System.Diagnostics.Debug.WriteLine("nilainya adalah: " + cartRepeater.Items.Count);

            if (footerItem != null && cartRepeater.Items.Count == 0)
            {
                Button checkOutButton = (Button) footerItem.FindControl("checkOutButton");
                checkOutButton.Enabled = false;
                checkOutButton.CssClass = "btn btn-secondary";
                
                Button clearCartButton = (Button)cartRepeater.Controls[0].FindControl("clearCartButton");
                clearCartButton.Enabled = false;
                clearCartButton.CssClass = "btn btn-secondary";
                return;
            }
        }

        protected List<Cart> CartLoad()
        {
            int user_id = ac.getUser().UserID;
            List<Cart> userCarts = ctc.GetCartsByUserID(user_id);
            cartRepeater.DataSource = userCarts;
            cartRepeater.DataBind();

            return userCarts;
        }

        protected void Quantity_Command(object sender, CommandEventArgs e)
        {
            int cartID = int.Parse(e.CommandArgument.ToString());
            int quantity = ctc.GetCartByID(cartID).Quantity;

            if (e.CommandName == "Increase")
            {
                quantity = ctc.IncreaseQuantity(cartID);
                CartLoad();
            }
            else if (e.CommandName == "Decrease")
            {
                quantity = ctc.DecreaseQuantity(cartID);
                if (quantity <= 0) ctc.DeleteCartByCartID(cartID);
                CartLoad();
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void SetQuantityLabel(object sender, int quantity)
        {
            Button button = (Button)sender;
            RepeaterItem ri = (RepeaterItem)button.NamingContainer;
            TextBox quantityTB = (TextBox)ri.FindControl("cardQuantity");
            quantityTB.Text = quantity.ToString();
        }

        protected string GetCardUrl(string card_id)
        {
            return cdc.GetCardUrl(cdc.GetCardByID(int.Parse(card_id)).CardName);
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

        protected void checkOutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CheckOut.aspx");
        }

        protected int getCartId(object sender)
        {
            TextBox quantityTB = (TextBox)sender;
            RepeaterItem ri = (RepeaterItem)quantityTB.NamingContainer;
            Button increaseButton = (Button)ri.FindControl("increase");
            int cart_id = Int32.Parse(increaseButton.CommandArgument.ToString());
            return cart_id;
        }

        protected void cardQuantity_TextChanged(object sender, EventArgs e)
        {
            int cart_id = getCartId(sender);
            ctc.ChangeQuantity(cart_id, Int32.Parse(((TextBox) sender).Text));
        }

        protected void clearCartButton_Click(object sender, EventArgs e)
        {
            int user_id = ac.getUser().UserID;
            ctc.DeleteCartsByUserId(user_id);
            Response.Redirect(Request.RawUrl);
        }
    }
}