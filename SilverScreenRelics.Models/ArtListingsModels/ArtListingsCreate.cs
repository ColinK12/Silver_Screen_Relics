using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.ArtListingsModels
{
    public class ArtListingsCreate
    {
        [Key]// or foregin key? to ArtItem?
        public int RelicId { get; set; }//Primary Key Movie Prop
        [Required]
        [Display(Name = "Movie Item Description")]
        public string ArtItemDescription { get; set; }
        //public virtual ICollection<ArtListings> ArtListing { get; set; } = new List<ArtListings>();
    }
}
