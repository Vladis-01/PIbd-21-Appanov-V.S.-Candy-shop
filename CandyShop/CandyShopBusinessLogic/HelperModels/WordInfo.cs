using CandyShopBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace CandyShopBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PastryViewModel> Pastrys { get; set; }
        public List<StorageViewModel> Storages { get; set; }
    }
}