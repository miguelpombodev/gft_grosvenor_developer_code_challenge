FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY . ./

RUN dotnet publish -c $BUILD_CONFIGURATION -o app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /src
COPY --from=build-env /src/app .
ENTRYPOINT ["dotnet", "GFTGrovelorDeveloperCodeChallenge.dll"]