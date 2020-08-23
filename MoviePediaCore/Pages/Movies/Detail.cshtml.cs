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
    public class DetailModel : PageModel
    {
        private readonly IMovieData _movieData;

        public Movie Movie { get; set; }

        public DetailModel(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public IActionResult OnGet(int movieId)
        { 
            Movie = _movieData.GetById(movieId);

            if (Movie == null)
                RedirectToPage("./NotFound");

            return Page();
        }
    }
}
