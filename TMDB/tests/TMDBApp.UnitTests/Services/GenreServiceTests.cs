using System.Threading.Tasks;
using TMDBApp.Services.Genres;
using TMDBApp.Services.RequestsProvider;
using TMDBApp.Services.Settings;
using Xunit;

namespace TMDBApp.UnitTests.Services
{
    public class GenreServiceTests
    {
        [Fact]
        public async Task GetAllGenres()
        {
            var requestProvider = new RequestProvider();
            var settingService = new SettingsService();
            var genreService = new GenreService(requestProvider, settingService);

            var genres = await genreService.GetGenresAsync();

            Assert.NotEmpty(genres);
        }
    }
}