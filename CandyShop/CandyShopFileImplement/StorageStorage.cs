using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopFileImplement;
using CandyShopFileImplement.Models;

namespace CandyShopFileImplement.Implements
{
    public class StorageStorage : IStorageStorage
    {
        private readonly FileDataListSingleton source;

        public StorageStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        private Storage CreateModel(StorageBindingModel model, Storage storage)
        {
            storage.StorageName = model.StorageName;
            storage.StorageManager = model.StorageManager;

            foreach (var key in storage.StorageSweets.Keys.ToList())
            {
                if (!model.StorageSweets.ContainsKey(key))
                {
                    storage.StorageSweets.Remove(key);
                }
            }

            foreach (var sweet in model.StorageSweets)
            {
                if (storage.StorageSweets.ContainsKey(sweet.Key))
                {
                    storage.StorageSweets[sweet.Key] =
                        model.StorageSweets[sweet.Key].Item2;
                }
                else
                {
                    storage.StorageSweets.Add(sweet.Key, model.StorageSweets[sweet.Key].Item2);
                }
            }

            return storage;
        }

        private StorageViewModel CreateModel(Storage storage)
        {
            Dictionary<int, (string, int)> storageSweets = new Dictionary<int, (string, int)>();

            foreach (var storageSweet in storage.StorageSweets)
            {
                string sweetName = string.Empty;
                foreach (var material in source.Sweets)
                {
                    if (storageSweet.Key == material.Id)
                    {
                        sweetName = material.SweetName;
                        break;
                    }
                }
                storageSweets.Add(storageSweet.Key, (sweetName, storageSweet.Value));
            }

            return new StorageViewModel
            {
                Id = storage.Id,
                StorageName = storage.StorageName,
                StorageManager = storage.StorageManager,
                DateCreate = storage.DateCreate,
                StorageSweets = storageSweets
            };
        }

        public List<StorageViewModel> GetFullList()
        {
            return source.Storages.Select(CreateModel).ToList();
        }

        public List<StorageViewModel> GetFilteredList(StorageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Storages
                .Where(xStorage => xStorage.StorageName
                .Contains(model.StorageName))
                .Select(CreateModel).ToList();
        }

        public StorageViewModel GetElement(StorageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var storage = source.Storages.
                FirstOrDefault(xStorage => xStorage.StorageName == model.StorageName || xStorage.Id == model.Id);

            return storage != null ? CreateModel(storage) : null;
        }

        public void Insert(StorageBindingModel model)
        {
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(xStorage => xStorage.Id) : 0;
            var storage = new Storage { Id = maxId + 1, StorageSweets = new Dictionary<int, int>(), DateCreate = DateTime.Now };
            source.Storages.Add(CreateModel(model, storage));
        }

        public void Update(StorageBindingModel model)
        {
            var storage = source.Storages.FirstOrDefault(XStorage => XStorage.Id == model.Id);

            if (storage == null)
            {
                throw new Exception("Склад не найден");
            }

            CreateModel(model, storage);
        }

        public void Delete(StorageBindingModel model)
        {
            var storage = source.Storages.FirstOrDefault(XStorage => XStorage.Id == model.Id);

            if (storage != null)
            {
                source.Storages.Remove(storage);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
        }

        public void CheckSweets(PastryViewModel model, int sweetCountInOrder)
        {
            throw new NotImplementedException();
        }
    }
}