using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        //private static <int, string> movies = new Dictionary<int, string>();
         private static int nextIdToUse = 1;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string movies)
        {
            //movies.Add(nextIdToUse, movies);
            nextIdToUse++;
            return RedirectToAction(actionName: nameof(Index));

        }



    }
}
