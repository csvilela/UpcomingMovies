using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMovies.API.Core.Data;
using UpcomingMovies.API.Core.Domain;

namespace UpcomingMovies.API.Infrastructure.Repositories
{
    public class UpcomingMovieRepository : BaseRepository, IUpcomingMovieRepository
    {
        public async Task<IEnumerable<UpcomingMovie>> GetUpcomingMovies(int page)
        {
            var uri = $"https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US&page={page}";

            var result = await this.GetAsync(uri);
            var jsonObject = JsonConvert.DeserializeObject<JObject>(result);

            var results = JsonConvert.DeserializeObject<IEnumerable<UpcomingMovie>>(jsonObject["results"].ToString());

            //TODO: Refactor to remove hard coded uri base
            return results.Select(m => {
                m.PosterPath = "http://image.tmdb.org/t/p/w185/" + m.PosterPath;
                return m; });
        }
    }
}
