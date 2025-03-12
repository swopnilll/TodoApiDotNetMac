# Stage 1: Build the application using the .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the project
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Create the runtime image using the ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose port 80 (HTTP) and optionally 443 (HTTPS)
EXPOSE 80
EXPOSE 443

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "EmployeeManagementSystemApi.dll"]
