using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.ArtItemModels
{
    public class ArtItemDetail
    {

        [Display(Name = "Movie Title")]
        public string ArtItemTitle { get; set; }

        [Display(Name = "Art Item Description")]
        public string ArtItemDescription { get; set; }
        [Required]
        public double ArtItemPrice { get; set; }
        public bool? IsActive { get; set; }

        [Display(Name = "Date of Posting")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
