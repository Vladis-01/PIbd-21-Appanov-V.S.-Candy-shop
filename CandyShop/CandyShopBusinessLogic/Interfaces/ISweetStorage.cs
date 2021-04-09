using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace CandyShopBusinessLogic.Interfaces
{
    public interface ISweetStorage
    {
        List<SweetViewModel> GetFullList();
        List<SweetViewModel> GetFilteredList(SweetBindingModel model);
        SweetViewModel GetElement(SweetBindingModel model);
        void Insert(SweetBindingModel model);
        void Update(SweetBindingModel model);
        void Delete(SweetBindingModel model);
    }
}
