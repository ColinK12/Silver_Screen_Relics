using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.ArtListingsModels
{
    public class ArtListingsDelete
    {
        [Required]
        public int RelicTypeId { get; set; } //Primary Key
    }
}
