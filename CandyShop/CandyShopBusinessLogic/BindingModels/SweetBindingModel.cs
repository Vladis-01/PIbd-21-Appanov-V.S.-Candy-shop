using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SweetBindingModel
    {
        public int? Id { get; set; }
        public string SweetName { get; set; }
    }

}
