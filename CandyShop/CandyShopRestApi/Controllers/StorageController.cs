using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using CandyShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly StorageLogic _storage;

        private readonly SweetLogic _sweet;

        public StorageController(StorageLogic storageLogic, SweetLogic sweetLogic)
        {
            _storage = storageLogic;
            _sweet = sweetLogic;
        }

        [HttpGet]
        public List<StorageViewModel> GetStorageList() => _storage.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateStorage(StorageBindingModel model) => _storage.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorage(StorageBindingModel model) => _storage.Delete(model);

        [HttpPost]
        public void AddSweetsToStorage(ReplenishStorageBindingModel model) => _storage.Replenishment(model);

        [HttpGet]
        public StorageViewModel GetStorage(int storageId) => _storage.Read(new StorageBindingModel { Id = storageId })?[0];

        [HttpGet]
        public List<SweetViewModel> GetSweetList() => _sweet.Read(null);
    }
}
