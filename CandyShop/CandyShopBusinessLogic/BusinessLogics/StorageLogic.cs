using System;
using System.Collections.Generic;
using System.Text;
using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;

namespace CandyShopBusinessLogic.BusinessLogics
{
    public class StorageLogic
    {
        private readonly IStorageStorage _storageStorage;

        private readonly ISweetStorage _sweetStorage;

        public StorageLogic(IStorageStorage storage, ISweetStorage sweetStorage)
        {
            _storageStorage = storage;
            _sweetStorage = sweetStorage;
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            if (model == null)
            {
                return _storageStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<StorageViewModel>
                {
                    _storageStorage.GetElement(model)
                };
            }

            return _storageStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StorageBindingModel model)
        {
            var element = _storageStorage.GetElement(new StorageBindingModel
            {
                StorageName = model.StorageName
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }

            if (model.Id.HasValue)
            {
                _storageStorage.Update(model);
            }
            else
            {
                _storageStorage.Insert(model);
            }
        }

        public void Delete(StorageBindingModel model)
        {
            var element = _storageStorage.GetElement(new StorageBindingModel
            {
                Id = model.Id
            });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            _storageStorage.Delete(model);
        }

        public void Replenishment(ReplenishStorageBindingModel model)
        {
            var storage = _storageStorage.GetElement(new StorageBindingModel
            {
                Id = model.StorageId
            });

            var sweet = _sweetStorage.GetElement(new SweetBindingModel
            {
                Id = model.SweetId
            });

            if (storage == null)
            {
                throw new Exception("Не найден склад");
            }

            if (sweet == null)
            {
                throw new Exception("Сладость не найдена");
            }

            if (storage.StorageSweets.ContainsKey(model.SweetId))
            {
                storage.StorageSweets[model.SweetId] = (sweet.SweetName, storage.StorageSweets[model.SweetId].Item2 + model.Count);
            }
            else
            {
                storage.StorageSweets.Add(sweet.Id, (sweet.SweetName, model.Count));
            }

            _storageStorage.Update(new StorageBindingModel
            {
                Id = storage.Id,
                StorageName = storage.StorageName,
                StorageManager = storage.StorageManager,
                DateCreate = storage.DateCreate,
                StorageSweets = storage.StorageSweets
            });
        }
    }
}
