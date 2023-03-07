using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Customer
    {
        public string Name { get; }
        public List<Account> Accounts { get; }

        public Customer(string name)
        {
            this.Name = name;
            this.Accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            this.Accounts.Add(account);
        }

        public void PrintCustomerStatement()
        {
            Console.WriteLine("Customer name: " + this.Name);

            if (this.Accounts.Count == 0)
            {
                Console.WriteLine("No accounts.");
                return;
            }

            Console.WriteLine("Accounts:");
            foreach (Account a in this.Accounts)
            {
                Console.WriteLine(a.GetType().Name + "\t" + a.AccountNumber + "\t" + a.Balance);
            }
        }
    }

}