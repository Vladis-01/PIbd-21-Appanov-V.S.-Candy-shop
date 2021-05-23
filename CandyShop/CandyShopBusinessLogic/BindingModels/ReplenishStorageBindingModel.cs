using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.BindingModels
{
    public class ReplenishStorageBindingModel
    {
        public int StorageId { get; set; }

        public int SweetId { get; set; }

        public int Count { get; set; }
    }
}
