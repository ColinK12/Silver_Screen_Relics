using ScreenRelics.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Data.Entities
{
    public class ArtItem
    {
        [Key]
        public int ArtItemId { get; set; } //Primary Key
        [Required]
        public string ArtItemTitle { get; set; }
        [Required]
        public string ArtItemDescription { get; set; }
        [Required]
        public double ArtItemPrice { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("RelicTypes")]
        public int RelicId { get; set; }//Composite Key/
        public virtual RelicType RelicTypes { get; set; }
        public virtual ICollection<ArtItem> ArtItems { get; set; }

        [Required]
        public bool? IsActive { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
