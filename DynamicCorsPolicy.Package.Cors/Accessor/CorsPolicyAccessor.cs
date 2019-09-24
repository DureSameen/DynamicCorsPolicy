using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using System;

namespace DynamicCorsPolicy.Package.Cors.Accessor
{/// <summary>
/// class that access a policy
/// </summary>
    public class CorsPolicyAccessor : ICorsPolicyAccessor
    {
        private readonly CorsOptions _options;
        public CorsPolicyAccessor(IOptions<CorsOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _options = options.Value;
        }

        public CorsPolicy GetPolicy()
        {
            return _options.GetPolicy(_options.DefaultPolicyName);
        }
        public CorsPolicy GetPolicy(string name)
        {
            return _options.GetPolicy(name);
        }
    }
}
