using LOrdCardShop.Handler;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Controller
{
	public class CartController
	{
        CartHandler ch = new CartHandler();
        public List<Cart> GetCarts()
        {
            return ch.GetCarts();
        }

        public List<Cart> GetCartsByUserID(int user_id)
        {
            return ch.GetCartsByUserID(user_id);
        }

        public Cart GetCartByID(int cart_id)
        {
            return ch.GetCartByID(cart_id);
        }

        public Cart GetCartByUserIDAndCardID(int user_id, int card_id)
        {
            return ch.GetCartByUserIDAndCardID(user_id, card_id);
        }

        public void DeleteCart(Cart cart)
        {
            ch.DeleteCart(cart);
        }

        public void DeleteCartByCartID(int cart_id)
        {
            ch.DeleteCartByCartID(cart_id);
        }

        public void DeleteCartsByCardID(int card_id)
        {
            ch.DeleteCartsByCardID(card_id);
        }

        public void DeleteCartsByCard(Card card)
        {
            ch.DeleteCartsByCard(card);
        }

        public void DeleteCartsByUserId(int user_id)
        {
            ch.DeleteCartsByUserId(user_id);
        }

        public decimal GetTotalPrice(int user_id)
        {
            return ch.GetTotalPrice(user_id);
        }

        public void InsertCart(Cart cart)
        {
            ch.InsertCart(cart);
        }

        public int DecreaseQuantity(int cart_id)
        {
            return ch.DecreaseQuantity(cart_id);
        }
        public int IncreaseQuantity(int cart_id)
        {
            return ch.IncreaseQuantity(cart_id);
        }

        public string GetQuantity(string quantity)
        {
            return quantity + " pcs";
        }

        public void CreateCart(int card_id, int user_id)
        {
            ch.CreateCart(card_id, user_id);
        }

        public void ChangeQuantityByCardAndUserId(int user_id, int card_id, int quantity)
        {
            ch.ChangeQuantityByCardAndUserId(user_id, card_id, quantity);
        }

        public void ChangeQuantity(int cart_id, int quantity)
        {
            ch.ChangeQuantity(cart_id, quantity);
        }
    }
}