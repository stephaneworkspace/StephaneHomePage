FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

WORKDIR /src
COPY ["StephaneHomePage/StephaneHomePage.csproj", "StephaneHomePage/"]
RUN dotnet restore "StephaneHomePage/StephaneHomePage.csproj"
COPY . .

#WORKDIR /.aspnet/https/
RUN dotnet dev-certs https -ep {HOME}/.aspnet/https/aspnetapp.pfx -p { 123456 }

WORKDIR "/src/StephaneHomePage"
RUN dotnet build "StephaneHomePage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StephaneHomePage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StephaneHomePage.dll"]