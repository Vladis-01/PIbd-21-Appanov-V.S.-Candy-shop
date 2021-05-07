using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CandyShopDatabaseImplement.Models
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class Sweet
    {
        public int Id { get; set; }
        [Required]
        public string SweetName { get; set; }
        [ForeignKey("SweetId")]
        public virtual List<PastrySweet> PastrySweets { get; set; }
    }
}