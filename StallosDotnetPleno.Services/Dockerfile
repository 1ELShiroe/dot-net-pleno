FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["StallosDotnetPleno.Services/StallosDotnetPleno.Services.csproj", "StallosDotnetPleno.Services/"]
COPY ["StallosDotnetPleno.Application/StallosDotnetPleno.Application.csproj", "StallosDotnetPleno.Application/"]
COPY ["StallosDotnetPleno.Domain/StallosDotnetPleno.Domain.csproj", "StallosDotnetPleno.Domain/"]
COPY ["StallosDotnetPleno.Infrastructure/StallosDotnetPleno.Infrastructure.csproj", "StallosDotnetPleno.Infrastructure/"]

RUN dotnet restore "StallosDotnetPleno.Services/StallosDotnetPleno.Services.csproj"

COPY . .
WORKDIR "/src/StallosDotnetPleno.Services"
RUN dotnet build "StallosDotnetPleno.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StallosDotnetPleno.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StallosDotnetPleno.Services.dll"]