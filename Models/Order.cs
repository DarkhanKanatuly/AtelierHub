namespace AtelierHub.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AtelierId { get; set; }
        public Atelier Atelier { get; set; } = null!;
        public string CustomerId { get; set; } = string.Empty; // Связь с пользователем (клиентом)
        public string Description { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed
    }
}
