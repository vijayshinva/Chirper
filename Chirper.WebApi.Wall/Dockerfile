FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Chirper.WebApi.Wall/Chirper.WebApi.Wall.csproj", "Chirper.WebApi.Wall/"]
COPY ["Chirper.Domain/Chirper.Domain.csproj", "Chirper.Domain/"]
RUN dotnet restore "Chirper.WebApi.Wall/Chirper.WebApi.Wall.csproj"
COPY . .
WORKDIR "/src/Chirper.WebApi.Wall"
RUN dotnet build "Chirper.WebApi.Wall.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chirper.WebApi.Wall.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chirper.WebApi.Wall.dll", "--server.urls", "http://*:80"]