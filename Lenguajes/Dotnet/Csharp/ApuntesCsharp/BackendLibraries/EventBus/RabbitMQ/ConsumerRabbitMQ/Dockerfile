FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendLibraries/EventBus/RabbitMQ/ConsumerRabbitMQ/ConsumerRabbitMQ.csproj", "BackendLibraries/EventBus/RabbitMQ/ConsumerRabbitMQ/"]
COPY ["BackendLibraries/EventBus/RabbitMQ/PubSubCommunication/PubSubCommunication.csproj", "BackendLibraries/EventBus/RabbitMQ/PubSubCommunication/"]
COPY ["BackendLibraries/EventBus/RabbitMQ/PubSubRabbitMQ/PubSubRabbitMQ.csproj", "BackendLibraries/EventBus/RabbitMQ/PubSubRabbitMQ/"]
RUN dotnet restore "BackendLibraries/EventBus/RabbitMQ/ConsumerRabbitMQ/ConsumerRabbitMQ.csproj"
COPY . .
WORKDIR "/src/BackendLibraries/EventBus/RabbitMQ/ConsumerRabbitMQ"
RUN dotnet build "ConsumerRabbitMQ.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConsumerRabbitMQ.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsumerRabbitMQ.dll"]
