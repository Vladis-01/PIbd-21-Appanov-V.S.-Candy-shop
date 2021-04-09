using System.ComponentModel;

namespace CandyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SweetViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название сладости")]
        public string SweetName { get; set; }
    }
}
