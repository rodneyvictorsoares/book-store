# Etapa de Build: utilizando o SDK Alpine do .NET 6
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.16 AS build
WORKDIR /src

# Copia os arquivos de projeto (note que os caminhos são relativos à raiz da solução)
COPY ["BOOKSTORE.WEB/BOOKSTORE.WEB.csproj", "BOOKSTORE.WEB/"]
COPY ["BOOKSTORE.APPLICATION/BOOKSTORE.APPLICATION.csproj", "BOOKSTORE.APPLICATION/"]
COPY ["BOOKSTORE.DOMAIN/BOOKSTORE.DOMAIN.csproj", "BOOKSTORE.DOMAIN/"]
COPY ["BOOKSTORE.IOC/BOOKSTORE.IOC.csproj", "BOOKSTORE.IOC/"]

# Restaura as dependências utilizando o csproj do projeto WEB
RUN dotnet restore "BOOKSTORE.WEB/BOOKSTORE.WEB.csproj"

# Copia todo o restante da solução (todos os arquivos e projetos)
COPY . .

WORKDIR "/src/BOOKSTORE.WEB"
RUN dotnet build "BOOKSTORE.WEB.csproj" -c Release -o /app/build

# Etapa de Publicação
FROM build AS publish
RUN dotnet publish "BOOKSTORE.WEB.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa Final: imagem de runtime usando Alpine e configurada para expor a porta 8081
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.16 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081
ENTRYPOINT ["dotnet", "BOOKSTORE.WEB.dll"]
