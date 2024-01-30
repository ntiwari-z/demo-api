FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tests/Tests.csproj", "Tests/"]
COPY ["Utility/Utility.csproj", "Utility/"]
COPY ["Model/Model.csproj", "Model/"]
RUN dotnet restore "./Tests/./Tests.csproj"
COPY . .
WORKDIR "/src/Tests"
RUN dotnet build "./Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tests.dll"]