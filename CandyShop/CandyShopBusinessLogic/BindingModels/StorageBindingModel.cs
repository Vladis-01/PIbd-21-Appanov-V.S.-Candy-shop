using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int? Id { get; set; }

        public string StorageName { get; set; }

        public string StorageManager { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StorageSweets { get; set; }
    }
}
