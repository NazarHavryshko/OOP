using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static void InputPosibleIntNumber(out int x)
        {
            x = -1;
            string input_text;
            input_text = Console.ReadLine();
            bool status = true;



            while (status)
            {
                if (int.TryParse(input_text, out x) && x > 0)
                {
                    status = false;
                }
                else
                {
                    Console.WriteLine("    Ви ввели некоректне значення спробуйте знову. ");
                    input_text = Console.ReadLine();
                }
            }

        }
    }
}
