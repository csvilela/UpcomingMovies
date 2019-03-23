using System.Threading.Tasks;

namespace UpcomingMovies.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri);
    }
}
