namespace AenEnterprise.FrontEndMvc.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate _next,ILogger<ExceptionMiddleware> logger)
        {
            next=_next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
