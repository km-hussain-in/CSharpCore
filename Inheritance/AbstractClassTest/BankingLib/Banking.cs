namespace Banking
{
	using System;

	public enum AccountFault {InsufficientFunds, IllegalTransfer}

	public class AccountException : ApplicationException
	{
		public AccountFault Cause {get; private set;}

		internal AccountException(AccountFault fault)
		{
			Cause = fault;
		}
	}

	//must inherit class
	public abstract class Account 
	{
		public int Id { get; internal set; }	

		public double Balance { get; protected set; }

		//must override method
		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(ReferenceEquals(this, that))
				throw new AccountException(AccountFault.IllegalTransfer);
			this.Withdraw(amount);
			that.Deposit(amount);
		}
	}
	
	//non-inheritable class
	sealed class CurrentAccount : Account
	{
		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}
	}

	sealed class SavingsAccount : Account
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
				throw new AccountException(AccountFault.InsufficientFunds);
			Balance -= amount;
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