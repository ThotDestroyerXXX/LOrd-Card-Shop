using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using LOrd_Card_Shop.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LOrd_Card_Shop.WebServices
{
    /// <summary>
    /// Summary description for CartWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CartWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public String AddCardtoCart(int cardId, int userId, int quantity)
        {
            return Json.Encode(CartHandler.AddCardtoCart(cardId, userId, quantity));
        }
        [WebMethod]
        public String GetCartsByUserId(int id)
        {
            return Json.Encode(CartHandler.GetCartsByUserId(id));
        }
        [WebMethod]
        public String SubtractCartQuantity(int cartId)
        {
            return Json.Encode(CartHandler.SubtractCartQuantity(cartId));
        }
        [WebMethod]
        public String AddCartQuantity(int cartId)
        {
            return Json.Encode(CartHandler.AddCartQuantity(cartId));
        }
        [WebMethod]
        public String RemoveCart(int cartId)
        {
            return Json.Encode(CartHandler.RemoveCart(cartId));
        }

        [WebMethod]
        public String RemoveAllCarts(int userId)
        {
            return Json.Encode(CartHandler.RemoveAllCarts(userId));
        }
    }
}
