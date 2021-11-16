using ScreenRelics.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Data.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }      
        public int MovieReleaseYear { get; set; }       
        public int UserRating { get; set; }
        public List<Movie> ListOfMovies { get; set; } = new List<Movie>();

        [ForeignKey("ArtItem")]
        public int ArtItemId { get; set; } //Primary Key

        public virtual ArtItem ArtItem { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }






    }
}
