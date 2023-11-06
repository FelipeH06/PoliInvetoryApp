FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /PoliInventory
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR . /src
COPY ["PoliInventory/PoliInventory.csproj", "./"]
RUN dotnet restore "./PoliInventory.csproj"
COPY . .
RUN dotnet build "PoliInventory/PoliInventory.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PoliInventory/PoliInventory.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_ENVIRONMENT Development
ENTRYPOINT ["dotnet", "PoliInventory.dll"]