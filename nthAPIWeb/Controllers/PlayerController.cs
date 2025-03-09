using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nthAPIWeb.models;

namespace nthAPIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return Ok(await _playerService.GetPlayersAsync());
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Player>> GetPlayer(string id)
        {
            var player = await _playerService.GetPlayerAsync(id);
            if (player == null) return NotFound();
            return player;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            await _playerService.CreatePlayerAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player._id }, player);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutPlayer(string id, Player player)
        {
            if (id != player._id) return BadRequest();

            var updated = await _playerService.UpdatePlayerAsync(id, player);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePlayer(string id)
        {
            var deleted = await _playerService.DeletePlayerAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }

}
