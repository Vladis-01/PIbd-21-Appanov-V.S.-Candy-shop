using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandyShopDatabaseImplement.Implements
{
    public class PastryStorage : IPastryStorage
    {
        public List<PastryViewModel> GetFullList()
        {
            using (var context = new CandyShopDatabase())
            {
                return context.Pastrys
                    .Include(rec => rec.PastrySweets)
                    .ThenInclude(rec => rec.Sweet)
                    .ToList()
                    .Select(rec => new PastryViewModel
                    {
                        Id = rec.Id,
                        PastryName = rec.PastryName,
                        Price = rec.Price,
                        PastrySweets = rec.PastrySweets
                            .ToDictionary(recPastrySweets => recPastrySweets.SweetId,
                            recPastrySweets => (recPastrySweets.Sweet?.SweetName,
                            recPastrySweets.Count))
                    })
                    .ToList();
            }
        }
        public List<PastryViewModel> GetFilteredList(PastryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CandyShopDatabase())
            {
                return context.Pastrys
                    .Include(rec => rec.PastrySweets)
                    .ThenInclude(rec => rec.Sweet)
                    .Where(rec => rec.PastryName.Contains(model.PastryName))
                    .ToList()
                    .Select(rec => new PastryViewModel
                    {
                        Id = rec.Id,
                        PastryName = rec.PastryName,
                        Price = rec.Price,
                        PastrySweets = rec.PastrySweets
                            .ToDictionary(recPastrySweets => recPastrySweets.SweetId,
                            recPastrySweets => (recPastrySweets.Sweet?.SweetName,
                            recPastrySweets.Count))
                    })
                    .ToList();
            }
        }
        public PastryViewModel GetElement(PastryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CandyShopDatabase())
            {
                var pastry = context.Pastrys
                    .Include(rec => rec.PastrySweets)
                    .ThenInclude(rec => rec.Sweet)
                    .FirstOrDefault(rec => rec.PastryName == model.PastryName ||
                    rec.Id == model.Id);

                return pastry != null ?
                    new PastryViewModel
                    {
                        Id = pastry.Id,
                        PastryName = pastry.PastryName,
                        Price = pastry.Price,
                        PastrySweets = pastry.PastrySweets
                            .ToDictionary(recPastrySweet => recPastrySweet.SweetId,
                            recPastrySweet => (recPastrySweet.Sweet?.SweetName,
                            recPastrySweet.Count))
                    } :
                    null;
            }
        }
        public void Insert(PastryBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Pastry(), context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(PastryBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var pastry = context.Pastrys.FirstOrDefault(rec => rec.Id == model.Id);

                        if (pastry == null)
                        {
                            throw new Exception("Подарок не найден");
                        }

                        CreateModel(model, pastry, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PastryBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                var sweet = context.Pastrys.FirstOrDefault(rec => rec.Id == model.Id);

                if (sweet == null)
                {
                    throw new Exception("Сладость не найдена");
                }

                context.Pastrys.Remove(sweet);
                context.SaveChanges();
            }
        }
        private Pastry CreateModel(PastryBindingModel model, Pastry pastry, CandyShopDatabase context)
        {
            pastry.PastryName = model.PastryName;
            pastry.Price = model.Price;
            if (pastry.Id == 0)
            {
                context.Pastrys.Add(pastry);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var giftMaterial = context.PastrySweets
                    .Where(rec => rec.PastryId == model.Id.Value)
                    .ToList();

                context.PastrySweets.RemoveRange(giftMaterial
                    .Where(rec => !model.PastrySweets.ContainsKey(rec.PastryId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateMaterial in giftMaterial)
                {
                    updateMaterial.Count = model.PastrySweets[updateMaterial.SweetId].Item2;
                    model.PastrySweets.Remove(updateMaterial.PastryId);
                }
                context.SaveChanges();
            }
            foreach (var pastrySweet in model.PastrySweets)
            {
                context.PastrySweets.Add(new PastrySweet
                {
                    PastryId = pastry.Id,
                    SweetId = pastrySweet.Key,
                    Count = pastrySweet.Value.Item2
                });
                context.SaveChanges();
            }
            return pastry;
        }
    }
}