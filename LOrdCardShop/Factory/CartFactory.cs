using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Factory
{
	public class CartFactory
	{

		public Cart CreateCart(int card_id, int user_id, int quantity)
		{
			Cart cart = new Cart
			{
				CardID = card_id,
				UserID = user_id,
				Quantity = quantity
			};

			return cart;
		} 
	}
}