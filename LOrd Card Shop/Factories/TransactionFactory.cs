using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTransactionHeader(int customerId, DateTime? transactionDate = null, string status = "unhandled")
        {
            DateTime finalTime = transactionDate ?? DateTime.Now;

            TransactionHeader transaction = new TransactionHeader();
            transaction.TransactionDate = finalTime;
            transaction.Status = status;
            transaction.CustomerID = customerId;

            return transaction;
        }

        public static TransactionDetail CreateTransactionDetail(int transactionId, int cardId, int quantity)
        {
            TransactionDetail transaction = new TransactionDetail();
            transaction.CardID = cardId;
            transaction.Quantity = quantity;    
            transaction.TransactionID = transactionId;

            return transaction;
        }
    }
}