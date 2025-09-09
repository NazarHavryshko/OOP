using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab___2_Console
{
    
    internal class Program
    {
        static void input_int_number(ref int x)
        {
            string input_text;
            input_text = Console.ReadLine();
            bool status = true;



            while (status)
            {
                if (int.TryParse(input_text, out x))
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
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool status = true;
            while (status) {
                Console.WriteLine("Яке завдання ви хочете подивитися (3). Введіть 0 щоб завершити програму");
                int task_number = -1;
                input_int_number(ref task_number);

                switch (task_number)
                {
                    case 3:
                        task_3 task_3 = new task_3();
                        task_3.start();
                        break;
                    case 0:
                        status = false;
                        break;
                }
            
            }
        }
    }
}
