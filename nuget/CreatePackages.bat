@echo off


@rd /S /Q packages
@mkdir packages

rem Most packages are now built automatically due to settings in the csproj files
rem nuget restore ..\src\DoddleReport.sln
rem nuget pack ..\src\DoddleReport\DoddleReport.csproj -prop Configuration=Release -Build -Symbols -OutputDirectory .\packages
rem nuget pack ..\src\DoddleReport.AbcPdf\DoddleReport.AbcPdf.csproj -prop Configuration=Release -Build -Symbols -OutputDirectory .\packages
rem nuget pack ..\src\DoddleReport.iTextSharp\DoddleReport.iTextSharp.csproj -prop Configuration=Release -Build -Symbols -OutputDirectory .\packages
rem nuget pack ..\src\DoddleReport.OpenXml\DoddleReport.OpenXml.csproj -prop Configuration=Release -Build -Symbols -OutputDirectory .\packages
nuget pack ..\src\DoddleReport.Web\DoddleReport.Web.csproj -prop Configuration=Release -Build -Symbols -OutputDirectory .\packages

rem nuget pack ..\src\DoddleReport.Sample.Web\DoddleReport.Sample.Mvc.nuspec -OutputDirectory .\packages

