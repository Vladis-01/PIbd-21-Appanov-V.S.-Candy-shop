using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.ViewModels;
using
System.Collections.Generic;
namespace CandyShopBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}
