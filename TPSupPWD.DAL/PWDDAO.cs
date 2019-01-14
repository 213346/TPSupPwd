using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSupPWD.BO;

namespace TPSupPWD.DAL
{
	public class PwdDAO : IManager<Pwd>
	{
		public Pwd Add(Pwd entity)
		{
			try
			{
				using (var db = new ManagerContext())
				{
					db.Pwds.Add(entity);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return entity;
		}

		public Pwd Edit(Pwd entity)
		{
			try
			{
				using (var db = new ManagerContext())
				{
					db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return entity;
		}

		public Pwd Find(int id)
		{
			Pwd pwd = null;
			try
			{
				using (var db = new ManagerContext())
				{
					pwd = db.Pwds?.FirstOrDefault(f => f.Id == id) as Pwd;
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return pwd;
		}

		public IEnumerable<Pwd> FindAll(string title = null)
		{
			IEnumerable<Pwd> Pwds = null;
			try
			{
				using (var db = new ManagerContext())
				{
					title = title ?? "";
					Pwds = db.Pwds?.ToList().Where(f => f.Title.Trim().ToLower().Contains(title.Trim().ToLower()));
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return Pwds;
		}

		public Pwd Remove(Pwd entity)
		{
			try
			{
				using (var db = new ManagerContext())
				{
					db.Pwds.Remove(entity);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return entity;
		}
	}
}
