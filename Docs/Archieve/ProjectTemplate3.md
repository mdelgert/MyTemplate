
# Managing .NET 8 Templates (Add, List, Remove, and Pack for NuGet)

In .NET 8, you can easily manage custom templates for various project types. This guide explains how to add, list, and remove templates, as well as how to package and submit your template to NuGet.

## Adding a .NET 8 Template

You can install a custom .NET template either from a local folder or from a `.nupkg` file (NuGet package).

### Installing from a Local Folder

If you have the template stored in a local folder, you can add it by running:

```bash
dotnet new install ./path/to/template/folder
```

This command installs the template from the specified folder. Make sure the folder contains the `.template.config` directory with the `template.json` file.

### Installing from a NuGet Package

If you have your template packaged into a `.nupkg` file, you can install it by running:

```bash
dotnet new install ./path/to/template.nupkg
```

If the template is published on NuGet, you can install it by using:

```bash
dotnet new install PackageName
```

For example:

```bash
dotnet new install MyMyTemplate
```

## Listing Installed Templates

To see all the installed templates on your system, use the following command:

```bash
dotnet new list
```

This command will display a list of all available templates along with their short names, languages, and types.

You can also filter the results by specific criteria. For example, to see all console-related templates, you can run:

```bash
dotnet new list --type project --search Console
```

## Removing a .NET Template

To remove an installed template, you can use the following command:

```bash
dotnet new uninstall TemplateNameOrPath
```

For example, to remove a locally installed template:

```bash
dotnet new uninstall ./path/to/template/folder
```

Or, if you want to remove a template installed from NuGet:

```bash
dotnet new uninstall MyMyTemplate
```

## Packing a .NET Template for NuGet

Once you’ve created your template and tested it locally, you can package it for distribution via NuGet. Follow these steps:

### Step 1: Prepare the Template

Ensure that your template has the following structure:

```
YourTemplate/
│
├── Project1/
│   └── Project1.csproj
├── Project2/
│   └── Project2.csproj
└── .template.config/
    └── template.json
```

### Step 2: Create a `.nuspec` File (Optional)

If you want more control over the packaging process, create a `.nuspec` file in the root directory of your template. This file defines metadata about your template package, such as its name, version, and description. Here's an example of a basic `.nuspec` file:

```xml
<?xml version="1.0"?>
<package>
  <metadata>
    <id>YourTemplateID</id>
    <version>1.0.0</version>
    <authors>Your Name</authors>
    <description>Your template description</description>
  </metadata>
</package>
```

### Step 3: Pack the Template

To create a `.nupkg` file for your template, run the following command from the root directory of your template (where the `.template.config` folder is located):

```bash
dotnet pack
```

This will generate a `.nupkg` file in the `bin/Debug/` or `bin/Release/` folder, depending on your build configuration.

### Step 4: Test the NuGet Package Locally

Before submitting your package to NuGet, you can test it locally by running:

```bash
dotnet new install ./path/to/YourTemplateID.nupkg
```

Then, create a new project using the installed template to ensure everything works as expected.

```bash
dotnet new YourTemplateShortName -n MyTestProject
```

### Step 5: Submit to NuGet

To submit your template to NuGet, you need to have a [NuGet.org](https://www.nuget.org/) account. Follow these steps:

1. **Generate an API Key**: 
   - Go to [NuGet.org](https://www.nuget.org/), sign in, and generate an API key from your account settings.

2. **Submit the Package**: 
   Use the following command to submit your `.nupkg` file to NuGet:

   ```bash
   dotnet nuget push ./path/to/YourTemplateID.nupkg --api-key YourAPIKey --source https://api.nuget.org/v3/index.json
   ```

   Replace `YourAPIKey` with the key you generated on NuGet.org.

Once submitted, your template will be available for others to install using the `dotnet new install` command.

## Conclusion

With these steps, you now know how to:

- Add, list, and remove .NET 8 templates.
- Package a template using `dotnet pack`.
- Submit your template to NuGet for global distribution.

This enables you to efficiently share templates with others or streamline your own project creation workflow.
```