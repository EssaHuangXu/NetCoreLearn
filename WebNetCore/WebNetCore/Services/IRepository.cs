using System.Collections.Generic;

namespace WebNetCore.Services
{
	public interface IRepository<T> where  T : class
	{
		IEnumerable<T> GetAll();
	}
}
