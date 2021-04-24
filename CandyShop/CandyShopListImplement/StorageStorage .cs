﻿using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyShopListImplement.Implements
{
    public class StorageStorage : IStorageStorage
    {
        private readonly DataListSingleton source;

        public StorageStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<StorageViewModel> GetFullList()
        {
            List<StorageViewModel> result = new List<StorageViewModel>();

            foreach (var storage in source.Storages)
            {
                result.Add(CreateModel(storage));
            }

            return result;
        }

        public List<StorageViewModel> GetFilteredList(StorageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            List<StorageViewModel> result = new List<StorageViewModel>();

            foreach (var storage in source.Storages)
            {
                if (storage.StorageName.Contains(model.StorageName))
                {
                    result.Add(CreateModel(storage));
                }
            }

            return result;
        }

        public StorageViewModel GetElement(StorageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var storage in source.Storages)
            {
                if (storage.Id == model.Id || storage.StorageName == model.StorageName)
                {
                    return CreateModel(storage);
                }
            }

            return null;
        }

        public void Insert(StorageBindingModel model)
        {
            Storage tempStorage = new Storage
            {
                Id = 1,
                StorageSweets = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };

            foreach (var storage in source.Storages)
            {
                if (storage.Id >= tempStorage.Id)
                {
                    tempStorage.Id = storage.Id + 1;
                }
            }

            source.Storages.Add(CreateModel(model, tempStorage));
        }

        public void Update(StorageBindingModel model)
        {
            Storage tempStorage = null;

            foreach (var storage in source.Storages)
            {
                if (storage.Id == model.Id)
                {
                    tempStorage = storage;
                }
            }

            if (tempStorage == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tempStorage);
        }

        public void Delete(StorageBindingModel model)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    source.Storages.RemoveAt(i);

                    return;
                }
            }
            throw new Exception("Элемент не найден");
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

            foreach (var sweets in model.StorageSweets)
            {
                if (storage.StorageSweets.ContainsKey(sweets.Key))
                {
                    storage.StorageSweets[sweets.Key] = model.StorageSweets[sweets.Key].Item2;
                }
                else
                {
                    storage.StorageSweets.Add(sweets.Key, model.StorageSweets[sweets.Key].Item2);
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

                foreach (var sweet in source.Sweets)
                {
                    if (storageSweet.Key == sweet.Id)
                    {
                        sweetName = sweet.SweetName;

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

        public bool TakeFromStorage(Dictionary<int, (string, int)> sweets, int count)
        {
            throw new NotImplementedException();
        }
    }
}