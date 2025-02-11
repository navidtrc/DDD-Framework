@echo off
setlocal

REM Define Variables
SET NUGET_SOURCE_NAME=
SET NUGET_SOURCE_URL=
SET NUGET_USERNAME=
SET NUGET_PASSWORD=
SET NUGET_API_KEY=
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

REM Remove existing NuGet source if it exists
echo Removing existing NuGet source "%NUGET_SOURCE_NAME%" if it exists...
dotnet nuget remove source %NUGET_SOURCE_NAME% >nul 2>&1

REM Add NuGet source with credentials
echo Adding NuGet source "%NUGET_SOURCE_NAME%"...
dotnet nuget add source %NUGET_SOURCE_URL% -n %NUGET_SOURCE_NAME% --username %NUGET_USERNAME% --password %NUGET_PASSWORD% --store-password-in-clear-text
IF %ERRORLEVEL% NEQ 0 (
    echo Adding NuGet source failed.
)

REM Push the packages
echo Pushing packages to NuGet source "%NUGET_SOURCE_NAME%"...
dotnet nuget push .\%OUTPUT_DIR%\*.nupkg --source %NUGET_SOURCE_NAME% --api-key %NUGET_API_KEY% --skip-duplicate
IF %ERRORLEVEL% NEQ 0 (
    echo Pushing packages failed.
)

REM Clean the output directory
IF EXIST %OUTPUT_DIR% (
    rmdir /s /q %OUTPUT_DIR%
)

echo All packages pushed successfully.
pause
endlocal
