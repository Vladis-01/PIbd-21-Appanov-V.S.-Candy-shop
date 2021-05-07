using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.HelperModels;
using
CandyShopBusinessLogic.Interfaces;
using
CandyShopBusinessLogic.ViewModels;
using
System;
using System.Collections.Generic;
using System.Linq;
namespace CandyShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ISweetStorage _sweetStorage;
        private readonly IPastryStorage _pastryStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorageStorage _storageStorage;

        public ReportLogic(IPastryStorage pastryStorage, ISweetStorage sweetStorage,
        IOrderStorage orderStorage, IStorageStorage storageStorage)
        {
            _pastryStorage = pastryStorage;
            _sweetStorage = sweetStorage;
            _orderStorage = orderStorage;
            _storageStorage = storageStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportPastrySweetViewModel> GetPastrySweet()
        {
            var sweets = _sweetStorage.GetFullList(); 
            var pastrys = _pastryStorage.GetFullList();
            var list = new List<ReportPastrySweetViewModel>();
            foreach (var pastry in pastrys)
            {
                var record = new ReportPastrySweetViewModel
                {
                    PastryName = pastry.PastryName,
                    Sweets = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var sweet in pastry.PastrySweets)
                {
                    record.Sweets.Add(new Tuple<string, int>(sweet.Value.Item1, sweet.Value.Item2));
                    record.TotalCount += sweet.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportStorageSweetViewModel> GetStorageSweet()
        {
            var sweets = _sweetStorage.GetFullList();
            var storages = _storageStorage.GetFullList();
            var list = new List<ReportStorageSweetViewModel>();
            foreach (var storage in storages)
            {
                var record = new ReportStorageSweetViewModel
                {
                    StorageName = storage.StorageName,
                    Sweets = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var sweet in sweets)
                {
                    if (storage.StorageSweets.ContainsKey(sweet.Id))
                    {
                        record.Sweets.Add(new Tuple<string, int>(storage.StorageName,
                       storage.StorageSweets[sweet.Id].Item2));
                        record.TotalCount +=
                       storage.StorageSweets[sweet.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PastryName = x.PastryName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        public List<ReportOrderByDatesViewModel> GetOrdersByDates()
        {
            return _orderStorage.GetFullList()
            .GroupBy(rec => rec.DateCreate.ToShortDateString())
            .Select(group => new ReportOrderByDatesViewModel
            {
                DateCreate = group.FirstOrDefault().DateCreate,
                OrdersCount = group.Count(),
                TotalSum = group.Sum(rec => rec.Sum)
            }).ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SavePastrysToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список кондитерских изделий",
                Pastrys = _pastryStorage.GetFullList()
            });
        }

        public void SaveStoragesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocStorages(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Storages = _storageStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SavePastrySweetToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                PastrySweets = GetPastrySweet()
            });
        }

        public void SaveStorageSweetToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Storages = GetStorageSweet()
            });
        }


        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        [Obsolete]
        public void SaveOrdersByDatesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocOrdersByDates(new PdfInfoOrdersByDates
            {
                FileName = model.FileName,
                Title = "Orders by dates list",
                Orders = GetOrdersByDates()
            });
        }
    }
}