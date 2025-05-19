using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LOrd_Card_Shop.Models.CombineModel;

namespace LOrd_Card_Shop.Controllers
{
    public class TransactionController
    {
        public static Response<TransactionHeader> CheckoutCard(int userId)
        {
            TransactionWebService transactionWS = new TransactionWebService();
            String jsonResponse = transactionWS.CheckoutCard(userId);

            return Json.Decode<Response<TransactionHeader>>(jsonResponse);
        }

        public static Response<List<TransactionGroup>> GetTransaction(int userId)
        {
            TransactionWebService transactionWS = new TransactionWebService();
            String jsonResponse = transactionWS.GetTransaction(userId);

            return Json.Decode<Response<List<TransactionGroup>>>(jsonResponse);
        }

        public static Response<List<TransactionGroup>> GetAllTransaction()
        {
            TransactionWebService transactionWS = new TransactionWebService();
            String jsonResponse = transactionWS.GetAllTransaction();

            return Json.Decode<Response<List<TransactionGroup>>>(jsonResponse);
        }

        public static Response<TransactionGroup> GetTransactionByCustomerIdAndTransactionId(int userId, string transactionId)
        {
            int newTransactionId = int.Parse(transactionId);
            TransactionWebService transactionWS = new TransactionWebService();
            String jsonResponse = transactionWS.GetTransactionByCustomerIdAndTransactionId(userId, newTransactionId);

            return Json.Decode<Response<TransactionGroup>>(jsonResponse);
        }

        public static Response<TransactionGroup> GetTransactionByTransactionId(string transactionId)
        {
            int newTransactionId = int.Parse(transactionId);
            TransactionWebService transactionWS = new TransactionWebService();
            String jsonResponse = transactionWS.GetTransactionByTransactionId(newTransactionId);

            return Json.Decode<Response<TransactionGroup>>(jsonResponse);
        }

        public static Response<TransactionGroup> UpdateStatus(string transactionId)
        {
            int id = int.Parse(transactionId);
            TransactionWebService transactionWS = new TransactionWebService();
            String jsonResponse = transactionWS.UpdateStatus(id);

            return Json.Decode<Response<TransactionGroup>>(jsonResponse);
        }
    }
}