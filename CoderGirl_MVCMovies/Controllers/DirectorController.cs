using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        public static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();
        [HttpGet]
        public IActionResult Index()
        {
            List<Director> directors = directorRepository.GetDirector();
            return View(directors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return RedirectToAction(controllerName: nameof(Director), actionName: nameof(Index));
        }
        [HttpPost]
        public IActionResult Create(Director director)
        {
            directorRepository.Save(director);
            return RedirectToAction(controllerName: nameof(Director), actionName: nameof(Index));
        }

       
        
    }
}