using CandyShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.HelperModels
{
    public class PdfInfoOrdersByDates
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrderByDatesViewModel> Orders { get; set; }
    }
}
