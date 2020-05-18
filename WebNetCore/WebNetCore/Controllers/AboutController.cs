using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebNetCore.Controllers
{
	//[Route("about")]
	//[Route("[controller]/[action]")]  //根据Controller的起始名称作为路由
	public class AboutController
	{ 
		public string Company()
		{
			return "Yuuse";
		}

		//[Route("employee")]
		public string Employee()
		{
			return "Huang Xu";
		}
	}
}
