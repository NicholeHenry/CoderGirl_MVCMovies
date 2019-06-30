using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.ViewModels.Directors
{
    public class DirectorCreateViewModel
    {   [Required(ErrorMessage="First Name must be included")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name must be included")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set;}

        public void Persist()
        {
            Director director = new Director
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Nationality = this.Nationality
            };
            RepositoryFactory.GetDirectorRepository().Save(director);
        }
    }
}
