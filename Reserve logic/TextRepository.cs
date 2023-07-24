using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveProject
{


    public class TextRepository<T> where T : Population
    {

        public int CountOfPopulations { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }
        public int MaxSize { get; set; }

        public T[] List { get; set; }

        public Population getTByIndex(int index)
        {
            return List[index];
        }

        public TextRepository()
        {
            CountOfPopulations = 0;
            MaxSize = 100;
            List = new T[MaxSize];
        }
        public TextRepository(Repository<T> repository)
        {
            CountOfPopulations = repository.CountOfPopulations;
            MaxSize = 100;
            Name = repository.Name;
            List = new T[MaxSize];
            Filename = repository.Filename;
            for (int i = 0; i < CountOfPopulations; i++)
            {
                List[i] = (T)repository.getTByIndex(i);
            }
        }
        public TextRepository(T[] list, int countOfPopulations)
        {
            MaxSize = 100;
            List = new T[MaxSize];
            CountOfPopulations = countOfPopulations;
            for (int i = 0; i < countOfPopulations; i++)
            {
                List[i] = list[i];
            }



        }
        public void AddPopulation(T population)
        {

            if (CountOfPopulations != MaxSize)
            {
                List[CountOfPopulations] = population;

                CountOfPopulations = CountOfPopulations + 1;
                //Console.WriteLine("Added!");

            }
        }
        public void AddPopulation(string name, int size)
        {

            if (CountOfPopulations != MaxSize)
            {
                T population = (T)new Population(name, size);
                List[CountOfPopulations] = population;

                CountOfPopulations = CountOfPopulations + 1;
                //Console.WriteLine("Added!");

            }
        }
        public void RemovePopulation(int index)
        {
            if (0 < index && index < CountOfPopulations)
            {
                for (int i = index - 1; i < CountOfPopulations; i++)
                {
                    List[i] = List[i + 1];
                }

                CountOfPopulations--;

            }
            else
            if (index == CountOfPopulations || index == MaxSize)
            {
                List[index - 1] = null;
                CountOfPopulations--;

            }

        }

        public void ShowInfo()
        {
            Console.WriteLine("Count of populations = " + CountOfPopulations);
            for (int i = 0; i < CountOfPopulations; i++)
            {
                Console.WriteLine(i + 1 + ") Population name: " + List[i].Name + ", population size: " + List[i].Size);
            }
        }
        public void ShowInfoAboutT()
        {
            for (int i = 0; i < CountOfPopulations; i++)
            {
                Console.WriteLine(List[i].Name);
            }
        }
        public void ReadFromFile()
        {
            for (int i = 0; i < CountOfPopulations; i++)
            {
                List[i] = null;
            }
            CountOfPopulations = 0;
            string[] allText = System.IO.File.ReadAllText(Filename).Split('\n');
            Name = allText[0];
            for (int i = 1; i < allText.Length; i++)
            {
                string[] data = allText[i].Split(',');
                AddPopulation(data[0], int.Parse(data[1]));
            }

        }

        public void WriteToFile()
        {
            int count = List.Length;
            for (int i = 0; i < List.Length; i++)
            {
                if (List[i] == null)
                {
                    count = i;
                    break;
                }
            }

            string output = Name + '\n';
            for (int i = 0; i < count - 1; i++)
            {
                output += List[i].Name + ',' + List[i].Size + '\n';
            }
            output += List[count - 1].Name + ',' + List[count - 1].Size;
            System.IO.File.WriteAllText(Filename, output);
        }
    }
}
