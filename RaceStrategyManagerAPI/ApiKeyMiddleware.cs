using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RaceStrategyManagerAPI;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration.GetValue<string>("ApiKey");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Allow OPTIONS requests to pass through for CORS preflight
        if (context.Request.Method == "OPTIONS")
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("OK");
            return;
        }

        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey) || apiKey != _apiKey)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid API Key");
            return;
        }

        await _next(context);
    }
}