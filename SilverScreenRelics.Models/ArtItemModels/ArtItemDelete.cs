using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.ArtItemModels
{
   public class ArtItemDelete
    {
        [Required]
        public int ArtItemId { get; set; } 
    }
}
