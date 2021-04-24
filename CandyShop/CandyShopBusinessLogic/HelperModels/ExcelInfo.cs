using CandyShopBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace CandyShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPastrySweetViewModel> PastrySweets { get; set; }
    }
}