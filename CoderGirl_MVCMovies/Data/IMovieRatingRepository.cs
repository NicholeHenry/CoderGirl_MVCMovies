using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    // TODO: Implement this interface
    public interface IMovieRatingRepository
    {        
        /// <summary>
        /// Given a movieName and rating, saves the rating and returns a unique id > 0.
        /// If the movie name and/or rating are null or empty, nothing should be saved and it should return 0
        /// </summary>
        /// <param name="movieName"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        int Save(MovieRating movieRating);
        double GetAverageRating(int movieId);
        /// <summary>
        /// Given an id, will return the associated rating 
        /// If the id does not exist, returns 0
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        int GetRatingCount(int movieId);
        

            MovieRating GetById(int id);

        // double GetAverageRatingByMovieName(string movieName);

        /// <summary>
        /// Given an id, will return the associated movie name.
        /// If the id does not exist, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        void Update(MovieRating movieRating);
        void Delete(int id);

        /// <summary>
        /// Given a movie name, returns the average rating of of the movie.
        /// If there are no ratings for the movie, returns an empty list.
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
       
        /// Returns a list of all the ids of saved movie ratings
        /// </summary>
        /// <returns></returns>
        
        List<MovieRating> GetMovieRatings();
    }
}
