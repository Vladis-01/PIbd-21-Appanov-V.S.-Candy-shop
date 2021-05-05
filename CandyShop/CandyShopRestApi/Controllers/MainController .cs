using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using CandyShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CandyShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order; private readonly PastryLogic _pastry; private readonly OrderLogic _main;
        public MainController(OrderLogic order, PastryLogic pastry, OrderLogic main)
        {
            _order = order;
            _pastry = pastry;
            _main = main;
        }

        [HttpGet]
        public List<PastryViewModel> GetPastryList() => _pastry.Read(null)?.ToList();

        [HttpGet]
        public PastryViewModel GetPastry(int pastryId) => _pastry.Read(new PastryBindingModel { Id = pastryId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
        _main.CreateOrder(model);
    }
}
