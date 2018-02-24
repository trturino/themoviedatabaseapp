using System.Collections.Generic;
using System.Threading.Tasks;
using TMDBApp.Core.Models;

namespace TMDBApp.Core.Services.Genres
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}
