using System;

namespace Finance
{
	public interface ILoan
	{
		float GetInterestRate(int period);
	}

	public class HomeLoan : ILoan
	{
		public float GetInterestRate(int period) {
			return period < 10 ? 9.25f : 8.75f;
		}

		public float GetInterestRateForWomen(int period) {
			return GetInterestRate(period) - 0.25f;
		}
	}

	public class PersonalLoan : ILoan
	{
		public float GetInterestRate(int period) {
			return 10 + 0.5f * (period / 3);
		}

		public float GetInterestRateForEmployees(int period) {
			return 0.75f * GetInterestRate(period);
		}
	}

	public class BusinessLoan : ILoan
	{
		public float GetInterestRate(int period) {
			return 12.5f;
		}
	}

	public class CarLoan : ILoan
	{
		public float GetInterestRate(int period) {
			return 10.75f + 0.25f * period; 
		}
	}

}
