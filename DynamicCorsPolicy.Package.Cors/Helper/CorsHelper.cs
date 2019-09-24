using System;
using System.Threading.Tasks;

namespace DynamicCorsPolicy.Package.Cors.Helper
{
    public class CorsHelper
    {
        public static string[]  GetAllowedOrigins(string configUrl)
        { 

            var appSettingsUrl = configUrl.EndsWith("/")
                ? $"{configUrl}api/allowedOrigins"
                : $"{configUrl}/api/allowedOrigins";

            
            var allowedOriginsString1 = new WebAPIHelper<string>(appSettingsUrl).Get(); 

            return allowedOriginsString1;
        }
       
    }
}
