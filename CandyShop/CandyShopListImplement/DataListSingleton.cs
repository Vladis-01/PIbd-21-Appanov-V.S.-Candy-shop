using CandyShopListImplement.Models;
using System.Collections.Generic;
namespace CandyShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Sweet> Sweets { get; set; }
        public List<Order> Orders { get; set; }
        public List<Pastry> Pastrys { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        private DataListSingleton()
        {
            Sweets = new List<Sweet>();
            Orders = new List<Order>();
            Pastrys = new List<Pastry>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
