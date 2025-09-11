using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab___2_Console
{
    internal class Task3
    {
        

        public void Start()
        {
            Console.WriteLine((Math.Pow(0.703, 3) + Math.Log(0.703)));
            InputNumbers inputDN = new InputNumbers();
            double x = 0, y = 0, z = 0;
            Console.WriteLine("Введіть дробове значення x ");
            inputDN.InputDoubleNumber(ref x);
            Console.WriteLine("Введіть дробове значення y ");
            inputDN.InputDoubleNumber(ref y);
            Console.WriteLine("Введіть дробове значення z ");
            inputDN.InputDoubleNumber(ref z);
            if ((Math.Pow(y, 2) - x) == 0 || (Math.Pow(x, 3) + Math.Log(x)) <= 0)
            {
                Console.WriteLine("При обчисленні виникли обчислення які в класичній математиці необчислюються.");
            } else
            {
                double s = Math.Round((Math.Pow(Math.Cos(z), 2) + (y / (Math.Pow(y, 2) - x))) / (Math.Pow((Math.Pow(x, 3) + Math.Log(x)), 0.25)), 4);

                Console.WriteLine($"S = {s}");
            }    
        }

    }
}
