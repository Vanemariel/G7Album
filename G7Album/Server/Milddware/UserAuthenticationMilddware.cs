using System.Security.Claims;

namespace G7Album.Server.Middlware
{
    public class UserAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public UserAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool containsPath = false;
            var method = context.Request.Method;
            //var path = context.Request.Path.ToString();
            var role = context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role);

            List<string> methods = new()
            {
                "GET",
                "PUT",
                "POST",
                "DELETE"
            };

            /* List<string> paths = new()
             {
                 "/api/Activities",
                 "/api/Categories",
                 "/api/News",
                 "/api/Organizations",
                 "/api/Roles",
                 "/api/Slides",
                 "/api/Testimonials"
             };

             foreach (string p in paths)
                 if (path.StartsWith(p))
                     containsPath = true;*/

            if (methods.Contains(method) && containsPath)
            {
                if (!role.Value.Equals("Administrador"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
