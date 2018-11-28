using System;

namespace NullValueTypeTest
{
    static class Program
    {
        //private static Nullable<double> GetBalance(string name)
        private static double? GetBalance(string name)
        {
            string[] names = { "jack", "john", "jill", "jane" };
            double[] balances = { 9000, 11000, 10000, 8000 };

            int i = Array.IndexOf(names, name);
            if (i >= 0)
                return balances[i];

            return null;
        }

        public static void Main(string[] args)
        {
            double? bal = GetBalance(args[0]);
            if (bal != null)
                Console.WriteLine("Balance: {0:0.00}", bal);
            else
                Console.WriteLine("Cannot find {0}!", args[0]);

            Console.WriteLine("Annual interest: {0:0.00}", 0.015 * (bal ?? 0));
        }
    }
}