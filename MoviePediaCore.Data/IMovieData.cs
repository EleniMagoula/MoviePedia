using MoviePediaCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePediaCore.Data
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetMoviesByName(string name);
        Movie GetById(int id);
        Movie Add(Movie newMovie);
        Movie Update(Movie updatedMovie);
        Movie Delete(int id);
        int Commit();
    }
}
