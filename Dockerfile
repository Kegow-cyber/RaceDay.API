FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore RaceDay.sln
RUN dotnet build RaceDay.sln -c Release -o /app/build

FROM build AS publish
RUN dotnet publish RaceDay.API/RaceDay.API.csproj -c Release -o /app/publish/api
RUN dotnet publish RaceDay.MVC/RaceDay.MVC.csproj -c Release -o /app/publish/mvc

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RaceDay.API.dll"]