using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        public int PastryId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }

}
