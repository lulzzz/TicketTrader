FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY TicketTrader.Customers.Host/TicketTrader.Customers.Host.csproj TicketTrader.Customers.Host/
RUN dotnet restore
COPY . .
WORKDIR /src/TicketTrader.Customers.Host
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TicketTrader.Customers.Host.dll"]
