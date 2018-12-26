#ifndef NATIVE_H
#define NATIVE_H

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

EXPORT long GreatestDivisor(long, long);

EXPORT int Encrypt(char*, int, const char*);

typedef struct {
	double amount;
	short period;
}Loan;

typedef float (*Scheme)(short);

EXPORT double EMI(const Loan*, Scheme);

#endif
