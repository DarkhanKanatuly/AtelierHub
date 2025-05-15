FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
RUN mkdir /app/data-protection-keys
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENV ASPNETCORE_URLS=http://+:80
ENV PORT=80
EXPOSE 80
ENTRYPOINT ["dotnet", "AtelierHub.dll"]