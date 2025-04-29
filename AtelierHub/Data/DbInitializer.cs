using AtelierHub.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace AtelierHub.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AtelierHubContext context)
{
    // Применяем миграции
    try
    {
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error applying migrations: {ex.Message}");
        throw;
    }

    // Проверяем и добавляем начальные данные
    try
    {
        if (!context.Users.Any())
        {
            var adminUser = new User
            {
                Username = "admin",
                Email = "admin@atelierhub.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                Role = "Admin"
            };
            context.Users.Add(adminUser);
            context.SaveChanges();
        }

        if (context.Masters.Any())
        {
            return;
        }

        var masters = new Master[]
        {
            new Master { Name = "Anna Smith", Specialty = "Tailor", Description = "Specializes in custom suits and dresses with over 10 years of experience.", ContactEmail = "anna.smith@atelierhub.com", ImageUrl = "/images/anna-smith.jpg" },
            new Master { Name = "Mark Johnson", Specialty = "Designer", Description = "Creates unique designs for modern fashion enthusiasts.", ContactEmail = "mark.johnson@atelierhub.com", ImageUrl = "/images/mark-johnson.jpg" }
        };

        context.Masters.AddRange(masters);
        context.SaveChanges();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error initializing database: {ex.Message}");
        throw;
    }
}
    }
}