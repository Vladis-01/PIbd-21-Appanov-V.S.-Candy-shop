using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Enums;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CandyShopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model.Id != null)
            {
                order.Id = (int)model.Id;
            }
            order.PastryId = model.PastryId;
            order.ClientId = (int)model.ClientId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            string pastryName = null;
            foreach (var pastry in source.Pastrys)
            {
                if (pastry.Id == order.PastryId)
                {
                    pastryName = pastry.PastryName;
                }
            }

            string clientFIO = null;
            foreach (var client in source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    clientFIO = client.ClientFIO;
                }
            }
            string implementerName = null;
            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == order.ImplementerId)
                {
                    implementerName = implementer.Name;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                PastryId = order.PastryId,
                PastryName = pastryName,
                ClientId = order.ClientId,
                ClientFIO = clientFIO,
                ImplementerId = order.ImplementerId.Value,
                ImplementerName = implementerName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }

        List<OrderViewModel> IOrderStorage.GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null || model.DateFrom == null || model.DateTo == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if ((!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate.Date == model.DateCreate.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && order.ClientId == model.ClientId) ||
                    (model.FreeOrders.HasValue && model.FreeOrders.Value && order.Status == OrderStatus.Принят) ||
                    (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && order.Status == OrderStatus.Выполняется))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id || order.PastryId == model.PastryId)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }

        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order
            {
                Id = 1
            };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
