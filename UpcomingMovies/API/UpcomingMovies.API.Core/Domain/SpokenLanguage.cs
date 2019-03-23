using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.API.Core.Domain
{
    public class SpokenLanguage
    {
        [JsonProperty("iso_639_1")]
        public string IsoCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
