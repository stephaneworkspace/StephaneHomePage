FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

WORKDIR /src
COPY ["StephaneHomePage/StephaneHomePage.csproj", "StephaneHomePage/"]
RUN dotnet restore "StephaneHomePage/StephaneHomePage.csproj"
COPY . .

RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -ep /src/StephaneHomePage/dev_cert.pfx -p 123456

WORKDIR "/src/StephaneHomePage"
RUN dotnet build "StephaneHomePage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StephaneHomePage.csproj" -c Release -o /app/publish

FROM base AS final
COPY --from=publish /app/publish .

WORKDIR "/app/"
RUN echo "TEST 0"
RUN ls
RUN echo "TEST 1"
WORKDIR "/app/publish/"
RUN ls

WORKDIR "/src/StephaneHomePage"
ENTRYPOINT ["dotnet", "StephaneHomePage.dll"]