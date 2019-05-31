using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.Models
{
    public class Director
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastAndFirstName
        {
            get { return LastName + ", " + FirstName; }
            
        }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public int Id { get; set; }
    }
}
