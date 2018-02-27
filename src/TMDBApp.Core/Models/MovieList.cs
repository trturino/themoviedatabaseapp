using System.Collections.Generic;
using Newtonsoft.Json;

namespace TMDBApp.Core.Models
{
    public class MovieList
    {
        public MovieList()
        {
            Results = new List<Movie>();
        }

        public int Page { get; set; }

        public IEnumerable<Movie> Results { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
