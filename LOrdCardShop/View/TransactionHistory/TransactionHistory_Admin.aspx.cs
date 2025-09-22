using LOrdCardShop.Controller;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.TransactionHistory
{
    public partial class TransactionHistory_Admin : System.Web.UI.Page
    {
        AuthController ac = new AuthController();
        TransactionDetailController tdc = new TransactionDetailController();
        TransactionHeaderController thc = new TransactionHeaderController();
        CardController cdc = new CardController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ac.AdminAuthentication("~/View/TransactionHistory/TransactionHistory_Customer.aspx");
                LoadCards();
            }
        }
        protected void LoadCards()
        {
            transactionHistoryRepeater.DataSource = tdc.GetTransactionDetails();
            transactionHistoryRepeater.DataBind();
        }

        protected string GetCardUrl(string card_name)
        {
            return cdc.GetCardUrl(card_name);
        }

        protected string GetCardNameByID(string id)
        {
            return cdc.GetCardByID(Convert.ToInt32(id)).CardName;
        }

        protected decimal GetPrice(string card_id, string quantity)
        {
            return cdc.GetCardByID(int.Parse(card_id)).CardPrice * int.Parse(quantity);
        }

        protected string GetDate(string transaction_id)
        {
            return thc.GetDate(transaction_id);
        }

        protected string GetQuantity(string quantity)
        {
            return tdc.GetQuantity(quantity);
        }

        protected void transaction_history_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                Response.Redirect("~/View/TransactionDetailView/TransactionDetail_Admin.aspx?TransactionID=" + e.CommandArgument.ToString());
            }
        }
    }
}