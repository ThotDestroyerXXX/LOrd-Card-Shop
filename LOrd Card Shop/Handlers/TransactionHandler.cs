using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LOrd_Card_Shop.Models.CombineModel;

namespace LOrd_Card_Shop.Handlers
{
    public class TransactionHandler
    {
        public static Response<TransactionHeader> CheckoutCard(int userId)
        {
            List<Carts> carts = CartRepository.GetCartsByUserId(userId);

            if(carts == null)
            {
                return new Response<TransactionHeader>
                {
                    Message = "No carts found!",
                    Success = false,
                };
            }

            else
            {
                TransactionHeader tHeader = TransactionFactory.CreateTransactionHeader(userId);
                TransactionRepository.CreateTransactionHeader(tHeader);

                int thId = TransactionRepository.GetLastTransactionId();

                foreach (Carts c in carts)
                {
                    TransactionDetail tDetail = TransactionFactory.CreateTransactionDetail(thId, c.CardID, c.Quantity);
                    TransactionRepository.CreateTransactionDetail(tDetail);
                    CartRepository.RemoveCart(c);
                }

                return new Response<TransactionHeader>
                {
                    Message = "Items purchased successfully!",
                    Success = true,
                    Payload = tHeader,
                };
            }
        }

        public static Response<List<TransactionGroup>> GetTransaction(int userId)
        {
            List<TransactionGroup> transactionGroup = TransactionRepository.GetTransaction(userId);

            if(transactionGroup == null || transactionGroup.Count <= 0)
            {
                return new Response<List<TransactionGroup>>
                {
                    Message = "No transactions yet...",
                    Success = false,
                };
            }

            else
            {
                return new Response<List<TransactionGroup>>
                {
                    Message = "Transaction received succesfully",
                    Success = true,
                    Payload = transactionGroup,
                };
            }
        }

        public static Response<List<TransactionGroup>> GetAllTransaction()
        {
            List<TransactionGroup> transactionGroup = TransactionRepository.GetAllTransaction();

            if (transactionGroup == null || transactionGroup.Count <= 0)
            {
                return new Response<List<TransactionGroup>>
                {
                    Message = "No transactions yet...",
                    Success = false,
                };
            }

            else
            {
                return new Response<List<TransactionGroup>>
                {
                    Message = "Transaction received succesfully",
                    Success = true,
                    Payload = transactionGroup,
                };
            }
        }

        public static Response<TransactionGroup> GetTransactionByCustomerIdAndTransactionId(int userId, int transactionId)
        {
            TransactionGroup detail = TransactionRepository.GetTransactionByCustomerIdAndTransactionId(userId, transactionId);

            if(detail == null)
            {
                return new Response<TransactionGroup>
                {
                    Message = "no transaction yet...",
                    Success = false,
                };
            }
            else
            {
                return new Response<TransactionGroup>
                {
                    Message = "Transaction found!",
                    Success = true,
                    Payload = detail,
                };
            }
        }

        public static Response<TransactionGroup> GetTransactionByTransactionId(int transactionId)
        {
            TransactionGroup detail = TransactionRepository.GetTransactionByTransactionId(transactionId);

            if (detail == null)
            {
                return new Response<TransactionGroup>
                {
                    Message = "transaction not found!",
                    Success = false,
                };
            }
            else
            {
                return new Response<TransactionGroup>
                {
                    Message = "Transaction found!",
                    Success = true,
                    Payload = detail,
                };
            }
        }

        public static Response<TransactionGroup> UpdateStatus(int transactionId)
        {
            TransactionGroup transaction = TransactionRepository.UpdateStatusByTransactionId(transactionId);
            if(transaction == null)
            {
                return new Response<TransactionGroup>
                {
                    Message = "No transaction found!",
                    Success = false,
                };
            }
            else
            {
                return new Response<TransactionGroup>
                {
                    Message = "Transaction status updated successfully!",
                    Success = true,
                    Payload = transaction,
                };
            }
        }
    }
}