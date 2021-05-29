using CandyShopBusinessLogic.Attributes;
using System.ComponentModel;

namespace CandyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SweetViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(title: "Название сладости", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SweetName { get; set; }
    }
}
