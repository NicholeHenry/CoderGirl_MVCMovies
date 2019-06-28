using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieEditViewModel
    {

        public static MovieEditViewModel GetModel(int id)
        {
            Movie movie = (Movie)RepositoryFactory.GetMovieRepository().GetById(id);
            return new MovieEditViewModel
            {
                Name = movie.Name,
                DirectorId = movie.DirectorId,
                Year = movie.Year


            };
        }
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public List<Director> Directors { get; set; }
        public int Year { get; set; }

        public void Persist(int id)
            {
                Movie movie = new Movie
                {
                    Id = id,
                    Name =this.Name,
                    Year = this.Year,
                    DirectorId = this.DirectorId

                };

                RepositoryFactory.GetMovieRepository().Update(movie);
            }
        
    }
}
