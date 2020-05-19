using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebNetCore.Models;
using WebNetCore.Services;
using WebNetCore.ViewModels.HomeIndexView;

namespace WebNetCore.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRepository<Student> _pository;

		public HomeController(IRepository<Student> pository)
		{
			_pository = pository;
		}
		
		public IActionResult Index()
		{ 
			////this.File();
			////return this.Content("Hello From Home Controller!");
			//Student st = new Student()
			//{
			//	 Id =  1,
			//	 Name =  "Huangxu"
			//};
			var lstStu = _pository.GetAll().Select(
				x=> new StudentViewModel()
				{
					Name = $"{x.LastName}-{x.Name}",
					Id = x.Id,
					BirthDay = DateTime.Now
				});
			var hm = new HomeIndexViewModel()
			{
				Students = lstStu
			};
			return View(hm);
		}

		public IActionResult Detail(int id)
		{
			//var svm = _pository.GetAll().Select(x => x.Id == id);
			var student = _pository.GetbyId(id);
			if (null == student)
				return RedirectToAction("Index");
			return View(student);
		}
	}
}
