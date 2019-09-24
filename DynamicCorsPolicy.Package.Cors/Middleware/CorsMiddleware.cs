using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicCorsPolicy.Package.Cors.Accessor;
using DynamicCorsPolicy.Package.Cors.Helper;
using Microsoft.AspNetCore.Http;

namespace DynamicCorsPolicy.Package.Cors.Middleware
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _policyName;
        private readonly string _apiUrl;
        public CorsMiddleware(RequestDelegate next, string policyName, string apiUrl)
        {
            _next = next;
            _policyName = policyName;
            _apiUrl = apiUrl;
        }

        public async Task InvokeAsync(HttpContext context, ICorsPolicyAccessor accessor 
            
             )
        {
            var policy = accessor.GetPolicy(_policyName);
            string[] origins =  CorsHelper.GetAllowedOrigins(_apiUrl);
            if (origins?.Length > 0)
            {
                var policyOrigins = policy.Origins;
                var newOrigins = origins.Except(policyOrigins);
                foreach (var origin in newOrigins)
                    policy.Origins.Add(origin);
            }

            await _next(context);
        }
    }
}
