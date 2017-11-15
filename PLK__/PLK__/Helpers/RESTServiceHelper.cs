using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PLK__
{
    public class RESTServiceHelper
    {
        const string baseURL = "http://192.168.0.107:8080";

        public static async Task<string> GetData(string url)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseURL);

            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        public static async Task<string> PostData(string url, string json)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseURL);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
