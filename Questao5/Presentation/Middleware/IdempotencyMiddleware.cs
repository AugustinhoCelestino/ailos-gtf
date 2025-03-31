using Microsoft.Extensions.Caching.Memory;

public class IdempotencyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;

    public IdempotencyMiddleware(RequestDelegate next, IMemoryCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Idempotency-Key", out var idempotencyKey))
        {
            await _next(context);
            return;
        }

        if (_cache.TryGetValue(idempotencyKey, out var cachedResponse))
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(cachedResponse.ToString());
            return;
        }

        var originalBody = context.Response.Body;
        using (var memoryStream = new System.IO.MemoryStream())
        {
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            var responseBody = new System.IO.StreamReader(memoryStream).ReadToEnd();

            _cache.Set(idempotencyKey, responseBody, TimeSpan.FromMinutes(5));

            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalBody);
        }
    }
}