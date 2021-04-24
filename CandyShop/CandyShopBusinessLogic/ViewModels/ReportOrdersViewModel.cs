using CandyShopBusinessLogic.Enums;
using System;
using System.ComponentModel;

namespace CandyShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        [DisplayName("Название кондитерского изделия")]
        public string PastryName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}