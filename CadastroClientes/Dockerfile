# Etapa 1: Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa 2: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o .csproj (já está na pasta atual)
COPY *.csproj ./
RUN dotnet restore

# Copia todos os arquivos da pasta atual
COPY . ./

# Publica a aplicação
RUN dotnet publish -c Release -o /app/publish

# Etapa 3: Imagem final leve
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CadastroClientes.dll"]
