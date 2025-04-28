# 1. Используем SDK-образ для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 2. Устанавливаем рабочую директорию
WORKDIR /app

# 3. Копируем весь проект
COPY AtelierHub/*.csproj ./AtelierHub/

# 4. Переходим в папку проекта
WORKDIR /app/AtelierHub

# 5. Восстанавливаем зависимости
RUN dotnet restore

# 6. Копируем остальные файлы проекта
COPY AtelierHub/. .

# 7. Собираем проект
RUN dotnet publish -c Release -o /app/publish

# 8. Используем рантайм-образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

# 9. Запускаем приложение
ENTRYPOINT ["dotnet", "AtelierHub.dll"]
