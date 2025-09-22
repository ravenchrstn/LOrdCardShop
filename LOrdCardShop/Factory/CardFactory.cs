using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Factory
{
	public class CardFactory
	{
		public Card CreateCard(string name, decimal price, string desc, string type, byte[] is_foil)
		{
            Card card = new Card
            {
                CardName = name,
                CardPrice = price,
                CardDesc = desc,
                CardType = type,
                isFoil = is_foil
            };

            return card;
		}
	}
}