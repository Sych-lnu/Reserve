using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveProject;

namespace ReserveUser
{
	class Menu : TemplateMenu
	{
		public override void ShowMenu(Reserve[] reserves, int size)
		{

			Console.Write("Welcome to our network of reserves!\n" +
				"You can:\n" +
				"1) See the list of reserves\n" +
				"2) See an info about reserve\n" +
				"0) Stop Program\n");

			int option = int.Parse(Console.ReadLine());
			if (option == 0)
			{
				for (int i = 0; i < size; i++)
				{
					FileManager.WriteInfoToFile(reserves[i].FileName, reserves[i]);
				}
			}
			else
			{
				Execute(reserves, size, option, this);
			}
		}
		public override void PrintLists(Reserve[] reserves, int size)
		{
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine(i + 1 + ") " + reserves[i].Name);
			}
		}
		public override void ShowInfoAboutReserve(Reserve[] reserves, int size)
		{
			PrintLists(reserves, size);
			Console.WriteLine("Information of which reserve you want to see ? ");
			int option = int.Parse(Console.ReadLine());
			if (option <= size)
			{
				reserves[option - 1].ShowInfo();
			}
		}
		public override void Sync(Reserve[] reserves, int size)
		{

			for (int i = 0; i < size; i++)
			{
				reserves[i] = new Reserve(reserves[i].FileName);
				FileManager.ReadInfoFromFile(reserves[i].FileName, reserves[i]);

			}
		}

	}
}
