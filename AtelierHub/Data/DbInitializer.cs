using AtelierHub.Models;

namespace AtelierHub.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AtelierHubContext context)
        {
            context.Database.EnsureCreated();

            if (context.Masters.Any())
            {
                return; // DB has been seeded
            }

            var masters = new Master[]
            {
                new Master
                {
                    Name = "Anna Smith",
                    Specialty = "Tailor",
                    Description = "Specializes in custom suits and dresses with over 10 years of experience.",
                    ImageUrl = "/images/anna-smith.jpg",
                    ContactEmail = "anna.smith@atelierhub.com"
                },
                new Master
                {
                    Name = "Mark Johnson",
                    Specialty = "Designer",
                    Description = "Creates unique designs for modern fashion enthusiasts.",
                    ImageUrl = "/images/mark-johnson.jpg",
                    ContactEmail = "mark.johnson@atelierhub.com"
                }
            };

            context.Masters.AddRange(masters);
            context.SaveChanges();
        }
    }
}