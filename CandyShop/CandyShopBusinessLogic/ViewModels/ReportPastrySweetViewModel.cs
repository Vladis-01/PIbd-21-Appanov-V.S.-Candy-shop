using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CandyShopBusinessLogic.ViewModels
{
    public class ReportPastrySweetViewModel
    {
        [DataMember]
        [DisplayName("Название сладости")]
        public string SweetName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public List<Tuple<string, int>> Pastrys { get; set; }
    }
}