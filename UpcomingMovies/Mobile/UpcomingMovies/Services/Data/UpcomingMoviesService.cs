using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.Constants;
using UpcomingMovies.Models;
using UpcomingMovies.Repository;

namespace UpcomingMovies.Services.Data
{
    public class UpcomingMoviesService : IUpcomingMoviesService
    {
        private readonly IGenericRepository _genericRepository;

        public UpcomingMoviesService(IGenericRepository genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task<IEnumerable<UpcomingMovie>> GetUpcomingMovies(int page = 1)
        {
            var uri = $"http://{ApiConstants.BaseUrl}{ApiConstants.UpcomingMoviesEndpoint}{page}";

            return await this._genericRepository.GetAsync<IEnumerable<UpcomingMovie>>(uri);
        }
    }
}
