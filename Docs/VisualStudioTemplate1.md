To distribute a Visual Studio template with one solution and multiple projects (like your `MultiProjectTemplate`), you can follow these steps to package the solution as a Visual Studio template:

### 1. Organize the Solution
Make sure your solution and projects are organized in a way that can be easily packaged. Based on your description, your solution structure would look like this:

```
MultiProjectTemplate/
    ├── MultiProjectTemplate.ConsoleApp/
    ├── MultiProjectTemplate.ClassLibrary/
    ├── MultiProjectTemplate.TestProject/
    ├── Settings/
    │   └── appsettings.development.json
    └── MultiProjectTemplate.sln
```

### 2. Create a Template Manifest File (`.vstemplate`)

Each project should have a corresponding `.vstemplate` file to define how Visual Studio will treat the project as a template. Here's how to create the `.vstemplate` files:

- **Create a `.vstemplate` for each project** (ConsoleApp, ClassLibrary, TestProject).
- **Create a `.vstemplate` for the solution** to bundle all the projects together.

#### Example for Solution-Level `.vstemplate`
Create a file named `MultiProjectTemplate.vstemplate` in the root folder (same level as `MultiProjectTemplate.sln`).

```xml
<VSTemplate Version="3.0.0" Type="ProjectGroup" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005">
  <TemplateData>
    <Name>MultiProject Template</Name>
    <Description>A template containing a console app, class library, and test project.</Description>
    <ProjectType>CSharp</ProjectType>
    <SortOrder>1000</SortOrder>
    <CreateNewFolder>true</CreateNewFolder>
    <DefaultName>MultiProjectTemplate</DefaultName>
  </TemplateData>
  <TemplateContent>
    <ProjectCollection>
      <ProjectTemplateLink ProjectName="MultiProjectTemplate.ConsoleApp">
        MultiProjectTemplate.ConsoleApp\MultiProjectTemplate.ConsoleApp.vstemplate
      </ProjectTemplateLink>
      <ProjectTemplateLink ProjectName="MultiProjectTemplate.ClassLibrary">
        MultiProjectTemplate.ClassLibrary\MultiProjectTemplate.ClassLibrary.vstemplate
      </ProjectTemplateLink>
      <ProjectTemplateLink ProjectName="MultiProjectTemplate.TestProject">
        MultiProjectTemplate.TestProject\MultiProjectTemplate.TestProject.vstemplate
      </ProjectTemplateLink>
    </ProjectCollection>
  </TemplateContent>
</VSTemplate>
```

#### Example for Console App Project `.vstemplate`
Inside the `MultiProjectTemplate.ConsoleApp` folder, create a file named `MultiProjectTemplate.ConsoleApp.vstemplate`.

```xml
<VSTemplate Version="3.0.0" Type="Project" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005">
  <TemplateData>
    <Name>MultiProject Console App</Name>
    <Description>A console application project for MultiProject template.</Description>
    <ProjectType>CSharp</ProjectType>
    <DefaultName>ConsoleApp</DefaultName>
    <SortOrder>1000</SortOrder>
  </TemplateData>
  <TemplateContent>
    <Project File="MultiProjectTemplate.ConsoleApp.csproj" ReplaceParameters="true">
      <ProjectItem ReplaceParameters="true">Program.cs</ProjectItem>
      <ProjectItem ReplaceParameters="true">..\Settings\appsettings.development.json</ProjectItem>
    </Project>
  </TemplateContent>
</VSTemplate>
```

Repeat a similar `.vstemplate` file for the `ClassLibrary` and `TestProject`, updating the names and description accordingly.

### 3. Customize Parameters (Optional)
In the `.vstemplate` files, you can replace project names, namespaces, and other content dynamically by adding template parameters. For example:

```xml
<CustomParameter Name="$projectname$" Value="MyProject"/>
```

You can reference `$projectname$` in your code or configuration files to allow users to customize the project name when they create the template.

### 4. Add Template Metadata
You can add custom icons and previews by adding these elements inside `<TemplateData>` in your `.vstemplate` file:

```xml
<Icon>MyTemplateIcon.ico</Icon>
<PreviewImage>MyTemplatePreview.png</PreviewImage>
```

### 5. Zip the Template
- After all `.vstemplate` files are created, select the entire solution folder (including all projects) and compress it into a `.zip` file.
- Ensure the `.zip` includes all necessary files (`.sln`, `.csproj`, `.vstemplate` files, etc.).

### 6. Install the Template
To install your template in Visual Studio:
- Place the `.zip` file in your Visual Studio user templates directory. For example, on Windows, this is typically:

```
%USERPROFILE%\Documents\Visual Studio {version}\Templates\ProjectTemplates
```

After placing the `.zip` file, restart Visual Studio. Your template should appear in the "New Project" dialog under "Installed" templates.

This method will allow others to use your solution with multiple projects as a template in Visual Studio!