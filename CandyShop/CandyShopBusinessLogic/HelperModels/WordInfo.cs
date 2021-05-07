using CandyShopBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace CandyShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PastryViewModel> Pastrys { get; set; }
    }
}