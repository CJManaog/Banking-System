using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class SavingsAccount : Account
    {
        private decimal InterestRate { get; }

        public SavingsAccount(string accountNumber, decimal interestRate) : base(accountNumber)
        {
            this.InterestRate = interestRate;
        }
        public override bool Deposit(decimal amount)
        {
            bool depositSuccessful = base.Deposit(amount);

            if (depositSuccessful)
            {
                decimal interest = this.Balance * this.InterestRate / 100;
                base.Deposit(interest);
                Console.WriteLine("Interest added: " + interest);
            }

            return depositSuccessful;
        }
    }


}