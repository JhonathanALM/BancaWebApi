FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BancaWebApi/BancaWebApi.csproj", "BancaWebApi/"]
COPY ["Modelo/Modelo.csproj", "Modelo/"]
COPY ["AccesoDatos/AccesoDatos.csproj", "AccesoDatos/"]
COPY ["Negocio/Negocio.csproj", "Negocio/"]
RUN dotnet restore "BancaWebApi/BancaWebApi.csproj"
COPY . .
WORKDIR "/src/BancaWebApi"
RUN dotnet build "BancaWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BancaWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BancaWebApi.dll"]