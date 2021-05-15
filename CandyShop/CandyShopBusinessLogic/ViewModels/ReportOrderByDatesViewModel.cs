using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.ViewModels
{
    public class ReportOrderByDatesViewModel
    {
        public DateTime DateCreate { get; set; }

        public int OrdersCount { get; set; }

        public decimal TotalSum { get; set; }
    }
}
