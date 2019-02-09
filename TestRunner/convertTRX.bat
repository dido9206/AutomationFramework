@ECHO OFF
echo The available TRX results from executions are:
echo.
cd TestResults
dir /b /a-d *.trx
cd..
echo.
set /p reportfile= Please enter the report file you want to convert: 
echo %reportfile%
start trxer-master\TrxerConsole\bin\Debug\TrxerConsole.exe TestResults\%reportfile%
exit