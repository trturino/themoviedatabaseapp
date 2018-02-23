using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TMDBApp.Models;
using TMDBApp.ViewModels;
using TMDBApp.ViewModels.Base;
using Xunit;

namespace TMDBApp.UnitTests.ViewModel
{
    public class MovieViewModelTest
    {
        [Fact]
        public async Task MoviesPropertyIsNotNullAfterViewModelInitializationTest()
        {
            var movieViewModel = ViewModelLocator.Resolve<MovieViewModel>();
            await movieViewModel.InitializeAsync(null);
            Assert.NotEmpty(movieViewModel.Movies);
        }

        [Fact]
        public async Task InitializeShouldRaiseCollectionChanged()
        {
            var movieViewModel = ViewModelLocator.Resolve<MovieViewModel>();
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
            var movieViewModel = ViewModelLocator.Resolve<MovieViewModel>();
            Assert.NotNull(movieViewModel.GetMovieDetailsCommand);
        }
    }
}
