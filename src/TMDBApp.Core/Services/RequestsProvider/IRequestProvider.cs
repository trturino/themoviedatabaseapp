using System.Threading.Tasks;

namespace TMDBApp.Core.Services.RequestsProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
