using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.TransactionDetailView
{
	public partial class TransactionDetail_Admin : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        TransactionHeaderController thc = new TransactionHeaderController();
        TransactionDetailController tdc = new TransactionDetailController();
        CardController cdc = new CardController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ac.AdminAuthentication("~/View/TransactionHistory/TransactionHistory_Customer.aspx");
                DataLoad();
            }
        }

        protected void DataLoad()
        {
            int transaction_id = Convert.ToInt32(Request.QueryString["TransactionID"]);
            TransactionHeader th = thc.GetTransactionHeaderByID(transaction_id);
            TransactionDetail td = tdc.GetTransactionDetailByTransactionID(transaction_id);
            Card card = cdc.GetCardByID(td.CardID);
            ShowData(th, td, card);
        }

        protected void ShowData(TransactionHeader th, TransactionDetail td, Card card)
        {
            card_image.ImageUrl = GetCardUrl(card.CardName);
            name_value.Text = card.CardName;
            price_value.Text = card.CardPrice.ToString();
            description_value.Text = card.CardDesc;
            type_value.Text = card.CardType;
            is_foil_value.Text = card.isFoil.ToString() == "1" ? "Yes" : "No";
            quantity_value.Text = td.Quantity.ToString();
            transaction_date.Text = th.TransactionDate.ToString();
            status.Text = th.Status;
            total_price_value.Text = (card.CardPrice * td.Quantity).ToString();
        }

        protected string GetDateFormat(DateTime date)
        {
            return thc.GetDate(date);
        }

        protected string GetCardUrl(string card_name)
        {
            return cdc.GetCardUrl(card_name);
        }

        protected void back_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionHistory/TransactionHistory_Admin.aspx");
        }
    }
}