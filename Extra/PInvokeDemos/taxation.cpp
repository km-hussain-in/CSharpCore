#include "taxation.h"

namespace Taxation
{
	double inline Excess(double value, double limit)
	{
		return (value > limit) * (value - limit);
	}

	TaxPayer::TaxPayer(short ageVal)
	{
		age = ageVal;
	}

	short TaxPayer::Age() const
	{
		return age;
	}

	double TaxPayer::IncomeTax(double income) const
	{
		double free = 250000 + 50000 * (age >= 60) + 200000 * (age >= 80);
		return 0.05 * Excess(income, free) + 0.2 * Excess(income, 500000) + 0.3 * Excess(income, 1000000);
	}
}



