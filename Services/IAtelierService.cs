using AtelierHub.Models;

namespace AtelierHub.Services
{
    public interface IAtelierService
    {
        Task<List<Atelier>> GetAllAsync();
        Task<Atelier?> GetByIdAsync(int id);
        Task AddAsync(Atelier atelier);
        Task UpdateAsync(Atelier atelier);
        Task DeleteAsync(int id);
    }
}