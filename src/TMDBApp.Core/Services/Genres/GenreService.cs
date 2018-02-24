using System.Collections.Generic;
using System.Threading.Tasks;
using TMDBApp.Core.Models;
using TMDBApp.Core.Services.RequestsProvider;
using TMDBApp.Core.Services.Settings;

namespace TMDBApp.Core.Services.Genres
{
    public class GenreService : IGenreService
    {
        private const string APIURL = "genre/movie/list";

        private readonly IRequestProvider _requestProvider;
        private readonly ISettingsService _settingsService;

        public GenreService(
            IRequestProvider requestProvider,
            ISettingsService settingsService
        )
        {
            _requestProvider = requestProvider;
            _settingsService = settingsService;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            var uri = $"{_settingsService.UrlBase}{APIURL}?api_key={_settingsService.ApiKey}";

            var result = await _requestProvider.GetAsync<GenreList>(uri);

            return result.Genres;
        }
    }
}
