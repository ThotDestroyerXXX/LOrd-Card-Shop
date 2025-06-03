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
    /// Summary description for CardWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CardWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public String GetAllCards()
        {
            return Json.Encode(CardHandler.GetAllCards());
        }

        [WebMethod]
        public String GetAllCardsBySearchFilter(string search)
        {
            return Json.Encode(CardHandler.GetAllCardsBySearchFilter(search));
        }

        [WebMethod]
        public String DeleteCardById(int id)
        {
            return Json.Encode(CardHandler.DeleteCardById(id));
        }
        [WebMethod]
        public String CreateCard(string name, decimal price, string description, string type, string foil)
        {
            return Json.Encode(CardHandler.CreateCard(name, price, description, type, foil));
        }
        [WebMethod]
        public String UpdateCard(string id, string name, decimal price, string description, string type, string foil)
        {
            return Json.Encode(CardHandler.UpdateCard(id, name, price, description, type, foil));
        }
        [WebMethod]
        public String GetCardById(int id)
        {
            return Json.Encode(CardHandler.GetCardById(id));
        }
    }
}
