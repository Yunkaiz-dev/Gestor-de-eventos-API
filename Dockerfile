# ETAPA 1: COMPILACIÓN
# Usamos el SDK de .NET para restaurar y compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiamos el archivo del proyecto (.csproj) y restauramos las dependencias (NuGet)
COPY *.csproj ./
RUN dotnet restore

# Copiamos todo el resto del código y compilamos la API en modo Release
COPY . ./
RUN dotnet publish -c Release -o out

# ETAPA 2: EJECUCIÓN
# Usamos una imagen mucho más pequeña que solo tiene el entorno de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiamos los archivos compilados desde la etapa anterior
COPY --from=build-env /app/out .

# Exponemos el puerto interno (por defecto en .NET 8 es el 8080)
EXPOSE 8080

# El comando que Docker ejecutará para iniciar tu API
# REEMPLAZA "TuProyectoAPI.dll" por el nombre real de tu archivo de salida (suele ser el mismo nombre de tu proyecto)
ENTRYPOINT ["dotnet", "gestor_de_eventos.dll"]