using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMovies.API.Models
{
    public class UpcomingMovie
    {
        public int VoteCount { get; set; }
        public int Id { get; set; }
        public bool HasVideo { get; set; }
        public double VoteAverage { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public int[] GenreIds { get; set; }
        public string BackdropPath { get; set; }
        public bool IsAdult { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
