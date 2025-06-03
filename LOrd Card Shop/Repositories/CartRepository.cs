using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class CartRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static Carts GetCartByCompositeId(int cardId, int userId)
        {
            return db.Carts.FirstOrDefault(i => i.CardID == cardId && i.UserID == userId);
        }

        public static Carts GetCartById(int cartId)
        {
            return db.Carts.FirstOrDefault(i => i.CartID ==  cartId);
        }

        public static Carts UpdateQuantity(Carts cart, int quantity)
        {
            cart.Quantity += quantity;
            db.SaveChanges();
            return cart;
        }

        public static void CreateCart(Carts cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static List<Carts> GetCartsByUserId(int id)
        {
            return db.Carts.Where(i => i.UserID == id).ToList();
        }

        public static void SubtractCartQuantity(int cartId)
        {
            Carts cart = GetCartById(cartId);

            cart.Quantity -= 1;
            db.SaveChanges();
        }

        public static Carts AddCartQuantity(int cartId)
        {
            Carts cart = GetCartById(cartId);
            cart.Quantity += 1;
            db.SaveChanges();
            return cart;
        }

        public static void RemoveCart(Carts cart)
        {
            if(cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public static void RemoveAllCarts(List<Carts> carts)
        {
            if(carts != null)
            {
                db.Carts.RemoveRange(carts);
                db.SaveChanges();
            }
        }
    }
}