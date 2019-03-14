using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Models;

namespace UpcomingMovies.Services.Data
{
    public interface IUpcomingMoviesService
    {
        Task<IEnumerable<UpcomingMovie>> GetUpcomingMovies(int page = 1);
    }
}
