using System;

namespace Finance
{
	[AttributeUsage(AttributeTargets.Class)]
	public class MaxDurationAttribute : Attribute
	{
		public int Limit {get; set;}

		public MaxDurationAttribute(int years)
		{
			Limit = years;
		}

		public MaxDurationAttribute() : this(3) {}
	}


	[MaxDuration(12)]
	public class HomeLoan
	{
		public float GetInterestRate(int period)
		{
			return period < 10 ? 3.0f : 3.5f;
		}
	}

	[MaxDuration]
	public class EducationLoan
	{
		public float GetInterestRate(int period)
		{
			return 2.0f;
		}
	}


	[MaxDuration(Limit = 4)]
	public class PersonalLoan
	{
		public float GetInterestRate(int period)
		{
			return period < 3 ? 4.5f : 5.0f;
		}
	}

	public class BusinessLoan
	{
		public float GetInterestRate(int period)
		{
			return 4.0f + 0.5f * (period / 3);
		}
	}

}
