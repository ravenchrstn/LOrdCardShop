using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;

namespace LOrdCardShop.Repository
{
	public class CardRepository
	{
        private LOrdCardShopVBLEntities db;

        public CardRepository(LOrdCardShopVBLEntities vbl)
        {
            db = vbl;
        }
        public List<Card> GetCards()
		{
			return (from card in db.Cards select card).ToList();
		}

		public List<Card> GetSpecificNameCards(string search)
		{
			return db.Cards.Where(s => s.CardName.Contains(search)).ToList();
		}

        public Card GetCardByID(int id)
		{
			return (from card in db.Cards where card.CardID == id select card).FirstOrDefault();
		}

		public Card GetCardByTransactionID(int transaction_id)
		{
            return (from card in db.Cards
                    join td in db.TransactionDetails
                    on card.CardID equals td.CardID
                    where td.TransactionID == transaction_id
                    select card).FirstOrDefault();
        }

        public void InsertCard(Card card)
		{
			db.Cards.Add(card);
			db.SaveChanges();
		}

		public void InsertCards(List<Card> cards)
		{
			db.Cards.AddRange(cards);
			db.SaveChanges();
		}

		public void UpdateCard(Card card, string name, decimal price, string desc, string type, byte[] is_foil)
		{
			card.CardName = name;
			card.CardPrice = price;
			card.CardDesc = desc;
			card.CardType = type;
			card.isFoil = is_foil;
			db.SaveChanges();
		}

		public void DeleteCard(Card card)
		{
            db.Cards.Remove(card);
            db.SaveChanges();
        }
		public void DeleteCards(List<Card> cards)
		{
			db.Cards.RemoveRange(cards);
			db.SaveChanges();
		}
    }
}