@echo off
setlocal

:: -------------------------
:: CONFIGURATION
:: -------------------------
set PROJECT_PATH=NameSorter\NameSorter.csproj
set OUTPUT_FOLDER=publish
set RUNTIME=win-x64
set FINAL_EXE=name-sorter.exe
set INPUT_FILE=unsorted-names-list.txt

:: -------------------------
echo Cleaning old publish folder...
if exist %OUTPUT_FOLDER% rmdir /s /q %OUTPUT_FOLDER%

:: -------------------------
echo Publishing %PROJECT_PATH%...
dotnet publish %PROJECT_PATH% ^
  -c Release ^
  -r %RUNTIME% ^
  --self-contained true ^
  -p:PublishSingleFile=true ^
  -p:UseAppHost=true ^
  -o %OUTPUT_FOLDER%

if errorlevel 1 (
  echo ? Publish failed. Exiting.
  exit /b 1
)

:: -------------------------
echo Renaming executable to %FINAL_EXE%...
cd %OUTPUT_FOLDER%
rename NameSorter.exe %FINAL_EXE%
cd ..

:: -------------------------
echo Copying input file...
copy /Y %INPUT_FILE% %OUTPUT_FOLDER%\

:: -------------------------
echo Running the app...
cd %OUTPUT_FOLDER%
%FINAL_EXE% ./unsorted-names-list.txt

endlocal
pause
