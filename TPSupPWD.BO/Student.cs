using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSupPWD.BO
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int CampusId { get; set; }

		[Required]
		public string Lastname { get; set; }

		public string Firstname { get; set; }

		[NotMapped]
		public string Fullname => string.Format("{0} {1}", Firstname, Lastname);

		public ICollection<Pwd> Pwds { get; set; }

		public static string[] Menus =
		{   "1 - Ajouter un étudiant",
			"2 - Afficher la liste des étudiants",
			"3 - Modifier un étudiant",
			"4 - Supprimer un étudiant",
			"5 - Afficher les mots de passe d'un étudiant",
			"6 - Retour"
		};
		public static void Menu()
		{
			Console.WriteLine("\t\t---------------------------------------------");
			foreach (var item in Menus)
			{
				Console.WriteLine("\t\t\t {0}", item);
			}
			Console.WriteLine("\t\t---------------------------------------------");
		}

		public Student()
		{
			this.CampusId = 200000;
		}

		public  void ChowStudentPassword()
		{
			int i = 1;
			if (this.Pwds.ToList().Count() != 0)
			{
				foreach (var item in this.Pwds)
				{
					Console.WriteLine("{0} - {1}", i, item);
					i++;
				}
			}
		}

		public static void ChowStudent(IEnumerable<Student> students)
		{
			int i = 1;
			if (students.ToList().Count !=0)
			{
				foreach (var item in students)
				{
					Console.WriteLine("{0} - {1}", i, item);
					i++;
				}
			}
		}
		
		public override string ToString()
		{
			return
				string.Format("CampusId = {0} , Fullname = {1}", this.CampusId, this.Fullname);
		}
	}
}
