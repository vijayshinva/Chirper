FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Chirper.Identity/Chirper.Identity.csproj", "Chirper.Identity/"]
RUN dotnet restore "Chirper.Identity/Chirper.Identity.csproj"
COPY . .
WORKDIR "/src/Chirper.Identity"
RUN dotnet build "Chirper.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chirper.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chirper.Identity.dll", "--server.urls", "http://*:80"]