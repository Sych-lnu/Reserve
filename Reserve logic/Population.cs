using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveProject
{
    public class Population
    {
        public Population()
        {
            Name = "";
            Size = 0;
        }
        public Population(string name, int size)
        {
            Name = name;
            Size = size;
        }
        public Population(Population population)
        {
            Name = population.Name;
            Size = population.Size;
        }
        public void PrintInfo()
        {
            Console.WriteLine("Population name: " + Name + ", population size: " + Size);
        }
        public int Size { get; set; }
        public string Name { get; set; }

        
    }
}
