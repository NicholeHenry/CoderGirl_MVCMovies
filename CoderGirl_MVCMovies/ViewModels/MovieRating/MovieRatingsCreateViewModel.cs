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
        public static MovieRatingsCreateViewModel GetMovieRatingCreateViewModel(int movieId)

        {

            var movie = (Movie)RepositoryFactory.GetMovieRepository().GetById(movieId);

            string movieName = movie.Name;

            MovieRating movieRating = new MovieRating();

            movieRating.MovieId = movieId;

            movieRating.MovieName = movieName;







            return new MovieRatingsCreateViewModel

            {

                MovieId = movieRating.MovieId,

                MovieName = movieRating.MovieName,

                Rating = movieRating.Rating,

                Id = movieRating.Id,



            };


        }


        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }

        public void Persist()
        {
            MovieRating movieRating = new MovieRating
            {
                MovieId = this.MovieId,
                MovieName = this.MovieName,
                Rating = this.Rating
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating);
        }
    }
}
