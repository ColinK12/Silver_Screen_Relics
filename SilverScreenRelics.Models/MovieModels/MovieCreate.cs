using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.Movie
{
    public class MovieCreate
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int MovieReleaseYear { get; set; }
        public int UserRating { get; set; }
    }
}
