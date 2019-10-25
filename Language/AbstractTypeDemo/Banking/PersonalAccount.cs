namespace Banking
{
    sealed class PersonalAccount : Account, IProfitable
    {
        const decimal MinBal = 100;

        internal PersonalAccount()
        {
            Balance = MinBal;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if(Balance - amount < MinBal)
                throw new InsufficientFundsException();
            Balance -= amount;
        }

        public decimal GetInterest(int months)
        {
            decimal rate = Balance < 60 * MinBal ? 1.0M : 1.2M;
            return Balance * rate * months / 1200;              
        }
    }
}
