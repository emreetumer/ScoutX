using Microsoft.EntityFrameworkCore;
using ScoutX.Domain.Entites;
using ScoutX.Domain.Interfaces;
using ScoutX.Infrastructure.Persistence;

namespace ScoutX.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }
        public async Task<Player?> GetByIdAsync(Guid id)
        {
           return await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
