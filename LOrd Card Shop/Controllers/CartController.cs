using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controllers
{
    public class CartController
    {
        public static Response<Carts> AddCardtoCart(string cardId, int userId, string quantity)
        {
            int newCardId = int.Parse(cardId);
            int qty = int.Parse(quantity);
            CartWebService cartWS = new CartWebService();
            String jsonResponse = cartWS.AddCardtoCart(newCardId, userId, qty);

            return Json.Decode<Response<Carts>>(jsonResponse);
        }

        public static Response<List<Carts>> GetCartsByUserId(int userId)
        {
            CartWebService cartWS = new CartWebService();
            String jsonResponse = cartWS.GetCartsByUserId(userId);

            return Json.Decode<Response<List<Carts>>>(jsonResponse);
        }

        public static Response<Carts> SubtractCartQuantity(string cartId)
        {
            int id = int.Parse(cartId);
            CartWebService cartWS = new CartWebService();
            String jsonResponse = cartWS.SubtractCartQuantity(id);

            return Json.Decode<Response<Carts>>(jsonResponse);
        }

        public static Response<Carts> AddCartQuantity(string cartId)
        {
            int id = int.Parse(cartId);
            CartWebService cartWS = new CartWebService();
            String jsonResponse = cartWS.AddCartQuantity(id);

            return Json.Decode<Response<Carts>>(jsonResponse);
        }

        public static Response<Carts> RemoveCart(string cartId)
        {
            int id = int.Parse(cartId);
            CartWebService cartWS = new CartWebService();
            String jsonResponse = cartWS.RemoveCart(id);

            return Json.Decode<Response<Carts>>(jsonResponse);
        }

        public static Response<List<Carts>> RemoveAllCarts(int userId)
        {
            CartWebService cartWS = new CartWebService();
            String jsonResponse = cartWS.RemoveAllCarts(userId);

            return Json.Decode<Response<List<Carts>>>(jsonResponse);
        }
    }
}