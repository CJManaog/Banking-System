using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Bank
    {
        public string Name { get; }
        public Loan loans { get; }
        public Account Account { get; }
        public Customer Customer { get; }

        public Bank(string name)
        {
            this.Name = name;
            this.Customers = new List<Customer>();
            this.Loans = new List<Loan>();
        }

        public void AddCustomer(Customer customer)
        {
            this.Customers.Add(customer);
        }

        public void AddLoan(Loan loan)
        {
            this.Loans.Add(loan);
        }

        public void PrintBankSummary()
        {
            Console.WriteLine("Bank name: " + this.Name);
            Console.WriteLine("Number of customers: " + this.Customers.Count);
            Console.WriteLine("Number of loans: " + this.Loans.Count);

            decimal totalDeposits = 0;
            decimal totalLoans = 0;
            foreach (Customer c in this.Customers)
            {
                foreach (Account a in c.Accounts)
                {
                    totalDeposits += a.Balance;
                }
            }
            foreach (Loan l in this.Loans)
            {
                totalLoans += l.Amount;
            }
            Console.WriteLine("Total deposits: " + totalDeposits);
            Console.WriteLine("Total loans: " + totalLoans);


        }
    }
 
 }