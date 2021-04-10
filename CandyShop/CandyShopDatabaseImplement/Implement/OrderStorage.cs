using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
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
                return context.Orders
                    .Include(rec => rec.Pastry)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        PastryName = rec.Pastry.PastryName,
                        PastryId = rec.PastryId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    })
                    .ToList();
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
                    .Where(rec => rec.PastryId == model.PastryId)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        PastryName = rec.Pastry.PastryName,
                        PastryId = rec.PastryId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
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
                    .Include(rec => rec.Pastry)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return order != null ?
                    new OrderViewModel
                    {
                        Id = order.Id,
                        PastryName = context.Pastrys.FirstOrDefault(rec => rec.Id == order.PastryId)?.PastryName,
                        PastryId = order.PastryId,
                        Count = order.Count,
                        Sum = order.Sum,
                        Status = order.Status,
                        DateCreate = order.DateCreate,
                        DateImplement = order.DateImplement
                    } :
                    null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
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
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }

                CreateModel(model, order);
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
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PastryId = model.PastryId;
            order.Sum = model.Sum;
            order.Count = model.Count;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;

            return order;
        }
    }
}
