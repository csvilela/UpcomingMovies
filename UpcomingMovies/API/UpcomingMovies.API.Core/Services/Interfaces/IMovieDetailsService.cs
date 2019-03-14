using System.Threading.Tasks;
using UpcomingMovies.API.Core.Domain;

namespace UpcomingMovies.API.Core.Services.Interfaces
{
    public interface IMovieDetailsService
    {
        Task<MovieDetail> GetMovieDetails(int movieId);
    }
}
