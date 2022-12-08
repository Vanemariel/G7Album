using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace G7Album.Server.Middlewares
{

    public class Lalala : IAsyncActionFilter
    {

        private readonly string _logger;

        public Lalala() { }
        public Lalala(string ok)
        {
            _logger = ok;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool bandera = true;
            // context.HttpContext.Response
            // context.HttpContext.Request.

            if (bandera)
            {
                await next();
            }
            else
            {
                context.Result = new BadRequestObjectResult("asdasdas!");
            }
        }
    }
}
