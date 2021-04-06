using Microsoft.AspNetCore.Mvc;
using Moscowl.Controllers.Errors;
using System;
using System.Threading.Tasks;

namespace Moscowl.Controllers
{
    public abstract  class ExtendedApiController<T> : ControllerBase where T: class
    {
        public T Service { get; }

        protected ExtendedApiController(T service)
        {
            Service = service;
        }

        protected IActionResult Error(Error error)
        {
            return new ObjectResult(error)
            {
                StatusCode = error.StatusCode
            };
        }

        public async Task<IActionResult> InvokeRequest(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                return Error(new Error(500, e.Message));
            }
        }

    }
}
