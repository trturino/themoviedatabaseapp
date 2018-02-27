using System.Collections.Generic;
using System.Threading.Tasks;
using TMDBApp.Core.Models;

namespace TMDBApp.Core.Services.Movies
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int page);

        Task<(IEnumerable<Movie>, int)> GetUpcomingMoviesAndPagesAsync(int page);

        Task<Movie> GetMovieByIdAsync(int movieId);
    }
}
