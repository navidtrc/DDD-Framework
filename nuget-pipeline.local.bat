@echo off
setlocal

REM Define Variables
SET OUTPUT_DIR=out

REM Clean the output directory
IF EXIST %OUTPUT_DIR% (
    rmdir /s /q %OUTPUT_DIR%
)

REM Build the solution
echo Building the solution...
dotnet build
IF %ERRORLEVEL% NEQ 0 (
    echo Build failed.
)

REM Pack the projects
echo Packing Framework.Utilities...
dotnet pack ./src/Common/Utilities/Utilities.csproj -c Debug --output ./%OUTPUT_DIR%
IF %ERRORLEVEL% NEQ 0 (
    echo Packing Utilities failed.
)

echo Packing Framework.Domain...
dotnet pack ./src/Framework/Domain/Framework.Domain.csproj -c Debug --output ./%OUTPUT_DIR%
IF %ERRORLEVEL% NEQ 0 (
    echo Packing Framework.Domain failed.
)

echo Packing Framework.Domain.Toolkits...
dotnet pack ./src/Framework/Domain.Toolkits/Framework.Domain.Toolkits.csproj -c Debug --output ./%OUTPUT_DIR%
IF %ERRORLEVEL% NEQ 0 (
    echo Packing Framework.Domain.Toolkits failed.
)

echo All packages pushed successfully.
pause
endlocal
