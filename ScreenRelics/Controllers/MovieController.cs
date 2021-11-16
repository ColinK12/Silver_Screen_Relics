using SilverScreenRelics.Models.Movie;
using SilverScreenRelics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class MovieController : Controller
    {
        private MovieServices movieService = new MovieServices();

        [Authorize]
        // GET: Movie
        public ActionResult Index()
        {
            var model = movieService.GetAllMovies();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (movieService.CreateMovie(model))
            {
                TempData["SaveResult"] = "Your movie was created.";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Movie could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = movieService.GetMovieById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail = movieService.GetMovieById(id);
            var model =
                new MovieUpdate
                {
                    MovieTitle = detail.MovieTitle,
                    MovieReleaseYear = detail.MovieReleaseYear,
                    UserRating = detail.UserRating,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieUpdate model)
        {
            if (ModelState.IsValid) return View(model);

            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (movieService.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your movie Was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your movie could not be updated.");
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            movieService.MovieDelete(id);

            TempData["Save Result"] = "Your movie was Deleted";

            return RedirectToAction("Index");
        }
    }
}
