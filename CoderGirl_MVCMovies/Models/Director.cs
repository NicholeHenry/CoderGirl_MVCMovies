﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.Models
{
    public class Director : IModel
    {
        public int Id { get; set; }
      
        [Required(ErrorMessage= "First Name must be included")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name ="Birth Date")]
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string FullName
        {
            get { return $"{LastName}, {FirstName}"; }
        }

    }
}
