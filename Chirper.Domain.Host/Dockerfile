FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Chirper.Domain.Host/Chirper.Domain.Host.csproj Chirper.Domain.Host/
COPY Chirper.Domain/Chirper.Domain.csproj Chirper.Domain/
RUN dotnet restore Chirper.Domain.Host/Chirper.Domain.Host.csproj
COPY . .
WORKDIR /src/Chirper.Domain.Host
RUN dotnet build Chirper.Domain.Host.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Chirper.Domain.Host.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chirper.Domain.Host.dll"]
