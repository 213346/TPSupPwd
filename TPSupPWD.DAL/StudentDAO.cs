using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSupPWD.BO;

namespace TPSupPWD.DAL
{
	public class StudentDAO : IManager<Student>
	{
		public Student Add(Student entity)
		{
			try
			{
				using(var db = new ManagerContext())
				{
					db.Students.Add(entity);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return entity;
		}

		public Student Edit(Student entity)
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

		public Student Find(int CampusId)
		{
			Student pwd = null;
			try
			{
				using (var db = new ManagerContext())
				{
					pwd = db.Students?.FirstOrDefault(f => f.CampusId == CampusId);
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return pwd;
		}


		public IEnumerable<Student> FindAll(string fullname = null)
		{
			IEnumerable<Student> students = null;
			try
			{
				using (var db = new ManagerContext())
				{
					fullname = fullname ?? "";
					students =db.Students?.ToList().Where(f => f.Fullname.Trim().ToLower().Contains(fullname.Trim().ToLower()));
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return students;
		}

		public int GetCampusId()
		{
			int CampusId = (new Student()).CampusId;
			try
			{
				using (var db = new ManagerContext())
				{

					CampusId = db.Students.ToList().Count == 0 ? CampusId : db.Students.Max(f => f.CampusId) + 1;
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			return CampusId;
		}



		public Student Remove(Student entity)
		{
			try
			{
				using (var db = new ManagerContext())
				{
					db.Students.Remove(entity);
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
