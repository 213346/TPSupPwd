using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSupPWD.DAL
{
	public class Manager
	{
		private static StudentDAO _StudentDAO;
		public static StudentDAO StudentDAO
		{
			get
			{
				if(_StudentDAO == null)
				{
					_StudentDAO = new StudentDAO();
				}
				return _StudentDAO;
			}
		}

		private static PwdDAO _PwdDAO;
		public static PwdDAO PwdDAO
		{
			get
			{
				if (_PwdDAO == null)
				{
					_PwdDAO = new PwdDAO();
				}
				return _PwdDAO;
			}
		}
	}
}
