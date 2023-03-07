// Sstatic void Main(string[] args)
using Banking_System;
{
    Bank myBank = new Bank("My Bank");
    // create and add customers
    Customer alice = new Customer("Alice");
    CheckingAccount aliceChecking = new CheckingAccount("1234");
    SavingsAccount aliceSavings = new SavingsAccount("5678", 1.5m);
    alice.AddAccount(aliceChecking);
    alice.AddAccount(aliceSavings);
    myBank.AddCustomer(alice);

    Customer bob = new Customer("Bob");
    SavingsAccount bobSavings = new SavingsAccount("4321", 2.0m);
    bob.AddAccount(bobSavings);
    myBank.AddCustomer(bob);

    // deposit and withdraw from accounts
    aliceChecking.Deposit(1000);
    aliceChecking.Withdraw(500);
    aliceChecking.Withdraw(600);

    aliceSavings.Deposit(2000);
    aliceSavings.Deposit(500);
    aliceSavings.Withdraw(1000);

    bobSavings.Deposit(5000);
    bobSavings.Withdraw(1000);

    // print customer statements
    alice.PrintCustomerStatement();
    Console.WriteLine();
    bob.PrintCustomerStatement();
    Console.WriteLine();

    // create and add loans
    Loan mortgage = new Loan("Mortgage", 500000, 3.5m, 360);
    Loan carLoan = new Loan("Car loan", 20000, 5.0m, 48);
    myBank.AddLoan(mortgage);
    myBank.AddLoan(carLoan);

    // print bank summary
    myBank.PrintBankSummary();
}