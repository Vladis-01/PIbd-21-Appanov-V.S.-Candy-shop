using CandyShopBusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;
using System;
using CandyShopDatabaseImplement.models;

namespace CandyShopDatabaseImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int PastryId { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }        
        public DateTime? DateImplement { get; set; }
        public virtual Pastry Pastry { get; set; }
        public virtual Client Client { get; set; }
        public virtual Implementer Implementer { get; set; }
    }
}
