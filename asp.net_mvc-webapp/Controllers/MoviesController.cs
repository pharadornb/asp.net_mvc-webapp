using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using asp.net_mvc_webapp.Models;
using asp.net_mvc_webapp.ViewModels;
using asp.net_mvc_webapp.Migrations;
using System.Data.Entity.Validation;

namespace asp.net_mvc_webapp.Controllers
{
    public class MoviesController : Controller
    {

        //connect to database is migration on app data, .mdf
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        //have error exception entity valid errors can ...?
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            //try
            //{

            //    _context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}

            return RedirectToAction("Index", "Movies");
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        //public ActionResult New()
        //{
        //    var membershipType = _context.MembershipTypes.ToList();
        //    var viewModel = new CustomerFormViewModel
        //    {
        //        MembershipTypes = membershipType
        //    };
        //    return View(viewModel);
        //}

        [HttpPost]
        //public ActionResult Create(NewCustomerViewModel viewModel)
        public ActionResult Create(Customer customer)
        {
            //Saving data
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}

        public ActionResult Details(int id)
        {
            //connect db.model.eager.find a value
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //viewdata["randommovie"] = movie;
            //viewbag.randommovie = movie;

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            //return Content("Hello World!"); --> show from content only
            //return HttpNotFound(); --> HTTP Error 404.0 - Not Found
            //return new EmptyResult(); --> empty page
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        }


        // movies/edit?id=1, movies/edit/1
        //public ActionResult edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        // movies, movies?pageIndex=2&sortBy=ReleaseDate
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //convention based route
        //movies/released/2015/4
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //attributes route, min, max, minlength, maxlength, int, float, guid, search => attributes constraint
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 2)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}