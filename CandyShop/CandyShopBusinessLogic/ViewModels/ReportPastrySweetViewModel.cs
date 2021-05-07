using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CandyShopBusinessLogic.ViewModels
{
    public class ReportPastrySweetViewModel
    {
        [DisplayName("Название кондитерского изделия")]
        public string PastryName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Sweets { get; set; }
    }
}