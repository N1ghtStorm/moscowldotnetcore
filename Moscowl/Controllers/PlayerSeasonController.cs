using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moscowl.Models;
using Moscowl.Services;
using System.Threading.Tasks;

namespace Moscowl.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class PlayerSeasonController : ExtendedApiController<IPlayerSeasonService>
    {
        public PlayerSeasonController(IPlayerSeasonService service) : base(service) { }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PlayerSeason player_season)
        {
            return await InvokeRequest(async () => {
                var result = await Service.CreatePlayerSeason(player_season);
                return Created("", result);
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return await InvokeRequest(async () => {
                var result = await Service.GetPlayersSeason();
                return Ok(result);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await InvokeRequest(async () => {
                var result = await Service.GetPlayerSeason(id);
                return Ok(result);
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await InvokeRequest(async () => {
                var result = await Service.DeletePlayerSeason(id);
                return Ok(result);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] PlayerSeason player_season)
        {
            return await InvokeRequest(async () => {
                var result = await Service.UpdatePlayerSeason(id, player_season);
                return Ok(result);
            });
        }
    }
}
