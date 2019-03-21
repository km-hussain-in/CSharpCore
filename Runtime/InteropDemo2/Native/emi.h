#ifndef EMI_H
#define EMI_H

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

typedef struct {
	double amount;
	short period;
}Loan;
typedef float (*Scheme)(short);
EXPORT double EMI(const Loan*, Scheme);

#endif
