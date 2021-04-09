using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopListImplement.Models;
using System;
using System.Collections.Generic;
namespace CandyShopListImplement.Implements
{
    public class SweetStorage : ISweetStorage
    {
        private readonly DataListSingleton source;
        public SweetStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SweetViewModel> GetFullList()
        {
            List<SweetViewModel> result = new List<SweetViewModel>();
            foreach (var sweet in source.Sweets)
            {
                result.Add(CreateModel(sweet));
            }
            return result;
        }
        public List<SweetViewModel> GetFilteredList(SweetBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<SweetViewModel> result = new List<SweetViewModel>();
            foreach (var sweet in source.Sweets)
            {
                if (sweet.SweetName.Contains(model.SweetName))
                {
                    result.Add(CreateModel(sweet));
                }
            }
            return result;
        }
        public SweetViewModel GetElement(SweetBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var sweet in source.Sweets)
            {
                if (sweet.Id == model.Id || sweet.SweetName ==
               model.SweetName)
                {
                    return CreateModel(sweet);
                }
            }
            return null;
        }
        public void Insert(SweetBindingModel model)
        {
            Sweet tempSweet = new Sweet { Id = 1 };
            foreach (var sweet in source.Sweets)
            {
                if (sweet.Id >= tempSweet.Id)
                {
                    tempSweet.Id = sweet.Id + 1;
                }
            }
            source.Sweets.Add(CreateModel(model, tempSweet));
        }
        public void Update(SweetBindingModel model)
        {
            Sweet tempSweet = null;
            foreach (var sweet in source.Sweets)
            {
                if (sweet.Id == model.Id)
                {
                    tempSweet = sweet;
                }
            }
            if (tempSweet == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempSweet);
        }
        public void Delete(SweetBindingModel model)
        {
            for (int i = 0; i < source.Sweets.Count; ++i)
            {
                if (source.Sweets[i].Id == model.Id.Value)
                {
                    source.Sweets.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Sweet CreateModel(SweetBindingModel model, Sweet sweet)
        {
            sweet.SweetName = model.SweetName;
            return sweet;
        }
        private SweetViewModel CreateModel(Sweet sweet)
        {
            return new SweetViewModel
            {
                Id = sweet.Id,
                SweetName = sweet.SweetName
            };
        }
    }
}
