#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG API_KEY

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/tnyWeather.Server.csproj", "Server/"]
COPY ["Engines/tnyWeather.Engines.csproj", "Engines/"]
COPY ["Shared/tnyWeather.Shared.csproj", "Shared/"]
COPY ["Client/tnyWeather.Client.csproj", "Client/"]
COPY ["Managers/tnyWeather.Managers.csproj", "Managers/"]
COPY ["Accessors/tnyWeather.Accessors.csproj", "Accessors/"]
RUN dotnet restore "Server/tnyWeather.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "tnyWeather.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tnyWeather.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV OPEN_WEATHER_API_KEY=${API_KEY}
ENTRYPOINT ["dotnet", "tnyWeather.Server.dll"]