using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieCreateViewModel
    {
        public static MovieCreateViewModel GetMovieCreateViewModel()
        {
            List<Director> directors = RepositoryFactory.GetDirectorRepository()
                .GetModels()
                .Cast<Director>()
                .ToList();
            
            return new MovieCreateViewModel(directors);
        }

        public MovieCreateViewModel()
        {

        }
        [Required(ErrorMessage ="Name must be included")]
        public string Name { get; set; }
        [Display(Name="Director Name")]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public List<Director> Directors { get; set; }
        public int Year { get; set; } 
        




        private MovieCreateViewModel(List<Director> directors)
        {
            this.Directors = directors;
        }
        
        public void Persist()
        {
            Movie movie = new Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                DirectorName = this.DirectorName,
                Year = this.Year,
               
            };
            RepositoryFactory.GetMovieRepository().Save(movie);
        }
    }
}
