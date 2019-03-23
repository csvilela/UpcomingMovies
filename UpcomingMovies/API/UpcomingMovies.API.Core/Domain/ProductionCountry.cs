using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.API.Core.Domain
{
    public class ProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string IsoCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
