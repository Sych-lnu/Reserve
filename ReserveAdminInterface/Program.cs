using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReserveProject;
namespace ReserveAdminInterface
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Reserve res1 = new Reserve();
            Reserve res2 = new Reserve();
            FileManager.ReadInfoFromFile("D:\\C# projects\\ReserveProject\\in1.txt", res1);
            FileManager.ReadInfoFromFile("D:\\C# projects\\ReserveProject\\in2.txt", res2);
            Reserve[] reserves = { res1, res2 };

            Application.Run(new AdminForm(reserves, 2));
        }
    }
}
