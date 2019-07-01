using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieListItemViewModel
    { 
          

    
        public static List<MovieListItemViewModel> GetMovieList()
        {
            return RepositoryFactory.GetMovieRepository()
                .GetModels()
                .Cast<Movie>()
                .Select(movie => new MovieListItemViewModel(movie))
                .ToList();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Director")]
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public  double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        // public List<int> Ratings { get; set; }


        public MovieListItemViewModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Year = movie.Year;
            this.DirectorName = movie.DirectorName;
            this.AverageRating = movie.Ratings.Average();
            this.AverageRating = movie.Ratings.Average();
            this.NumberOfRatings = movie.Ratings.Count();

        }
        


    }
}
 