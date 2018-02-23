using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TMDBApp.Extensions;
using TMDBApp.Models;
using TMDBApp.Services.Movies;
using TMDBApp.Services.Settings;
using TMDBApp.ViewModels.Base;
using Xamarin.Forms;

namespace TMDBApp.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IMovieService _movieService;

        private readonly ObservableCollection<Movie> _movies;

        private int _pages;
        private int _actualPage;

        public MovieViewModel(ISettingsService settingsService, IMovieService movieService)
        {
            _settingsService = settingsService;
            _movieService = movieService;
            _movies = new ObservableCollection<Movie>();
            _actualPage = 1;
        }

        public ICollection<Movie> Movies => _movies;

        public ICommand GetMovieDetailsCommand => new Command<Movie>(async (item) => await GetMovieDetailsAsync(item));

        private async Task GetMovieDetailsAsync(Movie movie)
        {
            await NavigationService.NavigateToAsync<MovieDetailsViewModel>(movie.Id);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                _actualPage = 1;

                (var movies, var pages) = await _movieService.GetUpcomingMoviesAndPagesAsync(_actualPage);

                _pages = pages;

                _movies.AddRange(movies);
            }
            catch (System.Exception)
            {
                await DialogService.ShowAlertAsync("There was an error encountered while loading the movies list! Please check your internet connection, and try again.", "", "Ok");
            }
        }
    }
}
