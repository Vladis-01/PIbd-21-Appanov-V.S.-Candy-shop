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
        public ReportLogic(IPastryStorage pastryStorage, ISweetStorage sweetStorage,
        IOrderStorage orderStorage)
        {
            _pastryStorage = pastryStorage;
            _sweetStorage = sweetStorage;
            _orderStorage = orderStorage;
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
            foreach (var sweet in sweets)
            {
                var record = new ReportPastrySweetViewModel
                {
                    SweetName = sweet.SweetName,
                    Pastrys = new
                List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var pastry in pastrys)
                {
                    if (pastry.PastrySweets.ContainsKey(sweet.Id))
                    {
                        record.Pastrys.Add(new Tuple<string, int>(pastry.PastryName,
                        pastry.PastrySweets[sweet.Id].Item2));
                        record.TotalCount += pastry.PastrySweets[sweet.Id].Item2;
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
                DateFrom =
            model.DateFrom,
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
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
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
    }
}