using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
namespace CandyShopBusinessLogic.BusinessLogics
{
    public class SweetLogic
    {
        private readonly ISweetStorage _sweetStorage;
        public SweetLogic(ISweetStorage sweetStorage)
        {
            _sweetStorage = sweetStorage;
        }
        public List<SweetViewModel> Read(SweetBindingModel model)
        {
            if (model == null)
            {
                return _sweetStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SweetViewModel> { _sweetStorage.GetElement(model)
};
            }
            return _sweetStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(SweetBindingModel model)
        {
            var element = _sweetStorage.GetElement(new SweetBindingModel
            {
                SweetName = model.SweetName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _sweetStorage.Update(model);
            }
            else
            {
                _sweetStorage.Insert(model);
            }
        }
        public void Delete(SweetBindingModel model)
        {
            var element = _sweetStorage.GetElement(new SweetBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _sweetStorage.Delete(model);
        }
    }
}
