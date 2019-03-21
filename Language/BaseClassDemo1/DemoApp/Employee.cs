namespace DemoApp
{
    class Employee
    {
        public int Hours {get; set;}

        public float Rate {get; set;}

        public Employee(int h, float r)
        {
            Hours = h;
            Rate = r;
            #if TESTING
            System.Console.WriteLine("Employee object constructed");
            #endif
        }

        public Employee() : this(0, 9){}

        public virtual double GetIncome() => Hours * Rate;
    }
}
