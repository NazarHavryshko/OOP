using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Console
{
    internal class Task4
    {
        public void Run() {
            int n = -1, m = -1;
            double max = 78.4, min = -217.8;

            InputNumbers inputPosInt = new InputNumbers();
            Console.WriteLine("Ведіть клькість рядків.");
            inputPosInt.InputPosibleIntNumber(ref n);
            Console.WriteLine("Ведіть клькість стовпців.");
            inputPosInt.InputPosibleIntNumber(ref m);

            double[,] array = new double[n, m];
            Random rand = new Random();
            

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++)
                {
                    array[i, j]  = Math.Round((rand.NextDouble() * (max - min) + min), 1);
                }
            }


            

            int numNeg = 0;
            bool posEl = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + "\t");
                    if (array[i, j] > 0)
                    {
                        posEl = true;
                    }
                }
                if (!posEl)
                {
                    numNeg++;
                }
                posEl = false;
                Console.WriteLine();
            }

            Console.WriteLine();



            double sumEl = 0d;
            double[,] arraySum = new double[2, m];

            Console.WriteLine($"Оригінальний масив.");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sumEl += array[j, i];
                }
                arraySum[0, i] = sumEl;
                sumEl = 0;
                arraySum[1, i] = i;
            }
            Console.WriteLine($"Кількість рядків, які не містять жодного додатного елемента = {numNeg}");
            Console.WriteLine("Сума елементів кожного стовпця.");
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arraySum[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double[] temp = new double[2];

            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < m - i -1; j++)
                {
                    if (arraySum[0, j] < arraySum[0, j + 1])
                    {
                        temp[0] = arraySum[0, j];
                        temp[1] = arraySum[1, j];
                        arraySum[0, j] = arraySum[0, j + 1];
                        arraySum[1, j] = arraySum[1, j + 1];
                        arraySum[0, j + 1] = temp[0];
                        arraySum[1, j + 1] = temp[1];
                    }
                }
            }
            Console.WriteLine("Відсортовані стовпці за спаданням сум елементів у стовпцях.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int k = (int)arraySum[1, j];
                    Console.Write(array[i, k] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Відсортовані суми елементів кожного стовпця.");
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arraySum[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
