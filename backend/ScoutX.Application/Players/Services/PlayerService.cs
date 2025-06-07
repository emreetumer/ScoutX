using ScoutX.Application.Players.DTOs;
using ScoutX.Application.Players.Interfaces;
using ScoutX.Domain.Entites;
using ScoutX.Domain.Interfaces;

namespace ScoutX.Application.Players.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task AddPlayerAsync(AddPlayerDto dto)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Position = dto.Position,
                Country = dto.Country,
                MarketValue = dto.MarketValue,
                Score = dto.Score
            };
            await _playerRepository.AddAsync(player);
        }

        public async Task<List<PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllAsync();
            var result = players.Select(p => new PlayerDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Position = p.Position,
                MarketValue = p.MarketValue,

            }).ToList();

            return result;
        }

        public async Task<PlayerDto?> GetPlayerByIdAsync(Guid id)
        {
            var player = await _playerRepository.GetByIdAsync(id);

            if(player == null)
            {
                return null;
            }

            return new PlayerDto
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Position = player.Position,
                MarketValue = player.MarketValue,
            };
        }
    }
}
