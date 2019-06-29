using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.ViewModels.MovieRating
{
    public class MovieRatingCreateViewModel
    {
        public int MovieId;
        public string MovieName { get; set; }
        public int Rating { get; set; }

        public void Persist()
        {
            MovieRating movieRating = new MovieRating
            {
                MovieName = this.MovieName,
                Rating = this.Rating
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating)
        }
    }
}
