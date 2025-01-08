using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");
            
            var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Expection", string.Empty));
            var result = JsonSerializer.Serialize(new {errorCode, ex.Message});
            await context.Response.WriteAsync(result);
        }
    }
    public static string ToUnderscoreCase(string value)
        => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i-1]) ? $"_{x}" : x.ToString())).ToLower();
    
}