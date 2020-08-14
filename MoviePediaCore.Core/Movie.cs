using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePediaCore.Core
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Description { get; set; }
        public Genre MovieGenre { get; set; }
    }
}
