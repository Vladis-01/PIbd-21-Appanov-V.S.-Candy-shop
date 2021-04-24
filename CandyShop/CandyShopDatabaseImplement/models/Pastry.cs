using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyShopDatabaseImplement.Models
{
    public class Pastry
    {
        public int Id { get; set; }
        [Required]
        public string PastryName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("PastryId")]
        public virtual List<PastrySweet> PastrySweets { get; set; }
        [ForeignKey("PastryId")]
        public virtual List<Order> Orders { get; set; }
    }
}
