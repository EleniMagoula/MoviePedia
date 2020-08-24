using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviePediaCore.Core;
using MoviePediaCore.Data;

namespace MoviePediaCore.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieData _movieData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Movie Movie { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public EditModel(IMovieData movieData, IHtmlHelper htmlHelper)
        {
            _movieData = movieData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? movieId)
        {
            Genres = _htmlHelper.GetEnumSelectList<Genre>();

            if (movieId.HasValue)
                Movie = _movieData.GetById(movieId.Value);
            else
                Movie = new Movie();

            if (Movie == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Genres = _htmlHelper.GetEnumSelectList<Genre>();
                return Page();
            }

            if (Movie.Id > 0)
            {
                _movieData.Update(Movie);
            }
            else
            {
                _movieData.Add(Movie);
            }

            _movieData.Commit();
            return RedirectToPage("./Detail", new { movieId = Movie.Id });
        }
    }
}
