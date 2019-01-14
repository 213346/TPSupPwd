using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSupPWD.BO;
using TPSupPWD.DAL;

namespace TPSupPWD
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				DoAction();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			

			Console.ReadKey();
		}

		public static void Menu()
		{
			Console.WriteLine("\t\t --------------------------------------");
			Console.WriteLine("\t\t\t 1 - Etudiant");
			Console.WriteLine("\t\t\t 2 - Mot de passe");
			Console.WriteLine("\t\t\t 3 - Quitter");
			Console.WriteLine("\t\t --------------------------------------");
		}

		public static string ChoosePrincipalMenu()
		{
			string choose = "-1";
			int result = -1;
			do
			{
				Console.Clear();
				Menu();
				Console.Write("Faite votre choix : ");
				choose = Console.ReadLine();
				int.TryParse(choose, out result);
			}
			while (result>3 && result<1);
			return choose;
		}


	
		public static string ChoosePasswordMenu()
		{
			string choose = "-1";
			int result = -1;
			do
			{
				Console.Clear();
				Pwd.Menu();
				Console.Write("Faite votre choix : ");
				choose = Console.ReadLine();
				int.TryParse(choose, out result);
			}
			while (result >5 && result <1);
			return choose;
		}

		public static string ChooseStudentMenu()
		{
			string choose = "-1";
			int result = -1;
			do
			{
				Console.Clear();
				Student.Menu();
				Console.Write("Faite votre choix : ");
				choose = Console.ReadLine();
				int.TryParse(choose, out result);
			}
			while (result > 6 && result <1);
			return choose;
		}

		public static void DoAction()
		{
			string choose = ChoosePrincipalMenu();
			try
			{
				switch (choose)
				{
					case "1":
						DoStudentAction();
						break;

					case "2":
						DoPwdAction();
						break;
					default:
						Console.WriteLine("Aurevoir !!!!!!!!!!!");
						System.Threading.Thread.Sleep(2000);
						break;
				}
			}
			catch (Exception ex) 
			{

				Console.WriteLine(ex.Message);
			}
		}


		public static void DoStudentAction()
		{
			string choose = ChooseStudentMenu();
			string lastname = null;
			string firstname = null;
			int campusId = 0;
			Student student = null;
			IEnumerable<Student> students = null;
			try
			{
				switch (choose)
				{
					case "1":
						Console.Write("Entrez votre nom : ");
						lastname = Console.ReadLine();
						Console.Write("Entrez votre prénom : ");
						firstname = Console.ReadLine();
						campusId = Manager.StudentDAO.GetCampusId();

						student = new Student()
						{
							Firstname = firstname,
							Lastname = lastname,
							CampusId = campusId
						};
						Manager.StudentDAO.Add(student);
						Console.WriteLine("Enregistrement effectué avec succès !");
						System.Threading.Thread.Sleep(1000);
						DoStudentAction();
						break;

					case "2":
						Console.Write("Entrer le nom d'un étudiant : ");
						lastname = Console.ReadLine();
						students = Manager.StudentDAO.FindAll(lastname);
						Student.ChowStudent(students);

						Console.ReadKey();
						DoStudentAction();

						break;
					case "3":
						students = Manager.StudentDAO.FindAll();
						Student.ChowStudent(students);
						Console.WriteLine("\n");

						Console.Write("Entrer le campus Id : ");
						campusId = int.Parse(Console.ReadLine());
						student = Manager.StudentDAO.Find(campusId);
						if (student != null)
						{
							Console.Write("Entrez votre nom : ");
							lastname = Console.ReadLine();
							Console.Write("Entrez votre prénom : ");
							firstname = Console.ReadLine();

							student.Firstname = firstname;
							student.Lastname = string.IsNullOrEmpty(lastname) ? student.Lastname : lastname;

							Manager.StudentDAO.Edit(student);
							Console.WriteLine("Enregistrement effectué avec succès !");
						}
						else
						{
							Console.WriteLine("Aucun étudiant trouvé !");
						}
						System.Threading.Thread.Sleep(1000);
						DoStudentAction();
						break;
					case "4":
						students = Manager.StudentDAO.FindAll();
						Student.ChowStudent(students);
						Console.WriteLine("\n");

						Console.Write("Entrer le campus Id : ");
						campusId = int.Parse(Console.ReadLine());
						student = Manager.StudentDAO.Find(campusId);
						if (student != null)
						{
							Manager.StudentDAO.Remove(student);
							Console.WriteLine("Suppression effectué avec succès !");
						}
						else
						{
							Console.WriteLine("Aucun étudiant trouvé !");
						}
						System.Threading.Thread.Sleep(1000);
						DoStudentAction();
						break;
					case "5":
						Console.Write("Entrer le campus Id : ");
						campusId = int.Parse(Console.ReadLine());
						student = Manager.StudentDAO.Find(campusId);
						if (student != null)
						{
							student.ChowStudentPassword();
							Console.ReadKey();
							DoStudentAction();
						}
						else
						{
							Console.WriteLine("Aucun étudiant trouvé !");

							System.Threading.Thread.Sleep(1000);
							DoStudentAction();
						}

						break;
					default:
						DoAction();
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}


		public static void DoPwdAction()
		{
			string choose = ChoosePasswordMenu();
			string title = null;
			string password = null;
			int id = 0;
			Pwd pwd = null;
			Student student = null;
			IEnumerable<Pwd> pwds = null;
			try
			{
				switch (choose)
				{
					case "1":
						Console.Write("Entrez le titre : ");
						title = Console.ReadLine();
						Console.Write("Entrez le mot de passe : ");
						password = Console.ReadLine();

						do
						{
							Console.Write("Entrez le campusid de l'étudiant : ");
							id = int.Parse(Console.ReadLine());
							student = Manager.StudentDAO.Find(id);
						}
						while (student == null);



						pwd = new Pwd()
						{
							Title = password,
							Password = title,
							StudentId = student.Id
						};
						Manager.PwdDAO.Add(pwd);
						Console.WriteLine("Enregistrement effectué avec succès !");
						System.Threading.Thread.Sleep(1000);
						DoPwdAction();
						break;

					case "2":
						Console.Write("Entrer le titre : ");
						title = Console.ReadLine();
						pwds = Manager.PwdDAO.FindAll(title);
						Pwd.ChowPassword(pwds);

						Console.ReadKey();
						DoStudentAction();

						break;
					case "3":
						pwds = Manager.PwdDAO.FindAll();
						Pwd.ChowPassword(pwds);
						Console.WriteLine("\n");
						Console.Write("Entrer l'id : ");
						id = int.Parse(Console.ReadLine());
						pwd = Manager.PwdDAO.Find(id);
						if (pwd != null)
						{
							Console.Write("Entrez le titre : ");
							title = Console.ReadLine();
							Console.Write("Entrez le mot de passe : ");
							password = Console.ReadLine();

							do
							{
								Console.Write("Entrez le campusid de l'étudiant : ");
								string myid = Console.ReadLine();
								if (string.IsNullOrEmpty(myid))
								{
									myid = pwd.Id.ToString();
								}
								id = int.Parse(myid);
								student = Manager.StudentDAO.Find(id);
							}
							while (student == null);

							pwd.Title = string.IsNullOrEmpty(title)? pwd.Title : title;
							pwd.Password = string.IsNullOrEmpty( password)  ? pwd.Password : password;
							pwd.StudentId = student.Id;

							Manager.PwdDAO.Edit(pwd);
							Console.WriteLine("Enregistrement effectué avec succès !");
						}
						else
						{
							Console.WriteLine("Aucun mot de passe trouvé !");
						}
						System.Threading.Thread.Sleep(1000);
						DoPwdAction();
						break;
					case "4":
						pwds = Manager.PwdDAO.FindAll();
						Pwd.ChowPassword(pwds);
						Console.WriteLine("\n");

						Console.Write("Entrer l'id : ");
						id = int.Parse(Console.ReadLine());
						pwd = Manager.PwdDAO.Find(id);
						if (pwd != null)
						{
							Manager.PwdDAO.Remove(pwd);
							Console.WriteLine("Suppression effectué avec succès !");
						}
						else
						{
							Console.WriteLine("Aucun Mot de passe trouvé !");
						}
						System.Threading.Thread.Sleep(1000);
						DoPwdAction();
						break;
					default:
						DoAction();
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
