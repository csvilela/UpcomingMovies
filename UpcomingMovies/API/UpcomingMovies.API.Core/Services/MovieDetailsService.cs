using System.Threading.Tasks;
using UpcomingMovies.API.Core.Data;
using UpcomingMovies.API.Core.Domain;
using UpcomingMovies.API.Core.Services.Interfaces;

namespace UpcomingMovies.API.Core.Services
{
    public class MovieDetailsService : IMovieDetailsService
    {
        private readonly IMovieDetailRepository _movieDetailRepository;

        public MovieDetailsService(IMovieDetailRepository movieDetailRepository)
        {
            this._movieDetailRepository = movieDetailRepository;
        }

        public async Task<MovieDetail> GetMovieDetails(int movieId)
        {
            return await this._movieDetailRepository.GetMovieDetail(movieId);
        }
    }
}
