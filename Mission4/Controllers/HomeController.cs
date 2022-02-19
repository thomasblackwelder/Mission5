using Mission4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }
       
        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            _movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Ratings = _movieContext.Ratings.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(ApplicationResponse ar)
        {
            //_movieContext.Add(ar);
            //_movieContext.SaveChanges();
            //return View("Confirmation", ar);
            if (ModelState.IsValid)
            {

                _movieContext.Add(ar);
                _movieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else //if invalid
            {
                ViewBag.Ratings = _movieContext.Ratings.ToList();
                return View(ar);
            }

        }

        public IActionResult MovieList()
        {
            var movies = _movieContext.responses
                 .Include(x => x.Rating)
                 //.Where(x => x.CreeperStalker == false)
                 //.OrderBy(x => x.LastName)
                 .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Ratings = _movieContext.Ratings.ToList();

            var movie = _movieContext.responses.Single(x => x.MovieId == movieid);

            return View("Movies", movie);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            _movieContext.Update(blah);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movies = _movieContext.responses.Single(x => x.MovieId == movieid);

            return View(movies);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _movieContext.responses.Remove(ar);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
