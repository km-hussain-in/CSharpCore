namespace DemoApp
{
    class SalesPerson : Employee
    {
        public double Sales {get;}

        public SalesPerson(int h, float r, double s) : base(h, r)
        {
            Sales = s;
            #if TESTING
            System.Console.WriteLine("SalesPerson object constructed");
            #endif            
        }

        public override double GetIncome() => base.GetIncome() + 0.02 * Sales;
    }
}