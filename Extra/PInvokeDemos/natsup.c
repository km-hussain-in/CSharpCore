#include <string.h>

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

EXPORT long long GCD(long long first, long long second)
{
	while(first != second)
	{
		if(first > second)
			first -= second;
		else
			second -= first;
	}

	return first;
}

EXPORT int ReverseString(const char* original, char* result)
{
	int n = strlen(original);
	register int i;

	for(i = 0; i < n; ++i)
		result[i] = original[n - i - 1];
	result[n] = 0;

	return n;

}

EXPORT int SquareAll(double values[], int count)
{
	register int i;

	for(i = 0; i < count; ++i)
		values[i] *= values[i];

	return count;
}

struct Range
{
	int begin;
	int end;
};

typedef float (*Sequence)(int);

EXPORT double SequenceSum(Sequence gen, const struct Range* lim)
{
	register int i;
	double total = 0;

	for(i = lim->begin; i < lim->end; ++i)
		total += gen(i);

	return total;
}

//Windows: cl /LD natsup.c
//Linux  : cc -shared -fPIC -o libnatsup.so natsup.c

