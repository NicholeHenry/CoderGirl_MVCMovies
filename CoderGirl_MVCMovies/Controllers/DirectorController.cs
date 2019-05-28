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

        public IActionResult Index()
        {
            List<Director> directors = directorRepository.GetDirector();
            return View(directors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Director directors)
        {
            directorRepository.Save(directors);
            return RedirectToAction
                (controllerName: nameof(Director), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Director director)
        {
            director.Id = id;
            directorRepository.Update(director);
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            directorRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}