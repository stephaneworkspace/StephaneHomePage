FROM mcr.microsoft.com/dotnet/core-nightly/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core-nightly/sdk:3.1 AS build

WORKDIR /src
COPY ["StephaneHomePage/StephaneHomePage.csproj", "StephaneHomePage/"]
RUN dotnet restore "StephaneHomePage/StephaneHomePage.csproj"
COPY . .

#RUN dotnet dev-certs https --clean
#RUN dotnet dev-certs https -ep /src/StephaneHomePage/dev_cert.pfx -p 123456

WORKDIR "/src/StephaneHomePage"
#RUN dotnet build "StephaneHomePage.csproj" -c Release -o /app/build
RUN dotnet build "StephaneHomePage.csproj" -c Debug -o /app/build

FROM build AS publish
#RUN dotnet publish "StephaneHomePage.csproj" -c Release -o /app/publish
RUN dotnet publish "StephaneHomePage.csproj" -c Debug -o /app/publish

FROM base AS final
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "StephaneHomePage.dll"]
