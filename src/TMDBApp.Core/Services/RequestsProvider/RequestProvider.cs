using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TMDBApp.Core.Exception;
using TMDBApp.Core.Factories;

namespace TMDBApp.Core.Services.RequestsProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            var httpClient = HttpClientFactory.Create();
            var response = await httpClient.GetAsync(uri);

            await HandleResponse(response);
            var serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }

    }
}
