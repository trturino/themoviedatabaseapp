using System.Net.Http;
using System.Net.Http.Headers;

namespace TMDBApp.Core.Factories
{
    public static class HttpClientFactory
    {
        public static HttpClient Create()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
