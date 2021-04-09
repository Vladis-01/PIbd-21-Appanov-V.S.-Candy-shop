using System.Collections.Generic;
using System.ComponentModel;

namespace CandyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class PastryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название кондитерского изделия")]
        public string PastryName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PastrySweets { get; set; }
    }

}
