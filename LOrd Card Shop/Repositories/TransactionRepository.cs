using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LOrd_Card_Shop.Models.CombineModel;

namespace LOrd_Card_Shop.Repositories
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static void CreateTransactionHeader(TransactionHeader transaction)
        {
            db.TransactionHeader.Add(transaction);
            db.SaveChanges();
        }

        public static void CreateTransactionDetail(TransactionDetail transaction)
        {
            db.TransactionDetail.Add(transaction);
            db.SaveChanges();
        }

        public static int GetLastTransactionId()
        {
            return db.TransactionHeader.OrderByDescending(a => a.TransactionID).FirstOrDefault().TransactionID;
        }

        public static List<TransactionGroup> GetTransaction(int userId)
        {
            return db.TransactionDetail
             .Where(i => i.TransactionHeader.CustomerID == userId)
             .GroupBy(td => new { td.TransactionHeader.TransactionDate, td.TransactionHeader.TransactionID, td.TransactionHeader.CustomerID })
             .Select(g => new TransactionGroup
             {
                 Header = g.FirstOrDefault().TransactionHeader,
                 Details = g.ToList()
             }).OrderByDescending(i => i.Header.TransactionID)
             .ToList();
        }

        public static List<TransactionGroup> GetAllTransaction()
        {
            return db.TransactionDetail
             .GroupBy(td => new { td.TransactionHeader.TransactionDate, td.TransactionHeader.TransactionID, td.TransactionHeader.CustomerID })
             .Select(g => new TransactionGroup
             {
                 Header = g.FirstOrDefault().TransactionHeader,
                 Details = g.ToList()
             }).OrderByDescending(i => i.Header.TransactionID)
             .ToList();
        }

        public static TransactionGroup GetTransactionByCustomerIdAndTransactionId(int customerId, int transactionID)
        {
            List<TransactionDetail> detail = db.TransactionDetail
                .Where(i => i.TransactionHeader.TransactionID == transactionID && i.TransactionHeader.CustomerID == customerId).ToList();

            if (!detail.Any() || detail.Count <= 0)
            {
                return null;
            }

            else
            {
                return new TransactionGroup
                {
                    Header = detail.FirstOrDefault().TransactionHeader,
                    Details = detail,
                };
            }
        }

        public static TransactionGroup GetTransactionByTransactionId(int transactionID)
        {
            List<TransactionDetail> detail = db.TransactionDetail
                .Where(i => i.TransactionHeader.TransactionID == transactionID).ToList();

            if (!detail.Any() || detail.Count <= 0)
            {
                return null;
            }

            else
            {
                return new TransactionGroup
                {
                    Header = detail.FirstOrDefault().TransactionHeader,
                    Details = detail,
                };
            }
        }

        public static TransactionGroup UpdateStatusByTransactionId(int transactionId)
        {
            TransactionGroup transactionGroup = GetTransactionByTransactionId(transactionId);

            if(transactionGroup != null && transactionGroup.Header.Status != "handled")
            {
                transactionGroup.Header.Status = "handled";
                db.SaveChanges();
                return transactionGroup;
            }
            else
            {
                return null;
            }
        }
    }
}