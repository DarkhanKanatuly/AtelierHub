using AtelierHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AtelierHub.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AtelierHubContext context)
        {
            context.Database.Migrate(); // Выполняет миграции

            // Дополнительная инициализация, например, добавление тестовых данных
            if (!context.Masters.Any())
            {
                context.Masters.Add(new Master
                {
                    Name = "Admin Master",
                    Specialty = "Admin Specialty",
                    Description = "This is a test master.",
                    ImageUrl = "https://example.com/image.jpg",
                    ContactEmail = "admin@example.com"
                });
                context.SaveChanges();
            }
        }
    }
}