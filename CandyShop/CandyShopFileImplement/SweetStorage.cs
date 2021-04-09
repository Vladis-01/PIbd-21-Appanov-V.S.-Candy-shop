using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyShopFileImplement.Implements
{
    public class SweetStorage : ISweetStorage
    {
        private readonly FileDataListSingleton source;
        public SweetStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<SweetViewModel> GetFullList()
        {
            return source.Sweets
            .Select(CreateModel)
            .ToList();
        }

        public List<SweetViewModel> GetFilteredList(SweetBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Sweets
            .Where(rec => rec.SweetName.Contains(model.SweetName))
            .Select(CreateModel)
            .ToList();
        }

        public SweetViewModel GetElement(SweetBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var sweet = source.Sweets
            .FirstOrDefault(rec => rec.SweetName == model.SweetName ||
            rec.Id == model.Id);

            return sweet != null ? CreateModel(sweet) : null;
        }

        public void Insert(SweetBindingModel model)
        {

            int maxId = source.Sweets.Count > 0 ? source.Sweets.Max(rec =>
            rec.Id) : 0;
            var element = new Sweet { Id = maxId + 1 }; source.Sweets.Add(CreateModel(model, element));

        }

        public void Update(SweetBindingModel model)
        {
            var element = source.Sweets.FirstOrDefault(rec => rec.Id == model.Id); if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
        }

        public void Delete(SweetBindingModel model)
        {

            Sweet element = source.Sweets.FirstOrDefault(rec => rec.Id ==
            model.Id);

            if (element != null)
            {
                source.Sweets.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
