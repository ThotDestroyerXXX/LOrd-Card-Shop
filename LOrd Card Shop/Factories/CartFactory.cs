using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
    public class CartFactory
    {
        public static Carts CreateCart(int cardId, int userId, int quantity)
        {
            Carts cart = new Carts();

            cart.CardID = cardId;
            cart.UserID = userId;
            cart.Quantity = quantity;

            return cart;
        }
    }
}