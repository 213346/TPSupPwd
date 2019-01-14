using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSupPWD.DAL
{
	public interface IManager<T> 
	{
		T Add(T entity);
		T Edit(T entity);
		T Remove(T entity);
		T Find(int id);

		IEnumerable<T> FindAll(string search=null);
	}
}
