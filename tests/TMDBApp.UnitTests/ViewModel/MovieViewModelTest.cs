using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TMDBApp.Core.Models;
using TMDBApp.Core.ViewModels;
using TMDBApp.Core.ViewModels.Base;
using Xunit;

namespace TMDBApp.UnitTests.ViewModel
{
    public class MovieViewModelTest
    {
        [Fact]
        public async Task MoviesPropertyIsNotNullAfterViewModelInitializationTest()
        {
            var movieViewModel = ViewModelLocator.Resolve<MovieListViewModel>();
            await movieViewModel.InitializeAsync(null);
            Assert.NotEmpty(movieViewModel.Movies);
        }

        [Fact]
        public async Task InitializeShouldRaiseCollectionChanged()
        {
            var movieViewModel = ViewModelLocator.Resolve<MovieListViewModel>();
            var moviesCollection = movieViewModel.Movies as ObservableCollection<Movie>;
            bool evenRaised = false;
            moviesCollection.CollectionChanged += (sender, e) =>
            {
                evenRaised = true;
            };

            await movieViewModel.InitializeAsync(null);

            Assert.True(evenRaised);
        }

        [Fact]
        public void GetMovieDetailsCommandIsNotNullTest()
        {
            var movieViewModel = ViewModelLocator.Resolve<MovieListViewModel>();
            Assert.NotNull(movieViewModel.GetMovieDetailsCommand);
        }
    }
}
