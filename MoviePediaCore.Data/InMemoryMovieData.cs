using MoviePediaCore.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MoviePediaCore.Data
{
    public class InMemoryMovieData : IMovieData
    {
        private readonly List<Movie> movies;

        public InMemoryMovieData()
        {
            movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Silence of the Lambs", Description = ".", YearOfRelease = 1991, MovieGenre = Genre.Thriller },
                new Movie { Id = 2, Name = "Knives Out", Description = ".", YearOfRelease = 2019, MovieGenre = Genre.Crime },
                new Movie { Id = 3, Name = "Sinister", Description = ".", YearOfRelease = 2012, MovieGenre = Genre.Horror },
                new Movie { Id = 4, Name = "Spy", Description = ".", YearOfRelease = 2015, MovieGenre = Genre.Comedy },
                new Movie { Id = 5, Name = "Taken", Description = ".", YearOfRelease = 2008, MovieGenre = Genre.Action }
            };
        }

        public IEnumerable<Movie> GetAll()
        {
            return from m in movies
                   orderby m.Name
                   select m;
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByName(string name)
        {
            throw new NotImplementedException();
        }

        public Movie Add(Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public Movie Update(Movie updatedMovie)
        {
            throw new NotImplementedException();
        }

        public Movie Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
