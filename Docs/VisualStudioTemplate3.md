To create a custom Visual Studio template for your project and provide commands for creating, installing, listing, and removing templates, along with deployment best practices, follow these steps:

### 1. **Create a Visual Studio Template from the Existing Projects**

#### Step 1: Organize Your Solution for Templating
Make sure your solution structure is ready to be templated. The folder structure and project references should be intact.

```
MyTemplate/
    ├── MyTemplate.ConsoleApp/
    ├── MyTemplate.Shared/
    ├── MyTemplate.TestProject/
    ├── Settings/
    │   └── appsettings.development.json
    └── MyTemplate.sln
```

#### Step 2: Prepare for Renaming (Add Parameterized Names)
You need to parameterize your project and solution names so that when the user runs `dotnet new mytemplate -n Demo`, it will generate a solution and projects with the correct namespaces.

- Update namespaces in all project files to use template parameters (e.g., `namespace $safeprojectname$.ConsoleApp`).
- Use tokens like `$ext_safeprojectname$` and `$safeprojectname$` to ensure the new name and namespace are generated dynamically.

#### Example Changes in `.csproj` files:
Replace fixed namespaces with tokens in your `.csproj` files.

For example:
```xml
<RootNamespace>$safeprojectname$.ConsoleApp</RootNamespace>
<AssembyName>$safeprojectname$.ConsoleApp</AssembyName>
```

In `MyTemplate.Shared.csproj`:
```xml
<RootNamespace>$safeprojectname$.Shared.Services</RootNamespace>
<AssembyName>$safeprojectname$.Shared.Services</AssembyName>
```

#### Step 3: Export the Template
1. Open Visual Studio and load your solution.
2. Click on **File > Export Template**.
3. Select **Project Template** or **Solution Template** depending on whether you want each project or the entire solution to be templated.
4. Fill out the details (template name, description) and finish the export process. This will generate `.zip` files of your template in the `Documents\Visual Studio <version>\My Exported Templates\` folder.

### 2. **Install the Template Locally**

Once you've exported the template:

1. Copy the `.zip` file generated from the export into the following folder:
   - For **dotnet new**: `%USERPROFILE%\.templateengine\dotnetcli\`
   - For **Visual Studio**: `%USERPROFILE%\Documents\Visual Studio <version>\Templates\ProjectTemplates`

2. Run `dotnet new --install <path-to-zip>` to install the template in the `dotnet` CLI.

### 3. **Use the Template**

Now that the template is installed, you can use the `dotnet` CLI to create new projects:

```bash
dotnet new mytemplate -n Demo
```

This will generate:
- `Demo.sln`
- `Demo.ConsoleApp.csproj` (namespace `Demo.ConsoleApp`)
- `Demo.Shared.csproj` (namespace `Demo.Shared.Services`)
- `Demo.TestProject.csproj` (namespace `Demo.TestProject`)

### 4. **List Installed Templates**

To list the installed templates:
```bash
dotnet new --list
```

### 5. **Remove the Template**

To remove the template:
```bash
dotnet new --uninstall <path-to-zip>
```

### 6. **Deploying the Template via NuGet**

To share your template with others, you can package and upload it to a NuGet feed.

#### Step 1: Create a `.nuspec` File
Create a `.nuspec` file for your template.

```xml
<?xml version="1.0"?>
<package>
  <metadata>
    <id>MyTemplate</id>
    <version>1.0.0</version>
    <authors>YourName</authors>
    <description>A multi-project template for .NET Core</description>
    <dependencies>
      <group targetFramework=".NETCoreApp">
        <dependency id="Microsoft.NET.Sdk" version="8.0.0" />
      </group>
    </dependencies>
  </metadata>
  <files>
    <file src="path-to-template-folder" target="content" />
  </files>
</package>
```

#### Step 2: Pack the Template
Package your template:

```bash
nuget pack MyTemplate.nuspec
```

#### Step 3: Publish the Package to NuGet
```bash
nuget push MyTemplate.<version>.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey <your-nuget-api-key>
```

### 7. **Deploying the Template via GitHub**

If you'd like to deploy the template via GitHub:

1. Create a repository for the template.
2. Upload the entire solution folder.
3. Add a clear `README.md` with installation instructions:
   ```bash
   git clone https://github.com/your-repo/MyTemplate.git
   dotnet new --install ./MyTemplate
   ```

### Best Practices for Templating

1. **Parameterization**: Ensure proper use of `$safeprojectname$` and other tokens for naming conventions.
2. **Versioning**: Maintain versioning when exporting and publishing templates.
3. **Documentation**: Always include clear instructions for installing and using the template, either via NuGet or GitHub.
4. **Testing**: Test the template across multiple environments (Windows, Linux, macOS) to ensure portability.

This setup should help you create, distribute, and use your multi-project Visual Studio template effectively!