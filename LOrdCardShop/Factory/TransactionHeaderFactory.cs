using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Factory
{
	public class TransactionHeaderFactory
	{

		public TransactionHeader CreateTransactionHeader(DateTime transaction_date, int user_id, string status)
		{
			TransactionHeader th = new TransactionHeader
			{
				TransactionDate = transaction_date,
				UserID = user_id,
				Status = status
			};

			return th;
		}
	}
}