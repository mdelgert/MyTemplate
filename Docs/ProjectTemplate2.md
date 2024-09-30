
# Creating a Multi-Project .NET Template (Console, Class Library, and Test Project)

This guide will walk you through creating a custom multi-project .NET template that scaffolds a solution with a console application, class library, and test project in a single command.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

Make sure you have .NET installed by running:

```bash
dotnet --version
```

## Step 1: Create the Folder Structure

Start by creating a folder for your template:

```bash
mkdir MultiProjectTemplate
cd MultiProjectTemplate
```

Inside this folder, you will create the following structure:

```
MultiProjectTemplate/
│
├── MultiProjectTemplate.ConsoleApp/
│   └── MultiProjectTemplate.ConsoleApp.csproj
│
├── MultiProjectTemplate.ClassLibrary/
│   └── MultiProjectTemplate.ClassLibrary.csproj
│
├── MultiProjectTemplate.TestProject/
│   └── MultiProjectTemplate.TestProject.csproj
│
└── .template.config/
    └── template.json
```

- `MultiProjectTemplate.ConsoleApp/`: The folder for the Console project.
- `MultiProjectTemplate.ClassLibrary/`: The folder for the Class Library project.
- `MultiProjectTemplate.TestProject/`: The folder for the Test project.
- `.template.config/`: The folder that contains the template definition (`template.json`).

### Step 2: Create `template.json`

Next, create the `template.json` file inside the `.template.config/` folder. This file will define how the projects will be scaffolded.

Here’s an example `template.json` file:

```json
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Your Name",
  "classifications": ["Console", "Library", "Test"],
  "identity": "MultiProjectTemplate",
  "name": "Multi Project Template",
  "shortName": "multi-template",
  "tags": {
    "language": "C#",
    "type": "project"
  },
  "primaryOutputs": [
    {
      "path": "MultiProjectTemplate.ConsoleApp/MultiProjectTemplate.ConsoleApp.csproj"
    },
    {
      "path": "MultiProjectTemplate.ClassLibrary/MultiProjectTemplate.ClassLibrary.csproj"
    },
    {
      "path": "MultiProjectTemplate.TestProject/MultiProjectTemplate.TestProject.csproj"
    }
  ],
  "symbols": {
    "MyProductName": {
      "type": "parameter",
      "description": "The name of the product",
      "replaces": "MyProduct"
    }
  },
  "sources": [
    {
      "modifiers": [
        {
          "condition": "(MyProductName != \"\")",
          "rename": {
            "MyProduct": "{MyProductName}"
          }
        }
      ]
    }
  ],
  "postActions": [
    {
      "actionId": "F403EC4B-33B2-41B3-8A60-6B481895AA47",
      "description": "Restore NuGet packages required by this project.",
      "manualInstructions": [
        {
          "text": "Run 'dotnet restore'"
        }
      ],
      "continueOnError": true
    }
  ]
}
```

### Step 3: Create the Projects

Now, create the actual .NET projects.

#### Console Application

1. Navigate to the `MultiProjectTemplate.ConsoleApp/` folder:
   ```bash
   cd MultiProjectTemplate.ConsoleApp
   ```
2. Create a new .NET console project:
   ```bash
   dotnet new console
   ```

#### Class Library

1. Navigate to the `MultiProjectTemplate.ClassLibrary/` folder:
   ```bash
   cd ../MultiProjectTemplate.ClassLibrary
   ```
2. Create a new .NET class library project:
   ```bash
   dotnet new classlib
   ```

#### Test Project

1. Navigate to the `MultiProjectTemplate.TestProject/` folder:
   ```bash
   cd ../MultiProjectTemplate.TestProject
   ```
2. Create a new .NET test project:
   ```bash
   dotnet new xunit
   ```

### Step 4: Add .NET Solution (Optional)

If you want to test the projects together locally, you can add a solution and link all three projects to it:

1. Navigate back to the root folder:
   ```bash
   cd ..
   ```
2. Create a new solution:
   ```bash
   dotnet new sln
   ```
3. Add the projects to the solution:
   ```bash
   dotnet sln add MultiProjectTemplate.ConsoleApp/MultiProjectTemplate.ConsoleApp.csproj
   dotnet sln add MultiProjectTemplate.ClassLibrary/MultiProjectTemplate.ClassLibrary.csproj
   dotnet sln add MultiProjectTemplate.TestProject/MultiProjectTemplate.TestProject.csproj
   ```

This is optional but helpful if you want to work on all projects in one solution.

## Step 5: Pack the Template

Once you have the structure and `template.json` ready, you need to pack the template into a `.nupkg` file to make it usable.

1. Navigate to the root directory of the template:
   ```bash
   cd ..
   ```
2. Run the following command to create the NuGet package:
   ```bash
   dotnet new -i . --force
   ```

This will install the template locally for testing purposes.

## Step 6: Test the Template

You can now test your new multi-project template. Run the following command to create a new solution with all three projects:

```bash
dotnet new multi-template -n MyNewSolution
```

This will generate a solution with a console application, class library, and test project named `MyNewSolution`.

## Step 7: (Optional) Publish the Template

Once you're satisfied with your template, you can publish it as a NuGet package so that others can use it as well.

1. Create a `.nuspec` file (or use `dotnet pack`) to prepare the package.
2. Publish the `.nupkg` file to [NuGet.org](https://www.nuget.org/) or share it privately.

## Conclusion

You’ve now created a multi-project template for .NET, which scaffolds a console application, class library, and test project in a single command. This template will save you time by reducing the repetitive setup work needed for new projects.
```