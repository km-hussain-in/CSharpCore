namespace Banking
{
	using System;

	public class InsufficientFundsException : ApplicationException {}

	public abstract class Account 
	{
		public int Id { get; internal set; }	

		public double Balance { get; protected set; }

		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(!ReferenceEquals(this, that))
			{
				this.Withdraw(amount);
				that.Deposit(amount);
			}
		}
	}

	public interface IProfitable
	{
		double GetInterest(int period);
	}

	public interface ITaxable
	{
		void Deduct();
	}

	public interface IFineable
	{
		void Deduct();
	}
	
	sealed class CurrentAccount : Account, ITaxable, IFineable
	{
		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}

		//explicit interface 
		void ITaxable.Deduct()
		{
			double amount = Balance - 25000;
			if(amount > 0)
				Balance -= 0.05 * amount;	
		}

		void IFineable.Deduct()
		{
			if(Balance < 0)
				Balance *= 1.1;
		}
	}

	sealed class SavingsAccount : Account, IProfitable
	{
		const double MinBal = 5000;

		internal SavingsAccount()
		{
			Balance = MinBal;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinBal)
				throw new InsufficientFundsException();
			Balance -= amount;
		}

		public double GetInterest(int period)
		{
			float rate = Balance < 3 * MinBal ? 4 : 5;
			return Balance * period * rate / 100;
		}		
	}

	public static class Banker
	{
		private static int nid = Environment.TickCount % 1000000;

		public static Account OpenCurrentAccount()
		{
			CurrentAccount acc = new CurrentAccount();
			acc.Id = 100000000 + nid++;
			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			SavingsAccount acc = new SavingsAccount();
			acc.Id = 200000000 + nid++;
			return acc;
		}
	}
}