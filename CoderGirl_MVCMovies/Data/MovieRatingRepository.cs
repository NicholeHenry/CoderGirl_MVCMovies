using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository

    {
        public static List<Movie> Movies = new List<Movie>();

        public double GetAverageRatingByMovieName(string movieName)
        {
            return Movies.Where(mo => mo.Name == movieName).Average(mo => mo.Rating);
        }

        /// <summary>
        /// Returns a list of all the ids of saved movie ratings
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {

            //return Movies.Select(mo => mo.Id).ToList();
            List<int> id = Movies.Select(mo => mo.Id).ToList();

            return id;
        }
    

        public string GetMovieNameById(int id)
        /// <summary>
        /// Given an id, will return the associated movie name.
        /// If the id does not exist, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        {
            if(id == 0)
            {
                return null;
            }

            return Movies[id-1].Name;
        }

        public int GetRatingById(int id)

        /// <summary>
        /// Given an id, will return the associated rating 
        /// If the id does not exist, returns 0
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        {
            if(id == 0)
            {
                return 0;
            }

            else
            return Movies[id -1].Rating;

            
        }

        public int SaveRating(string movieName, int rating)
        /// <summary>
        /// Given a movieName and rating, saves the rating and returns a unique id > 0.
        /// If the movie name and/or rating are null or empty, nothing should be saved and it should return 0
        /// </summary>
        /// <param name="movieName"></param>
        /// <param name="rating"></param>
        /// <returns></returns>


        {
            if (movieName == null || rating == 0)
            {
                return 0;
            }

            Movie movie = new Movie
            {
                Name = movieName,
                Rating = rating,
                Id = Movies.Count + 1
            };
            Movies.Add(movie);
            return movie.Id;
        }
    }
}
