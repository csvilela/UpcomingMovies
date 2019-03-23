using System.Threading.Tasks;
using UpcomingMovies.API.Core.Domain;

namespace UpcomingMovies.API.Core.Data
{
    public interface IMovieDetailRepository
    {
        Task<MovieDetail> GetMovieDetail(int movieId);
    }
}
