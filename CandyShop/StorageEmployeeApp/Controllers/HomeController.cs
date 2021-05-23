using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorageEmployeeApp.Models;

namespace StorageEmployeeApp.Controllers
{
    public class HomeController : Controller
    {
		public HomeController()
		{
		}


		public IActionResult Index()
		{
			if (Program.Enter == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View(ApiEmployee.GetRequest<List<StorageViewModel>>("api/storage/GetStorageList"));
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		[HttpGet]
		public IActionResult Enter()
		{
			return View();
		}


		[HttpPost]
		public void Enter(string password)
		{
			if (!string.IsNullOrEmpty(password))
			{
				if (password != Program.CurrentPassword)
				{
					throw new Exception("Invalid password");
				}
				Program.Enter = true;
				Response.Redirect("Index");
				return;
			}
			throw new Exception("Enter Password");
		}


		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public void Create(string name, string managerFullName)
		{
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(managerFullName))
			{
				ApiEmployee.PostRequest("api/storage/CreateOrUpdateStorage", new StorageBindingModel
				{
					StorageManager = managerFullName,
					StorageName = name,
					DateCreate = DateTime.Now,
					StorageSweets = new Dictionary<int, (string, int)>()
				});
				Response.Redirect("Index");
				return;
			}
			throw new Exception("Enter managers full name");
		}


		[HttpGet]
		public IActionResult Update(int storageId)
		{
			var storage = ApiEmployee.GetRequest<StorageViewModel>($"api/storage/GetStorage?storageId={storageId}");
			ViewBag.Sweets = storage.StorageSweets.Values;
			ViewBag.Name = storage.StorageName;
			ViewBag.ManagerFullName = storage.StorageManager;
			return View();
		}


		[HttpPost]
		public void Update(int storageId, string name, string managerFullName)
		{
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(managerFullName))
			{
				var storage = ApiEmployee.GetRequest<StorageViewModel>($"api/storage/GetStorage?storageId={storageId}");
				if (storage == null)
				{
					return;
				}
				ApiEmployee.PostRequest("api/storage/CreateOrUpdateStorage", new StorageBindingModel
				{
					StorageManager = managerFullName,
					StorageName = name,
					DateCreate = DateTime.Now,
					StorageSweets = storage.StorageSweets,
					Id = storage.Id
				});
				Response.Redirect("Index");
				return;
			}
			throw new Exception("Enter login, password and full name");
		}


		[HttpGet]
		public IActionResult Delete()
		{
			if (Program.Enter == null)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.Storage = ApiEmployee.GetRequest<List<StorageViewModel>>("api/storage/GetStorageList");
			return View();
		}


		[HttpPost]
		public void Delete(int storageId)
		{
			ApiEmployee.PostRequest("api/storage/DeleteStorage", new StorageBindingModel
			{
				Id = storageId
			});
			Response.Redirect("Index");
		}


		[HttpGet]
		public IActionResult AddSweetsToStorage()
		{
			if (Program.Enter == null)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.Storage = ApiEmployee.GetRequest<List<StorageViewModel>>("api/storage/GetStorageList");
			ViewBag.Sweet = ApiEmployee.GetRequest<List<SweetViewModel>>("api/storage/GetSweetList");
			return View();
		}


		[HttpPost]
		public void AddSweetsToStorage(int storageId, int sweetId, int count)
		{
			ApiEmployee.PostRequest("api/storage/AddSweetsToStorage", new ReplenishStorageBindingModel
			{
				StorageId = storageId,
				SweetId = sweetId,
				Count = count
			});
			Response.Redirect("AddSweetsToStorage");
		}

	}
}
