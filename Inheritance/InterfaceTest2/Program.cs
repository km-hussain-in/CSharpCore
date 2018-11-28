using System;

namespace InterfaceTest2
{
    static class Program
    {
        public static void Main()
        {
            ITaxPayer jill = new Consultant(24, 125);
            ITaxPayer jack = new Dealer(6500000);

            Console.WriteLine("Income tax of Employee jill: {0:0.00}", jill.GetIncomeTax(36)); //TaxPayers.GetIncomeTax(jill, 36)
            Console.WriteLine("Income tax of Dealer jack: {0:0.00}", jack.GetIncomeTax(63));
        }
    }
}
