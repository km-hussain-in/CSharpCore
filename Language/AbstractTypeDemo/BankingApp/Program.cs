using System;

namespace BankingApp
{
    using Banking;

    class Program
    {

        static void PayAnnualInterest(Account[] accounts)
        {
            foreach(Account acc in accounts)
            {
                IProfitable p = acc as IProfitable; // acc is IProfitable ? (IProfitable) acc : null
                if(p != null)
                {
                    decimal i = p.GetAnnualInterest();
                    acc.Deposit(i);
                }
            }
        }

        static void ApplyQuaterlyCharges(Account[] accounts)
        {
            foreach(Account acc in accounts)
            {
                IChargeable c = acc as IChargeable;
                c?.Deduct(4); //if(c != null) c.Deduct(4)
            }
        }

        static void Main(string[] args)
        {
            Account[] bank = new Account[4];
            bank[0] = Banker.OpenBusinessAccount();
            bank[0].Deposit(4000);
            bank[1] = Banker.OpenPersonalAccount();
            bank[1].Deposit(4900);
            bank[2] = Banker.OpenPersonalAccount();
            bank[2].Deposit(5900);
            bank[3] = Banker.OpenBusinessAccount();
            bank[3].Deposit(7000);
            if(args.Length > 0)
            {
                try
                {
                    decimal payment = Convert.ToDecimal(args[0]);
                    bank[1].Transfer(payment, bank[0]);
                    Console.WriteLine("Transfer succeeded.");
                }
                catch(InsufficientFundsException)
                {
                    Console.WriteLine("Transfer failed due to lack of funds!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                PayAnnualInterest(bank);
                ApplyQuaterlyCharges(bank);
            }
            foreach(Account acc in bank)
                Console.WriteLine($"{acc.Id}\t{acc.Balance:0.00}");            
        }
    }
}
