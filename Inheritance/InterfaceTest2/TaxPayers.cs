namespace InterfaceTest2
{
    interface ITaxPayer
    {
        double GetAnnualIncome();
    }

    static class TaxPayers
    {
        //extension method - a method of a static class which can be
        //invoked as an instance method of its first parameter type 
        //qualified with 'this' modifier
        public static double GetIncomeTax(this ITaxPayer that, int age)
        {
            double amount = that.GetAnnualIncome() - 120000;
            float rate = age < 60 ? 0.15f : 0.12f;

            return amount > 0 ? rate * amount : 0;
        }
    }

    class Consultant : Payroll.Employee, ITaxPayer
    {
        public Consultant(int days, float rate) : base(8 * days, rate)
        {
        }

        public double GetAnnualIncome()
        {
            return 12 * base.GetIncome();
        }
    }

    class Dealer : ITaxPayer
    {
        private double sales;

        public Dealer(double s)
        {
            sales = s;
        }

        public double GetAnnualIncome()
        {
            return 0.1 * sales;
        }
    }


}