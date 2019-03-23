using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMovies.API.Models
{
    public class MovieDetail
    {
        public bool IsAdult { get; set; }
        public string BackdropPath { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
