#include "legacy.h"
#include <string.h>

long GreatestDivisor(long first, long second)
{
	if(first < 0)
		first = -first;
	if(second < 0)
		second = -second;

	while(first != second)
	{
		if(first > second)
			first -= second;
		else
			second -= first;
	}

	return first;
}

int Encrypt(char* buffer, int count, const char* key)
{
	register int i; 
	int n = strlen(key);

	for(i = 0; i < count; ++i)
		buffer[i] ^= key[i % n];

	return count;
}

static double Power(double base, long index)
{
	if(index < 0)
		return Power(1 / base, -index);
	if(index == 0)
		return 1;
	return base * Power(base, index - 1);
}

double EMI(const Loan* info, Scheme policy)
{
	float i = policy(info->period) / 1200;
	long m = 12 * info->period;

	return info->amount * i / (1 - Power(1 + i, -m));
}

//Windows: cl /LD /Febin\Debug\netcoreapp2.2\legacy.dll legacy.c
//MacOS  : clang -dynamiclib legacy.c -o bin/Debug/netcoreapp2.2/liblegacy.dylib
//Linux  : cc -shared -fPIC legacy.c -o bin/Debug/netcoreapp2.2/liblegacy.so
