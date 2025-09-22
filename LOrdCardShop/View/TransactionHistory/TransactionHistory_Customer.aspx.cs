using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.TransactionHistory
{
	public partial class TransactionHistory_Customer : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        TransactionDetailController tdc = new TransactionDetailController();
        CardController cdc = new CardController();
        TransactionHeaderController thc = new TransactionHeaderController();
        CartController ctc = new CartController();

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ac.CustomerAuthentication("~/View/TransactionHistory/TransactionHistory_Admin.aspx");
                LoadCards();
            }
            
        }
        protected void LoadCards()
        {
            int user_id = ac.getUser().UserID;
            transactionHistoryRepeater.DataSource = tdc.GetTransactionDetailsByUserIDAndHandled(user_id);
            transactionHistoryRepeater.DataBind();
        }

        protected string GetCardUrl(string card_name)
        {
            return cdc.GetCardUrl(card_name);
        }
        protected string GetCardNameByCardID(string card_id)
        {
            return cdc.GetCardByID(Convert.ToInt32(card_id)).CardName;
        }

        protected decimal GetPrice(string card_id, string quantity)
        {
            return cdc.GetCardPriceWithQuantity(card_id, quantity);
        }

        protected string GetDate(string transaction_id)
        {
            return thc.GetDate(transaction_id);
        }

        protected string GetQuantity(string quantity)
        {
            return ctc.GetQuantity(quantity);
        }

        protected void detail_button_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                Response.Redirect("~/View/TransactionDetailView/TransactionDetail_Customer.aspx?TransactionID=" + e.CommandArgument);
            }
        }
    }
}