using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string SourceAccountNumber { get; set; }
        public string DestinationAccountNumber { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
