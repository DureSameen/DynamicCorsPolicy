using DynamicCorsPolicy.Package.Cors.Middleware;
using Microsoft.AspNetCore.Builder;

namespace DynamicCorsPolicy.Package.Cors.Extensions
{
    public static class CorsMiddlewareExtension
    { 
            public static IApplicationBuilder UseCorsUpdate(
                this IApplicationBuilder builder, string corsPolicy, string apiUrl)
            {
                return builder.UseMiddleware<CorsMiddleware>(corsPolicy, apiUrl);
            }
         
    }
}
