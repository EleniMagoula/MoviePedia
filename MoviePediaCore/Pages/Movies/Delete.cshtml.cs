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
    public class DeleteModel : PageModel
    {
        private readonly IMovieData _movieData;

        public Movie Movie { get; set; }

        public DeleteModel(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public IActionResult OnGet(int movieId)
        {
            Movie = _movieData.GetById(movieId);

            if (Movie == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int movieId)
        {
            Movie = _movieData.Delete(movieId);
            _movieData.Commit();

            if (Movie == null)
                return RedirectToPage("./NotFound");

            return RedirectToPage("./List");
        }
    }
}
