﻿using asp.net_mvc_webapp.Models;
using asp.net_mvc_webapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_mvc_webapp.Controllers
{
    public class MoviesController : Controller
    {
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
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies, movies?pageIndex=2&sortBy=ReleaseDate
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

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