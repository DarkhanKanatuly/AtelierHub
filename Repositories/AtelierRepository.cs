using Microsoft.EntityFrameworkCore;
using AtelierHub.Data;
using AtelierHub.Models;

namespace AtelierHub.Repositories
{
    public class AtelierRepository : IAtelierRepository
    {
        private readonly ApplicationDbContext _context;

        public AtelierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Atelier>> GetAllAsync()
        {
            return await _context.Ateliers.ToListAsync();
        }

        public async Task<Atelier?> GetByIdAsync(int id)
        {
            return await _context.Ateliers.FindAsync(id);
        }

        public async Task AddAsync(Atelier atelier)
        {
            _context.Ateliers.Add(atelier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Atelier atelier)
        {
            _context.Ateliers.Update(atelier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var atelier = await _context.Ateliers.FindAsync(id);
            if (atelier != null)
            {
                _context.Ateliers.Remove(atelier);
                await _context.SaveChangesAsync();
            }
        }
    }
}