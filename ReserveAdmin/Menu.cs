using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveProject;

namespace ReserveAdmin
{
	class Menu : TemplateMenu
	{
		public override void ShowMenu(Reserve[] reserves, int size)
		{

			Console.Write("Welcome to our network of reserves!\n" +
				"You can:\n" +
				"1) See the list of reserves\n" +
				"2) See an info about reserve\n" +
				"3) Remove Population\n" +
				"4) Add Population\n" +
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
		public override void AddPopulationToReserve(Reserve[] reserves, int size)
		{
			PrintLists(reserves, size);
			Console.WriteLine("Population to which reserve you want to add ? ");
			int option = int.Parse(Console.ReadLine());
			if (option <= size)
			{
				Console.WriteLine("Enter name of population: ");
				string name = Console.ReadLine();
				Console.WriteLine("Enter size of population: ");
				int popSize = int.Parse(Console.ReadLine());
				Population population = new Population(name, popSize);
				reserves[option - 1].AddPopulation(population);
			}

		}
		public override void RemovePopulation(Reserve[] reserves, int size)
		{	PrintLists(reserves, size);
			Console.WriteLine("Population from which reserve you want to remove ? ");
			int option = int.Parse(Console.ReadLine());
			reserves[option - 1].ShowInfo();
			Console.WriteLine("Which population you want to remove ? ");
			int index = int.Parse(Console.ReadLine());
			reserves[option-1].RemovePopulation(index);



		}
		public override void Sync(Reserve[] reserves, int size) 
		{
			for (int i = 0; i < size; i++)
			{
				FileManager.WriteInfoToFile(reserves[i].FileName, reserves[i]);

			}
		}

	}
}
