using Newtonsoft.Json;
using System.Threading.Tasks;
using UpcomingMovies.API.Core.Data;
using UpcomingMovies.API.Core.Domain;

namespace UpcomingMovies.API.Infrastructure.Repositories
{
    public class MovieDetailRepository : BaseRepository, IMovieDetailRepository
    {
        public async Task<MovieDetail> GetMovieDetail(int movieId)
        {
            var uri = $"https://api.themoviedb.org/3/movie/{movieId}?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US";

            var result = await this.GetAsync(uri);

            //TODO: Remove hardcoded base URI
            string baseUri = "http://image.tmdb.org/t/p/original/";
            var movie = JsonConvert.DeserializeObject<MovieDetail>(result);
            movie.PosterPath = baseUri + movie.PosterPath;
            movie.BackdropPath = baseUri + movie.BackdropPath;

            return movie;
        }
    }
}
