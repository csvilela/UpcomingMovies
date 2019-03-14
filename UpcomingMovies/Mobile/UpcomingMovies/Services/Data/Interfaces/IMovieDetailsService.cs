using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Models;

namespace UpcomingMovies.Services.Data
{
    public interface IMovieDetailsService
    {
        Task<MovieDetails> GetMovieDetails(int id);
    }
}
