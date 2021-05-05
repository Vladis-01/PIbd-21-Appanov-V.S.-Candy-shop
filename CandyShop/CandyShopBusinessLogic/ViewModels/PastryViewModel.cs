using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CandyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class PastryViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название кондитерского изделия")]
        public string PastryName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> PastrySweets { get; set; }
    }

}
