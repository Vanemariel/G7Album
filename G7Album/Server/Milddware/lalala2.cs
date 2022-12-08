using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace G7Album.Server.Middlware
{

    public class Lalala  : IAsyncActionFilter
    {

        private readonly ILogger<Lalala> _logger;

        public Lalala() { }
        public Lalala(ILogger<Lalala> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            // context.HttpContext.Response
            // context.HttpContext.Request.
            context.Result = new ContentResult()
            {
                Content = "Resource unavailable - header should not be set",
                StatusCode = 400

            };


            await next();
        }
    }

    // public class Lalala : ActionFilterAttribute /// ANDAA
    // {

    //     private readonly ILogger<Lalala> _logger;

    //     public Lalala() { }
    //     public Lalala(ILogger<Lalala> logger)
    //     {
    //         _logger = logger;
    //     }
    //     public override void OnActionExecuting(ActionExecutingContext context)
    //     {
    //         // context.HttpContext.RequestServices.GetServices();
    //         _logger.LogTrace("ANTES DEL METODO");
    //         base.OnActionExecuting(context);
    //     }

    //     public override void OnActionExecuted(ActionExecutedContext context)
    //     {
    //         _logger.LogTrace("DESPUES DEL METODO");
    //         base.OnActionExecuted(context);
    //     }

    // }
}
