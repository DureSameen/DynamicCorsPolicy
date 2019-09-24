using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DynamicCorsPolicy.Package.Cors.Accessor
{
    public interface ICorsPolicyAccessor
    {
        CorsPolicy GetPolicy();
        CorsPolicy GetPolicy(string name);
    }
}