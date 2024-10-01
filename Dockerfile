# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj files and restore as distinct layers
COPY MyTemplate.ConsoleApp/*.csproj ./MyTemplate.ConsoleApp/
COPY MyTemplate.Shared/*.csproj ./MyTemplate.Shared/
COPY MyTemplate.WebAPI/*.csproj ./MyTemplate.WebAPI/

#RUN dotnet restore ./MyTemplate.ConsoleApp/MyTemplate.ConsoleApp.csproj
RUN dotnet restore ./MyTemplate.WebAPI/MyTemplate.WebAPI.csproj

# Copy everything else and build
COPY . ./

#RUN dotnet publish ./MyTemplate.ConsoleApp/MyTemplate.ConsoleApp.csproj -c Release -o /app/publish
RUN dotnet publish ./MyTemplate.WebAPI/MyTemplate.WebAPI.csproj -c Release -o /app/publish

# Stage 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/publish ./

# Set environment variables
ENV DOTNET_ENVIRONMENT=Development

# Command to run the app

#ENTRYPOINT ["dotnet", "MyTemplate.ConsoleApp.dll"]
ENTRYPOINT ["dotnet", "MyTemplate.WebAPI.dll"]
