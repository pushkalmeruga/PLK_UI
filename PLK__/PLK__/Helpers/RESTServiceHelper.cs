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
        //const string baseURL = "http://localhost:8080";
        //const string baseURL = "http://10.0.2.2:8080";
        const string baseURL = "http://192.168.0.108:8080";

        public static async Task<HttpResponseMessage> GetData(string url)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseURL);

            HttpResponseMessage response = await client.GetAsync(url);

            return response;
        }

        public static async Task<string> PostData(string url, string json)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseURL);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
