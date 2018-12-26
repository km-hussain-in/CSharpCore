<h4>Creating native library</h4>

<pre>
Windows: cl /LD /Fe[EXECUTABLE-PATH]\native.dll native.c
MacOS  : clang -dynamiclib legacy.c -o [EXECUTABLE-PATH]/libnative.dylib
Linux  : cc -shared -fPIC legacy.c -o [EXECUTABLE-PATH]/libnative.so
</pre>