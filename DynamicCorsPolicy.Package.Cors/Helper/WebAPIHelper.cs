using System.Net.Http;
using Newtonsoft.Json;

namespace DynamicCorsPolicy.Package.Cors.Helper
{
    public class WebAPIHelper<T>  where T:class
    {
        private string url = "";
        HttpClient client = new HttpClient();

        public WebAPIHelper(string url)
        {
            this.url = url;
        }

        public T[] Get(string TId = "")
        {
            if (TId == "")
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                T[] data = JsonConvert.DeserializeObject<T[]>(response.Content.ReadAsStringAsync().Result);
                return data;
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(url + TId).Result;
                T obj = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                T[] data = new T[1];
                data[0] = obj;
                return data;
            }
        }

        
    }

}
