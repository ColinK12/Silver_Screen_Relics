using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Models.TransactionsModels
{
    public class TransactionsDelete
    {
        [Required]
        public int TransactionId { get; set; }
    }
}
