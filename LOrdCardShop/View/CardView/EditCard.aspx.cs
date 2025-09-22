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
	public partial class EditCard : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        CardController cdc = new CardController();
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
            string card_id = Request.QueryString["CardID"].ToString();
            Card card = cdc.GetCardByID(int.Parse(card_id));
            card_image.ImageUrl = cdc.GetCardUrl(card.CardName);
            nameInput.Text = card.CardName;
            priceInput.Text = card.CardPrice.ToString();
            descriptionInput.Text = card.CardDesc;
            typeInput.Text = card.CardType;
            isFoilInput.Text = cdc.GetIsFoil(card.isFoil);
        }

        protected void CardValidate(string name, string price, string description, string type, string is_foil)
        {
            errorName.Text = cdc.ValidateName(name);
            errorPrice.Text = cdc.ValidatePrice(price);
            errorDescription.Text = cdc.ValidateDescription(description);
            errorType.Text = cdc.ValidateType(type);
            errorIsFoil.Text = cdc.ValidateIsFoil(is_foil);
        }

        protected void update_button_Click(object sender, EventArgs e)
        {
            string card_id = Request.QueryString["CardID"].ToString();
            Card card = cdc.GetCardByID(int.Parse(card_id));
            string card_name = nameInput.Text;
            string card_price = priceInput.Text;
            string card_description = descriptionInput.Text;
            string card_type = typeInput.Text;
            string card_is_foil = isFoilInput.Text;

            CardValidate(card_name, card_price, card_description, card_type, card_is_foil);
            if (!errorName.Text.Equals("") || !errorPrice.Text.Equals("") || !errorDescription.Text.Equals("") || !errorType.Text.Equals("") || !errorIsFoil.Text.Equals("")) return;
            cdc.UpdateCard(card, card_name, Convert.ToDecimal(card_price), card_description, card_type, cdc.isFoilStringToByte(card_is_foil));
            Response.Redirect("~/View/CardView/ManageCard.aspx");
            //cdc.CreateCard(nameInput.Text, int.Parse(priceInput.Text), descriptionInput.Text, typeInput.Text, new byte[] { Convert.ToByte(isFoilInput) } );
        }
    }
}