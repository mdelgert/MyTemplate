
<img src="https://raw.githubusercontent.com/mdelgert/MultiProjectTemplate/refs/heads/main/Images/logo1.png?raw=true" alt="Logo" width="25%">

# MultiProjectTemplate

*A versatile .NET template for creating multiple project types with ease and flexibility.*

## Description

`MultiProjectTemplate` is a .NET 8 project template designed to streamline the creation of various project types, including Console applications, Class Libraries, and Test Projects. It provides developers with a modular, customizable solution to scaffold new projects quickly while maintaining flexibility and best practices. This template is ideal for teams and individuals looking to standardize project structure, reduce boilerplate, and speed up the development process.

## Features

- **Multiple Project Types**: Supports Console applications, Class Libraries, and Test Projects.
- **Customization Options**: Configure settings like project names and namespaces.
- **Modular Design**: Easily extendable to fit your specific needs.
- **Built-in Best Practices**: Follows recommended .NET coding standards and project organization.
- **Pre-configured Docker Support**: Ready-made Dockerfile for quick containerization.

## Prerequisites

To use the `MultiProjectTemplate`, you will need the following software and tools installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

Ensure that you have .NET 8.0 or higher by running:

```bash
dotnet --version
```

## Installation

You can install the `MultiProjectTemplate` template locally or globally.

### Global Installation

To install the template globally, run the following command:

```bash
dotnet new --install MultiProjectTemplate
```

### Local Installation

Alternatively, to install the template locally, navigate to the directory where you have the `.nupkg` file and run:

```bash
dotnet new --install ./path/to/MultiProjectTemplate.nupkg
```

## Usage

Once installed, you can create a new project using the `MultiProjectTemplate` by running the following commands.

### Console Application

```bash
dotnet new multi-template -n MyConsoleApp
```

### Class Library

```bash
dotnet new multi-template -n MyClassLibrary
```

### Test Project

```bash
dotnet new multi-template -n MyTestProject
```

### Available Template Options

- `-n | --name`: The name of your new project.
- `-t | --type`: The type of project to create (e.g., `console`, `classlib`, `test`).

## Customization

The `MultiProjectTemplate` allows for easy customization to fit different project types. After creating a project, you can modify configurations like:

- Changing namespaces in the `.csproj` and code files.
- Adding or modifying Docker support using the included Dockerfile and `DockerBuild.ps1` script.
- Organizing solution structure using the `CleanFolders.ps1` script to clean up build artifacts.

## Docker Support

This template comes with a pre-configured Dockerfile for easy containerization. You can build and run your projects in a Docker container using the following command:

```bash
docker build -t multi-project-template .
docker run --rm -e DOTNET_ENVIRONMENT=production multi-project-template
```

If you want to automate the Docker build process, use the provided `DockerBuild.ps1` script.

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/my-feature`).
3. Commit your changes (`git commit -m 'Add a new feature'`).
4. Push to the branch (`git push origin feature/my-feature`).
5. Create a Pull Request.

Please ensure that your changes follow the existing style and naming conventions.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits

A special thanks to all contributors who have helped in improving the template. We also acknowledge the use of open-source libraries and the .NET SDK in the development of this project.

## Contact Information

If you have any questions or issues, feel free to open an issue in the GitHub repository.
```