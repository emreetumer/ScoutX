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
    }
}
