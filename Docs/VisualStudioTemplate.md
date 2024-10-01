```PS

dotnet new install . --force
dotnet new uninstall .
dotnet new --list
dotnet new mytemplate -n Demo
```

```PS
winget install Microsoft.NuGet
nuget pack MyTemplate.nuspec
nuget push MyTemplate.1.0.0.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey <your-nuget-api-key>
```