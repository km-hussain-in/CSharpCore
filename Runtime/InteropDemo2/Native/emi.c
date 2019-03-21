#include "emi.h"

double EMI(const Loan* info, Scheme policy)
{
	register int m = 12 * info->period;
	float i = policy(info->period) / 1200;
	float n = 0;
	while(m--)
		n = (1 + n) / (1 + i);
	return info->amount / n;
}
