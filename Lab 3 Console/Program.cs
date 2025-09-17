using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Console
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            InputNumbers inputNumbers = new InputNumbers();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool status = true;
            while (status)
            {
                Console.WriteLine("Яке завдання ви хочете подивитися (3, 4). Введіть 0 щоб завершити програму");
                int task_number = -1;
                inputNumbers.InputIntNumber(ref task_number);

                switch (task_number)
                {
                    case 3:
                        Task3 task_3 = new Task3();
                        task_3.Start();
                        break;
                    case 4:
                        Task4 task_4 = new Task4();
                        task_4.Run();
                        break;
                    case 0:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Ви не вибрати існуюче завдання. Спробуйте знову.");
                        break;
                }

            }


        }
    }
}
