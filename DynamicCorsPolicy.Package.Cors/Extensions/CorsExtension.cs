using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamicCorsPolicy.Package.Cors.Accessor;
using DynamicCorsPolicy.Package.Cors.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicCorsPolicy.Package.Cors.Extensions
{
   public static class CorsExtension
    {
        public static IServiceCollection AddCorsPolicy(
             this IServiceCollection services,
             string corsPolicy, string apiUrl)
        {
             
            var allowedOrigins  =  CorsHelper.GetAllowedOrigins(apiUrl);
            if (allowedOrigins != null)
            {
                services.AddCors(x => x.AddPolicy(corsPolicy,
                 builder =>
                     builder.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod()));
            }
            services.AddTransient<ICorsPolicyAccessor, CorsPolicyAccessor>();

            return services;
        }


        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app, string corsPolicy, string apiUrl)
        {
            app.UseCorsUpdate(corsPolicy, apiUrl);
            app.UseCors(corsPolicy);
            return app;
        }
    }
}
