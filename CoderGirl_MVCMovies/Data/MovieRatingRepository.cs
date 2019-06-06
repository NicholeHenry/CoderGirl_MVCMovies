using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        private static List<MovieRating> movieRatings = new List<MovieRating>();
        private static int nextId = 1;
        static IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        public void Delete(int id)
        {
            movieRatings.RemoveAll(r => r.Id == id);
        }

        

        public double GetAverageRating(int movieId)
        {
            var averageRate = movieRatings
                 .Where(r => r.MovieId == movieId)
                 .GroupBy(r => r.MovieId)
                 .Select(r => r.Average(a => a.Rating))
                 .SingleOrDefault();
            return Convert.ToDouble(averageRate);

        }

        
        public MovieRating GetById(int id)
        {
            return movieRatings.SingleOrDefault(r => r.Id == id);
        }

        
        
        public List<MovieRating> GetMovieRatings()
        {
            return movieRatings;
        }

        

        public int GetRatingCount(int movieId)
        {
            var ratingCount = movieRatings
                .Where(r => r.MovieId == movieId)
                .Count();
            return ratingCount;
        }

        public int Save(MovieRating movieRating)
        {
            movieRating.Id = nextId++;
            movieRatings.Add(movieRating);
            return movieRating.Id;
        }

       
        public void Update(MovieRating movieRating)
        {
            this.Delete(movieRating.Id);
            movieRatings.Add(movieRating);
        }

       
    }
}
