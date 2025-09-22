using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Repository
{
	public class TransactionDetailRepository
	{
		private LOrdCardShopVBLEntities db;

		public TransactionDetailRepository(LOrdCardShopVBLEntities vbl)
		{
			db = vbl;
		}

		public List<TransactionDetail> GetTransactionDetails()
		{
			return (from transaction_detail in db.TransactionDetails select transaction_detail).ToList();
		}

        public List<TransactionDetail> GetTransactionDetailsByUnhandled()
        {
            return (from td in db.TransactionDetails 
					join th in db.TransactionHeaders
					on td.TransactionID equals th.TransactionID
					orderby th.Status == "Handled"
					select td).ToList();
        }

		public void DeleteTransactionDetailsByCardID(int card_id)
		{
			List<TransactionDetail> transaction_details = (from td in db.TransactionDetails
                                                           where td.CardID == card_id
                                                           select td).ToList();
            db.TransactionDetails.RemoveRange(transaction_details);
            db.SaveChanges();
        }

		public void DeleteTransactionDetailsByCard(Card card)
		{
            List<TransactionDetail> transaction_details = (from td in db.TransactionDetails
                                                           where td.CardID == card.CardID
                                                           select td).ToList();
            db.TransactionDetails.RemoveRange(transaction_details);
            db.SaveChanges();
        }

		public List<TransactionDetail> GetTransactionDetailsByCard(Card card)
		{
			return (from td in db.TransactionDetails
                    where td.CardID == card.CardID
                    select td).ToList();
        }

        public TransactionDetail GetTransactionDetailByTransactionID(int transaction_id)
        {

            return (from td in db.TransactionDetails
					where td.TransactionID == transaction_id
                    select td).FirstOrDefault();
        }

        public List<TransactionDetail> GetTransactionDetailsByUserIDAndHandled(int user_id)
		{

			return (from td in db.TransactionDetails 
					join th in db.TransactionHeaders on td.TransactionID equals th.TransactionID 
					where th.UserID == user_id && th.Status.Equals("Handled") select td).ToList();
		}

        public void InsertTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }
    }
}