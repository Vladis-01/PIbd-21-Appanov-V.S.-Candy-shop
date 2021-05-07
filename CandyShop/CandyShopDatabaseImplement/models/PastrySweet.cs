using System.ComponentModel.DataAnnotations;

namespace CandyShopDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class PastrySweet
    {
        public int Id { get; set; }

        public int PastryId { get; set; }
        public int SweetId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Sweet Sweet { get; set; }
        public virtual Pastry Pastry { get; set; }
    }
}
