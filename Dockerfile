# 9ka
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# kopi csproj и reink zav
COPY AtelierHub/*.csproj ./AtelierHub/
WORKDIR /app/AtelierHub
RUN dotnet restore

# kopi ost kod + bild pj
COPY AtelierHub/. .
RUN dotnet publish -c Release -o out

# use runtime obraz dlya zapuska
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/AtelierHub/out ./
ENTRYPOINT ["dotnet", "AtelierHub.dll"]