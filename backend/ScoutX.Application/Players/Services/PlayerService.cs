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
    }
}
