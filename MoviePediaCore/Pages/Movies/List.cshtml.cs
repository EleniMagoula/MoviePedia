using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviePediaCore.Core;
using MoviePediaCore.Data;

namespace MoviePediaCore.Pages.Movies
{
    public class ListModel : PageModel
    {
        private readonly IMovieData _movieData;

        public IEnumerable<Movie> Movies { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public void OnGet()
        {
            Movies = _movieData.GetMoviesByName(SearchTerm);
        }
    }

}
