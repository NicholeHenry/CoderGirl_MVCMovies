using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModel
{
    public class MovieCreatViewModel
    {
        public static MovieCreatViewModel GetMovieCreatViewModel()
        {
            MovieCreatViewModel viewModel = new MovieCreatViewModel();
           List<Director> directors = RepositoryFactory.GetDirectorRepository()
            .GetModels().Cast<Director>().ToList();viewModel.Directors = directors;
            return viewModel;




        }


        public string Name { get; set; }
        public int DirectorId { get; set; }
        public List<Director> Directors { get; set; }
        public int Year { get; set; }

        public void Save()
        {
            Movie movie = new Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                Year = this.Year
            };
            RepositoryFactory.GetMovieRepository().Save(movie);
        }
    }
}
