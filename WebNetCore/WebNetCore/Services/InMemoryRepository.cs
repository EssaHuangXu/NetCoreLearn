using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCore.Models;

namespace WebNetCore.Services
{
	public class InMemoryRepository : IRepository<Student>
	{
		public IEnumerable<Student> GetAll()
		{
			return  new List<Student>()
			{

				new Student()
				{
					Id = 1,
					Name = "Li san"
				},
				new Student()
				{
					Id = 2,
					Name = "Hang  san",
				},
				new Student()
				{
					Id = 3,
					Name = "Tum San"
				}
			};
		}
	}
}
