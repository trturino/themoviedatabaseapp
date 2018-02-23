using System.Threading.Tasks;

namespace TMDBApp.Services.RequestsProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
