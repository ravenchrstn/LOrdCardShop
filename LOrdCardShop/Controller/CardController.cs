using LOrdCardShop.Handler;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Controller
{
	public class CardController
	{
        CardHandler ch = new CardHandler();
        public List<Card> GetCards()
        {
            return ch.GetCards();
        }
        public List<Card> GetSpecificNameCards(string search)
        {
            return ch.GetSpecificNameCards(search);
        }

        public Card GetCardByID(int id)
        {
            return ch.GetCardByID(id);
        }

        public Card GetCardByTransactionID(int transaction_id)
        {
            return ch.GetCardByTransactionID(transaction_id);
        }

        public void InsertCard(Card card)
        {
            ch.InsertCard(card);
        }

        public void InsertCards(List<Card> cards)
        {
            ch.InsertCards(cards);
        }

        public void DeleteCard(Card card)
        {
            ch.DeleteCard(card);
        }

        public void DeleteCards(List<Card> cards)
        {
            ch.DeleteCards(cards);
        }

        public void CreateCard(string name, decimal price, string desc, string type, byte[] is_foil)
        {
            ch.CreateCard(name, price, desc, type, is_foil);
        }

        public void UpdateCard(Card card, string name, decimal price, string desc, string type, byte[] is_foil)
        {
            ch.UpdateCard(card, name, price, desc, type, is_foil);
        }

        public decimal GetCardPriceWithQuantity(string card_id, string quantity)
        {
            return ch.GetCardByID(int.Parse(card_id)).CardPrice * int.Parse(quantity);
        }

        public string GetCardUrl(string card_name)
        {
            string url = "~/Media/Card/" + card_name + ".png";
            string fullPath = HttpContext.Current.Server.MapPath(url);

            if (!System.IO.File.Exists(fullPath))
            {
                url = "~/Media/Card/steven's_dad.png";
            }
            return url;
        }

        public string GetIsFoil(byte[] is_foil)
        {
            if (is_foil[0].Equals(1)) return "Yes";
            else if (is_foil[0].Equals(0)) return "No";
            return null;
        }

        public byte[] isFoilStringToByte(string is_foil)
        {
            if (is_foil.Equals("Yes")) return new byte[] { Convert.ToByte("1") };
            else if (is_foil.Equals("No")) return new byte[] { Convert.ToByte("0") };
            return null;
        }

        protected bool IsAlphabetOrSpaceOnly(string text)
        {
            return text.All(c => char.IsLetter(c) || c == ' ');
        }

        public string ValidateName(string name)
        {
            if (name.Length < 5 || name.Length > 50) return "Name must be between 5 and 50 characters";
            else if (!IsAlphabetOrSpaceOnly(name)) return "Name must contain only letters and spaces";
            return "";
        }

        public string ValidatePrice(string price)
        {
            decimal decimal_price;
            if (!decimal.TryParse(price, out decimal_price)) return "Price must only be numbers";
            if (decimal_price < 10000) return "Price must be greater or equal than 10000";
            return "";
        }

        public string ValidateDescription(string description)
        {
            if (description.Equals("")) return "Description must not be empty";
            return "";
        }

        public string ValidateType(string type)
        {
            if (!type.Equals("Spell") && !type.Equals("Monster")) return "Type must be only 'Spell' or 'Monster'"; ;
            return "";
        }

        public string ValidateIsFoil(string is_foil)
        {
            if (!is_foil.Equals("Yes") && !is_foil.Equals("No")) return "Foil must be only 'Yes' or 'No'";
            return "";
        } 
    }
}