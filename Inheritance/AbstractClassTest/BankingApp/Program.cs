using System;

namespace BankingApp
{
    using Banking;

    static class Program
    {
        public static void Main(string[] args)
        {
            Account jack = Banker.OpenCurrentAccount();
            jack.Deposit(20000);

            Account jill = Banker.OpenSavingsAccount();
            jill.Deposit(15000);

            try
            {
                double amt = double.Parse(args[0]);
                jill.Transfer(amt, jack);
                Console.WriteLine("Transfer succeeded.");
            }
            catch (AccountException ex) when (ex.Cause == AccountFault.InsufficientFunds)
            {
                Console.WriteLine("Transfer failed due to lack of funds!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            Console.WriteLine("Jack's Account ID is {0} and Balance is {1:0.00}", jack.Id, jack.Balance);
            Console.WriteLine("Jill's Account ID is {0} and Balance is {1:0.00}", jill.Id, jill.Balance);
        }
    }
}