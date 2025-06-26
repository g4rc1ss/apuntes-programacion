FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendLibraries/Databases/NoSQL/LittleDB/LittleDB.csproj", "BackendLibraries/Databases/NoSQL/LittleDB/"]
RUN dotnet restore "BackendLibraries/Databases/NoSQL/LittleDB/LittleDB.csproj"
COPY . .
WORKDIR "/src/BackendLibraries/Databases/NoSQL/LittleDB"
RUN dotnet build "LittleDB.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LittleDB.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LittleDB.dll"]
