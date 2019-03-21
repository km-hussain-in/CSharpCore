#ifndef ENCRYPT_H
#define ENCRYPT_H

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

EXPORT int Encrypt(const char*, char*, int);

#endif
