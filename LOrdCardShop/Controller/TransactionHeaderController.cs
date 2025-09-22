using LOrdCardShop.Factory;
using LOrdCardShop.Handler;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Controller
{
	public class TransactionHeaderController
	{
        TransactionDetailHandler tdh = new TransactionDetailHandler();
        TransactionHeaderHandler thh = new TransactionHeaderHandler();
        TransactionHeaderFactory thf = new TransactionHeaderFactory();
        public List<TransactionHeader> GetTransactionHeaders()
        {
            return thh.GetTransactionHeaders();
        }

        public List<TransactionHeader> GetTransactionHeadersByHandled()
        {
            return thh.GetTransactionHeadersByHandled();
        }

        public TransactionHeader GetTransactionHeaderByID(int id)
        {
            return thh.GetTransactionHeaderByID(id);
        }

        public void DeleteTransactionHeaderByTransactionID(int transaction_id)
        {
            thh.DeleteTransactionHeaderByTransactionID(transaction_id);
        }

        public void DeleteTransactionHeadersByTransactionDetails(List<TransactionDetail> transaction_details)
        {
            thh.DeleteTransactionHeadersByTransactionDetails(transaction_details);
        }

        public void DeleteTransactionHeadersByCard(Card card)
        {
            thh.DeleteTransactionHeadersByCard(card);
        }

        public string GetDate(string transaction_id)
        {
            DateTime date = thh.GetTransactionHeaderByID(int.Parse(transaction_id)).TransactionDate;
            string date_format = date.ToString("MMMM, d") + GetDaySuffix(date.Day) + " " + date.ToString("yyyy");
            return date_format;
        }

        public string GetDate(DateTime date)
        {
            string date_format = date.ToString("MMMM, d") + GetDaySuffix(date.Day) + " " + date.ToString("yyyy");
            return date_format;
        }

        protected string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13) return "th";
            day %= 10;
            if (day == 1) return "st";
            else if (day == 2) return "nd";
            else if (day == 3) return "rd";
            else return "th";
        }

        public void ChangeStatusToHandled(int transaction_id)
        {
            thh.ChangeStatusToHandled(transaction_id);
        }

        public TransactionHeader InsertTransactionHeaderByCart(Cart cart)
        {
            TransactionHeader transactionHeader = thf.CreateTransactionHeader(DateTime.Now, cart.UserID, "Unhandled");
            thh.InsertTransactionHeader(transactionHeader);
            return transactionHeader;
        }
    }
}