@echo off
setlocal

set dotnethome=%~dp0
for /f %%i  in ('dotnet --version') do set sdkver=%%i
for /f "tokens=2" %%i in ('dotnet --list-runtimes ^| find "Microsoft.NETCore.App"') do set fwkver=%%i
set dotnetlib=%dotnethome%shared\Microsoft.NETCore.App\%fwkver%

set prog=%~n1
(
	echo -r:"%dotnetlib%\netstandard.dll"
	echo -r:"%dotnetlib%\System.dll" 
	echo -r:"%dotnetlib%\Microsoft.CSharp.dll"
) > %temp%\%prog%.rsp
for %%f in ("%dotnetlib%\System.*.dll") do echo -r:"%%f" >> %temp%\%prog%.rsp

dotnet "%dotnethome%sdk\%sdkver%\Roslyn\bincore\csc.dll" -d:NETCORE -nologo @%temp%\%prog%.rsp %*
del %temp%\%prog%.rsp
if exist %prog%.exe (
	move /Y %prog%.exe %prog%.dll > NUL
	if not exist %prog%.runtimeconfig.json (
	    (
		echo {
  		echo   "runtimeOptions": {
    		echo     "framework": {
      		echo       "name": "Microsoft.NETCore.App",
      		echo       "version": "%fwkver%"
    		echo     }
  		echo   }
		echo }
	    ) > %prog%.runtimeconfig.json
	)
rem	if not exist %prog%.bat echo @dotnet %prog%.dll %%* > %prog%.bat	
)





