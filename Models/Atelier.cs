namespace AtelierHub.Models
{
    public class Atelier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty; // Связь с пользователем (владельцем)
        public string Description { get; set; } = string.Empty;
    }
}