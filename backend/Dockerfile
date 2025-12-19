# Imagen base para compilar (.NET 8)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY MiProyectoWeb.csproj ./
RUN dotnet restore MiProyectoWeb.csproj

COPY . .
RUN dotnet publish MiProyectoWeb.csproj -c Release -o /out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80    

COPY --from=build /out .

EXPOSE 80

ENTRYPOINT ["dotnet", "MiProyectoWeb.dll"]


