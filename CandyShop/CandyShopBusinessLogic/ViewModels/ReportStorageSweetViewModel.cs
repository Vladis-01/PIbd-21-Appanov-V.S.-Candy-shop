using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.ViewModels
{
    public class ReportStorageSweetViewModel
    {
        public string StorageName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Sweets { get; set; }
    }
}
