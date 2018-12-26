<h4>Creating native library</h4>

<pre>
Windows: cl /LD /Fe[EXECUTABLE-PATH]\native.dll native.c
MacOS  : clang -dynamiclib native.c -o [EXECUTABLE-PATH]/libnative.dylib
Linux  : cc -shared -fPIC native.c -o [EXECUTABLE-PATH]/libnative.so
</pre>