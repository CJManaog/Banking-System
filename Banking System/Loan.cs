using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Loan
    {
        public string LoanNumber { get; }
        public decimal Amount { get; }
        public decimal InterestRate { get; }
        public int TermInMonths { get; }
        public decimal MonthlyPayment { get; }

        public Loan(string loanNumber, decimal amount, decimal interestRate, int termInMonths)
        {
            this.LoanNumber = loanNumber;
            this.Amount = amount;
            this.InterestRate = interestRate;
            this.TermInMonths = termInMonths;
            this.MonthlyPayment = CalculateMonthlyPayment();
        }

        private decimal CalculateMonthlyPayment()
        {
            decimal monthlyInterestRate = this.InterestRate / 100 / 12;
            decimal numerator = this.Amount * monthlyInterestRate;
            decimal denominator = 1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -this.TermInMonths);
            return numerator / denominator;
        }
    }
}