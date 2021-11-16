using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.TransactionsModels
{
    public class TransactionsCreate
    {
        public int TransactionId { get; set; }

        [Required]
        [Display(Name = "Movie Item")]
        public int ArtItemId { get; set; }

        [Required]
        [Display(Name = "Movie Item Price")]
        public double ArtItemPrice { get; set; }
    }
}
