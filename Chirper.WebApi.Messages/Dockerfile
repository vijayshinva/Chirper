FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Chirper.WebApi.Messages/Chirper.WebApi.Messages.csproj", "Chirper.WebApi.Messages/"]
COPY ["Chirper.Domain/Chirper.Domain.csproj", "Chirper.Domain/"]
RUN dotnet restore "Chirper.WebApi.Messages/Chirper.WebApi.Messages.csproj"
COPY . .
WORKDIR "/src/Chirper.WebApi.Messages"
RUN dotnet build "Chirper.WebApi.Messages.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chirper.WebApi.Messages.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chirper.WebApi.Messages.dll", "--server.urls", "http://*:80"]