using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery_Store.Models
{
    public class Order
    {
        public long Id { get; set; }
        //public int UserId { get; set; }

        public decimal BillAmount { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime Date { get; set; }
    }
}
