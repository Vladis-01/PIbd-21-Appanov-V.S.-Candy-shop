using CandyShopBusinessLogic.Attributes;
using CandyShopBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CandyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PastryId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PastryName { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerName { get; set; }
        [DataMember]
        [Column(title: "Количество", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", gridViewAutoSize: GridViewAutoSize.Fill)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", gridViewAutoSize: GridViewAutoSize.Fill)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime? DateImplement { get; set; }
    }

}
