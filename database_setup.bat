@echo off
set server=DESKTOP-5KO0J76\SQLEXPRESS
set username=sa
set password=admin
set scripts_dir=%~dp0

chcp 65001 > nul
for /f "tokens=*" %%f in ('dir /b /on "%scripts_dir%\*.sql"') do (
    sqlcmd -S %server% -U %username% -P %password% -f 65001 -i "%scripts_dir%\%%f"
)
pause
