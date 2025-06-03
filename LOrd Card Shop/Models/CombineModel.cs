using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Models
{
    public class CombineModel
    {
        public class TransactionGroup
        {
            public TransactionHeader Header { get; set; }
            public List<TransactionDetail> Details { get; set; }
            public int TotalQuantity => Details?.Sum(d => d.Quantity) ?? 0;
            public decimal TotalPrice => Details?.Sum(d => d.Quantity * d.Card.CardPrice) ?? 0;
        }
    }
}