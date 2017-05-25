@echo iniciando processos && echo.

@echo Build CORE
"C:\Program Files (x86)\MSBuild\14.0\Bin\Msbuild.exe" "TibiaTools.sln" /property:Configuration=Release

@echo processo finalizados

pause