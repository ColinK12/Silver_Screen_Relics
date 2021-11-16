using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.Movie
{
    public class MovieUpdate
    {
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "MovieTitle")]
        public string MovieTitle { get; set; }
        public int MovieReleaseYear { get; set; }
        public int UserRating { get; set; }

    }
}
