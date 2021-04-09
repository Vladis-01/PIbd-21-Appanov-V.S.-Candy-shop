using System.Collections.Generic;
namespace CandyShopFileImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Pastry
    {
        public int Id { get; set; }
        public string PastryName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> PastrySweets { get; set; }
    }
}