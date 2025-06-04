using ScoutX.Application.Players.DTOs;

namespace ScoutX.Application.Players.Interfaces
{
    public interface IPlayerService
    {
        Task AddPlayerAsync(AddPlayerDto dto);
    }
}
