using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveProject
{
    public class TemplateMenu
    {
        public void Execute(Reserve[] reserves, int size, int choice, TemplateMenu menu)
        {
            menu.Sync(reserves, size);

            if (choice == 1)
            {
                menu.PrintLists(reserves, size);

            }
            else
            if (choice == 2)
                menu.ShowInfoAboutReserve(reserves, size);
            else
               if (choice == 3)
                menu.RemovePopulation(reserves, size);
            else
                if (choice == 4)
                menu.AddPopulationToReserve(reserves, size);
            menu.Sync(reserves, size);

            ShowMenu(reserves, size);

        }
        public virtual void ShowMenu(Reserve[] reserves, int size) {
            Console.WriteLine("ShowMenu");
            Console.ReadLine();
        }
        public virtual void PrintLists(Reserve[] reserves, int size)
        {
            Console.WriteLine("PrintLists");
            Console.ReadLine();
        }
        public virtual void ShowInfoAboutReserve(Reserve[] reserves, int size)
        {
            Console.WriteLine("ShowInfoAboutReserve");
            Console.ReadLine();
        }
        public virtual void AddPopulationToReserve(Reserve[] reserves, int size)
        {
            Console.WriteLine("AddPopulationToReserve");
            Console.ReadLine();
        }
        public virtual void RemovePopulation(Reserve[] reserves, int size)
        {
            Console.WriteLine("RemovePopulation");
            Console.ReadLine();
        }
        public virtual void Sync(Reserve[] reserves, int size)
        {
            Console.WriteLine("Sync");
            Console.ReadLine();
        }

    }
}
