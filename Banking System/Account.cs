using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public abstract class Account
    {
        public decimal Balance { get; protected set; }
        public Transaction transactions{ get; }

        public Account(string accountNumber)
        {
            this.AccountNumber = accountNumber;
            this.Balance = 0;
            this.Transactions = new List<Transaction>();
        }

        public virtual bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return false;
            }

            this.Balance += amount;
            this.Transactions.Add(new Transaction
            {
                Amount = amount,
                Type = TransactionType.Deposit,
                SourceAccountNumber = this.AccountNumber,
                Timestamp = DateTime.Now
            });

            return true;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return false;
            }

            if (amount > this.Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            this.Balance -= amount;
            this.Transactions.Add(new Transaction
            {
                Amount = amount,
                Type = TransactionType.Withdrawal,
                SourceAccountNumber = this.AccountNumber,
                Timestamp = DateTime.Now
            });

            return true;
        }

        public virtual bool Transfer(decimal amount, Account destinationAccount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be greater than zero.");
                return false;
            }

            if (amount > this.Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            this.Balance -= amount;
            this.Transactions.Add(new Transaction
            {
                Amount = amount,
                Type = TransactionType.Transfer,
                SourceAccountNumber = this.AccountNumber,
                DestinationAccountNumber = destinationAccount.AccountNumber,
                Timestamp = DateTime.Now
            });

            destinationAccount.Balance += amount;
            destinationAccount.Transactions.Add(new Transaction
            {
                Amount = amount,
                Type = TransactionType.Deposit,
                SourceAccountNumber = this.AccountNumber,
                DestinationAccountNumber = destinationAccount.AccountNumber,
                Timestamp = DateTime.Now
            });

            return true;
        }

        public virtual void PrintAccountStatement()
        {
            Console.WriteLine("Account number: " + this.AccountNumber);
            Console.WriteLine("Balance: " + this.Balance);

            if (this.Transactions.Count == 0)
            {
                Console.WriteLine("No transactions.");
                return;
            }

            Console.WriteLine("Transactions:");
            Console.WriteLine("Date\t\tType\tAmount\tSource\tDestination");

            foreach (Transaction t in this.Transactions)
            {
                Console.Write(t.Timestamp + "\t");
                Console.Write(t.Type + "\t");
                Console.Write(t.Amount + "\t");
                Console.Write(t.SourceAccountNumber + "\t");
                Console.Write(t.DestinationAccountNumber + "\n");
            }
        }
    }
}
