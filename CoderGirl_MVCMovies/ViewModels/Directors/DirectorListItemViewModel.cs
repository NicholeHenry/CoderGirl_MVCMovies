using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.ViewModels.Directors
{
    public class DirectorListItemViewModel
    {
        public static List<DirectorListItemViewModel> GetDirectorList()
        {
            return RepositoryFactory.GetDirectorRepository()
                .GetModels()
                .Cast<Director>()
                .Select(director => GetDirectorListItemFromDirector(director))
                .ToList();
        }

        private static DirectorListItemViewModel GetDirectorListItemFromDirector(Director director)
        {
            return new DirectorListItemViewModel
            {
                Id = director.Id,
                Name = director.FullName,
                BirthDate = director.BirthDate.ToShortDateString(),
                Nationality = director.Nationality
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Birth Date")]
        public string BirthDate { get; set; }
        public string Nationality { get; set; }
    }
}
