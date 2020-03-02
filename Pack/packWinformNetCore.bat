msbuild ..\WinformsControlNetCore.Design\WinFormsControlNetCore.Design.csproj -p:Configuration=Release 
dotnet pack -p:PackageVersion=%PACKAGEVERSION% ..\WinformsControlNetCore\WinFormsControlNetCore.csproj --configuration=Release --output Packages
