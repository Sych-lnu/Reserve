using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveProject;

namespace ReserveUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Reserve res1 = new Reserve();
            Reserve res2 = new Reserve();
            FileManager.ReadInfoFromFile("D:\\C# projects\\ReserveProject\\in1.txt", res1);
            FileManager.ReadInfoFromFile("D:\\C# projects\\ReserveProject\\in2.txt", res2);
            Reserve[] reserves = { res1, res2 };
            Menu menu = new Menu();
            menu.ShowMenu(reserves, 2);
        }

    }
}
