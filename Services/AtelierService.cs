using Microsoft.Extensions.Caching.Memory;
using AtelierHub.Models;
using AtelierHub.Repositories;

namespace AtelierHub.Services
{
    public class AtelierService : IAtelierService
    {
        private readonly IAtelierRepository _repository;
        private readonly IMemoryCache _cache;

        public AtelierService(IAtelierRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<List<Atelier>> GetAllAsync()
        {
            const string cacheKey = "Ateliers";
            if (!_cache.TryGetValue(cacheKey, out List<Atelier>? ateliers))
            {
                ateliers = await _repository.GetAllAsync();
                _cache.Set(cacheKey, ateliers, TimeSpan.FromMinutes(10));
            }
            return ateliers!;
        }

        public async Task<Atelier?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Atelier atelier)
        {
            await _repository.AddAsync(atelier);
            _cache.Remove("Ateliers");
        }

        public async Task UpdateAsync(Atelier atelier)
        {
            await _repository.UpdateAsync(atelier);
            _cache.Remove("Ateliers");
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            _cache.Remove("Ateliers");
        }
    }
}