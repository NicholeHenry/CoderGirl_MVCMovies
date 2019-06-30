using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        static IRepository movieRepository = RepositoryFactory.GetMovieRepository();
        static IRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<MovieListItemViewModel> movies = MovieListItemViewModel.GetMovieList();
            
            //use list but creat special class movielistview model
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {

             MovieCreateViewModel createMovieViewModel = MovieCreateViewModel.GetMovieCreateViewModel();
           
            return View(createMovieViewModel);
        }
    

        [HttpPost]
        public IActionResult Create(/*[FromBody]*/MovieCreateViewModel model )
        {
           
            if(model.Year < 1888 || model.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Not a valid year");
            }
            
            if (ModelState.ErrorCount > 0)
            {
               model.Directors = directorRepository.GetModels().Cast<Director>().ToList();
                return View();
            }

            model.Persist();
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieEditViewModel model = MovieEditViewModel.GetModel(id);

           // Movie movie = (Movie)movieRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            //since id is not part of the edit form, it isn't included in the model, thus it needs to be set from the route value
            //there are alternative patterns for doing this - for one, you could include the id in the form but make it hidden
            //feel free to experiment - the tests wont' care as long as you preserve the id correctly in some manner
            movie.Id = id; 
            movieRepository.Update(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
            //only need to change actions that need a page or view
        }
    }
}