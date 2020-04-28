FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["VSCodeEventBus.csproj", "./"]
RUN dotnet restore "./VSCodeEventBus.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "VSCodeEventBus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VSCodeEventBus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VSCodeEventBus.dll"]
