using Microsoft.AspNetCore.Mvc;
using Movies.Web.Models.Movies;
using Movies.Web.Service;
using System.Linq;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private IMovies _movies;
        public MoviesController(IMovies movies)
        {
            _movies = movies;
        }
        public IActionResult Index()
        {
            var model = _movies.GetSearchResultsByTitle("Avengers");
            return View(model);
        }

        [Route("Details/{id?}")]
        public IActionResult Details(string id)
        {
            var model = _movies.GetDetailsById(id);
            return View(model);
        }

        [Route("Search/{title?}/{startYear?}/{endYear?}")]
        public IActionResult SearchResult(string title,string startYear, string endYear)
        {
            SearchResults searchResults = null;
            if (!string.IsNullOrEmpty(startYear) && !string.IsNullOrEmpty(endYear))
            {
                searchResults = _movies.SearchResultByTitleandYear(title, startYear, endYear);
            }
            else
            {
                searchResults = _movies.GetSearchResultsByTitle(title);
            }
            return View(searchResults);
        }

    }
}
