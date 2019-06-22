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
            return RepositoryFactory
                .GetMovieRepository()
                .GetModels().Cast<Movie>()
                .Select(m => GetMovieListItemFromMovie(movie))
                .ToList();

        }

        private static object GetMovieListItemFromMovie(Movie movie)
        {
           Id = movie.Id,
           Name = movie.Name,
            Director = movie.DirectorName,
            Year = movie.Year,
            AverageR =
        }
    }
}
 <th>Movie Name</th>
        <th>Director</th>
        <th>Year</th>
        <th>Average Rating</th>
        <th>Number of Ratings</th>
    </tr>