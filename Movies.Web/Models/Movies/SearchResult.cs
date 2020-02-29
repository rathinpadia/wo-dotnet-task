using Newtonsoft.Json;

namespace Movies.Web.Models.Movies
{
    public class SearchResult
    {
        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
