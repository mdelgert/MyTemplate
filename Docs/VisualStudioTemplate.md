# Install templates
```PS
dotnet new install . --force
dotnet new uninstall .
dotnet new --list
dotnet new mytemplate -n demo
```

# List installed templates
```PS
dotnet new uninstall
dotnet new uninstall C:\Source\MyTemplate (example uninstall)
```

```PS
winget install Microsoft.NuGet
nuget pack MyTemplate.nuspec
nuget push MyTemplateMelgert.1.0.0.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey <your-nuget-api-key>
```