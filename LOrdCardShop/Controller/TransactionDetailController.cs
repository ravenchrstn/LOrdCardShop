using LOrdCardShop.Factory;
using LOrdCardShop.Handler;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Controller
{
	public class TransactionDetailController
	{
        TransactionDetailHandler tdh = new TransactionDetailHandler();
        public List<TransactionDetail> GetTransactionDetails()
        {
            return tdh.GetTransactionDetails();
        }

        public List<TransactionDetail> GetTransactionDetailsByUnhandled()
        {
            return tdh.GetTransactionDetailsByUnhandled();
        }

        public TransactionDetail GetTransactionDetailByTransactionID(int transaction_id)
        {

            return tdh.GetTransactionDetailByTransactionID(transaction_id);
        }

        public void DeleteTransactionDetailsByCardID(int card_id)
        {
            tdh.DeleteTransactionDetailsByCardID(card_id);
        }

        public void DeleteTransactionDetailsByCard(Card card)
        {
            tdh.DeleteTransactionDetailsByCard(card);
        }

        public List<TransactionDetail> GetTransactionDetailsByCard(Card card)
        {
            return tdh.GetTransactionDetailsByCard(card);
        }

        public List<TransactionDetail> GetTransactionDetailsByUserIDAndHandled(int user_id)
        {

            return tdh.GetTransactionDetailsByUserIDAndHandled(user_id);
        }
        public string GetQuantity(string quantity)
        {
            return quantity + " pcs";
        }

        public void InsertTransactionDetailByCartAndTransactionHeader(Cart cart, TransactionHeader transactionHeader)
        {
            tdh.InsertTransactionDetailByCartAndTransactionHeader(cart, transactionHeader);
        }
    }
}