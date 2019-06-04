using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;
namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : IMovieRepository
    {
        static List<Movie> movies= new List<Movie>();
        static int nextId = 1;
        static IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();
        public void Delete(int id)
        {
            movies.RemoveAll(m => m.Id == id);
        }

        public Movie GetById(int id)
        {
            Movie movie =  movies.SingleOrDefault(m => m.Id == id);
            movie = SetMovieRatings(movie);
            movie = SetDirector(movie);
            movie.AverageRating = ratingRepository.GetAverageRating(movie.Id);

            movie.RatingCount = ratingRepository.GetRatingCount(movie.Id);

            return movie;

        }

        public List<Movie> GetMovie()
        {
            movies= movies.Select(movie => SetMovieRatings(movie)).ToList();
            movies = movies.Select(movie => SetAverageRating(movie)).ToList();
            movies = movies.Select(movie => SetRatingCount(movie)).ToList();
            movies = movies.Select(movie => SetDirector(movie)).ToList();
            return movies;

        }


        public int Save(Movie movie)
        {
            movie.Id = nextId++;
            movies.Add(movie);
            return movie.Id;
        }

        public void Update(Movie movie)
        {
            this.Delete(movie.Id);
            movies.Add(movie);
        }

        private Movie SetMovieRatings(Movie movies)
        {
            List<int> ratings = ratingRepository.GetMovieRatings()
                                                .Where(rating => rating.MovieId == movies.Id)
                                                .Select(rating => rating.Rating)
                                                .ToList();
            movies.Ratings = ratings;
            return movies;
        }

        private Movie SetDirector(Movie movie)
        {
            Director director= directorRepository.GetById(movie.DirectorId);

            if(director == null)
            {
                movie.DirectorName = "No director Added, yet.";
            }

            else
            {
                movie.DirectorName = director.LastAndFirstName;
            }

            return movie;
        }

        private Movie SetAverageRating(Movie movie)
        {
            movie.AverageRating = ratingRepository.GetAverageRating(movie.Id);
            return movie;
        }

        private Movie SetRatingCount(Movie movie)
        {
            movie.RatingCount = ratingRepository.GetRatingCount(movie.Id);
            return movie;
        }
    }
}
