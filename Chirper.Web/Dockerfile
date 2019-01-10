FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
COPY ["Chirper.Web/Chirper.Web.csproj", "Chirper.Web/"]
RUN dotnet restore "Chirper.Web/Chirper.Web.csproj"
COPY . .
WORKDIR "/src/Chirper.Web"
RUN dotnet build "Chirper.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chirper.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chirper.Web.dll", "--server.urls", "http://*:80"]