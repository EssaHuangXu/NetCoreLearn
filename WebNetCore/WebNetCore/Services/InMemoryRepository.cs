using System.Collections.Generic;
using System.Linq;
using WebNetCore.Models;

namespace WebNetCore.Services
{
	public class InMemoryRepository : IRepository<Student>
	{

		protected IEnumerable<Student> _students;

		public InMemoryRepository()
		{
			_students = new List<Student>()
			{

				new Student()
				{
					Id = 1,
					Name = "Li san",
					LastName =  "Com"
				},
				new Student()
				{
					Id = 2,
					Name = "Hang  san",
					LastName = "Bill"
				},
				new Student()
				{
					Id = 3,
					Name = "Tum San",
					LastName = "Sam"
				}
			};
		}
		public IEnumerable<Student> GetAll()
		{
			return _students;
		}

		public Student GetbyId(int id)
		{
			return _students.FirstOrDefault(x => x.Id == id);
		}
	}
}
