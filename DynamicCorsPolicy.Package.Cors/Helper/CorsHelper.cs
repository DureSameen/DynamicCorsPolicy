using System;
using System.Threading.Tasks;

namespace DynamicCorsPolicy.Package.Cors.Helper
{
    public class CorsHelper
    {
        public static string[]  GetAllowedOrigins(string configUrl)
        {
            try
            {

                var appSettingsUrl = configUrl.EndsWith("/")
                    ? $"{configUrl}allowedorigins"
                    : $"{configUrl}/allowedorigins";


                var allowedOrigins = new WebAPIHelper<string>(appSettingsUrl).Get();

                return allowedOrigins;
            }
            catch (Exception exp)
            { return null; }
    }
       
    }
}
