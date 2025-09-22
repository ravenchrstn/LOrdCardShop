using LOrdCardShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View
{
	public partial class HandleTransaction : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        CardController cdc = new CardController();
        TransactionHeaderController thc = new TransactionHeaderController();
        TransactionDetailController tdc = new TransactionDetailController();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ac.AdminAuthentication("~/View/Home/Home_Customer.aspx");
                LoadData();
            }

		}

        protected void LoadData()
        {
            handleTransactionRepeater.DataSource = tdc.GetTransactionDetailsByUnhandled();
            handleTransactionRepeater.DataBind();
        }

        protected string GetStatus(string transaction_id)
        {
            return thc.GetTransactionHeaderByID(int.Parse(transaction_id)).Status;
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

        protected void handleTransactionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string transaction_id = DataBinder.Eval(e.Item.DataItem, "TransactionID").ToString();
                string status = GetStatus(transaction_id);
                Button button = (Button)e.Item.FindControl("handle_button");
                if (status.Equals("Handled")) button.Visible = false;
            }
        }

        protected void handleTransactionRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Handle"))
            {
                thc.ChangeStatusToHandled(int.Parse(e.CommandArgument.ToString()));
                Button button = (Button) e.CommandSource;
                button.Visible = false;
                LoadData();
            }
        }
    }
}