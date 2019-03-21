#include "box.h"
#include <stdlib.h>

Box CreateBox(float length, float breadth, float height)
{
	float* dim = malloc(3 * sizeof(float));
	dim[0] = length;
	dim[1] = breadth;
	dim[2] = height;

	return dim;
}

double BoxGetVolume(Box box, float thickness)
{
	float* dim = box;
	return (dim[0] - 2 * thickness) * (dim[1] - 2 * thickness) * (dim[2] - 2 * thickness);
}

void DestroyBox(Box box)
{
	free(box);
}

/*
Windows: cl /LD box.c
MacOS  : clang -dynamiclib box.c -o libbox.dylib
*/

