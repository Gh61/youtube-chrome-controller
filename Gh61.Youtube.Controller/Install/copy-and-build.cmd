echo off
cls

echo COPYING NEW FILES
echo Please run Release build of Gh61.Youtube.Controller.Win and then press enter to continue...
echo.
pause

del /F /Q Source\*.*
copy ..\Gh61.Youtube.Controller.Win\bin\Release\Gh61.Youtube.Controller.Win.exe Source\*.*
copy ..\Gh61.Youtube.Controller.Win\bin\Release\websocket-sharp.clone.dll Source\*.*
copy Output\.gitignore Source\*.*
REM pause

echo.
echo Copied. Creating installator

Compiler\ISCC.exe install.iss

echo.
pause