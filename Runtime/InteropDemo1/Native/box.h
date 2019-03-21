#ifndef BOX_H
#define BOX_H

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

typedef void* Box;
EXPORT Box CreateBox(float, float, float);
EXPORT double  BoxGetVolume(Box, float);
EXPORT void DestroyBox(Box);

#endif
