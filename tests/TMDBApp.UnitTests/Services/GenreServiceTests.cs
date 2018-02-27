using System.Threading.Tasks;
using TMDBApp.Core.Services.Genres;
using TMDBApp.Core.Services.RequestsProvider;
using TMDBApp.Core.Services.Settings;
using Xunit;

namespace TMDBApp.UnitTests.Services
{
    public class GenreServiceTests
    {
        [Fact]
        public async Task ServiceShouldReturnGenres()
        {
            var requestProvider = new RequestProvider();
            var settingService = new SettingsService();
            var genreService = new GenreService(requestProvider, settingService);

            var genres = await genreService.GetGenresAsync();

            Assert.NotEmpty(genres);
        }
    }
}