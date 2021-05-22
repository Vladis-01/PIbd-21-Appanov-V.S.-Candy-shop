using CandyShopBusinessLogic.Enums;
using CandyShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CandyShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string SweetFileName = "Sweet.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PastryFileName = "Pastry.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string MessageFileName = "Message.xml";

        public List<Sweet> Sweets { get; set; }
        public List<Order> Orders { get; set; }
        public List<Pastry> Pastrys { get; set; }
        public List<Client> Clients { get; set; }
        public List<MessageInfo> Messages { get; set; }
        public List<Implementer> Implementers { get; set; }

        private FileDataListSingleton()
        {
            Sweets = LoadSweets();
            Orders = LoadOrders();
            Pastrys = LoadPastrys();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            Messages = LoadMessages();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }

            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveSweets();
            SaveOrders();
            SavePastrys();
            SaveMessages();
            SaveClients();
            SaveImplementers();
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Clients").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private List<Sweet> LoadSweets()
        {
            var list = new List<Sweet>();

            if (File.Exists(SweetFileName))
            {
                XDocument xDocument = XDocument.Load(SweetFileName);
                var xElements = xDocument.Root.Elements("Sweet").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Sweet
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SweetName = elem.Element("SweetName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    OrderStatus status = (OrderStatus)0;
                    switch ((elem.Element("Status").Value))
                    {
                        case "Принят":
                            status = (OrderStatus)0;
                            break;
                        case "Выполняется":
                            status = (OrderStatus)1;
                            break;
                        case "Готов":
                            status = (OrderStatus)2;
                            break;
                        case "Оплачен":
                            status = (OrderStatus)3;
                            break;

                    }

                    Order order = new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PastryId = Convert.ToInt32(elem.Element("PastryId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = status,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value)
                    };

                    if (!string.IsNullOrEmpty(elem.Element("DateImplement").Value))
                    {
                        order.DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value);
                    }

                    if (!string.IsNullOrEmpty(elem.Element("ImplementerId").Value))
                    {
                        order.ImplementerId = Convert.ToInt32(elem.Element("ImplementerId").Value);
                    }
                    list.Add(order);
                }
            }
            return list;
        }

        private List<Pastry> LoadPastrys()
        {
            var list = new List<Pastry>();

            if (File.Exists(PastryFileName))
            {
                XDocument xDocument = XDocument.Load(PastryFileName);
                var xElements = xDocument.Root.Elements("Pastry").ToList(); 
                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>(); 
                    foreach (var sweet in elem.Element("PastrySweets").Elements("PastrySweet").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(sweet.Element("Key").Value), Convert.ToInt32(sweet.Element("Value").Value));
                    }
                    list.Add(new Pastry
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PastryName = elem.Element("PastryName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PastrySweets = prodComp
                    });
                }
            }

            return list;
        }

        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementers").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        Name = elem.Element("Name").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }
            return list;
        }

        private List<MessageInfo> LoadMessages()
        {
            var list = new List<MessageInfo>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(MessageFileName);
                var xElements = xDocument.Root.Elements("Message").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Element("MessageId")?.Value,
                        Body = elem.Element("Body")?.Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId")?.Value),
                        Subject = elem.Element("Subject")?.Value,
                        SenderName = elem.Element("SenderName")?.Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery")?.Value)
                    });
                }
            }
            return list;
        }

        private void SaveSweets()
        {
            if (Sweets != null)
            {
                var xElement = new XElement("Sweets");

                foreach (var sweet in Sweets)
                {
                    xElement.Add(new XElement("Sweet", new XAttribute("Id", sweet.Id),
                    new XElement("SweetName", sweet.SweetName)));
                }
                XDocument xDocument = new XDocument(xElement); 
                xDocument.Save(SweetFileName);
            }
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var client in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", client.Id),
                    new XElement("Name", client.Name),
                    new XElement("WorkingTime", client.WorkingTime),
                    new XElement("PauseTime", client.PauseTime)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                 new XAttribute("Id", order.Id),
                 new XElement("PastryId", order.PastryId),
                 new XElement("Count", order.Count),
                 new XElement("Sum", order.Sum),
                 new XElement("Status", order.Status),
                 new XElement("DateCreate", order.DateCreate),
                 new XElement("DateImplement", order.DateImplement)
                 ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SavePastrys()
        {
            if (Pastrys != null)
            {
                var xElement = new XElement("Pastrys");

                foreach (var pastry in Pastrys)
                {
                    var compElement = new XElement("PastrySweets");
                    foreach (var sweet in pastry.PastrySweets)
                    {
                        compElement.Add(new XElement("PastrySweet", new XElement("Key", sweet.Key),
                        new XElement("Value", sweet.Value)));
                    }
                    xElement.Add(new XElement("Pastry", new XAttribute("Id", pastry.Id),
                    new XElement("PastryName", pastry.PastryName), new XElement("Price", pastry.Price), compElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PastryFileName);
            }
        }

        private void SaveMessages()
        {
            // прописать логику
            if (Messages != null)
            {
                var xElement = new XElement("Messages");
                foreach (var msg in Messages)
                {
                    xElement.Add(new XElement("Message",
                    new XAttribute("MessageId", msg.MessageId),
                    new XElement("Body", msg.Body),
                    new XElement("DateDelivery", msg.DateDelivery),
                    new XElement("SenderName", msg.SenderName),
                    new XElement("Subject", msg.Subject),
                    new XElement("ClientId", msg.ClientId)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageFileName);
            }
        }
    }
}
