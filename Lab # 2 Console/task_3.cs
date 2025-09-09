using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab___2_Console
{
    internal class task_3
    {
        void input_number(ref double x)
        {
            string input_text;
            input_text = Console.ReadLine();
            bool status = true;



            while (status)
            {
                if (double.TryParse(input_text, out x) && !input_text.Contains(","))
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

        public void start()
        {
            double x = 0, y = 0, z = 0;
            Console.WriteLine("Введіть дробове значення x ");
            input_number(ref x);
            Console.WriteLine("Введіть дробове значення y ");
            input_number(ref y);
            Console.WriteLine("Введіть дробове значення z ");
            input_number(ref z);

            double s = Math.Round((Math.Pow(Math.Cos(z), 2) + (y / (Math.Pow(y, 2) - x))) / (Math.Pow((Math.Pow(x, 3) + Math.Log(x)), 0.25)), 4);
          
            Console.WriteLine($"S = {s}");

        }

    }
}
