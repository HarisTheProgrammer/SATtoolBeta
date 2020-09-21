@ECHO OFF

IF NOT EXIST "SampleApp\ToDoApplication\bin\Debug\ToDoSample.Application.exe" (
  ECHO Please compile the ToDoSample application and try again.
  GOTO :EOF
)

ECHO Refreshing code analyzer assemblies...
COPY "StaticCodeAnalyzer\Arebis.CodeAnalysis.Static\bin\Debug" "Generator\bin" /y
ECHO Done.

PUSHD %~dp0Generator

ECHO Copying static files to output...
COPY /Y files\*.* ..\Output
ECHO Done.

ECHO Generating dynamic pages...
bin\CGEN GenerationSettings.xml
ECHO Done.

POPD

PAUSE


start Output\Index.html