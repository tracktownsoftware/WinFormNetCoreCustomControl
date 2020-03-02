msbuild ..\WPFControlNetFramework.Design\WPFControlNetFramework.Design.csproj -p:Configuration=Release 
msbuild ..\WPFControlNetFramework\WPFControlNetFramework.Design.csproj -p:Configuration=Release 
..\libs\nuget.exe pack ..\WpfControlNetFramework\WpfControlNetFramework.nuspec -Version %PACKAGEVERSION% -OutputDirectory Packages