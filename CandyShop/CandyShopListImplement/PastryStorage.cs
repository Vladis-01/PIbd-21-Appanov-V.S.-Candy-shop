using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CandyShopListImplement.Implements
{
    public class PastryStorage : IPastryStorage
    {
        private readonly DataListSingleton source;
        public PastryStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PastryViewModel> GetFullList()
        {
            List<PastryViewModel> result = new List<PastryViewModel>();
            foreach (var sweet in source.Pastrys)
            {
                result.Add(CreateModel(sweet));
            }
            return result;
        }
        public List<PastryViewModel> GetFilteredList(PastryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<PastryViewModel> result = new List<PastryViewModel>();
            foreach (var pastry in source.Pastrys)
            {
                if (pastry.PastryName.Contains(model.PastryName))
                {
                    result.Add(CreateModel(pastry));
                }
            }
            return result;
        }
        public PastryViewModel GetElement(PastryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var pastry in source.Pastrys)
            {
                if (pastry.Id == model.Id || pastry.PastryName ==
                model.PastryName)
                {
                    return CreateModel(pastry);
                }
            }
            return null;
        }
        public void Insert(PastryBindingModel model)
        {
            Pastry tempPastry = new Pastry
            {
                Id = 1,
                PastrySweets = new
            Dictionary<int, int>()
            };
            foreach (var pastry in source.Pastrys)
            {
                if (pastry.Id >= tempPastry.Id)
                {
                    tempPastry.Id = pastry.Id + 1;
                }
            }
            source.Pastrys.Add(CreateModel(model, tempPastry));
        }
        public void Update(PastryBindingModel model)
        {
            Pastry tempPastry = null;
            foreach (var pastry in source.Pastrys)
            {
                if (pastry.Id == model.Id)
                {
                    tempPastry = pastry;
                }
            }
            if (tempPastry == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempPastry);
        }
        public void Delete(PastryBindingModel model)
        {
            for (int i = 0; i < source.Pastrys.Count; ++i)
            {
                if (source.Pastrys[i].Id == model.Id)
                {
                    source.Pastrys.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Pastry CreateModel(PastryBindingModel model, Pastry pastry)
        {
            pastry.PastryName = model.PastryName;
            pastry.Price = model.Price;
            // удаляем убранные
            foreach (var key in pastry.PastrySweets.Keys.ToList())
            {
                if (!model.PastrySweets.ContainsKey(key))
                {
                    pastry.PastrySweets.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var sweet in model.PastrySweets)
            {
                if (pastry.PastrySweets.ContainsKey(sweet.Key))
                {
                    pastry.PastrySweets[sweet.Key] =
                    model.PastrySweets[sweet.Key].Item2;
                }
                else
                {
                    pastry.PastrySweets.Add(sweet.Key,
                    model.PastrySweets[sweet.Key].Item2);
                }
            }
            return pastry;
        }
        private PastryViewModel CreateModel(Pastry pastry)
        {
            // требуется дополнительно получить список компонентов для изделия c названиями и их количество
            Dictionary<int, (string, int)> pastrySweets = new
            Dictionary<int, (string, int)>();
            foreach (var pc in pastry.PastrySweets)
            {
                string sweetName = string.Empty;
                foreach (var sweet in source.Sweets)
                {
                    if (pc.Key == sweet.Id)
                    {
                        sweetName = sweet.SweetName;
                        break;
                    }
                }
                pastrySweets.Add(pc.Key, (sweetName, pc.Value));
            }
            return new PastryViewModel
            {
                Id = pastry.Id,
                PastryName = pastry.PastryName,
                Price = pastry.Price,
                PastrySweets = pastrySweets
            };
        }
    }
}
