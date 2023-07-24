using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveProject
{
    public class Reserve
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public Repository<Population> PopulationRepository { get; set; }
        public int CountOfPopulations {
            get {
                return PopulationRepository.CountOfPopulations;
            }
            set
            {
                PopulationRepository.CountOfPopulations = value;
            }
        }
        public int MaxSize {
            get {
                return PopulationRepository.MaxSize;
            } 
            set {
                PopulationRepository.MaxSize = value;
            }
        }
        public Population[] List
        {
            get
            {
                return PopulationRepository.List;
            }
        }
        public Reserve(string filename)
        {
            FileName = filename;
            PopulationRepository = new Repository<Population>();
            PopulationRepository.CountOfPopulations = 0;
            PopulationRepository.MaxSize = 100;
            PopulationRepository.List = new Population[100];

        }
        public Reserve()
        {
            PopulationRepository = new Repository<Population>();
            PopulationRepository.CountOfPopulations = 0;
            PopulationRepository.MaxSize = 100;
            PopulationRepository.List = new Population[100];
        }
        public Reserve(Population[]list, int countOfPopulations)
        {
            PopulationRepository = new Repository<Population>();

            PopulationRepository.MaxSize = 100;
            PopulationRepository.List = new Population[100];
            PopulationRepository.CountOfPopulations = countOfPopulations;
            for (int i = 0; i < countOfPopulations; i++)
            {
                PopulationRepository.List[i] = list[i];
            }
        }
        public void AddPopulation(Population population)
        {
            PopulationRepository.AddPopulation(population);
        }
        public void AddPopulation(string name,int size)
        {
            PopulationRepository.AddPopulation(name, size);

        }
        public void RemovePopulation(int index)
        {
            PopulationRepository.RemovePopulation(index);
        }
        public Population getPopulationByIndex(int index)
        {
            return PopulationRepository.getTByIndex(index);
        }
        public void ShowInfo()
        {
            PopulationRepository.ShowInfo();

        }
        public void ShowInfoAboutPopulations()
        {
            PopulationRepository.ShowInfoAboutT();

        }



    }
}
