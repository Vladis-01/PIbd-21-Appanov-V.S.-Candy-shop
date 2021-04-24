using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace CandyShopBusinessLogic.Interfaces
{
    public interface IStorageStorage
    {
        List<StorageViewModel> GetFullList();

        List<StorageViewModel> GetFilteredList(StorageBindingModel model);

        StorageViewModel GetElement(StorageBindingModel model);

        void Insert(StorageBindingModel model);

        void Update(StorageBindingModel model);

        void Delete(StorageBindingModel model);

        bool TakeFromStorage(Dictionary<int, (string, int)> sweets, int count);
    }
}