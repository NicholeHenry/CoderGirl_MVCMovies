using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.Models
{
    public class Movie : IModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Name must be included")]
        public string Name { get; set; }
        public string DirectorName { get; set; }
        [Required(ErrorMessage = "Year is not valid")]
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        public int DirectorId { get; set; }
    }
}
