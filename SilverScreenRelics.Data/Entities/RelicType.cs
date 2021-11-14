using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Data.Entities
{
    public class RelicType
    {
        [Key]
        public int RelicId { get; set; }
        public virtual RelicType RelicTypes { get; set; }
        public virtual ICollection<RelicType> Relic { get; set; } = new List<RelicType>();

        [Required]
        [Display(Name = "Movie Item Description")]
        public string ArtItemDescription { get; set; }
    }
}
