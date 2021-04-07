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
    public class PlayerController : ExtendedApiController<IPlayerService>
    {
        public PlayerController(IPlayerService service) : base(service) { }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Player player)
        {
            return await InvokeRequest(async () => {
                var result = await Service.CreatePlayer(player);
                return Created("", result);
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return await InvokeRequest(async () => {
                var result = await Service.GetPlayers();
                return Ok(result);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await InvokeRequest(async () => {
                var result = await Service.GetPlayer(id);
                return Ok(result);
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await InvokeRequest(async () => {
                var result = await Service.DeletePlayer(id);
                return Ok(result);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Player player)
        {
            return await InvokeRequest(async () => {
                var result = await Service.UpdatePlayer(id, player);
                return Ok(result);
            });
        }
    }
}
