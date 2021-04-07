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
    public class SeasonController : ExtendedApiController<ISeasonService>
    {
        public SeasonController(ISeasonService service) : base(service) { }
    }
}
