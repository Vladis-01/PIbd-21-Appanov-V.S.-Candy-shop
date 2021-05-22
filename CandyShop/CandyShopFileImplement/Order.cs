﻿using CandyShopBusinessLogic.Enums;
using System;
namespace CandyShopFileImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int PastryId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public int ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
