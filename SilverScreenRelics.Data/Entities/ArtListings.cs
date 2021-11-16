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
    public class ArtListings
    {
        [Key]// or foregin key? to ArtItem?
        public int ArtListingsId { get; set; }//Primary Key Movie Prop

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public List<ArtItem> ArtListing { get; set; } = new List<ArtItem>();//SelectListItem
    }
}
