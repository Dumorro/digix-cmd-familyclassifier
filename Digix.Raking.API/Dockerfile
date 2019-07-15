FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Digix.Raking.API/Digix.Raking.API.csproj", "Digix.Raking.API/"]
RUN dotnet restore "Digix.Raking.API/Digix.Raking.API.csproj"
COPY . .
WORKDIR "/src/Digix.Raking.API"
RUN dotnet build "Digix.Raking.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Digix.Raking.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Digix.Raking.API.dll"]