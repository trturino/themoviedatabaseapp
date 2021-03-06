﻿using System;
using System.Linq;
using System.Threading.Tasks;
using TMDBApp.Core.Services.Genres;
using TMDBApp.Core.Services.Movies;
using TMDBApp.Core.Services.RequestsProvider;
using TMDBApp.Core.Services.Settings;
using Xunit;

namespace TMDBApp.UnitTests.Services
{
    public class MovieServicesTest
    {
        [Fact]
        public async Task GetUpcomingMovieShouldReturnItens()
        {
            var movieService = CreateMovieService();

            var movies = await movieService.GetUpcomingMoviesAsync(1);
            movies = await movieService.GetUpcomingMoviesAsync(2);

            Assert.NotEmpty(movies);
            Assert.All(movies, (m) => Assert.True(m.ReleaseDate > DateTime.Now.Date));
        }

        [Fact]
        public async Task GetUpcomingMoviesShouldReturnNotReleasedMovies()
        {
            var movieService = CreateMovieService();

            (var movies, var pages) = await movieService.GetUpcomingMoviesAndPagesAsync(1);

            Assert.NotEmpty(movies);
            Assert.All(movies, (m) => Assert.True(m.ReleaseDate > DateTime.Now.Date));
            Assert.True(pages > 0);
        }

        [Fact]
        public async Task GetMovieByIdShouldReturnTheRequestedMovie()
        {
            var movieService = CreateMovieService();
            var movie = (await movieService.GetUpcomingMoviesAsync(1)).FirstOrDefault();
            var movieById = await movieService.GetMovieByIdAsync(movie.Id);

            Assert.True(movie.Id == movieById.Id);
        }

        private static MovieService CreateMovieService()
        {
            var requestProvider = new RequestProvider();
            var settingService = new SettingsService();
            var genreService = new GenreService(requestProvider, settingService);
            var movieService = new MovieService(requestProvider, settingService, genreService);
            return movieService;
        }
    }
}