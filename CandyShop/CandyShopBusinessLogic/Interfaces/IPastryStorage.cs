using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace CandyShopBusinessLogic.Interfaces
{
    public interface IPastryStorage
    {
        List<PastryViewModel> GetFullList();
        List<PastryViewModel> GetFilteredList(PastryBindingModel model);
        PastryViewModel GetElement(PastryBindingModel model);
        void Insert(PastryBindingModel model);
        void Update(PastryBindingModel model);
        void Delete(PastryBindingModel model);
    }
}
