using System.ComponentModel;
using System.Runtime.Serialization;
using CandyShopBusinessLogic.Attributes;

namespace CandyShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "ФИО", width: 150)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Email", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Password { get; set; }
    }
}