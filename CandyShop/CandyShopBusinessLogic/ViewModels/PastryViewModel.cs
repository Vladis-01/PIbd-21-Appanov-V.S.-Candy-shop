using CandyShopBusinessLogic.Attributes;
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
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название кондитерского изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PastryName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        [Column(visible: false)]
        public Dictionary<int, (string, int)> PastrySweets { get; set; }
    }

}
