﻿using CandyShopBusinessLogic.BusinessLogics;
using CandyShopBusinessLogic.HelperModels;
using CandyShopBusinessLogic.Interfaces;
using CandyShopDatabaseImplement.Implements;
using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
namespace CandyShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
         {
            var container = BuildUnityContainer();
            var value = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]);

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            });
            // создаем таймер
            var timer = new System.Threading.Timer(new TimerCallback(MailCheck), new
            MailCheckInfo
            {
                PopHost = ConfigurationManager.AppSettings["PopHost"],
                PopPort = Convert.ToInt32(ConfigurationManager.AppSettings["PopPort"]),
                Storage = container.Resolve<IMessageInfoStorage>(),
                ClientStorage = container.Resolve<IClientStorage>()
            }, 0, 100000);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new
HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISweetStorage, SweetStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPastryStorage, PastryStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMessageInfoStorage, MessageInfoStorage>(new
HierarchicalLifetimeManager());

            currentContainer.RegisterType<SweetLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PastryLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new
HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IImplementerStorage, ImplementerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ImplementerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WorkModeling>(new
HierarchicalLifetimeManager());
            currentContainer.RegisterType<MailLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }

        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }

    }
}
