msbuild ..\WinFormsControlNetFramework.Design\WinFormsControlNetFramework.Design.csproj -p:Configuration=Release 
msbuild ..\WinFormsControlNetFramework\WinFormsControlNetFramework.Design.csproj -p:Configuration=Release 
..\libs\nuget.exe pack ..\WinformsControlNetFramework\WinformsControlNetFramework.nuspec -Version %PACKAGEVERSION% -OutputDirectory Packages
