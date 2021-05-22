﻿using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using CandyShopBusinessLogic.Enums;
using CandyShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandyShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new CandyShopDatabase())
            {
                return context.Orders.Include(rec => rec.Pastry)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .Select(CreateModel).ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new CandyShopDatabase())
            {
                return context.Orders
                .Include(rec => rec.Pastry)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
                rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue &&
                rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <=
                model.DateTo.Value.Date) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status ==
                OrderStatus.Принят) ||
                (model.ImplementerId.HasValue && rec.ImplementerId ==
                model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    PastryId = rec.PastryId,
                    PastryName = rec.Pastry.PastryName,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerId = rec.ImplementerId,
                    ImplementerName = rec.ImplementerId.HasValue ?
rec.Implementer.Name : string.Empty,
                    Status = rec.Status,
                    Sum = rec.Sum
                })
                .ToList();
            }

        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CandyShopDatabase())
            {
                var order = context.Orders
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Pastry)
                    .Include(rec => rec.Implementer)
                .FirstOrDefault(rec => rec.Id == model.Id);

                return order != null ?
                CreateModel(order) : null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            if (!model.ClientId.HasValue)
            {
                throw new Exception("Client not specified");
            }
            using (var context = new CandyShopDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                var element = context.Orders.Include(rec => rec.Client)
                   .Include(rec => rec.Pastry)
                   .FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Element not found");
                }
                if (!model.ClientId.HasValue)
                {
                    model.ClientId = element.ClientId;
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new CandyShopDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }

                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
        private OrderViewModel CreateModel(Order order)
        {
         //   Console.WriteLine(order.Implementer.Name);
            return new OrderViewModel
            {
                Id = order.Id,
                PastryId = order.PastryId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ClientFIO = order.Client.ClientFIO,
                PastryName = order.Pastry.PastryName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order?.DateImplement,                
                ImplementerName = order.ImplementerId.HasValue ?
                    order.Implementer.Name : string.Empty
            };
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PastryId = model.PastryId;
            order.ClientId = Convert.ToInt32(model.ClientId);
            order.ImplementerId = model.ImplementerId;
            order.Sum = model.Sum;
            order.Count = model.Count;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;

            return order;
        }
    }
}
