using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View.CardView
{
	public partial class ManageCard : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        CardController cdc = new CardController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ac.AdminAuthentication("~/View/Home/Home_Customer.aspx");
                string search = Request.QueryString["search"];
                LoadData(search);
            }
            
        }

        protected void LoadData(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                manageCardRepeater.DataSource = cdc.GetCards();
                manageCardRepeater.DataBind();
                return;
            }
            manageCardRepeater.DataSource = cdc.GetSpecificNameCards(search);
            manageCardRepeater.DataBind();
        }

        protected string GetCardUrl(string card_name)
        {
            return cdc.GetCardUrl(card_name);
        }

        protected string GetIsFoil(object is_foil)
        {
            if (is_foil is byte[] byteArray)
            {
                return cdc.GetIsFoil(byteArray);
            }
            return "";
        }

        protected void Action_Command(object source, CommandEventArgs e)
        {
            if (e.CommandName.Equals("Add")) Response.Redirect("~/View/CardView/AddCard.aspx");

            int card_id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Delete"))
            {
                cdc.DeleteCard(cdc.GetCardByID(card_id));
                Response.Redirect("~/View/CardView/ManageCard.aspx");
            } else if (e.CommandName.Equals("Update")) Response.Redirect("~/View/CardView/EditCard.aspx?CardID=" + card_id); 
        }
    }
}