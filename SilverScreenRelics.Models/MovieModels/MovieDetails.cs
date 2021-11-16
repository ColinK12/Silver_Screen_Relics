using SilverScreenRelics.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.Movie
{
    public class MovieDetails
    {
        public string MovieTitle { get; set; }
        public int MovieReleaseYear { get; set; }
        public int UserRating { get; set; }
    }
}
