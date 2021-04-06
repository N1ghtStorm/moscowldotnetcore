﻿using Microsoft.AspNetCore.Mvc;
using Moscowl.DTOs;
using Moscowl.Services;
using System.Threading.Tasks;

namespace Moscowl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ExtendedApiController<IUserService>
    {
        public UserController(IUserService service) : base(service) { }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserDto user_dto)
        {
            return await InvokeRequest(async () => {
                await Service.CreateUser(user_dto);
                return Ok();
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserDto user_dto)
        {
            return await InvokeRequest(async () => {
                await Service.CreateUser(user_dto);
                return Ok();
            });
        }
    }
}