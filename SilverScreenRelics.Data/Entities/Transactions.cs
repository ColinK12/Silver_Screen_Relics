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
        [Required]
        public int UserId { get; set; }

        [ForeignKey("ArtItem")]
        [Display(Name = "Movie Item")]
        public int ArtItemId { get; set; }

        [Required]
        public double ArtItemPrice { get; set; }
        public virtual ArtItem ArtItem { get; set; }
    }
}
