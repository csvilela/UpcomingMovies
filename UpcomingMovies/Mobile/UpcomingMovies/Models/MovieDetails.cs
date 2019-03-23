using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Models
{
    public class MovieDetails
    {
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string BackdropPath { get; set; }
    }
}
