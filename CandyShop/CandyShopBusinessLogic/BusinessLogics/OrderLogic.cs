using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Enums;
using CandyShopBusinessLogic.HelperModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
namespace CandyShopBusinessLogic.BusinessLogics
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IPastryStorage _pastryStorage;
        private readonly IStorageStorage _storageStorage;
        private readonly IClientStorage _clientStorage;
        private readonly object locker = new object();
      
        public OrderLogic(IOrderStorage orderStorage, IPastryStorage pastryStorage, IStorageStorage storageStorage, IClientStorage clientStorage)       
        {
            _orderStorage = orderStorage;
            _pastryStorage = pastryStorage;
            _storageStorage = storageStorage;
            _clientStorage = clientStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                PastryId = model.PastryId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });

            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id =
model.ClientId
                })?.Email,
                Subject = $"Новый заказ",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum:N2} принят."
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                OrderStatus status = OrderStatus.Выполняется;
                var order = _orderStorage.GetElement(new OrderBindingModel
                {
                    Id =
                model.OrderId
                });
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }

                var pastry = _pastryStorage.GetElement(new PastryBindingModel
                {
                    Id = order.PastryId
                });

                if (!_storageStorage.CheckSweets(_pastryStorage.GetElement(new PastryBindingModel { Id = order.PastryId }), order.Count))
                {
                    status = OrderStatus.ТребуютсяСладости;
                }

                _orderStorage.Update(new OrderBindingModel
                {
                    Id = order.Id,
                    PastryId = order.PastryId,
                    ClientId = order.ClientId,
                    ImplementerId = model.ImplementerId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    Status = status
                      });
              
                MailLogic.MailSendAsync(new MailSendInfo
                {
                    MailAddress = _clientStorage.GetElement(new ClientBindingModel
                    {
                        Id = order.ClientId
                    })?.Email,
                    Subject = $"Заказ №{order.Id}",
                    Text = $"Заказ №{order.Id} передан в работу."
                });
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id =
           model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status == OrderStatus.ТребуютсяСладости && _storageStorage.CheckSweets(_pastryStorage.GetElement(new PastryBindingModel { Id = order.PastryId }), order.Count))
            {
                order.Status = OrderStatus.Выполняется;
            }

            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PastryId = order.PastryId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = OrderStatus.Готов
            });

            // Отправить письмо
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Finish order",
                Text = $"Order for the amount {order.Sum:N2} finished."
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id =
          model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Оплачен\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PastryId = order.PastryId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });

            // Отправить письмо
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Paid order",
                Text = $"Order for the amount {order.Sum:N2} paid."
            });
        }
    }
}
