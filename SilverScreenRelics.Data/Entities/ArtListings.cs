using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Data.Entities
{
    public class ArtListings
    {
        [Key]// or foregin key? to ArtItem?
        public int RelicId { get; set; }//Primary Key Movie Prop
        [Required]
        public string ArtItemTitle { get; set; }
        [Required]
        public string ArtItemDescription { get; set; }

        //public virtual ICollection<ArtListings> ArtListing { get; set; } = new List<ArtListings>();
        //public virtual ICollection<RelicType> Relic { get; set; } = new List<RelicType>();
    }
}
