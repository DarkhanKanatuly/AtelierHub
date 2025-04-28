# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем csproj из папки AtelierHub и восстанавливаем зависимости
COPY AtelierHub/AtelierHub.csproj ./
RUN dotnet restore AtelierHub.csproj

# Копируем остальные файлы и собираем проект
COPY AtelierHub/ ./
RUN dotnet publish AtelierHub.csproj -c Release -o out

# Используем образ для выполнения приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Указываем порт, который будет использоваться
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Запускаем приложение
ENTRYPOINT ["dotnet", "AtelierHub.dll"]