using System;
using System.Threading.Tasks;
using UpcomingMovies.Constants;
using UpcomingMovies.Models;
using UpcomingMovies.Repository;

namespace UpcomingMovies.Services.Data
{
    public class MovieDetailsService : IMovieDetailsService
    {
        private readonly IGenericRepository _genericRepository;

        public MovieDetailsService(IGenericRepository genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task<MovieDetails> GetMovieDetails(int id)
        {
            var uri = $"http://{ApiConstants.BaseUrl}{ApiConstants.MovieDetailsEndpoint}{id}";

            return await this._genericRepository.GetAsync<MovieDetails>(uri);

        }
    }
}
