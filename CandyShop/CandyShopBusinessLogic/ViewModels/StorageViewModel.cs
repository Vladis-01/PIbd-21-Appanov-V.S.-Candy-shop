using System;
using System.Collections.Generic;
using System.ComponentModel;
using CandyShopBusinessLogic.Attributes;

namespace CandyShopBusinessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [Column(title: "Название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string StorageName { get; set; }

        [DisplayName("ФИО ответственного")]
        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string StorageManager { get; set; }

        [DisplayName("Дата создания")]
        [Column(title: "Дата создания", width: 100, format: "D")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StorageSweets { get; set; }
    }
}
