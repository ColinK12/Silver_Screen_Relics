using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.ArtListingsModels
{
    public class ArtListingsUpdate
    {
        public int ArtItemId { get; set; }
        [Required]
        [Display(Name = "ArtItemTitle")]
        public string ArtItemTitle { get; set; }
        [Required]
        [Display(Name = "ArtItemDescription")]
        public string ArtItemDescription { get; set; }
    }
}
