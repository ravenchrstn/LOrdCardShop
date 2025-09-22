using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Repository
{
	public class TransactionHeaderRepository
	{
        LOrdCardShopVBLEntities db = null;
        public TransactionHeaderRepository(LOrdCardShopVBLEntities vbl)
        {
            db = vbl;
        }
        public List<TransactionHeader> GetTransactionHeaders()
		{
			return (from th in db.TransactionHeaders select th).ToList();
		}

        public List<TransactionHeader> GetTransactionHeadersByHandled()
        {
            return (from th in db.TransactionHeaders where th.Status.Equals("Handled") select th).ToList();
        }

        public TransactionHeader GetTransactionHeaderByID(int id)
		{
            return (from th in db.TransactionHeaders where th.TransactionID == id select th).FirstOrDefault();
		}

        public void DeleteTransactionHeadersByTransactionID(int transaction_id)
        {
            TransactionHeader transaction_header = (from th in db.TransactionHeaders where th.TransactionID == transaction_id select th).FirstOrDefault();
            db.TransactionHeaders.Remove(transaction_header);
            db.SaveChanges();
        }

        public void DeleteTransactionHeadersByCard(Card card)
        {
            List<TransactionHeader> transaction_headers = (from th in db.TransactionHeaders join td in db.TransactionDetails on th.TransactionID equals td.TransactionID where td.CardID == card.CardID select th).ToList();
            db.TransactionHeaders.RemoveRange(transaction_headers);
            db.SaveChanges();
        }

        public void DeleteTransactionHeadersByTransactionDetails(List<TransactionDetail> transaction_details)
        {
            foreach (TransactionDetail td in transaction_details)
            {
                DeleteTransactionHeadersByTransactionID(td.TransactionID);
            }
        }

        public void ChangeStatusToHandled(int transaction_id)
		{
			TransactionHeader transaction = GetTransactionHeaderByID(transaction_id);
			transaction.Status = "Handled";
			db.SaveChanges();
		}

        public void InsertTransactionHeader(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }
	}
}