using LOrdCardShop.Controller;
using System;

namespace LOrdCardShop.View.CardView
{
	public partial class AddCard : System.Web.UI.Page
	{
		AuthController ac = new AuthController();
        CardController cdc = new CardController();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack) ac.AdminAuthentication("~/View/Home/Home_Customer.aspx");
        }

        protected void insert_button_Click(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            string price = priceInput.Text;
            string description = descriptionInput.Text;
            string type = typeInput.Text;
            string is_foil = isFoilInput.Text;

            CardValidate(name, price, description, type, is_foil);
            if (!errorName.Text.Equals("") || !errorPrice.Text.Equals("") || !errorDescription.Text.Equals("") || !errorType.Text.Equals("") || !errorIsFoil.Text.Equals("")) return;

            cdc.CreateCard(name, Convert.ToDecimal(price), description, type, cdc.isFoilStringToByte(is_foil));
            Response.Redirect("~/View/CardView/ManageCard.aspx");
        }
        protected void CardValidate(string name, string price, string description, string type, string is_foil)
        {
            errorName.Text = cdc.ValidateName(name);
            errorPrice.Text = cdc.ValidatePrice(price);
            errorDescription.Text = cdc.ValidateDescription(description);
            errorType.Text = cdc.ValidateType(type);
            errorIsFoil.Text = cdc.ValidateIsFoil(is_foil);
        }
    }
}