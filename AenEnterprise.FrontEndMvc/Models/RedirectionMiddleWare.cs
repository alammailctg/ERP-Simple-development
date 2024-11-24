

namespace AenEnterprise.FrontEndMvc.Models
{
    public class RedirectionMiddleWare
    {
        private readonly RequestDelegate _next;
        public RedirectionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokAsync(HttpContext context)
        {
            if(!context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("/login");
            }
            else
            {
                context.Response.Redirect("/Dashboard");
            }
            await _next(context);
        }
    }
}
