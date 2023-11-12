using ChatSJTU.Plugin.Weather;

namespace ChatSJTU.Plugin.Log
{
    public class RequestResponseLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            HttpRequest request = context.Request;
            var url = request.Path.ToString();
            var method = request.Method;
            var excuteStartTime = DateTime.Now;

            //获取Response.Body内容
            var respStatus = context.Response.StatusCode;

            _logger.LogInformation($"[{excuteStartTime.ToString("g")}][{respStatus}] {method} {url}");
            return next.Invoke(context);
        }
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
