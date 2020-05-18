using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebNetCore.Models;
using WebNetCore.Services;

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
			var lstStu = _pository.GetAll();
			return View(lstStu);
		}
	}
}
