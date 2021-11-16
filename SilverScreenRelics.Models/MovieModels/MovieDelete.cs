using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.Movie
{
    public class MovieDelete
    {
        [Required]
        public int MovieId { get; set; }
    }
}
