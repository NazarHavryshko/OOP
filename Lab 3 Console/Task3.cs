using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Console
{
    internal class Task3
    {

        public void Start()
        {
            int n = -1;
            double min = -102.05, max = 5.13;
            
            double sumAddEl = 0;
            int first = -1, last = -1;

            
            double temp = 0;

            Console.WriteLine("Введіть довжину масиву");
            
            InputNumbers inputNumbers = new InputNumbers();
            inputNumbers.InputPosibleIntNumber(ref n);
            Random rnd = new Random();


            double[] array = new double[n];


            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round((rnd.NextDouble() * (max - min) + min), 2);
            }

            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0 && first == -1)
                {
                    first = i;
                }
                if ((i + 1) % 2 == 0 && array[i] > 0)
                {
                    sumAddEl += array[i];
                }
            }

            for (int i = n - 1; i > 0; i--)
            {
                if (array[i] < 0)
                {
                    last = i;
                    break;
                }
            }


            double[] sortArray = new double[n];


            for (int i = 0; i < n; i++)
            {
                sortArray[i] = array[i];
            }
            for (int i = 0; i < last - first + 2; i++)
            {
                for (int j = first; j < last - i; j++)
                {
                    if (sortArray[j] > sortArray[j + 1])
                    {
                        temp = sortArray[j];
                        sortArray[j] = sortArray[j + 1];
                        sortArray[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"{"Індекс"} \t {"Оригінал"} \t {"Відсортований"}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i} \t {array[i]}     \t {sortArray[i]}");
            }
            Console.WriteLine($"Сума дотатніх чисел які мають непарні індекси = {sumAddEl}");


        }
    }
}
