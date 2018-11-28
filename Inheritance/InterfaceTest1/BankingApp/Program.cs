using System;

namespace InterfaceTest1
{
    using Banking;

    static class Program
    {
        private static void PayAnnualInterest(Account[] accounts)
        {
            foreach (Account acc in accounts)
            {
                IProfitable p = acc as IProfitable;
                if (p != null)
                {
                    double amount = p.GetInterest(1);
                    acc.Deposit(amount);
                }
            }
        }

        private static void DeductTax(Account[] accounts)
        {
            foreach (Account acc in accounts)
            {
                ITaxable t = acc as ITaxable;
                t?.Deduct();
            }
        }

        public static void Main()
        {
            Account[] bank = new Account[4];
            bank[0] = Banker.OpenSavingsAccount();
            bank[0].Deposit(5000);
            bank[1] = Banker.OpenCurrentAccount();
            bank[1].Deposit(20000);
            bank[2] = Banker.OpenCurrentAccount();
            bank[2].Deposit(30000);
            bank[3] = Banker.OpenSavingsAccount();
            bank[3].Deposit(35000);

            PayAnnualInterest(bank);
            DeductTax(bank);

            foreach (Account acc in bank)
                Console.WriteLine($"{acc.Id}\t{acc.Balance}");
        }
    }
}

