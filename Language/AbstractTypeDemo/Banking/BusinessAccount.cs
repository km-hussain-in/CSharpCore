namespace Banking
{
    sealed class BusinessAccount : Account, IChargeable
    {
        public override void Deposit(decimal amount)
        {
            if(Balance < 0)
                amount *= 0.95M;
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        void IChargeable.Deduct(int months)
        {
            decimal rate = Balance < 5000 ? 5 : 2;
            Balance -= rate * months;
        }
    }
}