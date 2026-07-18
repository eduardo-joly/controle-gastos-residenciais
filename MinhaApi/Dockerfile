# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto (.csproj) e restaura as dependências
COPY ["MinhaApi.csproj", "./"]
RUN dotnet restore "MinhaApi.csproj"

# Copia todo o código fonte e realiza o build
COPY . .
RUN dotnet build "MinhaApi.csproj" -c Release -o /app/build

# Publica a aplicação gerando os binários otimizados
FROM build AS publish
RUN dotnet publish "MinhaApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio final utilizando a imagem de runtime leve do .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configura a porta do ASP.NET Core para usar a variável PORT do Railway (padrão: 8080)
ENV PORT=8080
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}

ENTRYPOINT ["dotnet", "MinhaApi.dll"]
