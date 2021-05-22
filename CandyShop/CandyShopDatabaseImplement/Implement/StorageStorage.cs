using System;
using System.Collections.Generic;
using System.Linq;
using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CandyShopDatabaseImplement.Implements

{
    public class StorageStorage : IStorageStorage
    {
        public List<StorageViewModel> GetFullList()
        {
            using (var context = new CandyShopDatabase())
            {
                return context.Storages
                    .Include(rec => rec.StorageSweets)
                    .ThenInclude(rec => rec.Sweet)
                    .ToList().Select(rec => new StorageViewModel
                    {
                        Id = rec.Id,
                        StorageName = rec.StorageName,
                        StorageManager = rec.StorageManager,
                        DateCreate = rec.DateCreate,
                        StorageSweets = rec.StorageSweets
                            .ToDictionary(recPPC => recPPC.SweetId,
                            recPPC => (recPPC.Sweet?.SweetName, recPPC.Count))
                    })
                    .ToList();
            }
        }

        public List<StorageViewModel> GetFilteredList(StorageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CandyShopDatabase())
            {
                return context.Storages
                    .Include(rec => rec.StorageSweets)
                    .ThenInclude(rec => rec.Sweet)
                    .Where(rec => rec.StorageName
                    .Contains(model.StorageName))
                    .ToList()
                    .Select(rec => new StorageViewModel
                    {
                        Id = rec.Id,
                        StorageName = rec.StorageName,
                        StorageManager = rec.StorageManager,
                        DateCreate = rec.DateCreate,
                        StorageSweets = rec.StorageSweets
                            .ToDictionary(recPC => recPC.SweetId, recPC => (recPC.Sweet?.SweetName, recPC.Count))
                    })
                    .ToList();
            }
        }

        public StorageViewModel GetElement(StorageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CandyShopDatabase())
            {
                var storehouse = context.Storages
                    .Include(rec => rec.StorageSweets)
                    .ThenInclude(rec => rec.Sweet)
                    .FirstOrDefault(rec => rec.StorageName == model.StorageName || rec.Id == model.Id);

                return storehouse != null ?
                    new StorageViewModel
                    {
                        Id = storehouse.Id,
                        StorageName = storehouse.StorageName,
                        StorageManager = storehouse.StorageManager,
                        DateCreate = storehouse.DateCreate,
                        StorageSweets = storehouse.StorageSweets
                            .ToDictionary(recPC => recPC.SweetId, recPC => (recPC.Sweet?.SweetName, recPC.Count))
                    } :
                    null;
            }
        }

        public void Insert(StorageBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Storage(), context);
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

        public void Update(StorageBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }

                        CreateModel(model, element, context);
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

        public void Delete(StorageBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                Storage element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Storages.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Storage CreateModel(StorageBindingModel model, Storage storage, CandyShopDatabase context)
        {
            storage.StorageName = model.StorageName;
            storage.StorageManager = model.StorageManager;
            storage.DateCreate = model.DateCreate;

            if (storage.Id == 0)
            {
                context.Storages.Add(storage);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var storageSweets = context.StorageSweets
                    .Where(rec => rec.StorageId == model.Id.Value)
                    .ToList();

                context.StorageSweets
                    .RemoveRange(storageSweets
                        .Where(rec => !model.StorageSweets
                            .ContainsKey(rec.SweetId))
                                .ToList());
                context.SaveChanges();

                foreach (var updateSweet in storageSweets)
                {
                    updateSweet.Count = model.StorageSweets[updateSweet.SweetId].Item2;
                    model.StorageSweets.Remove(updateSweet.SweetId);
                }
                context.SaveChanges();
            }

            foreach (var sweet in model.StorageSweets)
            {
                context.StorageSweets.Add(new StorageSweet
                {
                    StorageId = storage.Id,
                    SweetId = sweet.Key,
                    Count = sweet.Value.Item2
                });

                context.SaveChanges();
            }

            return storage;
        }

        public bool CheckSweets(PastryViewModel model, int sweetCountInOrder)
        {
            using (var context = new CandyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {

                    foreach (var sweetsInPastry in model.PastrySweets)
                    {
                        int sweetsCountInPastry = sweetsInPastry.Value.Item2 * sweetCountInOrder;

                        List<StorageSweet> oneOfSweet = context.StorageSweets
                            .Where(storehouse => storehouse.SweetId == sweetsInPastry.Key)
                            .ToList();

                        foreach (var sweet in oneOfSweet)
                        {
                            int sweetCountInStorage = sweet.Count;

                            if (sweetCountInStorage <= sweetsCountInPastry)
                            {
                                sweetsCountInPastry -= sweetCountInStorage;
                                context.Storages.FirstOrDefault(rec => rec.Id == sweet.StorageId).StorageSweets.Remove(sweet);
                            }
                            else
                            {
                                sweet.Count -= sweetsCountInPastry;
                                sweetsCountInPastry = 0;
                            }

                            if (sweetsCountInPastry == 0)
                            {
                                break;
                            }
                        }

                        if (sweetsCountInPastry > 0)
                        {
                            transaction.Rollback();

                            return false;
                        }
                    }

                    context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
            }
        }
    }
}