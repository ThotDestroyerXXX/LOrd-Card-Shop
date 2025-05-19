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
using static LOrd_Card_Shop.Models.CombineModel;

namespace LOrd_Card_Shop.WebServices
{
    /// <summary>
    /// Summary description for TransactionWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TransactionWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public String CheckoutCard(int userId)
        {
            return Json.Encode(TransactionHandler.CheckoutCard(userId));
        }
        [WebMethod]
        public String GetTransaction(int userId)
        {
            return Json.Encode(TransactionHandler.GetTransaction(userId));
        }
        [WebMethod]
        public String GetAllTransaction()
        {
            return Json.Encode(TransactionHandler.GetAllTransaction());
        }
        [WebMethod]
        public String GetTransactionByCustomerIdAndTransactionId(int userId, int transactionId)
        {
            return Json.Encode(TransactionHandler.GetTransactionByCustomerIdAndTransactionId(userId, transactionId));
        }
        [WebMethod]
        public String GetTransactionByTransactionId(int transactionId)
        {
            return Json.Encode(TransactionHandler.GetTransactionByTransactionId(transactionId));
        }
        [WebMethod]
        public String UpdateStatus(int transactionId)
        {
            return Json.Encode(TransactionHandler.UpdateStatus(transactionId));
        }
    }
}
