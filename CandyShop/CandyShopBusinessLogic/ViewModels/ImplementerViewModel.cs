using CandyShopBusinessLogic.Attributes;
using System.ComponentModel;
namespace CandyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerViewModel
    {
        [Column(title: "Number", width: 100)]
        public int Id { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Name { get; set; }
        [Column(title: "Время на заказ", width: 100)]
        public int WorkingTime { get; set; }
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
    }
}