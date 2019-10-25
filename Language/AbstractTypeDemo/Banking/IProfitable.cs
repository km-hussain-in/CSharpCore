namespace Banking
{
    public interface IProfitable
    {
        decimal GetInterest(int months);

		decimal GetAnnualInterest()
		{
			return GetInterest(12);
		}
    }
}
