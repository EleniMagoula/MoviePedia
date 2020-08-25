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
                new Movie { Id = 1, Title = "Silence of the Lambs", Description = "Lorem ipsum dolor sit amet, consectetur " +
                "adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tempor nec feugiat nisl " +
                "pretium fusce id velit ut tortor. Amet justo donec enim diam vulputate ut pharetra sit.",
                    YearOfRelease = 1991, MovieGenre = Genre.Thriller },
                new Movie { Id = 2, Title = "Knives Out", Description = ".", YearOfRelease = 2019, MovieGenre = Genre.Crime },
                new Movie { Id = 3, Title = "Sinister", Description = ".", YearOfRelease = 2012, MovieGenre = Genre.Horror },
                new Movie { Id = 4, Title = "Spy", Description = ".", YearOfRelease = 2015, MovieGenre = Genre.Comedy },
                new Movie { Id = 5, Title = "Taken", Description = ".", YearOfRelease = 2008, MovieGenre = Genre.Action }
            };
        }

        public IEnumerable<Movie> GetAll()
        {
            return from m in movies
                   orderby m.Title
                   select m;
        }

        public Movie GetById(int id)
        {
            return movies.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMoviesByName(string title = null)
        {
            return from m in movies
                   where string.IsNullOrEmpty(title) || m.Title.StartsWith(title)
                   orderby m.Title
                   select m;
        }

        public Movie Add(Movie newMovie)
        {
            movies.Add(newMovie);
            newMovie.Id = movies.Max(m => m.Id) + 1;
            return newMovie;
        }

        public Movie Update(Movie updatedMovie)
        {
            var movie = movies.SingleOrDefault(m => m.Id == updatedMovie.Id);

            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.YearOfRelease = updatedMovie.YearOfRelease;
                movie.Description = updatedMovie.Description;
                movie.MovieGenre = updatedMovie.MovieGenre;
            }

            return updatedMovie;
        }

        public Movie Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie != null)
                movies.Remove(movie);

            return movie;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
