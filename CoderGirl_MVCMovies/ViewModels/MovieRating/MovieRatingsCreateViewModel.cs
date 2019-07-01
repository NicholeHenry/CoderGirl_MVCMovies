using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingsCreateViewModel


    {
        static IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();



            public int MovieId { get; set; }
            public string MovieName { get; set;}
            public int Rating { get; set; }
            public List<int> Ratings { get; set; }
        

        

       
        internal void Persist()
        {
            MovieRating movieRating = new MovieRating
            {
                MovieId = this.MovieId,
                
                Rating = this.Rating
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating);
        }
    }
}
