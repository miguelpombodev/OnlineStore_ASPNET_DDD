# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./Src/OnlineStore.Web/OnlineStore.Web.csproj" --disable-parallel
RUN dotnet publish "./Src/OnlineStore.Web/OnlineStore.Web.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT [ "dotnet", "OnlineStore.Web.dll" ]

