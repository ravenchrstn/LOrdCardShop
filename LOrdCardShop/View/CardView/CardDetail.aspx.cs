using LOrdCardShop.Controller;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;


namespace LOrdCardShop.View.CardView
{
	public partial class CardDetail : System.Web.UI.Page
	{

        AuthController ac = new AuthController();
        CardController crc = new CardController();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                ac.CustomerAuthentication("~/View/Home/Home_Admin.aspx");
                if (!int.TryParse(Request.QueryString["CardID"], out int card_id)) Response.Redirect("~/View/Home/Home_Customer.aspx");
                LoadData(card_id);
                return;
            }
        }

        protected void LoadData(int card_id)
        {
            Card card = crc.GetCardByID(card_id);
            card_image.ImageUrl = GetCardUrl(card.CardName);
            name_value.Text = card.CardName;
            price_value.Text = card.CardPrice.ToString();
            description_value.Text = card.CardDesc;
            type_value.Text = card.CardType;
            is_foil_value.Text = card.isFoil.ToString() == "1" ? "Yes" : "No";
        }

        protected string GetCardUrl(string card_name)
        {
            return crc.GetCardUrl(card_name);
        }

        protected void back_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CardView/OrderCard.aspx");
        }
    }
}