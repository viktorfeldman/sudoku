using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("> Enter file name");

            string fileName = Console.ReadLine();
            string folder = ConfigurationManager.AppSettings["fileslocation"];
            Validator validator = new Validator();

            while (fileName != "")
            {

                fileName = folder + @"\" + fileName;
                if (validator.Validate(fileName))
                {
                    Console.WriteLine("Yes, valid");
                }
                else
                {
                    Console.WriteLine("No, invalid");
                }

                Console.WriteLine("> Enter file name or press enter to exit");
                fileName = Console.ReadLine();
            }
        }
    }
}
