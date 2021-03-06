﻿using System.Threading.Tasks;
using TMDBApp.Core.Models;
using TMDBApp.Core.Services.Movies;
using TMDBApp.Core.ViewModels.Base;

namespace TMDBApp.Core.ViewModels
{
    public class MovieDetailsViewModel : ViewModelBase
    {
        private readonly IMovieService _movieService;

        private Movie _movie;

        public MovieDetailsViewModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async override Task InitializeAsync(object navigationData)
        {
            if (navigationData is int movieId)
            {
                IsBusy = true;
                // Get movie by id
                Movie = await _movieService.GetMovieByIdAsync(movieId);
                IsBusy = false;
            }
        }

        public Movie Movie 
        {
            get => _movie;

            private set
            { 
                _movie = value; 
                RaisePropertyChanged(() => Movie); 
            }
        }

    }
}
