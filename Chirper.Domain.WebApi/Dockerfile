FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Chirper.Domain.WebApi/Chirper.Domain.WebApi.csproj", "Chirper.Domain.WebApi/"]
COPY ["Chirper.Domain/Chirper.Domain.csproj", "Chirper.Domain/"]
RUN dotnet restore "Chirper.Domain.WebApi/Chirper.Domain.WebApi.csproj"
COPY . .
WORKDIR "/src/Chirper.Domain.WebApi"
RUN dotnet build "Chirper.Domain.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chirper.Domain.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chirper.Domain.WebApi.dll", "--server.urls", "http://*:80"]