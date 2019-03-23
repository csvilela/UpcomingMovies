using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.API.Core.Domain;

namespace UpcomingMovies.API.Core.Data
{
    public interface IUpcomingMovieRepository
    {
        Task<IEnumerable<UpcomingMovie>> GetUpcomingMovies(int page);
    }
}
