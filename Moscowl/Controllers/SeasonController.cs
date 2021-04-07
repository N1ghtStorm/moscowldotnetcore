using Microsoft.AspNetCore.Mvc;
using Moscowl.Models;
using Moscowl.Services;
using System.Threading.Tasks;

namespace Moscowl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ExtendedApiController<ISeasonService>
    {
        public SeasonController(ISeasonService service) : base(service) { }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Season season)
        {
            return await InvokeRequest(async () => {
                var result = await Service.CreateSeason(season);
                return Ok(result);
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return await InvokeRequest(async () => {
                var result = await Service.GetSeasons();
                return Ok(result);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await InvokeRequest(async () => {
                var result = await Service.GetSeason(id);
                return Ok(result);
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await InvokeRequest(async () => {
                var result = await Service.DeleteSeason(id);
                return Ok(result);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Season season)
        {
            return await InvokeRequest(async () => {
                var result = await Service.UpdateSeason(id, season);
                return Ok(result);
            });
        }
    }
}
