using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveProject
{
    public class FileManager
    {
        public static void ReadInfoFromFile(string fileName, Reserve reserve)
        {
            //reserve = new Reserve();
            for(int i = 0; i < reserve.CountOfPopulations; i++)
            {
                reserve.List[i] = null;
            }
            reserve.CountOfPopulations = 0;
            string[] allText = System.IO.File.ReadAllText(fileName).Split('\n');
            reserve.FileName = fileName;
            reserve.Name = allText[0];
            for (int i = 1; i < allText.Length; i++)
            {
                string[] data = allText[i].Split(',');
                reserve.AddPopulation(data[0], int.Parse(data[1]));
            }
        }
        public static void WriteInfoToFile(string fileName, Reserve reserve)
        {
            int count = reserve.List.Length;
            for(int i = 0; i < reserve.List.Length; i++)
            {
                if(reserve.List[i]==null)
                {
                    count = i;
                    break;
                }
            }

            string output = reserve.Name + '\n';
            for (int i = 0; i < count - 1; i++)
            {
                    output += reserve.List[i].Name + ',' + reserve.List[i].Size + '\n';
            }
            output += reserve.List[count - 1].Name + ',' + reserve.List[count - 1].Size;
            System.IO.File.WriteAllText(fileName, output);

        }

    }
}
