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
        [Required(ErrorMessage = "Name is needed")]
        public string Name { get; set; }
        public string DirectorName { get; set; }
        
        public int Year { get; set; }
        public List<double> Ratings { get; set; }
        public int DirectorId { get; set; }
    }
}
