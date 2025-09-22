using LOrdCardShop.Factory;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Repository
{
	public class CartRepository
	{
        private LOrdCardShopVBLEntities db;

        public CartRepository(LOrdCardShopVBLEntities vbl)
        {
            db = vbl;
        }

        public List<Cart> GetCarts()
		{
			return (from cart in db.Carts select cart).ToList();
		}

        public List<Cart> GetCartsByUserID(int user_id)
        {
            return (from cart in db.Carts where cart.UserID == user_id select cart).ToList();
        }

        public Cart GetCartByID(int cart_id)
		{
			return (from cart in db.Carts where cart.CartID == cart_id select cart).FirstOrDefault();
		}

        public Cart GetCartByUserIDAndCardID(int user_id, int card_id)
        {
            return (from c in db.Carts where c.UserID == user_id && c.CardID == card_id select c).FirstOrDefault();
        }

        public void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public void DeleteCartByCartID(int cart_id)
        {
            Cart cart = (from c in db.Carts where c.CartID == cart_id select c).FirstOrDefault();
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public void DeleteCartsByCardID(int card_id)
        {
            List<Cart> carts = (from c in db.Carts where c.CardID == card_id select c).ToList();
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }
        public void DeleteCartsByCard(Card card)
        {
            List<Cart> carts = (from c in db.Carts where c.CardID == card.CardID select c).ToList();
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }

        public void DeleteCartsByUserId(int user_id)
        {
            List<Cart> carts = (from c in db.Carts where c.UserID == user_id select c).ToList();
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }

        public decimal GetTotalPrice(int user_id)
        {
            return (from cart in db.Carts join card in db.Cards on cart.CardID equals card.CardID where cart.UserID == user_id select cart.Quantity * card.CardPrice).Sum();
        }

        public void InsertCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public int DecreaseQuantity(int cart_id)
        {
            Cart cart = GetCartByID(cart_id);
            if (cart.Quantity >= 1)
            {
                cart.Quantity -= 1;
                db.SaveChanges();
            }
            return cart.Quantity;
        }
        public int IncreaseQuantity(int cart_id)
        {
            Cart cart = GetCartByID(cart_id);
            cart.Quantity += 1;
            db.SaveChanges();

            return cart.Quantity;
        }
    
        public void ChangeQuantity(int cart_id, int quantity)
        {
            Cart cart = GetCartByID(cart_id);
            cart.Quantity = quantity;
            db.SaveChanges();
        }
    }
}