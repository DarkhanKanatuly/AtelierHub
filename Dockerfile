# официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# копируиу csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# тут копирую остальные файлы и собираю проект
COPY . ./
RUN dotnet publish -c Release -o out

# юзаю образ для выполнения приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# указ порт, который будет использоваться
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# запуск приложение
ENTRYPOINT ["dotnet", "AtelierHub.dll"]