using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Factory
{
	public class TransactionDetailFactory
	{

		public TransactionDetail CreateTransactionDetail(int transaction_id, int card_id, int quantity)
		{
			TransactionDetail td = new TransactionDetail
			{
				TransactionID = transaction_id,
				CardID = card_id,
				Quantity = quantity
			};

			return td;
		}
	}
}