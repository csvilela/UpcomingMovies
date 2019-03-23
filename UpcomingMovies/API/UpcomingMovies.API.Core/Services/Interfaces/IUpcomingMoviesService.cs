using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.API.Core.Domain;

namespace UpcomingMovies.API.Core.Services.Interfaces
{
    public interface IUpcomingMoviesService
    {
        Task<IEnumerable<UpcomingMovie>> GetUpcomingMovies(int page);
    }
}
