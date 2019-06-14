using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        static IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IRepository movieRepository = RepositoryFactory.GetMovieRepository();

       public IActionResult Index()
        {
            List<MovieRating> movieRatings = movieRepository.GetModels().Cast<MovieRating>().ToList();
            return View(movieRatings);
        }

        [HttpGet]
        public IActionResult Create(int movieId)
        {
            string movieName = movieRepository.GetById(movieId).Name;
            MovieRating movieRating = new MovieRating();
            movieRating.MovieId = movieId;
            movieRating.MovieName = movieName;
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Create(int id, MovieRating movieRating)
        {
            BaseRepository.Save(movieRating);
            return RedirectToAction(controllerName: nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = BaseRepository.GetById(id);
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            ratingRepository.Update(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            BaseRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}