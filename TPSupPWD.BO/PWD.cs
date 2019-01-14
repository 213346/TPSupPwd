using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSupPWD.BO
{
	public class Pwd
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string Title { get; set; }
		[Required]
		public string Password { get; set; }

		[Required]
		public int StudentId { get; set; }
		public Student Student { get; set; }

		public static string[] Menus =
		{   "1 - Ajouter un mot de passe",
			"2 - Afficher la liste des mots de passe",
			"3 - Modifier un mot de passe",
			"4 - Supprimer un mot de passe",
			"5 - Retour"
		};
		public static void Menu()
		{
			Console.WriteLine("\t\t---------------------------------------------");
			foreach (var item in Menus)
			{
				Console.WriteLine("\t\t\t {0}",item);
			}
			Console.WriteLine("\t\t---------------------------------------------");
		}

		public static void ChowPassword(IEnumerable<Pwd> pwds)
		{
			int i = 1;
			if (pwds.ToList().Count != 0)
			{
				foreach (var item in pwds)
				{
					Console.WriteLine("{0} - {1}", i, item);
					i++;
				}
			}
		}

		public override string ToString()
		{
			return
				string.Format("Id = {0} , Title = {1}, Password = {2}", this.Id, this.Title, this.Password);
		}
	}
}
