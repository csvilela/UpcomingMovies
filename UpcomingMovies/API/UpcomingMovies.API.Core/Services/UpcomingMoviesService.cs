using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.API.Core.Data;
using UpcomingMovies.API.Core.Domain;
using UpcomingMovies.API.Core.Services.Interfaces;

namespace UpcomingMovies.API.Core.Services
{
    public class UpcomingMoviesService : IUpcomingMoviesService
    {
        private readonly IUpcomingMovieRepository _upcomingMovieRepository;

        public UpcomingMoviesService(IUpcomingMovieRepository upcomingMovieRepository)
        {
            this._upcomingMovieRepository = upcomingMovieRepository;
        }

        public async Task<IEnumerable<UpcomingMovie>> GetUpcomingMovies(int page)
        {
            return await this._upcomingMovieRepository.GetUpcomingMovies(page);
        }
    }
}
