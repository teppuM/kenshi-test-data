@echo off
setlocal

set "HERE=%~dp0"
if "%HERE:~-1%"=="\" set "HERE=%HERE:~0,-1%"

set "MEITOU_EXE=%~1"
if "%MEITOU_EXE%"=="" (
    echo Usage: "%~nx0" ^<path-to-MeitouClient.exe^> [path-to-Kenshi-folder]
    echo.
    echo You can also drag and drop MeitouClient.exe onto this batch file.
    echo If the second argument is omitted, KENSHI_PATH or the default Steam library is used.
    pause
    exit /b 1
)
if not exist "%MEITOU_EXE%" (
    echo ERROR: MeitouClient.exe not found at "%MEITOU_EXE%".
    pause
    exit /b 1
)

set "KENSHI_DIR=%~2"
if "%KENSHI_DIR%"=="" set "KENSHI_DIR=%KENSHI_PATH%"
if "%KENSHI_DIR%"=="" (
    if exist "C:\Program Files (x86)\Steam\steamapps\common\Kenshi\data" (
        set "KENSHI_DIR=C:\Program Files (x86)\Steam\steamapps\common\Kenshi"
    )
)
if "%KENSHI_DIR%"=="" (
    echo ERROR: Could not locate your Kenshi installation folder.
    echo Set KENSHI_PATH or pass the Kenshi folder as the second argument.
    pause
    exit /b 1
)

set "MOD_DST=%KENSHI_DIR%\mods\House Cellars"
if exist "%MOD_DST%" (
    echo ERROR: "%MOD_DST%" already exists. Move or back it up before running this test launcher so nothing is overwritten.
    pause
    exit /b 1
)

echo Installing temporary pure-data test mod (Eight-Storey Building, Floors -2 to 5)...
mkdir "%MOD_DST%\buildings"
copy /y "%HERE%\mod\House Cellars\House Cellars.mod" "%MOD_DST%\House Cellars.mod" >nul
xcopy "%HERE%\mod\House Cellars\buildings\*" "%MOD_DST%\buildings\" /q /y >nul

echo.
echo Launching MeitouClient on the arbitrary floors test save...
echo Leave this window open while testing. When MeitouClient closes, the
echo temporary mod folder will be removed automatically.
echo.

start "" /wait "%MEITOU_EXE%" --load "%HERE%\save" --mods-cfg "%HERE%\mods.cfg"

echo Cleaning up temporary test mod folder...
if exist "%MOD_DST%" rmdir /s /q "%MOD_DST%"
if exist "%MOD_DST%" (
    echo WARNING: Could not remove "%MOD_DST%". Delete it manually once no program is using it.
    pause
) else (
    echo Cleanup complete.
)
endlocal
