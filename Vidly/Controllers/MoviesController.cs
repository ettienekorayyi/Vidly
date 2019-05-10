using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var query = GetMovies().SingleOrDefault(m => m.Id == id);
            //if (query == null)
            //{
            //    return HttpNotFound();
            //}
            // 1.SingleOrDefault()
            // Without getting the first element of the list you are actually 
            // passing an enumerable list instead of a single item.
            return View(query);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // Can be overriden by using query string
        // Cannot be overridden by using url because 
        // that would require you to create a custom route.
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>() 
            {
               new Movie { Id = 1, Name = "Shrek" },
               new Movie { Id = 2, Name = "Wall-E" },
            };
        }
    }
}