set PACKAGEVERSION=1.2.70
msbuild ..\WinformsControlNetCore\WinFormsControlNetCore.csproj -p:Configuration=Release 
rem msbuild ..\WinformsControlNetCore.Design\WinFormsControlNetCore.Design.csproj -p:Configuration=Release 
rem msbuild ..\WinformsControlNetCore.DesignTools\WinformsControlNetCore.DesignTools.csproj -p:Configuration=Release 
dotnet pack -p:PackageVersion=%PACKAGEVERSION% ..\WinformsControlNetCore\WinFormsControlNetCore.csproj --configuration=Release --output Packages
