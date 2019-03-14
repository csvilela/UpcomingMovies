using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Models
{
    public class UpcomingMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
