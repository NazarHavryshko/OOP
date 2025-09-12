using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab___2_Console
{
    internal class Task4
    {
        public void Start()
        {
            InputNumbers inputIN = new InputNumbers();
            double a = 0, b = 0, c = 0;
            Console.WriteLine("Обчислення коренів квадратного рівняння");
            Console.WriteLine("Введіть ціле або дробове значення a ");
            inputIN.InputDoubleNumber(ref a);
            if (a == 0)
            {
                Console.WriteLine("Це не квадратне рівняння спробуйте ще раз спочатку. ");
            }
            else
            {
                Console.WriteLine("Введіть ціле або дробове значення b ");
                inputIN.InputDoubleNumber(ref b);
                Console.WriteLine("Введіть ціле або дробове значення c ");
                inputIN.InputDoubleNumber(ref c);
                double d = Math.Pow(b, 2) - (4 * a * c);
                if (d < 0)
                {
                    Console.WriteLine("Рівняння немає коренів.");
                }
                else if (d == 0)
                     {
                         double x = Math.Round(((-1 * b) / (2 * a)), 4);
                        Console.WriteLine($"Рівняння має один корінь х = {x}.");
                     }
                     else
                     {
                         double x1 = Math.Round((((-1 * b) - Math.Pow(d, 0.5)) / (2 * a)), 4);
                         double x2 = Math.Round((((-1 * b) + Math.Pow(d, 0.5)) / (2 * a)), 4);
                    Console.WriteLine($"Рівняння має два корінея х1 = {x1}, х2 = {x2}.");
                     }
                
            }
                
        }
    }
}
