using System.Collections.Generic;
using System.Threading.Tasks;
using TMDBApp.Models;

namespace TMDBApp.Services.Genres
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}
