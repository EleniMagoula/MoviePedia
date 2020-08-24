using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoviePediaCore.Core
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public int YearOfRelease { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        public Genre MovieGenre { get; set; }
    }
}
