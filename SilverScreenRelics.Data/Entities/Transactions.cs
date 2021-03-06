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
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ArtItem")]
        [Display(Name = "Movie Item")]
        public int ArtItemId { get; set; }
        public virtual ArtItem ArtItem { get; set; }

        [Required]
        public double ArtItemPrice { get; set; }
    }
}
