using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.Interfaces;
using
CandyShopBusinessLogic.ViewModels;
using
CandyShopDatabaseImplement.Models;
using
System;
using System.Collections.Generic;
using System.Linq;
namespace CandyShopDatabaseImplement.Implements
{
	public class SweetStorage : ISweetStorage
	{
		public List<SweetViewModel> GetFullList()
		{
			using (var context = new CandyShopDatabase())
			{
				return context.Sweets
				.Select(rec => new SweetViewModel
				{
					Id = rec.Id,
					SweetName = rec.SweetName
				})
.ToList();
			}
		}
		public List<SweetViewModel> GetFilteredList(SweetBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			using (var context = new CandyShopDatabase())
			{
				return context.Sweets
				.Where(rec => rec.SweetName.Contains(model.SweetName))
				.Select(rec => new SweetViewModel
				{
					Id = rec.Id,
					SweetName = rec.SweetName
				})
				.ToList();
			}
		}
		public SweetViewModel GetElement(SweetBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			using (var context = new CandyShopDatabase())
			{
				var sweet = context.Sweets
				.FirstOrDefault(rec => rec.SweetName == model.SweetName ||
				rec.Id == model.Id);
				return sweet != null ?
				new SweetViewModel
				{
					Id = sweet.Id,
					SweetName = sweet.SweetName
				} :
				null;
			}
		}
		public void Insert(SweetBindingModel model)
		{
			using (var context = new CandyShopDatabase())
			{
				context.Sweets.Add(CreateModel(model, new Sweet()));
				context.SaveChanges();
			}
		}
		public void Update(SweetBindingModel model)
		{
			using (var context = new CandyShopDatabase())
			{				
				var element = context.Sweets.FirstOrDefault(rec => rec.Id == model.Id);
				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}
				CreateModel(model, element);
				context.SaveChanges();
			}
		}
		public void Delete(SweetBindingModel model)
		{
			using (var context = new CandyShopDatabase())
			{
				Sweet element = context.Sweets.FirstOrDefault(rec => rec.Id ==
				model.Id);
				if (element != null)
				{
					context.Sweets.Remove(element);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Элемент не найден");
				}
			}
		}
		private Sweet CreateModel(SweetBindingModel model, Sweet sweet)
		{
			sweet.SweetName = model.SweetName;
			return sweet;
		}
	}
}