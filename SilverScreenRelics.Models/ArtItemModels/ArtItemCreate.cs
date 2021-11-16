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
    public class ArtItemCreate
    {

        [Required]
        [Display(Name = "ArtItemTitle")]
        public string ArtItemTitle { get; set; }
        [Required]
        [Display(Name = "ArtItemDescription")]
        public string ArtItemDescription { get; set; }

        [Required]
        public double ArtItemPrice { get; set; }

    }
}
