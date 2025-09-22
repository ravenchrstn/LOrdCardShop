using LOrdCardShop.Factory;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System.Collections.Generic;

namespace LOrdCardShop.Handler
{
	public class CartHandler
	{
        CartRepository cr = new CartRepository(new LOrdCardShopVBLEntities());
        CartFactory cf = new CartFactory();
        public List<Cart> GetCarts()
        {
            return cr.GetCarts();
        }

        public List<Cart> GetCartsByUserID(int user_id)
        {
            return cr.GetCartsByUserID(user_id);
        }

        public Cart GetCartByID(int cart_id)
        {
            return cr.GetCartByID(cart_id);
        }

        public Cart GetCartByUserIDAndCardID(int user_id, int card_id)
        {
            return cr.GetCartByUserIDAndCardID(user_id, card_id);
        }

        public void DeleteCart(Cart cart)
        {
            cr.DeleteCart(cart);
        }

        public void DeleteCartByCartID(int cart_id)
        {
            cr.DeleteCartByCartID(cart_id);
        }

        public void DeleteCartsByCardID(int card_id)
        {
            cr.DeleteCartsByCardID(card_id);
        }

        public void DeleteCartsByCard(Card card)
        {
            cr.DeleteCartsByCard(card);
        }

        public void DeleteCartsByUserId(int user_id)
        {
            cr.DeleteCartsByUserId(user_id);
        }

        public decimal GetTotalPrice(int user_id)
        {
            return cr.GetTotalPrice(user_id);
        }

        public void InsertCart(Cart cart)
        {
            cr.InsertCart(cart);
        }

        public int DecreaseQuantity(int cart_id)
        {
            return cr.DecreaseQuantity(cart_id);
        }
        public int IncreaseQuantity(int cart_id)
        {
            return cr.IncreaseQuantity(cart_id);
        }

        public void CreateCart(int card_id, int user_id)
        {
            cr.InsertCart(cf.CreateCart(card_id, user_id, 1));
        }
        public void ChangeQuantityByCardAndUserId(int user_id, int card_id, int quantity)
        {
            Cart cart = cr.GetCartByUserIDAndCardID(user_id, card_id);
            System.Diagnostics.Debug.WriteLine("nilai user_id adalah: " + user_id);
            System.Diagnostics.Debug.WriteLine("nilai card_id adalah: " + card_id);
            System.Diagnostics.Debug.WriteLine("nilai cart_id adalah: " + cart.CartID);
            cr.ChangeQuantity(cart.CartID, quantity);
        }

        public void ChangeQuantity(int cart_id, int quantity)
        {
            cr.ChangeQuantity(cart_id, quantity);
        }
    }
}