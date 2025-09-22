using LOrdCardShop.Factory;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Handler
{
	public class CardHandler
	{
        CardRepository cr = new CardRepository(new LOrdCardShopVBLEntities());
        CardFactory cf = new CardFactory();
        CartRepository ctr = new CartRepository(new LOrdCardShopVBLEntities());
        TransactionDetailRepository tdr = new TransactionDetailRepository(new LOrdCardShopVBLEntities());
        TransactionHeaderRepository thr = new TransactionHeaderRepository(new LOrdCardShopVBLEntities());
        public List<Card> GetCards()
        {
            return cr.GetCards();
        }

        public List<Card> GetSpecificNameCards(string search)
        {
            return cr.GetSpecificNameCards(search);
        }

        public Card GetCardByID(int id)
        {
            return cr.GetCardByID(id);
        }

        public Card GetCardByTransactionID(int transaction_id)
        {
            return cr.GetCardByTransactionID(transaction_id);
        }

        public void InsertCard(Card card)
        {
            cr.InsertCard(card);
        }

        public void InsertCards(List<Card> cards)
        {
            cr.InsertCards(cards);
        }

        public void CreateCard(string name, decimal price, string desc, string type, byte[] is_foil)
        {
            cr.InsertCard(cf.CreateCard(name, price, desc, type, is_foil));
        }

        public void UpdateCard(Card card, string name, decimal price, string desc, string type, byte[] is_foil)
        {
            cr.UpdateCard(card, name, price, desc, type, is_foil);
        }

        public void DeleteCard(Card card)
        {
            ctr.DeleteCartsByCard(card);
            List<TransactionDetail> transaction_details = tdr.GetTransactionDetailsByCard(card);
            tdr.DeleteTransactionDetailsByCard(card);
            thr.DeleteTransactionHeadersByTransactionDetails(transaction_details);
            
            cr.DeleteCard(card);
        }
        public void DeleteCards(List<Card> cards)
        {
            cr.DeleteCards(cards);
        }
    }
}