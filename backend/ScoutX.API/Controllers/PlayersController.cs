using Microsoft.AspNetCore.Mvc;
using ScoutX.Application.Players.DTOs;
using ScoutX.Application.Players.Interfaces;

namespace ScoutX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPlayerDto dto)
        {
            await _playerService.AddPlayerAsync(dto);
            return Ok(new { message = "Oyuncu Başarıyla Eklendi" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayer()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);

            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}
