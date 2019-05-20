@echo off

SET option=%1
SET name=%2

echo Running migrations [Option = %option%, name = %name%]

SET "startup-project=./src/NginxDash"
SET "project=./src/NginxDashCore"
SET cmd=x

if "%option%" == "add" (
    SET "cmd=dotnet ef migrations add %name% --startup-project %startup-project% --project %project%"
)

if "%option%" == "update" (
    SET "cmd=dotnet ef database update --startup-project %startup-project% --project %project%"
)

if "%option%" == "remove" (
    SET "cmd=dotnet ef migrations remove --startup-project %startup-project% --project %project%"
)

if "%option%" == "revert" (
    SET "cmd=dotnet ef database update %name% --startup-project %startup-project% --project %project%"
)

if "%option%" == "script" (
    SET "cmd=dotnet ef migrations script --startup-project %startup-project% --project %project%"
)

echo %cmd%
echo .
call %cmd%