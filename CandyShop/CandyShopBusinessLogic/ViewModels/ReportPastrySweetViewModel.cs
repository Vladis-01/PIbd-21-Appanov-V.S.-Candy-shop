using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CandyShopBusinessLogic.ViewModels
{
    public class ReportPastrySweetViewModel
    {
        [DisplayName("Название сладости")]
        public string SweetName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Pastrys { get; set; }
    }
}