# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj files and restore as distinct layers
COPY MultiProjectTemplate.ConsoleApp/*.csproj ./MultiProjectTemplate.ConsoleApp/
COPY MultiProjectTemplate.ClassLibrary/*.csproj ./MultiProjectTemplate.ClassLibrary/
RUN dotnet restore ./MultiProjectTemplate.ConsoleApp/MultiProjectTemplate.ConsoleApp.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./MultiProjectTemplate.ConsoleApp/MultiProjectTemplate.ConsoleApp.csproj -c Release -o /app/publish

# Stage 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/publish ./

# Set environment variables
ENV DOTNET_ENVIRONMENT=Development

# Command to run the app
ENTRYPOINT ["dotnet", "MultiProjectTemplate.ConsoleApp.dll"]
