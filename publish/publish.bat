cd %~dp0


@echo clean TibiaTools bin folder

set TibiaToolsFolder=..\TibiaTools.Application\bin\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Application\obj\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Core\bin\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Core\obj\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Database\bin\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Database\obj\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Domain\bin\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

set TibiaToolsFolder=..\TibiaTools.Domain\obj\
RD /S /Q %TibiaToolsFolder%
mkdir %TibiaToolsFolder%

@echo build TibiaTools

"C:\Program Files (x86)\MSBuild\14.0\Bin\Msbuild.exe" "..\TibiaTools.sln" /property:Configuration=Release

@echo run MSBUILD

"C:\Program Files (x86)\MSBuild\14.0\Bin\Msbuild.exe" "publish.msbuild"

PAUSE

@echo processo finalizados