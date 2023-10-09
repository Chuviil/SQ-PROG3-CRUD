FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TP3-CRUD-TS/TP3-CRUD-TS.csproj", "TP3-CRUD-TS/"]
RUN dotnet restore "TP3-CRUD-TS/TP3-CRUD-TS.csproj"
COPY . .
WORKDIR "/src/TP3-CRUD-TS"
RUN dotnet build "TP3-CRUD-TS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TP3-CRUD-TS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TP3-CRUD-TS.dll"]
