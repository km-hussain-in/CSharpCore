@echo off
setlocal

rem set dotnethome=%~dp0
for /f "usebackq delims=" %%i  in (`where dotnet.exe`) do set dotnethome=%%~dpi
for /f %%i  in ('dotnet --version') do set sdkver=%%i
for /f "tokens=2" %%i in ('dotnet --list-runtimes ^| find "Microsoft.NETCore.App"') do set fwkver=%%i
set dotnetlib=%dotnethome%shared\Microsoft.NETCore.App\%fwkver%

if "%1" == "" goto :help

set prog=%~n1
(
	echo -r:"%dotnetlib%\netstandard.dll"
	echo -r:"%dotnetlib%\System.dll" 
	echo -r:"%dotnetlib%\Microsoft.CSharp.dll"
) > %temp%\%prog%.rsp
for %%f in ("%dotnetlib%\System.*.dll") do echo -r:"%%f" >> %temp%\%prog%.rsp

dotnet "%dotnethome%sdk\%sdkver%\Roslyn\bincore\csc.dll" -d:NETCOREAPP -nologo @%temp%\%prog%.rsp %*
if %errorlevel% == 0 (
    if exist %prog%.exe (
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
rem	if not exist %prog%.bat echo @dotnet %prog%.exe %%* > %prog%.bat
    )
)

del %temp%\%prog%.rsp

goto done
:help
dotnet "%dotnethome%sdk\%sdkver%\Roslyn\bincore\csc.dll" -help
:done
echo.


