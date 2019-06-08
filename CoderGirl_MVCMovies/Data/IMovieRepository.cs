﻿using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public interface IMovieRepository
    {
        int Save(Movie movie);

        List<Movie> GetMovie();

        Movie GetById(int id);

        void Update(Movie movie);

        void Delete(int id);

        string GetMovieName(Movie movie);


        

        
    }
}
