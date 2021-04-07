using Microsoft.AspNetCore.Mvc;
using Moscowl.Services;

namespace Moscowl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ExtendedApiController<IPlayerService>
    {
        public PlayerController(IPlayerService service) : base(service) { }
    }
}
