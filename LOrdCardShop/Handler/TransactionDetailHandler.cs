using LOrdCardShop.Factory;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Handler
{
	public class TransactionDetailHandler
	{
        TransactionDetailRepository tdr = new TransactionDetailRepository(new LOrdCardShopVBLEntities());
        TransactionDetailFactory tdf = new TransactionDetailFactory();
        public List<TransactionDetail> GetTransactionDetails()
        {
            return tdr.GetTransactionDetails();
        }

        public List<TransactionDetail> GetTransactionDetailsByUnhandled()
        {
            return tdr.GetTransactionDetailsByUnhandled();
        }

        public TransactionDetail GetTransactionDetailByTransactionID(int transaction_id)
        {

            return tdr.GetTransactionDetailByTransactionID(transaction_id);
        }

        public void DeleteTransactionDetailsByCardID(int card_id)
        {
            tdr.DeleteTransactionDetailsByCardID(card_id);
        }

        public void DeleteTransactionDetailsByCard(Card card)
        {
            tdr.DeleteTransactionDetailsByCard(card);
        }

        public List<TransactionDetail> GetTransactionDetailsByCard(Card card)
        {
            return tdr.GetTransactionDetailsByCard(card);
        }

        public List<TransactionDetail> GetTransactionDetailsByUserIDAndHandled(int user_id)
        {

            return tdr.GetTransactionDetailsByUserIDAndHandled(user_id);
        }

        public void InsertTransactionDetail(TransactionDetail transactionDetail)
        {
            tdr.InsertTransactionDetail(transactionDetail);
        }

        public void InsertTransactionDetailByCartAndTransactionHeader(Cart cart, TransactionHeader transactionHeader)
        {
            TransactionDetail transactionDetail = tdf.CreateTransactionDetail(transactionHeader.TransactionID, cart.CardID, cart.Quantity);
            tdr.InsertTransactionDetail(transactionDetail);
        }
    }
}