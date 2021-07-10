#include "taxation.h"


extern "C" double IncomeTaxFunc(short age, double income)
{
	Taxation::TaxPayer payer(age);

	return payer.IncomeTax(income);
}

//Windows: cl /LD txnshim.cpp taxation.obj /link /export:IncomeTaxFunc
//Linux  : c++ -shared -fPIC -o libtxnshim.so txnshim.cpp taxation.o

