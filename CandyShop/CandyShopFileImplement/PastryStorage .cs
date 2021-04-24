using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyShopFileImplement.Implements
{
    public class PastryStorage : IPastryStorage
    {
        private readonly FileDataListSingleton source;

        public PastryStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<PastryViewModel> GetFullList()
        {
            return source.Pastrys
            .Select(CreateModel)
            .ToList();
        }

        public List<PastryViewModel> GetFilteredList(PastryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Pastrys
            .Where(rec => rec.PastryName.Contains(model.PastryName))
            .Select(CreateModel)
            .ToList();
        }

        public PastryViewModel GetElement(PastryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var pastry = source.Pastrys
            .FirstOrDefault(rec => rec.PastryName == model.PastryName || rec.Id
            == model.Id);

            return pastry != null ? CreateModel(pastry) : null;
        }

        public void Insert(PastryBindingModel model)
        {
            int maxId = source.Pastrys.Count > 0 ? source.Sweets.Max(rec => rec.Id) : 0;
            

            var element = new Pastry
            {
                Id = maxId + 1,
                PastrySweets = new

            Dictionary<int, int>()
            };
            source.Pastrys.Add(CreateModel(model, element));
        }

        public void Update(PastryBindingModel model)
        {
            var element = source.Pastrys.FirstOrDefault(rec => rec.Id == model.Id); 
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
        }

        public void Delete(PastryBindingModel model)
        {
            Pastry element = source.Pastrys.FirstOrDefault(rec => rec.Id == model.Id); 
            if (element != null)
            {
                source.Pastrys.Remove(element);

            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Pastry CreateModel(PastryBindingModel model, Pastry pastry)
        {
            pastry.PastryName = model.PastryName; pastry.Price = model.Price;
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
                    pastry.PastrySweets[sweet.Key] = model.PastrySweets[sweet.Key].Item2;
                }
                else
                {
                    pastry.PastrySweets.Add(sweet.Key, model.PastrySweets[sweet.Key].Item2);
                }
            }

            return pastry;
        }

        private PastryViewModel CreateModel(Pastry pastry)
        {
            return new PastryViewModel
            {
                Id = pastry.Id,
                PastryName = pastry.PastryName,
                Price = pastry.Price,
                PastrySweets = pastry.PastrySweets
.ToDictionary(recPC => recPC.Key, recPC => (source.Sweets.FirstOrDefault(recC => recC.Id ==
recPC.Key)?.SweetName, recPC.Value))
            };
        }
    }
}
