```PS
dotnet new install . --force
dotnet new uninstall .
dotnet new --list
dotnet new mytemplate -n Demo1
dotnet new mytemplate -n Demo1
```

Please provide how to create, install, list, remove and other related commands concepts for following visual studio template, it has solution named MyTemplate and projects MyTemplate.Shared, MyTemplate.TestProject and MyTemplate.ConsoleApp. Please provide suggestions the ways to deploy from nugget and GitHub. Include suggestion for easiest and best practices.

MyTemplate/
    ├── MyTemplate.ConsoleApp/
    ├── MyTemplate.Shared/
    ├── MyTemplate.TestProject/
    ├── Settings/
    │   └── appsettings.development.json
    └── MyTemplate.sln

I would like the functiuonality when I run "dotnet new mytemplate -n Demo" the new namespace, solution, project files should be the following.

Demo.sln
Demo.ConsoleApp.csproj
Demo.Shared.csproj
Demo.TestProject.csproj

Below are the current project files.