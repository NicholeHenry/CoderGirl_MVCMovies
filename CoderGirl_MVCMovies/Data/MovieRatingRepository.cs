using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        static List<MovieRating> movieRating = new List<MovieRating>();
        static int nextId = 1;

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MovieRating GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieRating> GetMovieRatings()
        {
            throw new NotImplementedException();
        }

        public int Save(MovieRating movieRating)
        {
            throw new NotImplementedException();
        }

        public void Update(MovieRating movie)
        {
            throw new NotImplementedException();
        }
    }
}
