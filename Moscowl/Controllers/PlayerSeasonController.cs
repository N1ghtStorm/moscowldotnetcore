using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moscowl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moscowl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerSeasonController : ExtendedApiController<IPlayerSeasonService>
    {
        public PlayerSeasonController(IPlayerSeasonService service) : base(service) { }
    }
}
