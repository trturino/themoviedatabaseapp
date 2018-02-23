using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMDBApp.Models;
using TMDBApp.Services.Genres;
using TMDBApp.Services.RequestsProvider;
using TMDBApp.Services.Settings;
using System.Linq;

namespace TMDBApp.Services.Movies
{
    public class MovieService : IMovieService
    {
        private const string DISCOVERAPIURL = "discover/movie";
        private const string MOVIEAPIURL = "movie";

        private readonly IRequestProvider _requestProvider;
        private readonly ISettingsService _settingsService;
        private readonly IGenreService _genreService;

        private readonly Lazy<Task<IEnumerable<Genre>>> _genresCache;

        public MovieService(
            IRequestProvider requestProvider,
            ISettingsService settingService,
            IGenreService genreService
        )
        {
            _requestProvider = requestProvider;
            _settingsService = settingService;
            _genreService = genreService;
            _genresCache = new Lazy<Task<IEnumerable<Genre>>>(async () => await _genreService.GetGenresAsync());
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            var uri = $"{_settingsService.UrlBase}{MOVIEAPIURL}/{movieId}?api_key={_settingsService.ApiKey}" +
                $"&language=en-US";

            var movie = await _requestProvider.GetAsync<Movie>(uri);
            await FillGenre(movie);

            return movie;
        }

        public async Task<(IEnumerable<Movie>, int)> GetUpcomingMoviesAndPagesAsync(int page)
        {
            var result = await GetMovieListAsync(page);

            return (result.Results, result.TotalPages);
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int page)
        {
            var result = await GetMovieListAsync(page);

            return result.Results;
        }

        private async Task<MovieList> GetMovieListAsync(int page)
        {
            var uri = $"{_settingsService.UrlBase}{DISCOVERAPIURL}?api_key={_settingsService.ApiKey}" +
                $"&language=en-US&include_adult=false&include_video=false&page={page}" +
                $"&primary_release_date.gte={DateTime.Now:yyyy-MM-dd}&sort_by=release_date.asc";

            var movieList = await _requestProvider.GetAsync<MovieList>(uri);

            var genres = await _genresCache.Value;

            foreach (var item in movieList.Results)
                await FillGenre(item);

            return movieList;
        }

        private async Task FillGenre(Movie movie)
        {
            var genres = await _genresCache.Value;
            foreach (var genreId in movie.GenreIds)
            {
                var genre = genres.FirstOrDefault(x => x.Id == genreId);
                if (genre != null)
                    movie.Genres.Add(genre);
            }
        }
    }
}
