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
        private IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRepository movieRepository = RepositoryFactory.GetMovieRepository();

        public IActionResult Index()
        {
            List<MovieRating> movieRatings = movieRatingRepository.GetMovieRatings();
            return View(movieRatings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var movie = (Movie)movieRespository.GetById(movieId);
            string movieName = movie.Name;
            MovieRating movieRating = new MovieRating();
            movieRating.MovieId = movieId;
            movieRating.MovieName = movieName;
            return View(movieRating);
        }

    }

        
    

    [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            movieRatingRepository.Save(movieRating);
            return RedirectToAction(controllerName:nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = movieRatingRepository.GetById(id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            movieRatingRepository.Update(movieRating);
            return RedirectToAction(controllerName: nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRatingRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}