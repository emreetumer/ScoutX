using ScoutX.Domain.Entites;

namespace ScoutX.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task AddAsync(Player player);
        Task<List<Player>> GetAllAsync(); // sonraki işlem için
    }
}
