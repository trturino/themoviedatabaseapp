using System.Linq;
using System.Threading.Tasks;
using TMDBApp.Core.Services.Movies;
using TMDBApp.Core.ViewModels;
using TMDBApp.Core.ViewModels.Base;
using Xunit;

namespace TMDBApp.UnitTests.ViewModel
{
    public class MovieDetailViewModelTest
    {

        [Fact]
        public void MoviePropertyShouldBeNullBeforeInitialize()
        {
            var movieDetailsViewModel = ViewModelLocator.Resolve<MovieDetailsViewModel>();
            Assert.Null(movieDetailsViewModel.Movie);
        }

        [Fact]
        public async Task MoviePropertyShouldBeNullAfterInitialize()
        {
            var movieDetailsViewModel = ViewModelLocator.Resolve<MovieDetailsViewModel>();
            var movieService = ViewModelLocator.Resolve<IMovieService>();

            var movies = await movieService.GetUpcomingMoviesAsync(1);

            await movieDetailsViewModel.InitializeAsync(movies.FirstOrDefault().Id);

            Assert.NotNull(movieDetailsViewModel.Movie);
        }

        [Fact]
        public async Task MoviePropertyShouldRaisePropertyChanged()
        {
            bool invoked = false;
            var movieDetailsViewModel = ViewModelLocator.Resolve<MovieDetailsViewModel>();
            var movieService = ViewModelLocator.Resolve<IMovieService>();

            var movies = await movieService.GetUpcomingMoviesAsync(1);

            movieDetailsViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Movie"))
                    invoked = true;
            };

            await movieDetailsViewModel.InitializeAsync(movies.FirstOrDefault().Id);

            Assert.True(invoked);
        }
    }
}
