# Use the official .NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET Core SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserManagementAPI/UserManagementAPI.csproj", "UserManagementAPI/"]
RUN dotnet restore "UserManagementAPI/UserManagementAPI.csproj"
COPY . .
WORKDIR "/src/UserManagementAPI"
RUN dotnet build "UserManagementAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "UserManagementAPI.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementAPI.dll"]
