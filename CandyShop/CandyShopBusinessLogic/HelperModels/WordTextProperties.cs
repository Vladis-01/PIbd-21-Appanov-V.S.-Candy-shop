using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandyShopBusinessLogic.HelperModels
{
    class WordTextProperties
    {
        public String Size { get; set; }
        public Boolean Bold { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
