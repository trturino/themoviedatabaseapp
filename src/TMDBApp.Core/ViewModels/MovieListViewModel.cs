using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TMDBApp.Core.Extensions;
using TMDBApp.Core.Models;
using TMDBApp.Core.Services.Movies;
using TMDBApp.Core.Services.Settings;
using TMDBApp.Core.ViewModels.Base;
using Xamarin.Forms;

namespace TMDBApp.Core.ViewModels
{
    public class MovieListViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IMovieService _movieService;
        private readonly ObservableCollection<Movie> _movies;

        private int _pages;
        private int _currentPage;

        public MovieListViewModel(ISettingsService settingsService, IMovieService movieService)
        {
            _settingsService = settingsService;
            _movieService = movieService;
            _movies = new ObservableCollection<Movie>();
            _currentPage = 1;
        }

        public ICollection<Movie> Movies => _movies;

        public ICommand GetMovieDetailsCommand => new Command<Movie>(async (item) => await GetMovieDetailsAsync(item));

        public ICommand LoadMoreCommand => new Command(async () => await LoadNextPage());

        private async Task LoadNextPage()
        {
            try
            {
                var movies = await _movieService.GetUpcomingMoviesAsync(++_currentPage);

                _movies.AddRange(movies);
            } 
            catch (System.Exception)
            {
                await DialogService.ShowAlertAsync("There was an error encountered while loading the movies list! Please check your internet connection, and try again.", "", "Ok");
            }
        }

        private async Task GetMovieDetailsAsync(Movie movie)
        {
            await NavigationService.NavigateToAsync<MovieDetailsViewModel>(movie.Id);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                _currentPage = 1;

                (var movies, var pages) = await _movieService.GetUpcomingMoviesAndPagesAsync(_currentPage);

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
