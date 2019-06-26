using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieListItemViewModel
    {
        public static List<MovieListItemViewModel> GetMovieList()
        {
            return RepositoryFactory.GetMovieRepository()
                 .GetModels()
                 .Cast<Movie>()
                 .Select(movie => GetMovieListItemFromMovie(movie))
                 .ToList();
           

        }

        private static MovieListItemViewModel  GetMovieListItemFromMovie(Movie movie)
        {
            return new MovieListItemViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                DirectorName = movie.DirectorName,
                Year = movie.Year,
               Ratings = movie.Ratings
            };
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Ratings { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }



    }
}
 