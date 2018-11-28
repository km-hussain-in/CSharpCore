namespace Payroll
{
	public class Employee
	{
		private int id;
		internal int hours;
		protected float rate;
		static int count;

		public Employee(int h, float r)
		{
			id = 101 + count++;
			hours = h;
			rate = r;
		}

		public Employee() : this(0, 0)
		{	
		}

		public int Id
		{
			get { return id; }
		}

		public int Hours
		{
			get { return hours; }
			set { hours = value; }
		}

		public float Rate
		{
			get { return rate; }
			set { rate = value; }		
		}		
		
		//overridable method  
		public virtual double GetIncome()
		{
			double income = hours * rate;
			int ot = hours - 180;
	
			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		public static int CountInstances()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		public double Sales { get; set; }

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			Sales = s;	
		}

		//overriding base class method
		public override double GetIncome()
		{
			double income = base.GetIncome();
			
			if(Sales >= 20000)
				income += 0.05 * Sales;

			return income;
		}
	}
}