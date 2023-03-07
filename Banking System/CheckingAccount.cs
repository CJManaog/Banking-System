using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string accountNumber) : base(accountNumber)
        {
        }
    }
    public override bool Withdraw(decimal amount)
    {
        bool withdrawalSuccessful = base.Withdraw(amount);

        if (!withdrawalSuccessful)
        {
            Console.WriteLine("Overdraft fee charged: 20");
            base.Withdraw(20);
        }

        return withdrawalSuccessful;
    }
}
