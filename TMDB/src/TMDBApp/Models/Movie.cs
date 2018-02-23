using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TMDBApp.Models
{
    public class Movie
    {
        public Movie()
        {
            GenreIds = new List<int>();
            Genres = new List<Genre>();
        }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        public bool Adult { get; set; }

        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenreIds { get; set; }

        public List<Genre> Genres { get; set; }

        public string GenreNames => string.Join(", ", Genres.Select(x => x.Name));

        public int Id { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        public string Title { get; set; }

        public string BackdropPath { get; set; }

        public string Popularity { get; set; }

        [JsonProperty("vote_count")]
        public string VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public string VoteAverage { get; set; }

    }
}
