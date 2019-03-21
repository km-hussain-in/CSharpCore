#include "encrypt.h"
#include <string.h>

int Encrypt(const char* key, char* buffer, int count)
{
	register int i; 
	int n = strlen(key);
	for(i = 0; i < count; ++i)
		buffer[i] ^= key[i % n];
	return count;
}

