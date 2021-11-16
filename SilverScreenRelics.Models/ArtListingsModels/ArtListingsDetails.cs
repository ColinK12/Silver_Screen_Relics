using SilverScreenRelics.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.ArtListingsModels
{
    public class ArtListingsDetails
    {
        public int RelicId { get; set; }

        [Display(Name = "Movie Item Description")]
        public string ArtItemDescription { get; set; }
        public virtual ICollection<ArtListings> ArtListing { get; set; } = new List<ArtListings>();
    }
}
