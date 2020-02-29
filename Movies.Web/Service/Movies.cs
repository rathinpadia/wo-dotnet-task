using Movies.Web.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Service
{
    public class Movies : IMovies
    {

        private IAPIService _service;
         
        public Movies(IAPIService service)
        {
            _service = service;
        }

        public Details GetDetailsById(string id)
        {
            var result = _service.GetDetailsById(id);
            return result;
        }

        public SearchResults GetSearchResultsByTitle(string title)
        {
            var result = _service.SearchResult(title);
            return result;
        }

        public SearchResults SearchResultByTitleandYear(string title, string startYear, string endYear)
        {
            var result = _service.SearchResultByTitleandYear(title, startYear, endYear);
            return result;
        }
    }
}
