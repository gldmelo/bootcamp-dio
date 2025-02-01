FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
EXPOSE 443

# Copy everything
COPY ["src/LabAz204Api/LabAz204Api.csproj", "src/LabAz204Api/"]
# Restore as distinct layers
RUN dotnet restore "src/LabAz204Api/LabAz204Api.csproj"
COPY . .

# Build and publish a release
WORKDIR "/app/src/LabAz204Api"
RUN dotnet publish "LabAz204Api.csproj" -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LabAz204Api.dll"]