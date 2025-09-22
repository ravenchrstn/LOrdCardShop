using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Handler
{
	public class TransactionHeaderHandler
	{
        TransactionHeaderRepository thr = new TransactionHeaderRepository(new LOrdCardShopVBLEntities());
        public List<TransactionHeader> GetTransactionHeaders()
        {
            return thr.GetTransactionHeaders();
        }
        public List<TransactionHeader> GetTransactionHeadersByHandled()
        {
            return thr.GetTransactionHeadersByHandled();
        }

        public TransactionHeader GetTransactionHeaderByID(int id)
        {
            return thr.GetTransactionHeaderByID(id);
        }

        public void DeleteTransactionHeaderByTransactionID(int transaction_id)
        {
            thr.DeleteTransactionHeadersByTransactionID(transaction_id);
        }

        public void DeleteTransactionHeadersByCard(Card card)
        {
            thr.DeleteTransactionHeadersByCard(card);
        }

        public void DeleteTransactionHeadersByTransactionDetails(List<TransactionDetail> transaction_details)
        {
            thr.DeleteTransactionHeadersByTransactionDetails(transaction_details);
        }

        public void ChangeStatusToHandled(int transaction_id)
        {
            thr.ChangeStatusToHandled(transaction_id);
        }

        public void InsertTransactionHeader(TransactionHeader transactionHeader)
        {
            thr.InsertTransactionHeader(transactionHeader);
        }
    }
}